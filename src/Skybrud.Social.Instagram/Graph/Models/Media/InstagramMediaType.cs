using Newtonsoft.Json;
using Skybrud.Essentials.Json.Converters.Enums;

namespace Skybrud.Social.Instagram.Graph.Models.Media {

    /// <summary>
    /// Indicates the type of an <see cref="InstagramMedia"/>.
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
        /// Indicates that the media is a carousel with child images and/or videos.
        /// </summary>
        CarouselAlbum

    }

}