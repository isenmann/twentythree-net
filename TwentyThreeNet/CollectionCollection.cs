using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Collections.Generic;

namespace TwentyThreeNet
{
    /// <remarks/>
    public sealed class CollectionCollection : System.Collections.ObjectModel.Collection<Collection>, ITwentyThreeParsable
    {
        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            if (reader.LocalName != "collections")
                UtilityMethods.CheckParsingException(reader);

            reader.Read();

            while (reader.LocalName == "collection")
            {
                var c = new Collection();
                ((ITwentyThreeParsable)c).Load(reader);
                Add(c);
            }

            // Skip to next element (if any)
            reader.Skip();
        }
    }


}
