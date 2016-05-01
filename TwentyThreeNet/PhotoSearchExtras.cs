using System;
using System.ComponentModel;

namespace TwentyThreeNet
{
    /// <summary>
    /// Which photo search extras to be included. Can be combined to include more than one
    /// value.
    /// </summary>
    /// <example>
    /// The following code sets options to return both the license and owner name along with
    /// the other search results.
    /// <code>
    /// PhotoSearchOptions options = new PhotoSearchOptions();
    /// options.Extras = PhotoSearchExtras.License &amp; PhotoSearchExtras.OwnerName
    /// </code>
    /// </example>
    [Flags]
    [Serializable]
    public enum PhotoSearchExtras : long
    {
        /// <summary>
        /// No extras selected.
        /// </summary>
        [Description("")] None = 0,

        /// <summary>
        /// Returns a license.
        /// </summary>
        [Description("license")] License = 1,

        /// <summary>
        /// Returned the date the photos was uploaded.
        /// </summary>
        [Description("date_upload")] DateUploaded = 2,

        /// <summary>
        /// Returned the date the photo was taken.
        /// </summary>
        [Description("date_taken")] DateTaken = 4,

        /// <summary>
        /// Returns the name of the owner of the photo.
        /// </summary>
        [Description("owner_name")] OwnerName = 8,

        /// <summary>
        /// Returns the server for the buddy icon for this user.
        /// </summary>
        [Description("icon_server")] IconServer = 16,

        /// <summary>
        /// Returns the date the photo was last updated.
        /// </summary>
        [Description("last_update")] LastUpdated = 32,

        /// <summary>
        /// Returns Tags attribute
        /// </summary>
        [Description("tags")] Tags = 64,

        /// <summary>
        /// Returns the number of views for a photo.
        /// </summary>
        [Description("views")] Views = 128,

        /// <summary>
        /// Returns the media type of the photo, currently either 'photo' or 'video'.
        /// </summary>
        [Description("media")] Media = 256,

        /// <summary>
        /// Returns the details for IsPublic, IsFamily and IsFriend.
        /// </summary>
        [Description("visibility")] Visibility = 512,

        /// <summary>
        /// Returns all the above information.
        /// </summary>
        All =
            License | DateUploaded | DateTaken | OwnerName | IconServer | LastUpdated | Tags | 
            Views | Media | Visibility,
    }
}
