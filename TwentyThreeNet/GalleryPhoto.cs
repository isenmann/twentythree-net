using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyThreeNet
{
    /// <summary>
    /// An instance of a photo returned by <see cref="TwentyThree.GalleriesGetPhotos(string, PhotoSearchExtras)"/>.
    /// </summary>
    public class GalleryPhoto : Photo, ITwentyThreeParsable
    {
        /// <summary>
        /// The comment added to this photo in the gallery, if any.
        /// </summary>
        public string Comment { get; set; }

        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            Load(reader, false);

            if (reader.LocalName == "comment")
                Comment = reader.ReadElementContentAsString();

            if (reader.LocalName == "description")
                Description = reader.ReadElementContentAsString();

            if (reader.NodeType == System.Xml.XmlNodeType.EndElement && reader.LocalName == "photo")
                reader.Skip();
        }
    }
}
