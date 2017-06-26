using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Models.Common;
using Skybrud.Social.Instagram.Models.Media;
using Skybrud.Social.Instagram.Models.Pagination;

namespace Skybrud.Social.Instagram.Responses.Locations {
    
    /// <summary>
    /// Class representing the response of a call to get recent media of a location.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_media_recent</cref>
    /// </see>
    public class InstagramGetLocationRecentMediaResponse : InstagramResponse<InstagramLocationRecentMediaResponseBody> {

        #region Constructors

        private InstagramGetLocationRecentMediaResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramLocationRecentMediaResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramGetLocationRecentMediaResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramGetLocationRecentMediaResponse"/>.</returns>
        public static InstagramGetLocationRecentMediaResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new InstagramGetLocationRecentMediaResponse(response);

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a call to get recent media of a location.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_media_recent</cref>
    /// </see>
    public class InstagramLocationRecentMediaResponseBody : InstagramEnvelope<InstagramMedia[]> {

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
        protected InstagramLocationRecentMediaResponseBody(JObject obj) : base(obj) {
            Pagination = obj.GetObject("pagination", InstagramIdBasedPagination.Parse);
            Data = obj.GetArray("data", InstagramMedia.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramLocationRecentMediaResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramLocationRecentMediaResponseBody"/>.</returns>
        public static InstagramLocationRecentMediaResponseBody Parse(JObject obj) {
            return obj == null ? null : new InstagramLocationRecentMediaResponseBody(obj);
        }

        #endregion

    }

}