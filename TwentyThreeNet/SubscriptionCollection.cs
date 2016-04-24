using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace TwentyThreeNet
{
    /// <summary>
    /// A collection of <see cref="Subscription"/> instances for the calling user.
    /// </summary>
    public sealed class SubscriptionCollection : Collection<Subscription>, ITwentyThreeParsable
    {
        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            if (reader == null) throw new ArgumentNullException("reader");
            if (reader.LocalName != "subscriptions") { UtilityMethods.CheckParsingException(reader); return; }

            reader.Read();

            while (reader.LocalName == "subscription")
            {
                var item = new Subscription();
                ((ITwentyThreeParsable)item).Load(reader);
                Add(item);
            }

            reader.Skip();
        }
    }
}
