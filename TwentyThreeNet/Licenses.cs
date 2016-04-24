using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Collections.Generic;

namespace TwentyThreeNet
{

    /// <summary>
    /// Details of a particular license available from Flickr.
    /// </summary>
    public sealed class License : ITwentyThreeParsable
    {
        /// <summary>
        ///     The ID of the license. Used by <see cref="TwentyThree.PhotosGetInfo(string)"/> and 
        ///     <see cref="TwentyThree.PhotosGetInfo(string, string)"/>.
        /// </summary>
        public LicenseType LicenseId { get; set; }

        /// <summary>The name of the license.</summary>
        public string LicenseName { get; set; }

        /// <summary>The URL for the license text.</summary>
        public string LicenseUrl { get; set; }

        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            while (reader.MoveToNextAttribute())
            {
                switch (reader.LocalName)
                {
                    case "id":
                        LicenseId = (LicenseType)reader.ReadContentAsInt();
                        break;
                    case "name":
                        LicenseName = reader.Value;
                        break;
                    case "url":
                        if (!string.IsNullOrEmpty(reader.Value))
                        {
                            LicenseUrl = reader.Value;
                        }
                        break;
                    default:
                        UtilityMethods.CheckParsingException(reader);
                        break;
                }
            }

            reader.Read();
        }
    }
}
