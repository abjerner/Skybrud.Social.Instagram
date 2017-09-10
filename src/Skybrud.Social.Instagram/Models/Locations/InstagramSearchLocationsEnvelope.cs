using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.Models.Common;

namespace Skybrud.Social.Instagram.Models.Locations {
    
    /// <summary>
    /// Class representing the response body of a call for getting a list of locations.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_search</cref>
    /// </see>
    public class InstagramSearchLocationsEnvelope : InstagramEnvelope<InstagramLocation[]> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramSearchLocationsEnvelope(JObject obj) : base(obj) {
            Data = obj.GetArray("data", InstagramLocation.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramSearchLocationsEnvelope"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="InstagramSearchLocationsEnvelope"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramSearchLocationsEnvelope"/>.</returns>
        public static InstagramSearchLocationsEnvelope Parse(JObject obj) {
            return obj == null ? null : new InstagramSearchLocationsEnvelope(obj);
        }

        #endregion

    }

}