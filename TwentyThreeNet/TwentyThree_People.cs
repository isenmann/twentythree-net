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
        /// <returns>The <see cref="FoundUser"/> object containing the matching details.</returns>
        /// <exception cref="TwentyThreeApiException">A FlickrApiException is raised if the email address is not found.</exception>
        public FoundUser PeopleFindByEmail(string emailAddress)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.people.findByEmail");
            parameters.Add("api_key", apiKey);
            parameters.Add("find_email", emailAddress);

            return GetResponseCache<FoundUser>(parameters);
        }

        /// <summary>
        /// Returns a <see cref="FoundUser"/> object matching the screen name.
        /// </summary>
        /// <param name="userName">The screen name or username of the user.</param>
        /// <returns>A <see cref="FoundUser"/> class containing the userId and username of the user.</returns>
        /// <exception cref="TwentyThreeApiException">A FlickrApiException is raised if the email address is not found.</exception>
        public FoundUser PeopleFindByUserName(string userName)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.people.findByUsername");
            parameters.Add("api_key", apiKey);
            parameters.Add("username", userName);

            return GetResponseCache<FoundUser>(parameters);
        }

        /// <summary>
        /// Gets a list of groups the user is a member of.
        /// </summary>
        /// <param name="userId">The user whose groups you wish to return.</param>
        /// <returns></returns>
        public GroupInfoCollection PeopleGetGroups(string userId)
        {
            CheckRequiresAuthentication();

            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.people.getGroups");
            parameters.Add("user_id", userId);

            return GetResponseCache<GroupInfoCollection>(parameters);
        }

        /// <summary>
        /// Gets the <see cref="Person"/> object for the given user id.
        /// </summary>
        /// <param name="userId">The user id to find.</param>
        /// <returns>The <see cref="Person"/> object containing the users details.</returns>
        public Person PeopleGetInfo(string userId)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.people.getInfo");
            parameters.Add("user_id", userId);

            return GetResponseCache<Person>(parameters);
        }

        /// <summary>
        /// Returns the limits for a person. See <see cref="PersonLimits"/> for more details.
        /// </summary>
        /// <returns></returns>
        public PersonLimits PeopleGetLimits()
        {
            CheckRequiresAuthentication();

            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.people.getLimits");

            return GetResponseCache<PersonLimits>(parameters);
        }

        /// <summary>
        /// Gets the upload status of the authenticated user.
        /// </summary>
        /// <returns>The <see cref="UserStatus"/> object containing the users details.</returns>
        public UserStatus PeopleGetUploadStatus()
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.people.getUploadStatus");

            return GetResponseCache<UserStatus>(parameters);
        }

        /// <summary>
        /// Get a list of public groups for a user.
        /// </summary>
        /// <param name="userId">The user id to get groups for.</param>
        /// <returns>An array of <see cref="GroupInfo"/> instances.</returns>
        public GroupInfoCollection PeopleGetPublicGroups(string userId)
        {
            return PeopleGetPublicGroups(userId, null);
        }
        
        /// <summary>
        /// Get a list of public groups for a user.
        /// </summary>
        /// <param name="userId">The user id to get groups for.</param>
        /// <param name="includeInvitationOnly">Wheither to include public but invitation only groups in the results.</param>
        /// <returns>An array of <see cref="GroupInfo"/> instances.</returns>
        public GroupInfoCollection PeopleGetPublicGroups(string userId, bool? includeInvitationOnly)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.people.getPublicGroups");
            parameters.Add("api_key", apiKey);
            parameters.Add("user_id", userId);
            if (includeInvitationOnly.HasValue) parameters.Add("invitation_only", includeInvitationOnly.Value ? "1" : "0");


            return GetResponseCache<GroupInfoCollection>(parameters);
        }

        /// <summary>
        /// Gets a users public photos. Excludes private photos.
        /// </summary>
        /// <param name="userId">The user id of the user.</param>
        /// <returns>The collection of photos contained within a <see cref="Photo"/> object.</returns>
        public PhotoCollection PeopleGetPublicPhotos(string userId)
        {
            return PeopleGetPublicPhotos(userId, 0, 0, SafetyLevel.None, PhotoSearchExtras.None);
        }

        /// <summary>
        /// Gets a users public photos. Excludes private photos.
        /// </summary>
        /// <param name="userId">The user id of the user.</param>
        /// <param name="page">The page to return. Defaults to page 1.</param>
        /// <param name="perPage">The number of photos to return per page. Default is 100.</param>
        /// <returns>The collection of photos contained within a <see cref="Photo"/> object.</returns>
        public PhotoCollection PeopleGetPublicPhotos(string userId, int page, int perPage)
        {
            return PeopleGetPublicPhotos(userId, page, perPage, SafetyLevel.None, PhotoSearchExtras.None);
        }

        /// <summary>
        /// Gets a users public photos. Excludes private photos.
        /// </summary>
        /// <param name="userId">The user id of the user.</param>
        /// <param name="extras">Which (if any) extra information to return. The default is none.</param>
        /// <returns>The collection of photos contained within a <see cref="Photo"/> object.</returns>
        public PhotoCollection PeopleGetPublicPhotos(string userId, PhotoSearchExtras extras)
        {
            return PeopleGetPublicPhotos(userId, 0, 0, SafetyLevel.None, extras);
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
        /// <returns>The collection of photos contained within a <see cref="Photo"/> object.</returns>
        public PhotoCollection PeopleGetPublicPhotos(string userId, int page, int perPage, SafetyLevel safetyLevel, PhotoSearchExtras extras)
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

            return GetResponseCache<PhotoCollection>(parameters);
        }
    }
}
