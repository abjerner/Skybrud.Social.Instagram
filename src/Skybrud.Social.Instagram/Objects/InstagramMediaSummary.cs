using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Instagram.Objects {
    
    /// <summary>
    /// Class representing a summary of a image or video format available for an Instagram media.
    /// </summary>
    public class InstagramMediaSummary : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the URL of the format.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Gets the width of the format.
        /// </summary>
        public int Width { get; private set; }
        
        /// <summary>
        /// Gets the height of the format.
        /// </summary>
        public int Height { get; private set; }

        #endregion

        #region Constructors

        internal InstagramMediaSummary(JObject obj) : base(obj) {
            Url = obj.GetString("url");
            Width = obj.GetInt32("width");
            Height = obj.GetInt32("height");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramMediaSummary"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramMediaSummary"/>.</returns>
        public static InstagramMediaSummary Parse(JObject obj) {
            return obj == null ? null : new InstagramMediaSummary(obj);
        }

        #endregion

    }

}