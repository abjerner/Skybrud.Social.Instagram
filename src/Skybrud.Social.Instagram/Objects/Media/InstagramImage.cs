using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Instagram.Objects.Media {

    /// <summary>
    /// Class representing an Instagram image.
    /// </summary>
    public class InstagramImage : InstagramMedia {

        #region Constructors

        internal InstagramImage(JObject obj) : base(obj) { }

        #endregion

        #region Static methods
        
        /// <summary>
        /// Gets an image from the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        public new static InstagramImage Parse(JObject obj) {
            return InstagramMedia.Parse(obj) as InstagramImage;
        }

        #endregion

    }

}