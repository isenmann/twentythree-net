﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;

namespace TwentyThreeNet
{
    public partial class TwentyThree
    {
        /// <summary>
        /// Gets the currently authenticated users default content type.
        /// </summary>
        /// <param name="callback">Callback method to call upon return of the response from Flickr.</param>
        public void PrefsGetContentTypeAsync(Action<TwentyThreeResult<ContentType>> callback)
        {
            CheckRequiresAuthentication();

            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.prefs.getContentType");

            GetResponseAsync<UnknownResponse>(
                parameters, 
                r =>
                {
                    var result = new TwentyThreeResult<ContentType>();
                    result.Error = r.Error;
                    if (!r.HasError)
                    {
                        result.Result = (ContentType)int.Parse(r.Result.GetAttributeValue("*", "content_type"), System.Globalization.NumberFormatInfo.InvariantInfo);
                    }
                    callback(result);
                });
        }

        /// <summary>
        /// Returns the default privacy level for geographic information attached to the user's photos and whether 
        /// or not the user has chosen to use geo-related EXIF information to automatically geotag their photos.
        /// </summary>
        /// <param name="callback">Callback method to call upon return of the response from Flickr.</param>
        public void PrefsGetGeoPermsAsync(Action<TwentyThreeResult<UserGeoPermissions>> callback)
        {
            CheckRequiresAuthentication();

            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.prefs.getGeoPerms");

            GetResponseAsync<UserGeoPermissions>(parameters, callback);
        }

        /// <summary>
        /// Gets the currently authenticated users default hidden from search setting.
        /// </summary>
        /// <param name="callback">Callback method to call upon return of the response from Flickr.</param>
        public void PrefsGetHiddenAsync(Action<TwentyThreeResult<HiddenFromSearch>> callback)
        {
            CheckRequiresAuthentication();

            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.prefs.getHidden");

            GetResponseAsync<UnknownResponse>(
                parameters,
                r =>
                {
                    var result = new TwentyThreeResult<HiddenFromSearch>();
                    result.Error = r.Error;
                    if (!r.HasError)
                    {
                        result.Result = (HiddenFromSearch)int.Parse(r.Result.GetAttributeValue("*", "hidden"), System.Globalization.NumberFormatInfo.InvariantInfo);
                    }
                    callback(result);
                });
        }

        /// <summary>
        /// Returns the default privacy level preference for the user. 
        /// </summary>
        /// <param name="callback">Callback method to call upon return of the response from Flickr.</param>
        public void PrefsGetPrivacyAsync(Action<TwentyThreeResult<PrivacyFilter>> callback)
        {
            CheckRequiresAuthentication();

            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.prefs.getPrivacy");

            GetResponseAsync<UnknownResponse>(
                parameters,
                r =>
                {
                    var result = new TwentyThreeResult<PrivacyFilter>();
                    result.Error = r.Error;
                    if (!r.HasError)
                    {
                        result.Result = (PrivacyFilter)int.Parse(r.Result.GetAttributeValue("*", "privacy"), System.Globalization.NumberFormatInfo.InvariantInfo);
                    }
                    callback(result);
                });

        }

        /// <summary>
        /// Gets the currently authenticated users default safety level.
        /// </summary>
        /// <param name="callback">Callback method to call upon return of the response from Flickr.</param>
        public void PrefsGetSafetyLevelAsync(Action<TwentyThreeResult<SafetyLevel>> callback)
        {
            CheckRequiresAuthentication();

            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.prefs.getSafetyLevel");

            GetResponseAsync<UnknownResponse>(
                parameters,
                r =>
                {
                    var result = new TwentyThreeResult<SafetyLevel>();
                    result.Error = r.Error;
                    if (!r.HasError)
                    {
                        result.Result = (SafetyLevel)int.Parse(r.Result.GetAttributeValue("*", "safety_level"), System.Globalization.NumberFormatInfo.InvariantInfo);
                    }
                    callback(result);
                });
        }

    }
}
