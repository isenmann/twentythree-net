using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyThreeNet
{
    /// <summary>
    /// The referrer details returned by <see cref="TwentyThree.StatsGetCollectionReferrers(DateTime, string, string, int, int)"/>, 
    /// <see cref="TwentyThree.StatsGetPhotoReferrers(DateTime, string, string, int, int)"/>,
    /// <see cref="TwentyThree.StatsGetPhotosetReferrers(DateTime, string, string, int, int)"/> 
    /// and <see cref="TwentyThree.StatsGetPhotostreamReferrers(DateTime, string, int, int)"/>.
    /// </summary>
    public sealed class StatReferrer : ITwentyThreeParsable
    {
        /// <summary>
        /// The url that the referrer referred from.
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// The number of times that URL was referred from.
        /// </summary>
        public int Views { get; set; }

        /// <summary>
        /// Then the referrer is a search engine this will contain the search term used.
        /// </summary>
        public string SearchTerm { get; set; }

        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            if (reader.LocalName != "referrer")
                UtilityMethods.CheckParsingException(reader);

            while (reader.MoveToNextAttribute())
            {
                switch (reader.LocalName)
                {
                    case "url":
                        Url = reader.Value;
                        break;
                    case "searchterm":
                        SearchTerm = reader.Value;
                        break;
                    case "views":
                        Views = int.Parse(reader.Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                        break;
                    default:
                        UtilityMethods.CheckParsingException(reader);
                        break;
                }
            }

            reader.Skip();
        }
    }
}
