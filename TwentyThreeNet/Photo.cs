using System;
using System.Xml;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TwentyThreeNet
{
    /// <remarks/>
    public class Photo : ITwentyThreeParsable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Photo"/> class.
        /// </summary>
        public Photo()
        {
            Tags = new Collection<string>();
        }

        /// <summary>
        /// The list of clean tags for the photograph.
        /// </summary>
        public Collection<string> Tags { get; set; }

        /// <remarks/>
        public string PhotoId { get; set; }
    
        /// <remarks/>
        public string UserId { get; set; }
    
        /// <remarks/>
        public string Secret { get; set; }
    
        /// <remarks/>
        public string Server { get; set; }
    
        /// <remarks/>
        public string Farm { get; set; }
    
        /// <remarks/>
        public string Title { get; set; }
    
        /// <remarks/>
        public bool IsPublic { get; set; }
    
        /// <remarks/>
        public bool IsFriend { get; set; }
    
        /// <remarks/>
        public bool IsFamily { get; set; }

        /// <remarks/>
        public LicenseType License { get; set; }

        /// <summary>
        /// Converts the raw dateupload field to a <see cref="DateTime"/>.
        /// </summary>
        public DateTime DateUploaded { get; set; }

        /// <summary>
        /// Converts the raw lastupdate field to a <see cref="DateTime"/>.
        /// Returns <see cref="DateTime.MinValue"/> if the raw value was not returned.
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Converts the raw datetaken field to a <see cref="DateTime"/>.
        /// Returns <see cref="DateTime.MinValue"/> if the raw value was not returned.
        /// </summary>
        public DateTime DateTaken { get; set; }

        /// <summary>
        /// Is the date taken unknown?
        /// </summary>
        public bool DateTakenUnknown { get; set; }

        /// <summary>
        /// The date the photo was added to the group. Only returned by <see cref="TwentyThree.GroupsPoolsGetPhotos(string)"/>.
        /// </summary>
        public DateTime? DateAddedToGroup { get; set; }

        /// <summary>
        /// The date the photo was favourited. Only returned by <see cref="TwentyThree.FavoritesGetPublicList(string)"/>.
        /// </summary>
        public DateTime? DateFavorited { get; set; }

        /// <remarks/>
        public string OwnerName { get; set; }

        /// <remarks/>
        public string IconServer { get; set; }

        /// <summary>
        /// The url to the web page for this photo. Uses the users userId, not their web alias, but
        /// will still work.
        /// </summary>
        public string WebUrl
        {
            get
            {
                return string.Format(System.Globalization.CultureInfo.InvariantCulture, "http://www.23hq.com/user/{0}/photo/{1}", UserId, PhotoId);
            }
        }

        /// <summary>
        /// The URL for the square thumbnail of a photo.
        /// </summary>
        public string SquareThumbnailUrl
        {
            get
            {
                return UtilityMethods.UrlFormat(this, "quad50", "jpg");
            }
        }

        /// <summary>
        /// The URL for the large (100x100) square thumbnail of a photo.
        /// </summary>
        public string LargeSquareThumbnailUrl
        {
            get
            {
                return UtilityMethods.UrlFormat(this, "quad100", "jpg");
            }
        }

        /// <summary>
        /// The URL for the thumbnail of a photo.
        /// </summary>
        public string ThumbnailUrl
        {
            get
            {
                return UtilityMethods.UrlFormat(this, "thumb", "jpg");
            }
        }

        /// <summary>
        /// The URL for the small copy of a photo.
        /// </summary>
        public string SmallUrl
        {
            get
            {
                return UtilityMethods.UrlFormat(this, "mblog", "jpg");
            }
        }

        /// <summary>
        /// The URL for the medium copy of a photo.
        /// </summary>
        /// <remarks>There is a chance that extremely small images will not have a medium copy.
        /// Use <see cref="TwentyThree.PhotosGetSizes"/> to get the available URLs for a photo.</remarks>
        public string MediumUrl
        {
            get
            {
                return UtilityMethods.UrlFormat(this, "standard", "jpg");
            }
        }

        /// <summary>
        /// The URL for the large copy of a photo.
        /// </summary>
        /// <remarks>There is a chance that small images will not have a large copy.
        /// Use <see cref="TwentyThree.PhotosGetSizes"/> to get the available URLs for a photo.</remarks>
        public string LargeUrl
        {
            get
            {
                return UtilityMethods.UrlFormat(this, "large1k", "jpg");
            }
        }

        /// <summary>
        /// This will contain the url of the original file.
        /// </summary>
        public string OriginalUrl
        {
            get 
            {
                return String.Format("http://www.23hq.com/{0}/photo/{1}/original", OwnerName, PhotoId);
            }
        }

        /// <summary>
        /// Can the current user (or unauthenticated user if no authentication token provided) comment on this photo.
        /// </summary>
        /// <remarks>Will always be false for unauthenticated calls.</remarks>
        public bool? CanComment { get; set; }

        /// <summary>
        /// Can the current user (or unauthenticated user if no authentication token provided) print this photo.
        /// </summary>
        /// <remarks>Will always be false for unauthenticated calls.</remarks>
        public bool? CanPrint { get; set; }

        /// <summary>
        /// Can the current user (or unauthenticated user if no authentication token provided) download this photo.
        /// </summary>
        public bool? CanDownload { get; set; }

        /// <summary>
        /// Can the current user (or unauthenticated user if no authentication token provided) add 'meta' to this photo (notes, tags etc).
        /// </summary>
        /// <remarks>Will always be false for unauthenticated calls.</remarks>
        public bool? CanAddMeta { get; set; }

        /// <summary>
        /// Can the current user (or unauthenticated user if no authentication token provided) blog this photo.
        /// </summary>
        /// <remarks>Will always be false for unauthenticated calls.</remarks>
        public bool? CanBlog { get; set; }

        /// <summary>
        /// Can the current user (or unauthenticated user if no authentication token provided) share on this photo.
        /// </summary>
        /// <remarks>Will always be false for unauthenticated calls.</remarks>
        public bool? CanShare { get; set; }

        /// <summary>
        /// The number of views for this photo. Only returned if PhotoSearchExtras.Views is set.
        /// </summary>
        public int? Views { get; set; }

        /// <summary>
        /// The media format for this photo. Only returned if PhotoSearchExtras.Media is set.
        /// </summary>
        public string Media { get; set; }

        /// <summary>
        /// The status of the media for this photo. Only returned if PhotoSearchExtras.Media is set.
        /// </summary>
        public string MediaStatus { get; set; }
        
        /// <summary>
        /// The description for the photo. Only returned if <see cref="PhotoSearchExtras.Description"/> is set.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Latitude. Will be 0 if Geo tags not specified.
        /// </summary>
        public double Latitude
        {
            get
            {
                double lat = 0;

                if (Tags != null && Tags.Count > 0)
                {
                    foreach (var tag in Tags)
                    {
                        if (tag.Contains("geo:lat="))
                        {
                            lat = Double.Parse(tag.Replace("geo:lat=", ""), System.Globalization.NumberFormatInfo.InvariantInfo);
                            break;
                        }
                    }
                }

                return lat;
            }
        }

        /// <summary>
        /// Longitude. Will be 0 if geo tags not specified.
        /// </summary>
        public double Longitude
        {
            get
            {
                double lon = 0;

                if (Tags != null && Tags.Count > 0)
                {
                    foreach (var tag in Tags)
                    {
                        if (tag.Contains("geo:long="))
                        {
                            lon = Double.Parse(tag.Replace("geo:long=", ""), System.Globalization.NumberFormatInfo.InvariantInfo);
                            break;
                        }

                        if (tag.Contains("geo:lon="))
                        {
                            lon = Double.Parse(tag.Replace("geo:lon=", ""), System.Globalization.NumberFormatInfo.InvariantInfo);
                            break;
                        }
                    }
                }

                return lon;
            }
        }

        /// <summary>
        /// If Geolocation information is returned for this photo then this will contain the permissions for who can see those permissions.
        /// </summary>
        public GeoPermissions GeoPermissions { get; set; }

        /// <summary>
        /// If requested will contain the number of degrees the photo has been rotated since upload.
        /// </summary>
        /// <remarks>
        /// This might be due to the photo containing rotation information so done automatically, or by manually rotating the photo in Flickr.
        /// </remarks>
        public int? Rotation { get; set; }

        void ITwentyThreeParsable.Load(XmlReader reader)
        {
            Load(reader, false);

            if (reader.LocalName == "photo" && reader.NodeType == XmlNodeType.EndElement) reader.Read();
        }

        /// <summary>
        /// Protected method that does the actual initialization of the Photo instance. Should be called by subclasses of the Photo class.
        /// </summary>
        /// <param name="reader">The reader containing the XML to be parsed.</param>
        /// <param name="allowExtraAtrributes">Wheither to allow unknown extra attributes. 
        /// In debug builds will throw an exception if this parameter is false and an unknown attribute is found.</param>
        protected void Load(XmlReader reader, bool allowExtraAtrributes)
        {
            if (reader.LocalName != "photo" && reader.LocalName != "primary_photo_extras")
                UtilityMethods.CheckParsingException(reader);

            while (reader.MoveToNextAttribute())
            {
                switch (reader.LocalName)
                {
                    case "id":
                        PhotoId = reader.Value;
                        if (string.IsNullOrEmpty(reader.Value))
                        {
                            reader.Skip();
                            return;
                        }
                        break;
                    case "owner":
                        UserId = reader.Value;
                        break;
                    case "secret":
                        Secret = reader.Value;
                        break;
                    case "server":
                        Server = reader.Value;
                        break;
                    case "farm":
                        Farm = reader.Value;
                        break;
                    case "title":
                        Title = reader.Value;
                        break;
                    case "ispublic":
                        IsPublic = reader.Value == "1";
                        break;
                    case "isfamily":
                        IsFamily = reader.Value == "1";
                        break;
                    case "isfriend":
                        IsFriend = reader.Value == "1";
                        break;
                    case "tags":
                        foreach (string tag in reader.Value.Split(' '))
                        {
                            Tags.Add(tag);
                        }
                        break;
                    case "datetaken":
                        // For example : 2007-11-04 08:55:18
                        DateTaken = UtilityMethods.ParseDateWithGranularity(reader.Value);
                        break;
                    case "datetakengranularity":
                        break;
                    case "datetakenunknown":
                        DateTakenUnknown = reader.Value == "1";
                        break;
                    case "dateupload":
                        DateUploaded = UtilityMethods.UnixTimestampToDate(reader.Value);
                        break;
                    case "license":
                        License = (LicenseType)int.Parse(reader.Value, System.Globalization.CultureInfo.InvariantCulture);
                        break;
                    case "ownername":
                        OwnerName = reader.Value;
                        break;
                    case "last_update":
                        LastUpdated = UtilityMethods.UnixTimestampToDate(reader.Value);
                        break;
                        break;
                    case "views":
                        Views = int.Parse(reader.Value, System.Globalization.CultureInfo.InvariantCulture);
                        break;
                    case "media":
                        Media = reader.Value;
                        break;
                    case "media_status":
                        MediaStatus = reader.Value;
                        break;
                    case "iconserver":
                        IconServer = reader.Value;
                        break;
                    case "username":
                        OwnerName = reader.Value;
                        break;
                    case "isprimary":
                    case "is_primary":
                        break;
                    case "dateadded":
                        DateAddedToGroup = UtilityMethods.UnixTimestampToDate(reader.Value);
                        break;
                    case "date_faved":
                        DateFavorited = UtilityMethods.UnixTimestampToDate(reader.Value);
                        break;
                    case "has_comment": // Gallery photos return this, but we ignore it and set GalleryPhoto.Comment instead.
                        break;
                    case "can_comment":
                        CanComment = reader.Value == "1";
                        break;
                    case "can_addmeta":
                        CanAddMeta = reader.Value == "1";
                        break;
                    case "can_blog":
                        CanBlog = reader.Value == "1";
                        break;
                    case "can_print":
                        CanPrint = reader.Value == "1";
                        break;
                    case "can_download":
                        CanDownload = reader.Value == "1";
                        break;
                    case "can_share":
                        CanShare = reader.Value == "1";
                        break;
                    case "geo_is_family":
                        if (GeoPermissions == null)
                        {
                            GeoPermissions = new GeoPermissions(); 
                            GeoPermissions.PhotoId = PhotoId;
                        }
                        GeoPermissions.IsFamily = reader.Value == "1";
                        break;
                    case "geo_is_friend":
                        if (GeoPermissions == null)
                        {
                            GeoPermissions = new GeoPermissions(); 
                            GeoPermissions.PhotoId = PhotoId;
                        }
                        GeoPermissions.IsFriend = reader.Value == "1";
                        break;
                    case "geo_is_public":
                        if (GeoPermissions == null)
                        {
                            GeoPermissions = new GeoPermissions(); 
                            GeoPermissions.PhotoId = PhotoId;
                        }
                        GeoPermissions.IsPublic = reader.Value == "1";
                        break;
                    case "geo_is_contact":
                        if (GeoPermissions == null)
                        {
                            GeoPermissions = new GeoPermissions(); 
                            GeoPermissions.PhotoId = PhotoId;
                        }
                        GeoPermissions.IsContact = reader.Value == "1";
                        break;
                    case "rotation":
                        Rotation = reader.ReadContentAsInt();
                        break;
                    default:
                        if (!allowExtraAtrributes) UtilityMethods.CheckParsingException(reader);
                        break;
                }
            }

            reader.Read();

            if (reader.LocalName == "description")
                Description = reader.ReadElementContentAsString();

        }
    }
}
