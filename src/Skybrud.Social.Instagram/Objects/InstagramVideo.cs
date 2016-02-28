using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Instagram.Objects {

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
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramVideo"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramVideo"/>.</returns>
        public new static InstagramVideo Parse(JObject obj) {
            return InstagramMedia.Parse(obj) as InstagramVideo;
        }

        #endregion

    }

}