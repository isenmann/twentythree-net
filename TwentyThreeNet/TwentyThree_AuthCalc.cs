﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyThreeNet
{
    public partial class TwentyThree
    {
        /// <summary>
        /// Calculates a URL for revoking permissions for your application by the user.
        /// </summary>
        /// <param name="appToken">The 'application id' of your application. 
        /// Go to https://www.23hq.com/services/auth/list.gne to get your application token.</param>
        /// <returns></returns>
        public string AuthCalcRevokeUrl(string appToken)
        {
            return "https://www.23hq.com/services/auth/revoke.gne?token=" + appToken;
        }

        /// <summary>
        /// Calculates the URL to redirect the user to Flickr web site for
        /// authentication. Used by desktop application. 
        /// See <see cref="AuthGetFrob"/> for example code.
        /// </summary>
        /// <param name="frob">The FROB to be used for authentication.</param>
        /// <param name="authLevel">The <see cref="AuthLevel"/> stating the maximum authentication level your application requires.</param>
        /// <returns>The url to redirect the user to.</returns>
        public string AuthCalcUrl(string frob, AuthLevel authLevel)
        {
            if (sharedSecret == null) throw new SignatureRequiredException();

            string hash = sharedSecret + "api_key" + apiKey + "frob" + frob + "perms" + UtilityMethods.AuthLevelToString(authLevel);
            hash = UtilityMethods.MD5Hash(hash);
            string url = AuthUrl + "?api_key=" + apiKey + "&perms=" + UtilityMethods.AuthLevelToString(authLevel) + "&frob=" + frob;
            url += "&api_sig=" + hash;

            return url;
        }

        /// <summary>
        /// Calculates the URL to redirect the user to Flickr web site for
        /// authentication. Used by Web applications. 
        /// See <see cref="AuthGetFrob"/> for example code.
        /// </summary>
        /// <param name="authLevel">The <see cref="AuthLevel"/> stating the maximum authentication level your application requires.</param>
        /// <returns>The url to redirect the user to.</returns>
        public string AuthCalcWebUrl(AuthLevel authLevel)
        {
            return AuthCalcWebUrl(authLevel, null);
        }

        /// <summary>
        /// Calculates the URL to redirect the user to Flickr web site for
        /// authentication. Used by Web applications. 
        /// See <see cref="AuthGetFrob"/> for example code.
        /// </summary>
        /// <param name="authLevel">The <see cref="AuthLevel"/> stating the maximum authentication level your application requires.</param>
        /// <param name="extra">An extra string value which Flickr will return to the callback URL along with the frob.</param>
        /// <returns>The url to redirect the user to.</returns>
        public string AuthCalcWebUrl(AuthLevel authLevel, string extra)
        {
            CheckApiKey();

            CheckSigned();

            string textToHash = sharedSecret + "api_key" + apiKey;
            string url = AuthUrl + "?api_key=" + apiKey + "&perms=" + UtilityMethods.AuthLevelToString(authLevel);

            if (!string.IsNullOrEmpty(extra))
            {
                textToHash += "extra" + extra;
                url += "&extra=" + Uri.EscapeDataString(extra);
            }

            textToHash += "perms" + UtilityMethods.AuthLevelToString(authLevel);

            string hash = UtilityMethods.MD5Hash(textToHash);
            url += "&api_sig=" + hash;

            return url;
        }
    }
}
