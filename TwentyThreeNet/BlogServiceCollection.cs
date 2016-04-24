using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TwentyThreeNet
{
    /// <summary>
    /// A list of the blog services that Flickr aupports. 
    /// </summary>
    public sealed class BlogServiceCollection : System.Collections.ObjectModel.Collection<BlogService>, ITwentyThreeParsable
    {
        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            if (reader.LocalName != "services")
                UtilityMethods.CheckParsingException(reader);

            reader.Read();

            while (reader.LocalName == "service")
            {
                var service = new BlogService();
                ((ITwentyThreeParsable)service).Load(reader);
                Add(service);
            }

            reader.Skip();

        }
    }
}
