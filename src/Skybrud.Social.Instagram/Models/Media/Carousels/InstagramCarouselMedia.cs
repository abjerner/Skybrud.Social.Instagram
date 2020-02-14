using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.Models.Users;

namespace Skybrud.Social.Instagram.Models.Media.Carousels {
    
    /// <summary>
    /// Class representing a media in a carousel.
    /// </summary>
    public class InstagramCarouselMedia : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the type of the carousel media - eg. <code>image</code> or <code>video</code>.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets an array of users tagged in the media.
        /// </summary>
        public InstagramTaggedUser[] UsersInPhoto { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        protected InstagramCarouselMedia(JObject obj) : base(obj) {
            Type = obj.GetString("type");
            UsersInPhoto = obj.GetArray("users_in_photo", InstagramTaggedUser.Parse);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets whether the media is an image - AKA an instance of <see cref="InstagramCarouselImage"/>.
        /// </summary>
        /// <returns><code>true</code> if this media is an instance of <see cref="InstagramCarouselImage"/>, otherwise <code>false</code>.</returns>
        public bool IsImage() {
            return this is InstagramCarouselImage;
        }

        /// <summary>
        /// Gets whether the media is an image - AKA an instance of <see cref="InstagramCarouselImage"/>.
        /// </summary>
        /// <param name="image">The instance of <see cref="InstagramImage"/> if an image, otherwise <code>null</code>.</param>
        /// <returns><code>true</code> if this media is an instance of <see cref="InstagramCarouselImage"/>, otherwise <code>false</code>.</returns>
        public bool IsImage(out InstagramCarouselImage image) {
            image = this as InstagramCarouselImage;
            return image != null;
        }

        /// <summary>
        /// Gets whether the media is a video - AKA an instance of <see cref="InstagramCarouselVideo"/>.
        /// </summary>
        /// <returns><code>true</code> if this media is an instance of <see cref="InstagramCarouselVideo"/>, otherwise <code>false</code>.</returns>
        public bool IsVideo() {
            return this is InstagramCarouselVideo;
        }

        /// <summary>
        /// Gets whether the media is a video - AKA an instance of <see cref="InstagramCarouselVideo"/>.
        /// </summary>
        /// <param name="video">The instance of <see cref="InstagramVideo"/> if a video, otherwise <code>null</code>.</param>
        /// <returns><code>true</code> if this media is an instance of <see cref="InstagramCarouselVideo"/>, otherwise <code>false</code>.</returns>
        public bool IsVideo(out InstagramCarouselVideo video) {
            video = this as InstagramCarouselVideo;
            return video != null;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramCarouselMedia"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramCarouselMedia"/>.</returns>
        public static InstagramCarouselMedia Parse(JObject obj) {
            if (obj == null) return null;
            switch (obj.GetString("type")) {
                case "image": return InstagramCarouselImage.Parse(obj);
                case "video": return InstagramCarouselVideo.Parse(obj);
                default: return new InstagramCarouselMedia(obj);
            }
        }

        #endregion

    }

}