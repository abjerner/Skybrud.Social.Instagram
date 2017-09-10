using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.Models.Common;

namespace Skybrud.Social.Instagram.Models.Locations {
    
    /// <summary>
    /// Class representing the response body of a call to get information about a given location.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations</cref>
    /// </see>
    public class InstagramGetLocationEnvelope : InstagramEnvelope<InstagramLocation> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramGetLocationEnvelope(JObject obj) : base(obj) {
            Data = obj.GetObject("data", InstagramLocation.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramGetLocationEnvelope"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="InstagramGetLocationEnvelope"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramGetLocationEnvelope"/>.</returns>
        public static InstagramGetLocationEnvelope Parse(JObject obj) {
            return obj == null ? null : new InstagramGetLocationEnvelope(obj);
        }

        #endregion

    }

}