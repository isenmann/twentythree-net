using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace TwentyThreeNet
{
    public partial class TwentyThree
    {

        private T GetResponseNoCache<T>(Dictionary<string, string> parameters) where T : ITwentyThreeParsable, new()
        {
            return GetResponse<T>(parameters, TimeSpan.MinValue);
        }

        private T GetResponseCache<T>(Dictionary<string, string> parameters) where T : ITwentyThreeParsable, new()
        {
            return GetResponse<T>(parameters, Cache.CacheTimeout);
        }

        private T GetResponse<T>(Dictionary<string, string> parameters, TimeSpan cacheTimeout) where T : ITwentyThreeParsable, new()
        {
            // Flow for GetResponse.
            // 1. Check API Key
            // 2. Calculate Cache URL.
            // 3. Check Cache for URL.
            // 4. Get Response if not in cache.
            // 5. Write Cache.
            // 6. Parse Response.

            CheckApiKey();

            parameters["api_key"] = ApiKey;

            // If performing one of the old 'flickr.auth' methods then use old authentication details.
            var method = parameters["method"];

            if (method.StartsWith("flickr.auth", StringComparison.Ordinal))
            {
                if (!string.IsNullOrEmpty(AuthToken)) { parameters["auth_token"] = AuthToken; }
            }
            
            var url = CalculateUri(parameters, !string.IsNullOrEmpty(sharedSecret));

            lastRequest = url;

            string responseXml;

            if (InstanceCacheDisabled)
            {
                responseXml = TwentyThreeResponder.GetDataResponse(this, BaseUri.AbsoluteUri, parameters);
            }
            else
            {
                var urlComplete = url;

                var cached = (ResponseCacheItem)Cache.Responses.Get(urlComplete, cacheTimeout, true);
                if (cached != null)
                {
                    Debug.WriteLine("Cache hit.");
                    responseXml = cached.Response;
                }
                else
                {
                    Debug.WriteLine("Cache miss.");
                    responseXml = TwentyThreeResponder.GetDataResponse(this, BaseUri.AbsoluteUri, parameters);

                    var resCache = new ResponseCacheItem(new Uri(urlComplete), responseXml, DateTime.UtcNow);

                    Cache.Responses.Shrink(Math.Max(0, Cache.CacheSizeLimit - responseXml.Length));
                    Cache.Responses[urlComplete] = resCache;
                }
            }

            lastResponse = responseXml;

            var item = new T();
            item.Load(responseXml);

            return item;

        }

    }


}
