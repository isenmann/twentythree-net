﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyThreeNet
{
    /// <summary>
    /// Information about a group the authenticated user is a member of.
    /// </summary>
    public sealed class MemberGroupInfo : ITwentyThreeParsable
    {
        /// <summary>
        /// Property which returns the group id for the group.
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>The group name.</summary>
        public string GroupName { get; set; }

        /// <summary>
        /// True if the user is the admin for the group, false if they are not.
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// The privacy of the pool (see <see cref="PoolPrivacy"/>).
        /// </summary>
        public PoolPrivacy Privacy { get; set; }

        /// <summary>
        /// The server number for the group icon.
        /// </summary>
        public string IconServer { get; set; }

        /// <summary>
        /// The web farm ID for the group icon.
        /// </summary>
        public string IconFarm { get; set; }

        /// <summary>
        /// The number of photos currently in this group.
        /// </summary>
        public long Photos { get; set; }

        /// <summary>
        /// True if the group is for user with an age over 18
        /// </summary>
        public bool IsEighteenPlus { get; set; }

        /// <summary>
        /// The URL for the group icon.
        /// </summary>
        public string GroupIconUrl
        {
            get
            {
                return UtilityMethods.BuddyIcon(GroupName);
            }
        }

        /// <summary>
        /// The URL for the group web page.
        /// </summary>
        public string GroupUrl
        {
            get { return string.Format(System.Globalization.CultureInfo.InvariantCulture, "https://www.23hq.com/groups/{0}/", GroupId); }
        }

        void ITwentyThreeParsable.Load(System.Xml.XmlReader reader)
        {
            while (reader.MoveToNextAttribute())
            {
                switch (reader.LocalName)
                {
                    case "nsid":
                    case "id":
                        GroupId = reader.Value;
                        break;
                    case "name":
                        GroupName = reader.Value;
                        break;
                    case "admin":
                        IsAdmin = reader.Value == "1";
                        break;
                    case "privacy":
                        Privacy = (PoolPrivacy)Enum.Parse(typeof(PoolPrivacy), reader.Value, true);
                        break;
                    case "iconsserver":
                        IconServer = reader.Value;
                        break;
                    case "iconfarm":
                        IconFarm = reader.Value;
                        break;
                    case "photos":
                    case "pool_count":
                        Photos = long.Parse(reader.Value, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo);
                        break;
                    case "member":
                        IsMember = reader.Value == "1";
                        break;
                    case "moderator":
                        IsModerator = reader.Value == "1";
                        break;
                    case "member_count":
                        MemberCount = reader.ReadContentAsInt();
                        break;
                    case "topic_count":
                        TopicCount = reader.ReadContentAsInt();
                        break;
                    case "eighteenplus":
                        IsEighteenPlus = reader.Value == "1";
                        break;
                    default:
                        UtilityMethods.CheckParsingException(reader);
                        break;
                }
            }

            reader.Read();
        }

        /// <summary>
        /// Is the current authenticated user a member of this group. Null if the call is not authenticated.
        /// </summary>
        public bool? IsMember { get; set; }

        /// <summary>
        /// Is the current authenticated user a moderator of this group. Null if the call is not authenticated.
        /// </summary>
        public bool? IsModerator { get; set; }

        /// <summary>
        /// Number of members of this group.
        /// </summary>
        public int MemberCount { get; set; }

        /// <summary>
        /// The number of discussion topics in this group.
        /// </summary>
        public int TopicCount { get; set; }
    }

}
