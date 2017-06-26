using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Models.Media.Carousels {
    
    /// <summary>
    /// Class representing a media of a carousel.
    /// </summary>
    public class InstagramCarouselVideo : InstagramCarouselMedia {

        #region Properties

        /// <summary>
        /// Gets a summary of the video formats available for this Instagram video.
        /// </summary>
        public InstagramVideoSummary Videos { get; internal set; }

        #endregion

        #region Constructors

        private InstagramCarouselVideo(JObject obj) : base(obj) {
            Videos = obj.GetObject("videos", InstagramVideoSummary.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramCarouselVideo"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramCarouselVideo"/>.</returns>
        public static new InstagramCarouselVideo Parse(JObject obj) {
            return obj == null ? null : new InstagramCarouselVideo(obj);
        }

        #endregion

    }

}