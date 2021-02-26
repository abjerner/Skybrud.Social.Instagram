using Skybrud.Social.Instagram.BasicDisplay.Models.Media;

namespace Skybrud.Social.Instagram.BasicDisplay.Fields {

    /// <summary>
    /// Static class with constants representing the fields of an Instagram media.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/media#fields</cref>
    /// </see>
    public class InstagramMediaFields {

        /// <summary>
        /// The caption of the media.
        /// </summary>
        public static readonly InstagramField Caption = new InstagramField("caption");

        /// <summary>
        /// The type of the media. Raw values can be <c>IMAGE</c>, <c>VIDEO</c>, or <c>CAROUSEL_ALBUM</c>.
        /// </summary>
        public static readonly InstagramField MediaType = new InstagramField("media_type");
        
        /// <summary>
        /// The URL of the media.
        /// </summary>
        public static readonly InstagramField MediaUrl = new InstagramField("media_url");

        /// <summary>
        /// The Media's permanent URL. Will be omitted if the Media contains copyrighted material, or has been flagged for a copyright violation.
        /// </summary>
        public static readonly InstagramField Permalink = new InstagramField("permalink");

        /// <summary>
        /// The Media's thumbnail image URL. Only available on <see cref="InstagramMediaType.Video"/> Media.
        /// </summary>
        public static readonly InstagramField ThumbnailUrl = new InstagramField("thumbnail_url");

        /// <summary>
        /// The Media's publish date.
        /// </summary>
        public static readonly InstagramField Timestamp = new InstagramField("timestamp");

        /// <summary>
        /// The Media owner's username.
        /// </summary>
        public static readonly InstagramField Username = new InstagramField("username");

        /// <summary>
        /// A list of Media on the Media album. Only available on <see cref="InstagramMediaType.CarouselAlbum"/> Media.
        /// </summary>
        public static readonly InstagramField Children = new InstagramField("children");

    }

}