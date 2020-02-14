using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.Models.Media.Carousels;

namespace Skybrud.Social.Instagram.Models.Media {

    /// <summary>
    /// Class representing an Instagram video.
    /// </summary>
    public class InstagramCarousel : InstagramMedia {

        #region Properties

        /// <summary>
        /// Gets an array of the media of the carousel.
        /// </summary>
        public InstagramCarouselMedia[] CarouselMedia { get; }

        #endregion

        #region Constructors

        internal InstagramCarousel(JObject obj) : base(obj) {
            CarouselMedia = obj.GetArrayItems("carousel_media", InstagramCarouselMedia.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramCarousel"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="InstagramCarousel"/>.</returns>
        public new static InstagramCarousel Parse(JObject obj) {
            return InstagramMedia.Parse(obj) as InstagramCarousel;
        }

        #endregion

    }

}