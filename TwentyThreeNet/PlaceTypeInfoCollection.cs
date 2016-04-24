using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyThreeNet
{
    /// <summary>
    /// Collection containing information about the types of 'places' available from the Flickr API.
    /// </summary>
    /// <remarks>
    /// Use the <see cref="PlaceInfo"/> enumeration were possible.
    /// </remarks>
    public sealed class PlaceTypeInfoCollection : System.Collections.ObjectModel.Collection<PlaceTypeInfo>, ITwentyThreeParsable
    {
        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            if (reader.LocalName != "place_types")
                UtilityMethods.CheckParsingException(reader);

            reader.Read();

            while (reader.LocalName == "place_type")
            {
                var item = new PlaceTypeInfo();
                ((ITwentyThreeParsable)item).Load(reader);
                Add(item);
            }

            reader.Skip();

        }
    }
}
