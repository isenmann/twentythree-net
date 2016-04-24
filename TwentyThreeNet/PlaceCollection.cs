using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyThreeNet
{
    /// <summary>
    /// A list of <see cref="Place"/> items.
    /// </summary>
    public sealed class PlaceCollection : System.Collections.ObjectModel.Collection<Place>, ITwentyThreeParsable
    {
        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            reader.Read();

            while (reader.LocalName == "place")
            {
                var place = new Place();
                ((ITwentyThreeParsable)place).Load(reader);
                Add(place);
            }

            reader.Skip();
        }
    }
}
