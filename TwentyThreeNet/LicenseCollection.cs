using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyThreeNet
{
    /// <summary>
    /// A class which encapsulates a single property, an array of
    /// <see cref="License"/> objects in its <see cref="LicenseCollection"/> property.
    /// </summary>
    public sealed class LicenseCollection : System.Collections.ObjectModel.Collection<License>, ITwentyThreeParsable
    {
        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            reader.Read();

            while (reader.LocalName == "license")
            {
                var license = new License();
                ((ITwentyThreeParsable)license).Load(reader);
                Add(license);
            }

            reader.Skip();
        }
    }

}
