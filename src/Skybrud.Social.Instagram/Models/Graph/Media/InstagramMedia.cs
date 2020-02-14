using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Instagram.Models.Graph.Media {

    /// <summary>
    /// Class representing an Instagram media.
    /// </summary>
    public class InstagramMedia : InstagramObject {

        #region Properties
        
        /// <summary>
        /// Gets the caption (text) of the image.
        /// </summary>
        public string Caption { get; }

        /// <summary>
        /// Gets a list of of child media (carousel albums only).
        /// </summary>
        public InstagramMediaList Children { get; }

        /// <summary>
        /// Gets the total amount of comments (includes replies).
        /// </summary>
        public long CommentsCount { get; }

        /// <summary>
        /// Gets the Facebook ID of the media.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the Instagram ID of the media.
        /// </summary>
        public string InstagramId { get; }

        /// <summary>
        /// Gets whether comments are available.
        /// </summary>
        public bool IsCommentsEnabled { get; }

        /// <summary>
        /// Gets the total amount of likes the media has received.
        /// </summary>
        public long LikeCount { get; }

        /// <summary>
        /// Gets the type of the media.
        /// </summary>
        public InstagramMediaType MediaType { get; }
        
        /// <summary>
        /// Gets the media URL.
        /// </summary>
        public string MediaUrl { get; }

        /// <summary>
        /// Gets the permalink of the media.
        /// </summary>
        public string Permalink { get; }

        /// <summary>
        /// Gets the shortcode of the media.
        /// </summary>
        public string Shortcode { get; }

        /// <summary>
        /// Gets the thumbnail URL (only available for videos).
        /// </summary>
        public string ThumbnailUrl { get; }

        /// <summary>
        /// Gets a timestam for when the media was uploaded to Instagram.
        /// </summary>
        public EssentialsTime Timestamp { get; }

        /// <summary>
        /// Gets the username of the user.
        /// </summary>
        public string Username { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the entry.</param>
        protected InstagramMedia(JObject obj) : base(obj) {
            Id = obj.GetString("id");
            Caption = obj.GetString("caption");
            Children = obj.GetObject("children", InstagramMediaList.Parse);
            CommentsCount = obj.GetInt64("comments_count");
            InstagramId = obj.GetString("ig_id");
            IsCommentsEnabled = obj.GetBoolean("is_comment_enabled");
            LikeCount = obj.GetInt64("like_count");
            MediaType = obj.GetString("media_type", ParseMediaType);
            MediaUrl = obj.GetString("media_url");
            // owner
            Permalink = obj.GetString("permalink");
            Shortcode = obj.GetString("shortcode");
            ThumbnailUrl = obj.GetString("thumbnail_url");
            Timestamp = obj.GetString("timestamp", EssentialsTime.Parse);
            Username = obj.GetString("username");
        }

        #endregion

        #region Member methods

        private InstagramMediaType ParseMediaType(string value) {
            if (string.IsNullOrWhiteSpace(value)) return InstagramMediaType.Unspecified;
            if (EnumUtils.TryParseEnum(value, out InstagramMediaType type)) return type;
            throw new Exception("Unknown media type: " + value);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramMedia"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramMedia"/>.</returns>
        public static InstagramMedia Parse(JObject obj) {
            return obj == null ? null : new InstagramMedia(obj);
        }

        #endregion

    }

}