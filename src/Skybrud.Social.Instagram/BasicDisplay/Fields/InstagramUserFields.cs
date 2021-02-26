namespace Skybrud.Social.Instagram.BasicDisplay.Fields {
   
    /// <summary>
    /// Static class with constants representing the fields of an Instagram user.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/user#fields</cref>
    /// </see>
    public class InstagramUserFields {

        /// <summary>
        /// The User's ID.
        /// </summary>
        public static readonly InstagramField Id = new InstagramField("id");

        /// <summary>
        /// TTe User's account type. Can be <c>BUSINESS</c>, <c>MEDIA_CREATOR</c>, or <c>PERSONAL</c>.
        /// </summary>
        public static readonly InstagramField AccountType = new InstagramField("account_type");

        /// <summary>
        /// The User's username.
        /// </summary>
        public static readonly InstagramField Username = new InstagramField("username");

        /// <summary>
        /// The number of Media on the User. This field requires the <c>instagram_graph_user_media</c> permission.
        /// </summary>
        public static readonly InstagramField MediaCount = new InstagramField("media_count");

        /// <summary>
        /// A list of Media on the User.
        /// </summary>
        public static readonly InstagramField Media = new InstagramField("media");

    }

}