using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.Models.Locations;

namespace Skybrud.Social.Instagram.Responses.Locations {
    
    /// <summary>
    /// Class representing the response of a call to get recent media of a location.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_media_recent</cref>
    /// </see>
    public class InstagramGetLocationRecentMediaResponse : InstagramResponse<InstagramGetLocationRecentMediaEnvelope> {

        #region Constructors

        private InstagramGetLocationRecentMediaResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramGetLocationRecentMediaEnvelope.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramGetLocationRecentMediaResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramGetLocationRecentMediaResponse"/>.</returns>
        public static InstagramGetLocationRecentMediaResponse ParseResponse(IHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException(nameof(response));

            // Initialize the response object
            return new InstagramGetLocationRecentMediaResponse(response);

        }

        #endregion

    }
}