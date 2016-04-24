using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyThreeNet
{
    /// <summary>
    /// A hot tag. Returned by <see cref="TwentyThree.TagsGetHotList()"/>.
    /// </summary>
    public sealed class HotTag : ITwentyThreeParsable
    {
        /// <summary>
        /// The tag that is hot.
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// The score for the tag.
        /// </summary>
        public int Score { get; set; }

        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            while (reader.MoveToNextAttribute())
            {
                switch (reader.LocalName)
                {
                    case "score":
                        Score = reader.ReadContentAsInt();
                        break;
                }
            }

            reader.Read();

            if (reader.NodeType == System.Xml.XmlNodeType.Text)
                Tag = reader.ReadContentAsString();

            reader.Read();
        }
    }
}
