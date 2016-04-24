using System;
using System.Configuration;
using System.Xml;

#if !(MONOTOUCH || WindowsCE || SILVERLIGHT)
namespace TwentyThreeNet
{
    /// <summary>
    /// Summary description for FlickrConfigurationManager.
    /// </summary>
    internal class TwentyThreeConfigurationManager : IConfigurationSectionHandler
    {
        private static string configSection = "flickrNet";
        private static TwentyThreeConfigurationSettings settings;

        public static TwentyThreeConfigurationSettings Settings
        {
            get
            {
                if (settings == null)
                {
                    settings = (TwentyThreeConfigurationSettings)ConfigurationManager.GetSection(configSection);
                }

                return settings;
            }
        }

        public object Create(object parent, object configContext, XmlNode section)
        {
            configSection = section.Name;
            return new TwentyThreeConfigurationSettings(section);
        }
    }
}
#endif
