using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Objects.Media {

    /// <summary>
    /// Class representing a summary of the video formats available for an Instagram media.
    /// </summary>
    public class InstagramVideoSummary : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets information about the low bandwidth format.
        /// </summary>
        public InstagramMediaSummary LowBandwidth { get; private set; }

        /// <summary>
        /// Gets information about the low resolution format.
        /// </summary>
        public InstagramMediaSummary LowResolution { get; private set; }

        /// <summary>
        /// Gets information about the standard resolution format.
        /// </summary>
        public InstagramMediaSummary StandardResolution { get; private set; }

        #endregion

        #region Constructors

        private InstagramVideoSummary(JObject obj) : base(obj) {
            LowBandwidth = obj.GetObject("low_bandwidth", InstagramMediaSummary.Parse);
            LowResolution = obj.GetObject("low_resolution", InstagramMediaSummary.Parse);
            StandardResolution = obj.GetObject("standard_resolution", InstagramMediaSummary.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramVideoSummary"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramVideoSummary"/>.</returns>
        public static InstagramVideoSummary Parse(JObject obj) {
            return obj == null ? null : new InstagramVideoSummary(obj);
        }

        #endregion
        
    }

}