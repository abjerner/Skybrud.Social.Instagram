using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.Models.Common;

namespace Skybrud.Social.Instagram.Models.Media {
    
    /// <summary>
    /// Class representing the response body of a call for getting information of a given media.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/media/#get_media</cref>
    /// </see>
    public class InstagramGetMediaEnvelope : InstagramEnvelope<InstagramMedia> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramGetMediaEnvelope(JObject obj) : base(obj) {
            Data = obj.GetObject("data", InstagramMedia.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramGetMediaEnvelope"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramGetMediaEnvelope"/>.</returns>
        public static InstagramGetMediaEnvelope Parse(JObject obj) {
            return obj == null ? null : new InstagramGetMediaEnvelope(obj);
        }

        #endregion

    }

}