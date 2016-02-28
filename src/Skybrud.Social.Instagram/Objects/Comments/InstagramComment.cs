using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Instagram.Objects.Users;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Instagram.Objects.Comments {

    /// <summary>
    /// Class representing a comment of a media.
    /// </summary>
    public class InstagramComment : InstagramObject {

        #region Properties
        
        /// <summary>
        /// Gets the ID of the comment.
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// Gets the timestamp for when the comment was created.
        /// </summary>
        public DateTime Created { get; internal set; }

        /// <summary>
        /// Gets the text/message of the comment.
        /// </summary>
        public string Text { get; internal set; }

        /// <summary>
        /// Gets the user responsible for the comment.
        /// </summary>
        public InstagramUserSummary User { get; internal set; }

        #endregion

        #region Constructors

        private InstagramComment(JObject obj) : base(obj) {
            Id = obj.GetInt64("id");
            Created = obj.GetInt64("created_time", SocialUtils.GetDateTimeFromUnixTime);
            Text = obj.GetString("text");
            User = obj.GetObject("from", InstagramUserSummary.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="InstagramComment"/> from the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>Returns an instance of <see cref="InstagramComment"/>.</returns>
        public static InstagramComment Parse(JObject obj) {
            return obj == null ? null : new InstagramComment(obj);
        }

        #endregion

    }

}