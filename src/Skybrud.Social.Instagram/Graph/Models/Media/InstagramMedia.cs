using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Instagram.Graph.Fields;
using Skybrud.Social.Instagram.Graph.Models.Comments;

// ReSharper disable InconsistentNaming

namespace Skybrud.Social.Instagram.Graph.Models.Media {

    /// <summary>
    /// Class representing an Instagram media.
    /// </summary>
    public class InstagramMedia : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the caption (text) of the image.
        /// </summary>
        public string? Caption { get; }

        /// <summary>
        /// Gets a list of child media (carousel albums only). Requires the <see cref="InstagramMediaFields.Children"/> field.
        /// </summary>
        public InstagramMediaList? Children { get; }

        /// <summary>
        /// Gets whether the media has any child media.
        /// </summary>
        [JsonIgnore]
        [MemberNotNullWhen(true, "Children")]
        public bool HasChildren => Children != null;

        /// <summary>
        /// Gets the total amount of comments (includes replies).
        /// </summary>
        public long? CommentsCount { get; }

        /// <summary>
        /// Gets the Facebook ID of the media.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the Instagram ID of the media.
        /// </summary>
        public string? InstagramId { get; }

        /// <summary>
        /// Gets whether comments are available.
        /// </summary>
        public bool? IsCommentsEnabled { get; }

        /// <summary>
        /// Gets the total amount of likes the media has received.
        /// </summary>
        public long? LikeCount { get; }

        /// <summary>
        /// Gets the type of the media.
        /// </summary>
        public InstagramMediaType? MediaType { get; }

        /// <summary>
        /// Gets the media URL.
        /// </summary>
        public string? MediaUrl { get; }

        /// <summary>
        /// Gets the permalink of the media.
        /// </summary>
        public string? Permalink { get; }

        /// <summary>
        /// Gets the shortcode of the media.
        /// </summary>
        public string? Shortcode { get; }

        /// <summary>
        /// Gets the thumbnail URL (only available for videos).
        /// </summary>
        public string? ThumbnailUrl { get; }

        /// <summary>
        /// Gets a timestam for when the media was uploaded to Instagram.
        /// </summary>
        public EssentialsTime? Timestamp { get; }

        /// <summary>
        /// Gets the username of the user.
        /// </summary>
        public string? Username { get; }

        /// <summary>
        /// Gets a list of comments of the media. Requires the <see cref="InstagramMediaFields.Comments"/> field.
        /// </summary>
        public InstagramCommentList? Comments { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the entry.</param>
        protected InstagramMedia(JObject obj) : base(obj) {
            Id = obj.GetString("id")!;
            Caption = obj.GetString("caption");
            Children = obj.GetObject("children", InstagramMediaList.Parse);
            CommentsCount = obj.GetInt64OrNull("comments_count");
            InstagramId = obj.GetString("ig_id");
            IsCommentsEnabled = obj.GetBooleanOrNull("is_comment_enabled");
            LikeCount = obj.GetInt64OrNull("like_count");
            MediaType = obj.GetString("media_type", ParseMediaType);
            MediaUrl = obj.GetString("media_url");
            // owner
            Permalink = obj.GetString("permalink");
            Shortcode = obj.GetString("shortcode");
            ThumbnailUrl = obj.GetString("thumbnail_url");
            Timestamp = obj.GetString("timestamp", EssentialsTime.Parse);
            Username = obj.GetString("username");
            Comments = obj.GetObject("comments", InstagramCommentList.Parse);
        }

        #endregion

        #region Static methods

        private static InstagramMediaType ParseMediaType(string value) {
            if (string.IsNullOrWhiteSpace(value)) return InstagramMediaType.Unspecified;
            if (EnumUtils.TryParseEnum(value, out InstagramMediaType type)) return type;
            throw new Exception("Unknown media type: " + value);
        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="InstagramMedia"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramMedia"/>. <paramref name="json"/> is <see langword="null"/>, <see langword="null"/> is returned instead.</returns>
        [return: NotNullIfNotNull("json")]
        public static InstagramMedia? Parse(JObject? json) {
            return json == null ? null : new InstagramMedia(json);
        }

        #endregion

    }

}