// ReSharper disable InconsistentNaming

namespace Skybrud.Social.Instagram.Graph.Models.Media {

    /// <summary>
    /// Indicates the type of an <see cref="InstagramMedia"/>.
    /// </summary>
    public enum InstagramMediaType {

        /// <summary>
        /// Indicates that the <c>media_type</c> property was not included in the response.
        /// </summary>
        Unspecified,

        /// <summary>
        /// Indicates that the media is an image.
        /// </summary>
        Image,

        /// <summary>
        /// Indicates that the media is a video.
        /// </summary>
        Video,

        /// <summary>
        /// Indicates that the media is a carousel with child images and/or videos.
        /// </summary>
        CarouselAlbum

    }

}