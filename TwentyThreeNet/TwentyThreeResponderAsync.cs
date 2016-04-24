using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace TwentyThreeNet
{
    public static partial class TwentyThreeResponder
    {
        /// <summary>
        /// Gets a data response for the given base url and parameters, 
        /// </summary>
        /// <param name="flickr">The current instance of the <see cref="TwentyThree"/> class.</param>
        /// <param name="baseUrl">The base url to be called.</param>
        /// <param name="parameters">A dictionary of parameters.</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static void GetDataResponseAsync(TwentyThree flickr, string baseUrl, Dictionary<string, string> parameters, Action<TwentyThreeResult<string>> callback)
        {
            GetDataResponseNormalAsync(flickr, baseUrl, parameters, callback);
        }

        private static void GetDataResponseNormalAsync(TwentyThree flickr, string baseUrl, Dictionary<string, string> parameters, Action<TwentyThreeResult<string>> callback) 
        {
            var method = "POST";

            var data = string.Empty;

            foreach (var k in parameters)
            {
                data += k.Key + "=" + UtilityMethods.EscapeDataString(k.Value) + "&";
            }

            if (method == "GET" && data.Length > 2000) method = "POST";

            if (method == "GET")
                DownloadDataAsync(method, baseUrl + "?" + data, null, null, null, callback);
            else
                DownloadDataAsync(method, baseUrl, data, PostContentType, null, callback);
        }
        
        private static void DownloadDataAsync(string method, string baseUrl, string data, string contentType, string authHeader, Action<TwentyThreeResult<string>> callback)
        {
            var client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            if (!string.IsNullOrEmpty(contentType)) client.Headers["Content-Type"] = contentType;
            if (!string.IsNullOrEmpty(authHeader)) client.Headers["Authorization"] = authHeader;

            if (method == "POST")
            {
                client.UploadStringCompleted += delegate(object sender, UploadStringCompletedEventArgs e)
                {
                    var result = new TwentyThreeResult<string>();
                    if (e.Error != null)
                    {
                        result.Error = e.Error;
                        callback(result);
                        return;
                    }

                    result.Result = e.Result;
                    callback(result);
                    return;
                };

                client.UploadStringAsync(new Uri(baseUrl), data);
            }
            else
            {
                client.DownloadStringCompleted += delegate(object sender, DownloadStringCompletedEventArgs e)
                {
                    var result = new TwentyThreeResult<string>();
                    if (e.Error != null)
                    {
                        result.Error = e.Error;
                        callback(result);
                        return;
                    }

                    result.Result = e.Result;
                    callback(result);
                    return;
                };

                client.DownloadStringAsync(new Uri(baseUrl));

            }
        }
    }
}
