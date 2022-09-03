namespace Skybrud.Social.Instagram.Graph.Scopes {

    /// <summary>
    /// Static class with known scopes of the <strong>Instagram Graph API</strong>.
    /// </summary>
    public static class InstagramScopes {

        /// <summary>
        /// To read any and all data related to a user (e.g. following/followed-by lists, photos, etc.) (granted by default).
        /// </summary>
        public static readonly InstagramScope Basic = new("basic");

        /// <summary>
        /// Grants your app read access to public content of other Instagram users.
        /// </summary>
        public static readonly InstagramScope PublicContent = new("public_content");

        /// <summary>
        /// Grants your app read access to the list of followers and followed-by users.
        /// </summary>
        public static readonly InstagramScope FollowerList = new("follower_list");

        /// <summary>
        /// To create or delete comments on a user’s behalf.
        /// </summary>
        public static readonly InstagramScope Comments = new("comments");

        /// <summary>
        /// To follow and unfollow users on a user’s behalf.
        /// </summary>
        public static readonly InstagramScope Relationships = new("relationships");

        /// <summary>
        /// To like and unlike items on a user’s behalf.
        /// </summary>
        public static readonly InstagramScope Likes = new("likes");

    }

}