using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace TwentyThreeNet
{
    /// <summary>
    /// A collection of <see cref="Ticket"/> instances.
    /// </summary>
    public sealed class TicketCollection : Collection<Ticket>, ITwentyThreeParsable
    {
        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            reader.Read();

            while (reader.LocalName == "ticket")
            {
                var ticket = new Ticket();
                ((ITwentyThreeParsable)ticket).Load(reader);
                Add(ticket);
            }

            reader.Skip();

        }
    }
}
