using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyThreeNet
{
    /// <summary>
    /// A list of <see cref="PhotoComment"/> items.
    /// </summary>
    public sealed class PhotosetCommentCollection : System.Collections.ObjectModel.Collection<PhotoComment>, ITwentyThreeParsable
    {
        /// <summary>
        /// The ID of the photoset for this comment.
        /// </summary>
        public string PhotosetId { get; set; }

        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            if (reader.LocalName != "comments")
                UtilityMethods.CheckParsingException(reader);

            while (reader.MoveToNextAttribute())
            {
                switch (reader.LocalName)
                {
                    case "photoset_id":
                        PhotosetId = reader.Value;
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
