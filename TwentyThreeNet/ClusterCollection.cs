﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace TwentyThreeNet
{
    /// <summary>
    /// A collection of <see cref="Cluster"/> instances.
    /// </summary>
    public sealed class ClusterCollection : Collection<Cluster>, ITwentyThreeParsable
    {
        /// <summary>
        /// The source tag for this cluster collection.
        /// </summary>
        public string SourceTag { get; set; }

        /// <summary>
        /// The total number of clusters for this tag.
        /// </summary>
        public int TotalClusters { get; set; }

        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            while (reader.MoveToNextAttribute())
            {
                switch (reader.LocalName)
                {
                    case "source":
                        SourceTag = reader.Value;
                        break;
                    case "total":
                        TotalClusters = reader.ReadContentAsInt();
                        break;
                }
            }

            reader.Read();

            while (reader.LocalName == "cluster")
            {
                var item = new Cluster();
                ((ITwentyThreeParsable)item).Load(reader);
                item.SourceTag = SourceTag;
                Add(item);
            }

            reader.Skip();

        }
    }
}
