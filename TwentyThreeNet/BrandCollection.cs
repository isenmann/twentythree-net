using System.Collections.ObjectModel;
using System.Xml;

namespace TwentyThreeNet
{
    /// <summary>
    /// A collection of camera brands
    /// </summary>
    public class BrandCollection : Collection<Brand>, ITwentyThreeParsable
    {
        void ITwentyThreeParsable.Load(XmlReader reader)
        {
            if (reader.LocalName != "brands")
                UtilityMethods.CheckParsingException(reader);

            reader.Read();

            while (reader.LocalName == "brand")
            {
                var b = new Brand();
                ((ITwentyThreeParsable)b).Load(reader);
                Add(b);
            }

            // Skip to next element (if any)
            reader.Skip();
        }
    }
}