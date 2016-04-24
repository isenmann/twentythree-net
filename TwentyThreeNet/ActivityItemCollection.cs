using System.Collections.ObjectModel;

namespace TwentyThreeNet
{
    /// <summary>
    /// A list of <see cref="ActivityItem"/> items.
    /// </summary>
    public sealed class ActivityItemCollection : Collection<ActivityItem>, ITwentyThreeParsable
    {
        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            if (reader.LocalName != "items")
                UtilityMethods.CheckParsingException(reader);

            reader.Read();

            while (reader.LocalName == "item")
            {
                var item = new ActivityItem();
                ((ITwentyThreeParsable)item).Load(reader);
                Add(item);
            }

            reader.Skip();
        }
    }
}
