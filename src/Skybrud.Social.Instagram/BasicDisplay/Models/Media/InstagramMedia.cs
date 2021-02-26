using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
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
        public string Caption { get; }

        /// <summary>
        /// Gets the caption of the media.
        /// </summary>
        public string MediaType { get; }

        /// <summary>
        /// Gets the caption of the media.
        /// </summary>
        public string MediaUrl { get; }

        /// <summary>
        /// Gets the caption of the media.
        /// </summary>
        public string Permalink { get; }

        /// <summary>
        /// Gets the caption of the media.
        /// </summary>
        public string ThumbnailUrl { get; }

        /// <summary>
        /// Gets the caption of the media.
        /// </summary>
        public EssentialsTime Timestamp { get; }

        /// <summary>
        /// Gets the username of the user.
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// Gets a list of media on an album. Only available on <see cref="InstagramMediaType.CarouselAlbum"/> media.
        /// </summary>
        public InstagramMediaList Children { get; }

        #endregion

        #region Constructors

        private InstagramMedia(JObject obj) : base(obj) {
            Id = obj.GetString("id");
            Caption = obj.GetString("caption");
            MediaType = obj.GetString("media_type");
            MediaUrl = obj.GetString("media_url");
            Permalink = obj.GetString("permalink");
            ThumbnailUrl = obj.GetString("thumbnail_url");
            Timestamp = obj.GetString("timestamp", EssentialsTime.Parse);
            Username = obj.GetString("username");
            Children = obj.GetObject("children", InstagramMediaList.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="InstagramMedia"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramMedia"/>.</returns>
        public static InstagramMedia Parse(JObject obj) {
            return obj == null ? null : new InstagramMedia(obj);
        }

        #endregion

    }

}