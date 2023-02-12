using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Instagram.BasicDisplay.Models.Media {

    /// <summary>
    /// Class representing an Instagram media.
    /// </summary>
    public class InstagramMedia : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the media.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the caption of the media.
        /// </summary>
        public string? Caption { get; }

        /// <summary>
        /// Gets the type of the media.
        /// </summary>
        public InstagramMediaType? MediaType { get; }

        /// <summary>
        /// Gets the caption of the media.
        /// </summary>
        public string? MediaUrl { get; }

        /// <summary>
        /// Gets the caption of the media.
        /// </summary>
        public string? Permalink { get; }

        /// <summary>
        /// Gets the caption of the media.
        /// </summary>
        public string? ThumbnailUrl { get; }

        /// <summary>
        /// Gets the caption of the media.
        /// </summary>
        public EssentialsTime? Timestamp { get; }

        /// <summary>
        /// Gets the username of the user.
        /// </summary>
        public string? Username { get; }

        /// <summary>
        /// Gets a list of media on an album. Only available on <see cref="InstagramMediaType.CarouselAlbum"/> media.
        /// </summary>
        public InstagramMediaList? Children { get; }

        #endregion

        #region Constructors

        private InstagramMedia(JObject json) : base(json) {
            Id = json.GetString("id")!;
            Caption = json.GetString("caption");
            MediaType = json.GetString("media_type", ParseEnumOrDefault<InstagramMediaType>);
            MediaUrl = json.GetString("media_url");
            Permalink = json.GetString("permalink");
            ThumbnailUrl = json.GetString("thumbnail_url");
            Timestamp = json.GetString("timestamp", EssentialsTime.Parse);
            Username = json.GetString("username");
            Children = json.GetObject("children", InstagramMediaList.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="InstagramMedia"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramMedia"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static InstagramMedia? Parse(JObject? json) {
            return json == null ? null : new InstagramMedia(json);
        }

        #endregion

    }

}