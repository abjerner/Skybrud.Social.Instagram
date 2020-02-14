using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.Models.Locations;

namespace Skybrud.Social.Instagram.Responses.Locations {

    /// <summary>
    /// Class representing the response of a call to get information about a given location.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations</cref>
    /// </see>
    public class InstagramGetLocationResponse : InstagramResponse<InstagramGetLocationEnvelope> {

        #region Constructors

        private InstagramGetLocationResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramGetLocationEnvelope.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramGetLocationResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramGetLocationResponse"/>.</returns>
        public static InstagramGetLocationResponse ParseResponse(IHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException(nameof(response));

            // Initialize the response object
            return new InstagramGetLocationResponse(response);

        }

        #endregion

    }
}