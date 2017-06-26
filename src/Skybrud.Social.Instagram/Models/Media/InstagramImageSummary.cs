using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Models.Media {

    /// <summary>
    /// Class representing a summary of the image formats available for an Instagram media.
    /// </summary>
    public class InstagramImageSummary : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets a summary of the low resolution format.
        /// </summary>
        public InstagramMediaSummary LowResolution { get; private set; }
        
        /// <summary>
        /// Gets a summary of the thumbnail format.
        /// </summary>
        public InstagramMediaSummary Thumbnail { get; private set; }

        /// <summary>
        /// Gets a summary of the standard resolution format.
        /// </summary>
        public InstagramMediaSummary StandardResolution { get; private set; }

        #endregion

        #region Constructors

        private InstagramImageSummary(JObject obj) : base(obj) {
            LowResolution = obj.GetObject("low_resolution", InstagramMediaSummary.Parse);
            Thumbnail = obj.GetObject("thumbnail", InstagramMediaSummary.Parse);
            StandardResolution = obj.GetObject("standard_resolution", InstagramMediaSummary.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramImageSummary"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramImageSummary"/>.</returns>
        public static InstagramImageSummary Parse(JObject obj) {
            return obj == null ? null : new InstagramImageSummary(obj);
        }

        #endregion

    }

}