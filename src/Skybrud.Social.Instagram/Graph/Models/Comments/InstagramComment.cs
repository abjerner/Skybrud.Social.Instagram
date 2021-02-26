using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

// ReSharper disable InconsistentNaming

namespace Skybrud.Social.Instagram.Graph.Models.Comments {

    /// <summary>
    /// Class representing an Instagram comment.
    /// </summary>
    public class InstagramComment : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets whether the comment is hidden.
        /// </summary>
        public bool IsHidden { get; }

        /// <summary>
        /// Gets the ID of the comment.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the amount of likes the comment has received.
        /// </summary>
        public int LikeCount { get; }

        /// <summary>
        /// Gets the text of the comment.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Gets a timestamp for when the comment was posted.
        /// </summary>
        public EssentialsTime Timestamp { get; }

        /// <summary>
        /// Gets the username of the user behind the comment.
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// Gets a list of replies to the comment. Requires the <c>replies</c> field.
        /// </summary>
        public InstagramCommentList Replies { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the entry.</param>
        protected InstagramComment(JObject obj) : base(obj) {
            IsHidden = obj.GetBoolean("hidden");
            Id = obj.GetString("id");
            LikeCount = obj.GetInt32("like_count");
            Text = obj.GetString("text");
            Timestamp = obj.GetString("timestamp", EssentialsTime.Parse);
            Username = obj.GetString("username");
            Replies = obj.GetObject("replies", InstagramCommentList.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramComment"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramComment"/>.</returns>
        public static InstagramComment Parse(JObject obj) {
            return obj == null ? null : new InstagramComment(obj);
        }

        #endregion

    }

}