using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.Models.Common;
using Skybrud.Social.Instagram.Models.Media;
using Skybrud.Social.Instagram.Models.Pagination;

namespace Skybrud.Social.Instagram.Models.Locations {
    
    /// <summary>
    /// Class representing the response body of a call to get recent media of a location.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_media_recent</cref>
    /// </see>
    public class InstagramGetLocationRecentMediaEnvelope : InstagramEnvelope<InstagramMedia[]> {

        #region Properties

        /// <summary>
        /// Gets pagination information of the response.
        /// </summary>
        public InstagramIdBasedPagination Pagination { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramGetLocationRecentMediaEnvelope(JObject obj) : base(obj) {
            Pagination = obj.GetObject("pagination", InstagramIdBasedPagination.Parse);
            Data = obj.GetArray("data", InstagramMedia.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramGetLocationRecentMediaEnvelope"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="InstagramGetLocationRecentMediaEnvelope"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramGetLocationRecentMediaEnvelope"/>.</returns>
        public static InstagramGetLocationRecentMediaEnvelope Parse(JObject obj) {
            return obj == null ? null : new InstagramGetLocationRecentMediaEnvelope(obj);
        }

        #endregion

    }

}