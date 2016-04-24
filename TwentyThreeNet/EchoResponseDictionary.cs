using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyThreeNet
{
    /// <summary>
    /// The response returned by the <see cref="TwentyThree.TestEcho"/> method.
    /// </summary>
    [Serializable]
    public sealed class EchoResponseDictionary : Dictionary<string, string>, ITwentyThreeParsable
    {
        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            while (reader.NodeType != System.Xml.XmlNodeType.None && reader.NodeType != System.Xml.XmlNodeType.EndElement)
            {
                Add(reader.Name, reader.ReadElementContentAsString());
            }
        }
    }
}
