using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Instagram.Models.Media {

    /// <summary>
    /// Class representing an Instagram image.
    /// </summary>
    public class InstagramImage : InstagramMedia {

        #region Constructors

        internal InstagramImage(JObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramImage"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="InstagramImage"/>.</returns>
        public new static InstagramImage Parse(JObject obj) {
            return InstagramMedia.Parse(obj) as InstagramImage;
        }

        #endregion

    }

}