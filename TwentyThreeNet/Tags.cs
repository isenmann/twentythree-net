using System;
using System.Xml;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TwentyThreeNet
{
    /// <summary>
    /// List containing <see cref="Tag"/> items.
    /// </summary>
    public sealed class TagCollection : System.Collections.ObjectModel.Collection<Tag>, ITwentyThreeParsable
    {
        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            reader.ReadToDescendant("tag");

            while (reader.LocalName == "tag")
            {
                var member = new Tag();
                ((ITwentyThreeParsable)member).Load(reader);
                Add(member);
            }

            reader.Skip();
        }
    }

    /// <summary>
    /// A simple tag class, containing a tag name and optional count (for <see cref="TwentyThree.TagsGetListUserPopular()"/>)
    /// </summary>
    public sealed class Tag : ITwentyThreeParsable
    {
        /// <summary>
        /// The name of the tag.
        /// </summary>
        public string TagName { get; set; }

        /// <summary>
        /// The poularity of the tag. Will be 0 if not returned via <see cref="TwentyThree.TagsGetListUserPopular()"/>
        /// </summary>
        public int Count { get; set; }

        void ITwentyThreeParsable.Load(XmlReader reader)
        {
            while (reader.MoveToNextAttribute())
            {
                switch (reader.LocalName)
                {
                    case "count":
                        Count = reader.ReadContentAsInt();
                        break;
                    default:
                        UtilityMethods.CheckParsingException(reader);
                        break;
                }
            }

            reader.Read();

            TagName = reader.ReadContentAsString();

            reader.Read();

        }
    }

    /// <summary>
    /// List containing <see cref="RawTag"/> items.
    /// </summary>
    public sealed class RawTagCollection : System.Collections.ObjectModel.Collection<RawTag>, ITwentyThreeParsable
    {
        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            reader.ReadToDescendant("tag");

            while (reader.LocalName == "tag")
            {
                var member = new RawTag();
                ((ITwentyThreeParsable)member).Load(reader);
                Add(member);
            }

            reader.Skip();
        }
    }

    /// <summary>
    /// Raw tags, as returned by the <see cref="TwentyThree.TagsGetListUserRaw(string)"/> method.
    /// </summary>
    public sealed class RawTag : ITwentyThreeParsable
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public RawTag()
        {
            RawTags = new Collection<string>();
        }

        /// <summary>
        /// An array of strings containing the raw tags returned by the method.
        /// </summary>
        public Collection<string> RawTags { get; set; }

        /// <summary>
        /// The clean tag.
        /// </summary>
        public string CleanTag { get; set; }
        
        void ITwentyThreeParsable.Load(XmlReader reader)
        {
            while (reader.MoveToNextAttribute())
            {
                switch (reader.LocalName)
                {
                    case "clean":
                        CleanTag = reader.ReadContentAsString();
                        break;
                    default:
                        UtilityMethods.CheckParsingException(reader);
                        break;
                }
            }

            reader.Read();

            while (reader.LocalName == "raw")
            {
                RawTags.Add(reader.ReadElementContentAsString());
            }

            reader.Read();
        }
    }
}
