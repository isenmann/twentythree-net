using System;
using System.Collections;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TwentyThreeNet
{
    /// <summary>
    /// The context of the current photo, as returned by
    /// <see cref="TwentyThree.PhotosGetContext"/>,
    /// <see cref="TwentyThree.PhotosetsGetContext"/>
    ///  and <see cref="TwentyThree.GroupsPoolsGetContext"/> methods.
    /// </summary>
    public sealed class Context : ITwentyThreeParsable
    {
        /// <summary>
        /// The number of photos in the current context, e.g. Group, Set or photostream.
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// The next photo in the context.
        /// </summary>
        public ContextPhoto NextPhoto { get; set; }
        /// <summary>
        /// The previous photo in the context.
        /// </summary>
        public ContextPhoto PreviousPhoto { get; set; }

        void ITwentyThreeParsable.Load(XmlReader reader)
        {
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                switch (reader.LocalName)
                {
                    case "count":
                        Count = reader.ReadElementContentAsInt();
                        break;
                    case "prevphoto":
                        PreviousPhoto = new ContextPhoto();
                        ((ITwentyThreeParsable)PreviousPhoto).Load(reader);
                        if (PreviousPhoto.PhotoId == "0") PreviousPhoto = null;
                        break;
                    case "nextphoto":
                        NextPhoto = new ContextPhoto();
                        ((ITwentyThreeParsable)NextPhoto).Load(reader);
                        if (NextPhoto.PhotoId == "0") NextPhoto = null;
                        break;

                }
            }
        }
    }

    /// <summary>
    /// The next (or previous) photo in the current context.
    /// </summary>
    public sealed class ContextPhoto : ITwentyThreeParsable
    {
        /// <summary>
        /// The id of the next photo. Will be "0" if this photo is the last.
        /// </summary>
        public string PhotoId { get; set; }

        /// <summary>
        /// The secret for the photo.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// The server for this photo.
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// The web server farm for this photos images.
        /// </summary>
        public string Farm { get; set; }

        /// <summary>
        /// The title of the next photo in context.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The URL, in the given context, for the next or previous photo.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The URL for the thumbnail of the photo.
        /// </summary>
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// The media type of this item.
        /// </summary>
        public MediaType MediaType { get; set; }

        void ITwentyThreeParsable.Load(XmlReader reader)
        {
            while (reader.MoveToNextAttribute())
            {
                switch (reader.LocalName)
                {
                    case "id":
                        PhotoId = reader.Value;
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
                    case "url":
                        Url = "https://www.23hq.com" + reader.Value;
                        break;
                    case "thumb":
                        ThumbnailUrl = reader.Value;
                        break;
                    case "media":
                        MediaType = reader.Value == "photo" ? MediaType.Photos : MediaType.Videos;
                        break;

                }
            }

            reader.Read();
        }
    }

    /// <summary>
    /// All contexts that a photo is in.
    /// </summary>
    public sealed class AllContexts : ITwentyThreeParsable
    {
        /// <summary>
        /// An array of <see cref="ContextSet"/> objects for the current photo.
        /// </summary>
        public Collection<ContextSet> Sets { get; set; }

        /// <summary>
        /// An array of <see cref="ContextGroup"/> objects for the current photo.
        /// </summary>
        public Collection<ContextGroup> Groups { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AllContexts()
        {
            Sets = new Collection<ContextSet>();
            Groups = new Collection<ContextGroup>();
        }

        void ITwentyThreeParsable.Load(XmlReader reader)
        {
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                switch (reader.LocalName)
                {
                    case "set":
                        var set = new ContextSet();
                        set.PhotosetId = reader.GetAttribute("id");
                        set.Title = reader.GetAttribute("title");
                        Sets.Add(set);
                        reader.Read();
                        break;
                    case "pool":
                        var group = new ContextGroup();
                        group.GroupId = reader.GetAttribute("id");
                        group.Title = reader.GetAttribute("title");
                        Groups.Add(group);
                        reader.Read();
                        break;
                }
            }
        }
    }

    /// <summary>
    /// A set context for a photo.
    /// </summary>
    public class ContextSet
    {
        /// <summary>
        /// The Photoset ID of the set the selected photo is in.
        /// </summary>
        public string PhotosetId { get; set; }
        /// <summary>
        /// The title of the set the selected photo is in.
        /// </summary>
        public string Title { get; set; }
    }

    /// <summary>
    /// A group context got a photo.
    /// </summary>
    public class ContextGroup
    {
        /// <summary>
        /// The Group ID for the group that the selected photo is in.
        /// </summary>
        public string GroupId { get; set; }
        /// <summary>
        /// The title of the group that then selected photo is in.
        /// </summary>
        public string Title { get; set; }
    }
}
