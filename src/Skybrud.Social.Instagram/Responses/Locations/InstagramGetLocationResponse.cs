using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Models.Common;
using Skybrud.Social.Instagram.Models.Locations;

namespace Skybrud.Social.Instagram.Responses.Locations {

    /// <summary>
    /// Class representing the response of a call to get information about a given location.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations</cref>
    /// </see>
    public class InstagramGetLocationResponse : InstagramResponse<InstagramLocationResponseBody> {

        #region Constructors

        private InstagramGetLocationResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramLocationResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramGetLocationResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramGetLocationResponse"/>.</returns>
        public static InstagramGetLocationResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new InstagramGetLocationResponse(response);

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a call to get information about a given location.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations</cref>
    /// </see>
    public class InstagramLocationResponseBody : InstagramEnvelope<InstagramLocation> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramLocationResponseBody(JObject obj) : base(obj) {
            Data = obj.GetObject("data", InstagramLocation.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramLocationResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramLocationResponseBody"/>.</returns>
        public static InstagramLocationResponseBody Parse(JObject obj) {
            return obj == null ? null : new InstagramLocationResponseBody(obj);
        }

        #endregion

    }

}