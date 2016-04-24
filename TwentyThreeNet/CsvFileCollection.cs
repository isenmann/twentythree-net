using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyThreeNet
{
    /// <summary>
    /// The collection of CSV files containing archived stats available for download from Flickr.
    /// </summary>
    /// <remarks>
    /// Only supported until the 1st June 2010.
    /// </remarks>
    public sealed class CsvFileCollection : System.Collections.ObjectModel.Collection<CsvFile>, ITwentyThreeParsable
    {
        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            reader.ReadToDescendant("csv");

            while (reader.LocalName == "csv" && reader.NodeType != System.Xml.XmlNodeType.EndElement)
            {
                var file = new CsvFile();
                ((ITwentyThreeParsable)file).Load(reader);
                Add(file);
            }
        }
    }
}
