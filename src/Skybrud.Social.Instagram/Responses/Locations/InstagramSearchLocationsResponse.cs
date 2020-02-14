using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.Models.Locations;

namespace Skybrud.Social.Instagram.Responses.Locations {
    
    /// <summary>
    /// Class representing the response of a call for getting a list of locations.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_search</cref>
    /// </see>
    public class InstagramSearchLocationsResponse : InstagramResponse<InstagramSearchLocationsEnvelope> {

        #region Constructors

        private InstagramSearchLocationsResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramSearchLocationsEnvelope.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramSearchLocationsResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramSearchLocationsResponse"/>.</returns>
        public static InstagramSearchLocationsResponse ParseResponse(IHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new InstagramSearchLocationsResponse(response);

        }

        #endregion

    }

}