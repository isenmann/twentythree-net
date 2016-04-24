using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

namespace TwentyThreeNet
{
    /// <summary>
    /// Contains a list of <see cref="Blog"/> items for the user.
    /// </summary>
    public sealed class BlogCollection : Collection<Blog>, ITwentyThreeParsable
    {
        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            if (reader.LocalName != "blogs")
                UtilityMethods.CheckParsingException(reader);

            reader.Read();

            while (reader.LocalName == "blog")
            {
                var b = new Blog();
                ((ITwentyThreeParsable)b).Load(reader);
                Add(b);
            }

            // Skip to next element (if any)
            reader.Skip();
        }
    }
}