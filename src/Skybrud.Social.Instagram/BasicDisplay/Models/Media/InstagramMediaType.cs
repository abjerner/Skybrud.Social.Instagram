using Skybrud.Social.Instagram.BasicDisplay.Fields;

namespace Skybrud.Social.Instagram.BasicDisplay.Models.Media {

    /// <summary>
    /// Enum class representing the type of a media.
    /// </summary>
    public enum InstagramMediaType {

        /// <summary>
        /// Indicates that the type is unspecified - eg. if the <see cref="InstagramMediaFields.MediaType"/> isn't requested or returned by the API.
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
        /// Indicates that the media as a carousel album.
        /// </summary>
        CarouselAlbum

    }

}