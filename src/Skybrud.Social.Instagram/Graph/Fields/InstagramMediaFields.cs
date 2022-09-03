namespace Skybrud.Social.Instagram.Graph.Fields {

    /// <summary>
    /// Static class with constants representing the fields of an Instagram media.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/instagram-api/reference/user/media#get-media</cref>
    /// </see>
    public class InstagramMediaFields {

        /// <summary>
        /// The caption of the media.
        /// </summary>
        public static readonly InstagramField Caption = new("caption");

        /// <summary>
        /// The total amount of comments the media has received.
        /// </summary>
        public static readonly InstagramField CommentsCount = new("comments_count");

        /// <summary>
        /// The Instagram ID of the media.
        /// </summary>
        public static readonly InstagramField Id = new("ig_id");

        /// <summary>
        /// Whether comments has been enabled for the media.
        /// </summary>
        public static readonly InstagramField IsCommentEnabled = new("is_comment_enabled");

        /// <summary>
        /// The total amount of likes the media has received.
        /// </summary>
        public static readonly InstagramField LikeCount = new("like_count");

        /// <summary>
        /// The type of the media.
        /// </summary>
        public static readonly InstagramField MediaType = new("media_type");

        /// <summary>
        /// The URL of the media.
        /// </summary>
        public static readonly InstagramField MediaUrl = new("media_url");

        /// <summary>
        /// The owner of the media.
        /// </summary>
        public static readonly InstagramField Owner = new("owner");

        /// <summary>
        /// The permalink (web URL) of the media.
        /// </summary>
        public static readonly InstagramField Permalink = new("permalink");

        /// <summary>
        /// The shortcode of the media.
        /// </summary>
        public static readonly InstagramField Shortcode = new("shortcode");

        /// <summary>
        /// The thumbnail URL of the media.
        /// </summary>
        public static readonly InstagramField ThumbnailUrl = new("caption");

        /// <summary>
        /// The timestamp of the media.
        /// </summary>
        public static readonly InstagramField Timestamp = new("timestamp");

        /// <summary>
        /// The username of the media.
        /// </summary>
        public static readonly InstagramField Username = new("username");

        /// <summary>
        /// The child media of the media (carousel albums only).
        /// </summary>
        public static readonly InstagramField Children = new("children");

        /// <summary>
        /// Represents the <c>comments</c> edge of the media.
        /// </summary>
        public static readonly InstagramField Comments = new("comments");

    }

}