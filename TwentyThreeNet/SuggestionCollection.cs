using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace TwentyThreeNet
{
    /// <summary>
    /// The collection of location suggestions returned by <see cref="TwentyThree.PhotosSuggestionsGetList"/>.
    /// </summary>
    public sealed class SuggestionCollection : Collection<Suggestion>, ITwentyThreeParsable
    {
        /// <summary>
        /// The total number of suggestions available.
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// The number of suggestions per page.
        /// </summary>
        public int PerPage { get; set; }
        /// <summary>
        /// The current page of suggestions returned.
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// The total number of pages of suggestions available.
        /// </summary>
        public int Pages { get { return (int)Math.Ceiling(1.0 * Total / PerPage); } }

        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            if (reader == null) throw new ArgumentNullException("reader");
            if (reader.LocalName != "suggestions") { UtilityMethods.CheckParsingException(reader); return; }

            while (reader.MoveToNextAttribute())
            {
                switch (reader.LocalName)
                {
                    case "total":
                        Total = reader.ReadContentAsInt();
                        break;
                    case "page":
                        Page = reader.ReadContentAsInt();
                        break;
                    case "per_page":
                        PerPage = reader.ReadContentAsInt();
                        break;
                }
            }

            reader.Read();

            while (reader.LocalName == "suggestion")
            {
                var suggestion = new Suggestion();
                ((ITwentyThreeParsable)suggestion).Load(reader);
                Add(suggestion);
            }

            return;
        }
    }
}
