using System;
using System.Net;
using System.Xml;
using System.IO;
using System.Collections.Generic;

#pragma warning disable CS0618 // Type or member is obsolete

namespace TwentyThreeNet
{
    public partial class TwentyThree
    {
        private void GetResponseEvent<T>(Dictionary<string, string> parameters, EventHandler<TwentyThreeResultArgs<T>> handler) where T : ITwentyThreeParsable, new()
        {
            GetResponseAsync<T>(
                parameters,
                r =>
                {
                    handler(this, new TwentyThreeResultArgs<T>(r));
                });
        }

        private void GetResponseAsync<T>(Dictionary<string, string> parameters, Action<TwentyThreeResult<T>> callback) where T : ITwentyThreeParsable, new()
        {
            CheckApiKey();

            parameters["api_key"] = ApiKey;

            // If performing one of the old 'flickr.auth' methods then use old authentication details.
            string method = parameters["method"];
            
            if (method.StartsWith("flickr.auth", StringComparison.Ordinal))
            {
                if (!string.IsNullOrEmpty(AuthToken)) parameters["auth_token"] = AuthToken;
            }
           
            var url = CalculateUri(parameters, !string.IsNullOrEmpty(sharedSecret));

            lastRequest = url;

            try
            {
                TwentyThreeResponder.GetDataResponseAsync(this, BaseUri.AbsoluteUri, parameters, (r)
                    =>
                    {
                        var result = new TwentyThreeResult<T>();
                        if (r.HasError)
                        {
                            result.Error = r.Error;
                        }
                        else
                        {
                            try
                            {
                                lastResponse = r.Result;

                                var t = new T();
                                ((ITwentyThreeParsable)t).Load(r.Result);
                                result.Result = t;
                                result.HasError = false;
                            }
                            catch (Exception ex)
                            {
                                result.Error = ex;
                            }
                        }

                        if (callback != null) callback(result);
                    });
            }
            catch (Exception ex)
            {
                var result = new TwentyThreeResult<T>();
                result.Error = ex;
                if (null != callback) callback(result);
            }

        }

        private void DoGetResponseAsync<T>(Uri url, Action<TwentyThreeResult<T>> callback) where T : ITwentyThreeParsable, new()
        {
            string postContents = string.Empty;

            if (url.AbsoluteUri.Length > 2000)
            {
                postContents = url.Query.Substring(1);
                url = new Uri(url, string.Empty);
            }

            var result = new TwentyThreeResult<T>();

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            request.BeginGetRequestStream(requestAsyncResult =>
            {
                using (Stream s = request.EndGetRequestStream(requestAsyncResult))
                {
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        sw.Write(postContents);
                        sw.Close();
                    }
                    s.Close();
                }

                request.BeginGetResponse(responseAsyncResult =>
                {
                    try
                    {
                        var response = (HttpWebResponse)request.EndGetResponse(responseAsyncResult);
                        using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                        {
                            string responseXml = sr.ReadToEnd();

                            lastResponse = responseXml;
                            
                            var t = new T();
                            ((ITwentyThreeParsable)t).Load(responseXml);
                            result.Result = t;
                            result.HasError = false;

                            sr.Close();
                        }

                        if (null != callback) callback(result);

                    }
                    catch(Exception ex)
                    {
                        result.Error = ex;
                        if (null != callback) callback(result);
                    }
                }, null);

            }, null);

        }
    }
}
