namespace Skybrud.Social.Instagram.BasicDisplay.Scopes {

    /// <summary>
    /// Static class with known scopes of the <strong>Instagram Basic Display API</strong>.
    /// </summary>
    public static class InstagramScopes {

        /// <summary>
        /// Allows your app to read the User node, which represents the Instagram user, and the node’s edges.
        /// </summary>
        public static readonly InstagramScope UserProfile = new InstagramScope("user_profile", "User Profile");

        /// <summary>
        /// Allows your app to read the Media node, which represents an image, video, or album, and the node’s edges.
        /// </summary>
        public static readonly InstagramScope UserMedia = new InstagramScope("user_media", "User Media");

    }

}