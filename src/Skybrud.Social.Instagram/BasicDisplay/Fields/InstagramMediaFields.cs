namespace Skybrud.Social.Instagram.BasicDisplay.Fields {

    /// <summary>
    /// Static class with constants representing the fields of an Insatgram media.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/instagram-api/reference/user/media#get-media</cref>
    /// </see>
    public class InstagramMediaFields {

        /// <summary>
        /// The caption of the media.
        /// </summary>
        public static readonly InstagramField Caption = new InstagramField("caption");

        public static readonly InstagramField MediaType = new InstagramField("media_type");
        
        public static readonly InstagramField MediaUrl = new InstagramField("media_url");
        
        public static readonly InstagramField Permalink = new InstagramField("permalink");
        
        public static readonly InstagramField ThumbnailUrl = new InstagramField("thumbnail_url");
        
        public static readonly InstagramField Timestamp = new InstagramField("timestamp");
        
        public static readonly InstagramField Username = new InstagramField("username");
        
        public static readonly InstagramField Children = new InstagramField("children");

    }

}