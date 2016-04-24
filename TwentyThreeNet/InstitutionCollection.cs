using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace TwentyThreeNet
{
    /// <summary>
    /// A collection of <see cref="Institution"/> instances.
    /// </summary>
    public sealed class InstitutionCollection : Collection<Institution>, ITwentyThreeParsable
    {
        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            reader.Read();

            while (reader.LocalName == "institution")
            {
                var service = new Institution();
                ((ITwentyThreeParsable)service).Load(reader);
                Add(service);
            }

        }
    }
}
