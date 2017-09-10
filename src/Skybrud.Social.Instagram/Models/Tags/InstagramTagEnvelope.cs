using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.Models.Common;

namespace Skybrud.Social.Instagram.Models.Tags {
    
    /// <summary>
    /// Class representing the response body of a call for getting information about a given tag.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags</cref>
    /// </see>
    public class InstagramTagEnvelope : InstagramEnvelope<InstagramTag> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramTagEnvelope(JObject obj) : base(obj) {
            Data = obj.GetObject("data", InstagramTag.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramTagEnvelope"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramTagEnvelope"/>.</returns>
        public static InstagramTagEnvelope Parse(JObject obj) {
            return obj == null ? null : new InstagramTagEnvelope(obj);
        }

        #endregion

    }

}