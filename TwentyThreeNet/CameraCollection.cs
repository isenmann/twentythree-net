using System.Collections.ObjectModel;
using System.Xml;

namespace TwentyThreeNet
{
    /// <summary>
    /// A collection of camera models for a particular brand.
    /// </summary>
    public class CameraCollection : Collection<Camera>, ITwentyThreeParsable
    {
        void ITwentyThreeParsable.Load(XmlReader reader)
        {
            if (reader.LocalName != "cameras")
                UtilityMethods.CheckParsingException(reader);

            reader.Read();

            while (reader.LocalName == "camera")
            {
                var c = new Camera();
                ((ITwentyThreeParsable)c).Load(reader);
                Add(c);
            }

            // Skip to next element (if any)
            reader.Skip();

        }
    }
}