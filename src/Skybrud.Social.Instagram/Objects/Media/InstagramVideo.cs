using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Objects.Media {

    /// <summary>
    /// Class representing an Instagram video.
    /// </summary>
    public class InstagramVideo : InstagramMedia {
        
        #region Properties

        /// <summary>
        /// Gets a summary of the video formats available for this Instagram video.
        /// </summary>
        public InstagramVideoSummary Videos { get; internal set; }

        #endregion

        #region Constructors

        internal InstagramVideo(JObject obj) : base(obj) {
            Videos = obj.GetObject("videos", InstagramVideoSummary.Parse);
        }

        #endregion

        #region Static methods
        
        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramVideo"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="InstagramVideo"/>.</returns>
        public new static InstagramVideo Parse(JObject obj) {
            return InstagramMedia.Parse(obj) as InstagramVideo;
        }

        #endregion

    }

}