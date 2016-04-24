using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace TwentyThreeNet
{
    /// <summary>
    /// A collection of <see cref="HotTag"/> instances.
    /// </summary>
    public sealed class HotTagCollection : Collection<HotTag>, ITwentyThreeParsable
    {
        /// <summary>
        /// The period that was used for the query.
        /// </summary>
        public string Period { get; set; }

        /// <summary>
        /// The count that was used for the query.
        /// </summary>
        public int TagCount { get; set; }

        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            while (reader.MoveToNextAttribute())
            {
                switch (reader.LocalName)
                {
                    case "period":
                        Period = reader.Value;
                        break;
                    case "count":
                        TagCount = reader.ReadContentAsInt();
                        break;
                }
            }

            reader.Read();

            while (reader.LocalName == "tag")
            {
                var item = new HotTag();
                ((ITwentyThreeParsable)item).Load(reader);
                Add(item);
            }

            reader.Skip();
        }
    }
}
