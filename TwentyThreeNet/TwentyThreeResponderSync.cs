﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Diagnostics;

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
        /// <returns></returns>
        public static string GetDataResponse(TwentyThree flickr, string baseUrl, Dictionary<string, string> parameters)
        {
            return GetDataResponseNormal(flickr, baseUrl, parameters);
        }

        private static string GetDataResponseNormal(TwentyThree flickr, string baseUrl, Dictionary<string, string> parameters)
        {
            string method = "POST";

            string data = string.Empty;

            foreach (var k in parameters)
            {
                data += k.Key + "=" + UtilityMethods.EscapeDataString(k.Value) + "&";
            }

            if (method == "GET" && data.Length > 2000) method = "POST";

            if (method == "GET")
                return DownloadData(method, baseUrl + "?" + data, null, null, null);
            else
                return DownloadData(method, baseUrl, data, PostContentType, null);
        }
        
#if !WindowsCE
        private static string DownloadData(string method, string baseUrl, string data, string contentType, string authHeader)
        {
            Func<string> f = () =>
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    if (!string.IsNullOrEmpty(contentType)) client.Headers.Add("Content-Type", contentType);
                    if (!string.IsNullOrEmpty(authHeader)) client.Headers.Add("Authorization", authHeader);

                    if (method == "POST")
                    {
                        return client.UploadString(baseUrl, data);
                    }
                    return client.DownloadString(baseUrl);
                }
            };

            try
            {
                return f();
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null && (response.StatusCode == HttpStatusCode.BadGateway || response.StatusCode == HttpStatusCode.GatewayTimeout))
                    {
                        System.Threading.Thread.Sleep(1000);
                        return f();
                    }
                }
                throw;
            }

        }
#else
        private static string DownloadData(string method, string baseUrl, string data, string contentType, string authHeader)
        {
            byte[] postArray = Encoding.UTF8.GetBytes(data);

            // Initialise the web request
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(baseUrl);
            req.Method = method;

            if (req.Method == "POST") req.ContentLength = postArray.Length;

            req.KeepAlive = false;

            if (data.Length > 0)
            {
                req.ContentType = "application/x-www-form-urlencoded";
                using (Stream dataStream = req.GetRequestStream())
                {
                    dataStream.Write(postArray, 0, postArray.Length);
                }
            }
            else
            {
                // This is needed in the Compact Framework
                // See for more details: http://msdn2.microsoft.com/en-us/library/1afx2b0f.aspx
                req.GetRequestStream().Close();
            }

            HttpWebResponse res = null;

            try
            {
                // Get response from the internet
                res = (HttpWebResponse)req.GetResponse();
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse res2 = (HttpWebResponse)ex.Response;
                    if (res2 != null)
                    {
                        throw new FlickrWebException(String.Format(System.Globalization.CultureInfo.InvariantCulture, "HTTP Error {0}, {1}", (int)res2.StatusCode, res2.StatusDescription), ex);
                    }
                }
                throw new FlickrWebException(ex.Message, ex);
            }

            string responseString = string.Empty;

            using (StreamReader sr = new StreamReader(res.GetResponseStream()))
            {
                responseString = sr.ReadToEnd();
            }

            return responseString;
        }
#endif

    }
}
