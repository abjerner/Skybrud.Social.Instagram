using Newtonsoft.Json;
using Skybrud.Essentials.Json.Converters.Enums;

namespace Skybrud.Social.Instagram.BasicDisplay.Models.Media {

    /// <summary>
    /// Enum class representing the type ofan <see cref="InstagramMedia"/>.
    /// </summary>
    [JsonConverter(typeof(EnumStringConverter))]
    public enum InstagramMediaType {

        /// <summary>
        /// Indiciates a media type that is currently not supported by this package.
        /// </summary>
        Unknown,

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