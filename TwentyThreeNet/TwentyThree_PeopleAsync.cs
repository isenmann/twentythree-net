using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TwentyThreeNet
{
    public partial class TwentyThree
    {
        /// <summary>
        /// Used to fid a flickr users details by specifying their email address.
        /// </summary>
        /// <param name="emailAddress">The email address to search on.</param>
        /// <param name="callback">Callback method to call upon return of the response from Flickr.</param>
        /// <exception cref="TwentyThreeApiException">A FlickrApiException is raised if the email address is not found.</exception>
        public void PeopleFindByEmailAsync(string emailAddress, Action<TwentyThreeResult<FoundUser>> callback)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.people.findByEmail");
            parameters.Add("api_key", apiKey);
            parameters.Add("find_email", emailAddress);

            GetResponseAsync<FoundUser>(parameters, callback);
        }

        /// <summary>
        /// Returns a <see cref="FoundUser"/> object matching the screen name.
        /// </summary>
        /// <param name="userName">The screen name or username of the user.</param>
        /// <param name="callback">Callback method to call upon return of the response from Flickr.</param>
        /// <exception cref="TwentyThreeApiException">A FlickrApiException is raised if the email address is not found.</exception>
        public void PeopleFindByUserNameAsync(string userName, Action<TwentyThreeResult<FoundUser>> callback)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.people.findByUsername");
            parameters.Add("api_key", apiKey);
            parameters.Add("username", userName);

            GetResponseAsync<FoundUser>(parameters, callback);
        }

        /// <summary>
        /// Gets a list of groups the user is a member of.
        /// </summary>
        /// <param name="userId">The user whose groups you wish to return.</param>
        /// <param name="callback"></param>
        public void PeopleGetGroupsAsync(string userId, Action<TwentyThreeResult<GroupInfoCollection>> callback)
        {
            CheckRequiresAuthentication();

            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.people.getGroups");
            parameters.Add("user_id", userId);

            GetResponseAsync<GroupInfoCollection>(parameters, callback);
        }


        /// <summary>
        /// Gets the <see cref="Person"/> object for the given user id.
        /// </summary>
        /// <param name="userId">The user id to find.</param>
        /// <param name="callback">Callback method to call upon return of the response from Flickr.</param>
        public void PeopleGetInfoAsync(string userId, Action<TwentyThreeResult<Person>> callback)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.people.getInfo");
            parameters.Add("api_key", apiKey);
            parameters.Add("user_id", userId);

            GetResponseAsync<Person>(parameters, callback);
        }

        /// <summary>
        /// Returns the limits for a person. See <see cref="PersonLimits"/> for more details.
        /// </summary>
        /// <returns></returns>
        public void PeopleGetLimitsAsync(Action<TwentyThreeResult<PersonLimits>> callback)
        {
            CheckRequiresAuthentication();

            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.people.getLimits");

            GetResponseAsync<PersonLimits>(parameters, callback);
        }

        /// <summary>
        /// Gets the upload status of the authenticated user.
        /// </summary>
        /// <param name="callback">Callback method to call upon return of the response from Flickr.</param>
        public void PeopleGetUploadStatusAsync(Action<TwentyThreeResult<UserStatus>> callback)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.people.getUploadStatus");

            GetResponseAsync<UserStatus>(parameters, callback);
        }

        /// <summary>
        /// Get a list of public groups for a user.
        /// </summary>
        /// <param name="userId">The user id to get groups for.</param>
        /// <param name="callback">Callback method to call upon return of the response from Flickr.</param>
        public void PeopleGetPublicGroupsAsync(string userId, Action<TwentyThreeResult<GroupInfoCollection>> callback)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.people.getPublicGroups");
            parameters.Add("api_key", apiKey);
            parameters.Add("user_id", userId);

            GetResponseAsync<GroupInfoCollection>(parameters, callback);
        }

        /// <summary>
        /// Gets a users public photos. Excludes private photos.
        /// </summary>
        /// <param name="userId">The user id of the user.</param>
        /// <param name="callback">Callback method to call upon return of the response from Flickr.</param>
        public void PeopleGetPublicPhotosAsync(string userId, Action<TwentyThreeResult<PhotoCollection>> callback)
        {
            PeopleGetPublicPhotosAsync(userId, 0, 0, SafetyLevel.None, PhotoSearchExtras.None, callback);
        }

        /// <summary>
        /// Gets a users public photos. Excludes private photos.
        /// </summary>
        /// <param name="userId">The user id of the user.</param>
        /// <param name="page">The page to return. Defaults to page 1.</param>
        /// <param name="perPage">The number of photos to return per page. Default is 100.</param>
        /// <param name="callback">Callback method to call upon return of the response from Flickr.</param>
        public void PeopleGetPublicPhotosAsync(string userId, int page, int perPage, Action<TwentyThreeResult<PhotoCollection>> callback)
        {
            PeopleGetPublicPhotosAsync(userId, page, perPage, SafetyLevel.None, PhotoSearchExtras.None, callback);
        }

        /// <summary>
        /// Gets a users public photos. Excludes private photos.
        /// </summary>
        /// <param name="userId">The user id of the user.</param>
        /// <param name="page">The page to return. Defaults to page 1.</param>
        /// <param name="perPage">The number of photos to return per page. Default is 100.</param>
        /// <param name="extras">Which (if any) extra information to return. The default is none.</param>
        /// <param name="safetyLevel">The safety level of the returned photos. 
        /// Unauthenticated calls can only return Safe photos.</param>
        /// <param name="callback">Callback method to call upon return of the response from Flickr.</param>
        public void PeopleGetPublicPhotosAsync(string userId, int page, int perPage, SafetyLevel safetyLevel, PhotoSearchExtras extras, Action<TwentyThreeResult<PhotoCollection>> callback)
        {
            if (!IsAuthenticated && safetyLevel > SafetyLevel.Safe)
                throw new ArgumentException("Safety level may only be 'Safe' for unauthenticated calls", "safetyLevel");

            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.people.getPublicPhotos");
            parameters.Add("api_key", apiKey);
            parameters.Add("user_id", userId);
            if (perPage > 0) parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
            if (page > 0) parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
            if (safetyLevel != SafetyLevel.None) parameters.Add("safety_level", safetyLevel.ToString("D"));
            if (extras != PhotoSearchExtras.None) parameters.Add("extras", UtilityMethods.ExtrasToString(extras));

            GetResponseAsync<PhotoCollection>(parameters, callback);
        }
    }
}
