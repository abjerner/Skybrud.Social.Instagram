using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Instagram.Graph.Models.Comments {

    /// <summary>
    /// Class representing an Instagram comment.
    /// </summary>
    public class InstagramComment : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets whether the comment is hidden.
        /// </summary>
        public bool? IsHidden { get; }

        /// <summary>
        /// Gets the ID of the comment.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the amount of likes the comment has received.
        /// </summary>
        public int? LikeCount { get; }

        /// <summary>
        /// Gets the text of the comment.
        /// </summary>
        public string? Text { get; }

        /// <summary>
        /// Gets a timestamp for when the comment was posted.
        /// </summary>
        public EssentialsTime? Timestamp { get; }

        /// <summary>
        /// Gets the username of the user behind the comment.
        /// </summary>
        public string? Username { get; }

        /// <summary>
        /// Gets a list of replies to the comment. Requires the <c>replies</c> field.
        /// </summary>
        public InstagramCommentList? Replies { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the entry.</param>
        protected InstagramComment(JObject json) : base(json) {
            IsHidden = json.GetBooleanOrNull("hidden");
            Id = json.GetString("id")!;
            LikeCount = json.GetInt32OrNull("like_count");
            Text = json.GetString("text");
            Timestamp = json.GetString("timestamp", EssentialsTime.Parse);
            Username = json.GetString("username");
            Replies = json.GetObject("replies", InstagramCommentList.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="InstagramComment"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramComment"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static InstagramComment? Parse(JObject? json) {
            return json == null ? null : new InstagramComment(json);
        }

        #endregion

    }

}