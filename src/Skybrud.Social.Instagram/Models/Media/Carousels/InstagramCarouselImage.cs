using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Models.Media.Carousels {
    
    /// <summary>
    /// Class representing an image in a carousel.
    /// </summary>
    public class InstagramCarouselImage : InstagramCarouselMedia {

        #region Properties

        /// <summary>
        /// Gets a summary of the image formats available for this Instagram image.
        /// </summary>
        public InstagramImageSummary Images { get; private set; }

        #endregion

        #region Constructors

        private InstagramCarouselImage(JObject obj) : base(obj) {
            Images = obj.GetObject("images", InstagramImageSummary.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramCarouselImage"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramCarouselImage"/>.</returns>
        public static new InstagramCarouselImage Parse(JObject obj) {
            return obj == null ? null : new InstagramCarouselImage(obj);
        }

        #endregion

    }

}