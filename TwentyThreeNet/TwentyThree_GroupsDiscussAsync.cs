﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyThreeNet
{
    public partial class TwentyThree
    {
        /// <summary>
        /// Add a new reply to a topic.
        /// </summary>
        /// <param name="topicId">The id of the topic to add the reply to.</param>
        /// <param name="message">The message content to add.</param>
        /// <param name="callback"></param>
        public void GroupsDiscussRepliesAddAsync(string topicId, string message, Action<TwentyThreeResult<NoResponse>> callback)
        {
            CheckRequiresAuthentication();

            if (string.IsNullOrEmpty(topicId)) throw new ArgumentNullException("topicId");
            if (string.IsNullOrEmpty(message)) throw new ArgumentNullException("message");

            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.groups.discuss.replies.add");
            parameters.Add("topic_id", topicId);
            parameters.Add("message", message);

            GetResponseAsync<NoResponse>(parameters, callback);
        }

        /// <summary>
        /// Delete a reply to a particular topic.
        /// </summary>
        /// <param name="topicId">The id of the topic to delete the reply from.</param>
        /// <param name="replyId">The id of the reply to delete.</param>
        /// <param name="callback"></param>
        public void GroupsDiscussRepliesDeleteAsync(string topicId, string replyId, Action<TwentyThreeResult<NoResponse>> callback)
        {
            CheckRequiresAuthentication();

            if (string.IsNullOrEmpty(topicId)) throw new ArgumentNullException("topicId");
            if (string.IsNullOrEmpty(replyId)) throw new ArgumentNullException("replyId");

            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.groups.discuss.replies.delete");
            parameters.Add("topic_id", topicId);
            parameters.Add("reply_id", replyId);

            GetResponseAsync<NoResponse>(parameters, callback);
        }

        /// <summary>
        /// Edit the contents of a reply.
        /// </summary>
        /// <param name="topicId">The id of the topic whose reply you want to edit.</param>
        /// <param name="replyId">The id of the reply to edit.</param>
        /// <param name="message">The new message content to replace the reply with.</param>
        /// <param name="callback"></param>
        public void GroupsDiscussRepliesEditAsync(string topicId, string replyId, string message, Action<TwentyThreeResult<NoResponse>> callback)
        {
            CheckRequiresAuthentication();

            if (string.IsNullOrEmpty(topicId)) throw new ArgumentNullException("topicId");
            if (string.IsNullOrEmpty(replyId)) throw new ArgumentNullException("replyId");
            if (string.IsNullOrEmpty(message)) throw new ArgumentNullException("message");

            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.groups.discuss.replies.edit");
            parameters.Add("topic_id", topicId);
            parameters.Add("reply_id", replyId);
            parameters.Add("message", message);

            GetResponseAsync<NoResponse>(parameters, callback);
        }

        /// <summary>
        /// Gets the details of a particular reply.
        /// </summary>
        /// <param name="topicId">The id of the topic for whose reply you want the details of.</param>
        /// <param name="replyId">The id of the reply you want the details of.</param>
        /// <param name="callback"></param>
        public void GroupsDiscussRepliesGetInfoAsync(string topicId, string replyId, Action<TwentyThreeResult<TopicReply>> callback)
        {
            if (string.IsNullOrEmpty(topicId)) throw new ArgumentNullException("topicId");
            if (string.IsNullOrEmpty(replyId)) throw new ArgumentNullException("replyId");

            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.groups.discuss.replies.getInfo");
            parameters.Add("topic_id", topicId);
            parameters.Add("reply_id", replyId);

            GetResponseAsync<TopicReply>(parameters, callback);
        }

        /// <summary>
        /// Gets a list of replies for a particular topic.
        /// </summary>
        /// <param name="topicId">The id of the topic to get the replies for.</param>
        /// <param name="page">The page of replies you wish to get.</param>
        /// <param name="perPage">The number of replies per page you wish to get.</param>
        /// <param name="callback"></param>
        public void GroupsDiscussRepliesGetListAsync(string topicId, int page, int perPage, Action<TwentyThreeResult<TopicReplyCollection>> callback)
        {
            if (string.IsNullOrEmpty(topicId)) throw new ArgumentNullException("topicId");

            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.groups.discuss.replies.getList");
            parameters.Add("topic_id", topicId);
            if (page > 0) parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
            if (perPage > 0) parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

            GetResponseAsync<TopicReplyCollection>(parameters, callback);
        }

        /// <summary>
        /// Add a new topic to a group.
        /// </summary>
        /// <param name="groupId">The id of the group to add a new topic too.</param>
        /// <param name="subject">The subject line of the new topic.</param>
        /// <param name="message">The message content of the new topic.</param>
        /// <param name="callback"></param>
        public void GroupsDiscussTopicsAddAsync(string groupId, string subject, string message, Action<TwentyThreeResult<NoResponse>> callback)
        {
            CheckRequiresAuthentication();

            if (string.IsNullOrEmpty(groupId)) throw new ArgumentNullException("groupId");
            if (string.IsNullOrEmpty(subject)) throw new ArgumentNullException("subject");
            if (string.IsNullOrEmpty(message)) throw new ArgumentNullException("message");

            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.groups.discuss.topics.add");
            parameters.Add("group_id", groupId);
            parameters.Add("subject", subject);
            parameters.Add("message", message);

            GetResponseAsync<NoResponse>(parameters, callback);
        }

        /// <summary>
        /// Gets a list of topics for a particular group.
        /// </summary>
        /// <param name="groupId">The id of the group.</param>
        /// <param name="page">The page of topics you wish to return.</param>
        /// <param name="perPage">The number of topics per page to return.</param>
        /// <param name="callback"></param>
        public void GroupsDiscussTopicsGetListAsync(string groupId, int page, int perPage, Action<TwentyThreeResult<TopicCollection>> callback)
        {
            if (string.IsNullOrEmpty(groupId)) throw new ArgumentNullException("groupId");

            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.groups.discuss.topics.getList");
            parameters.Add("group_id", groupId);
            if (page > 0) parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
            if (perPage > 0) parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

            GetResponseAsync<TopicCollection>(parameters, callback);
        }

        /// <summary>
        /// Gets information on a particular topic with a group.
        /// </summary>
        /// <param name="topicId">The id of the topic you with information on.</param>
        /// <param name="callback"></param>
        public void GroupsDiscussTopicsGetInfoAsync(string topicId, Action<TwentyThreeResult<Topic>> callback)
        {
            if (string.IsNullOrEmpty(topicId)) throw new ArgumentNullException("topicId");

            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.groups.discuss.topics.getInfo");
            parameters.Add("topic_id", topicId);

            GetResponseAsync<Topic>(parameters, callback);
        }

    }
}
