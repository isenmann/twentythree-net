using System;
using System.Xml;
using System.Collections.Generic;

namespace TwentyThreeNet
{
    /// <summary>
    /// A list of <see cref="PhotoComment"/> items.
    /// </summary>
    public sealed class PhotoCommentCollection : System.Collections.ObjectModel.Collection<PhotoComment>, ITwentyThreeParsable
    {
        /// <summary>
        /// The ID of photo for these comments.
        /// </summary>
        public string PhotoId { get; set; }

        void ITwentyThreeParsable.Load(XmlReader reader)
        {
            if (reader.LocalName != "comments")
                UtilityMethods.CheckParsingException(reader);

            while (reader.MoveToNextAttribute())
            {
                switch (reader.LocalName)
                {
                    case "photo_id":
                        PhotoId = reader.Value;
                        break;
                    default:
                        UtilityMethods.CheckParsingException(reader);
                        break;
                }
            }

            reader.Read();

            while (reader.LocalName == "comment")
            {
                var comment = new PhotoComment();
                ((ITwentyThreeParsable)comment).Load(reader);
                Add(comment);
            }
            reader.Skip();
        }
    }
}
