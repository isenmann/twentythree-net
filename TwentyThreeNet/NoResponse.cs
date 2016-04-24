using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyThreeNet
{
    /// <summary>
    /// Used by the FlickrNet library when Flickr does not return anything in the body of a response, e.g. for update methods.
    /// </summary>
    public sealed class NoResponse : ITwentyThreeParsable
    {
        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
        }
    }
}
