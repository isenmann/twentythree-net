﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyThreeNet
{
    /// <summary>
    /// A collection of photos returned by the <see cref="TwentyThree.PandaGetPhotos(string)"/> methods.
    /// </summary>
    public sealed class PandaPhotoCollection : System.Collections.ObjectModel.Collection<Photo>, ITwentyThreeParsable
    {
        /// <summary>
        /// The number of seconds the application developer should wait before calling this panda again.
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// When the list of photos from this panda was last updated.
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// The total number of photos returned.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// The pands that returned this set of photos.
        /// </summary>
        public string PandaName { get; set; }

        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            if (reader.LocalName != "photos")
                UtilityMethods.CheckParsingException(reader);

            while (reader.MoveToNextAttribute())
            {
                switch (reader.LocalName)
                {
                    case "total":
                        Total = int.Parse(reader.Value, System.Globalization.CultureInfo.InvariantCulture);
                        break;
                    case "interval":
                        Interval = int.Parse(reader.Value, System.Globalization.CultureInfo.InvariantCulture);
                        break;
                    case "panda":
                        PandaName = reader.Value;
                        break;
                    case "lastupdate":
                        LastUpdated = UtilityMethods.UnixTimestampToDate(reader.Value);
                        break;
                    default:
                        UtilityMethods.CheckParsingException(reader);
                        break;

                }
            }

            reader.Read();

            while (reader.LocalName == "photo")
            {
                var p = new Photo();
                ((ITwentyThreeParsable)p).Load(reader);
                if (!string.IsNullOrEmpty(p.PhotoId)) Add(p);
            }

            // Skip to next element (if any)
            reader.Skip();
            
        }
    }
}
