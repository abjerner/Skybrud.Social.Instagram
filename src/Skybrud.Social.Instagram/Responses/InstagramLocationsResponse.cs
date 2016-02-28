using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Instagram.Responses {
    
    /// <summary>
    /// Class representing the response of a call for getting a list of locations.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_search</cref>
    /// </see>
    public class InstagramLocationsResponse : InstagramResponse<InstagramLocationsResponseBody> {

        #region Constructors

        private InstagramLocationsResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramLocationsResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramLocationsResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramLocationsResponse"/>.</returns>
        public static InstagramLocationsResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new InstagramLocationsResponse(response);

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a call for getting a list of locations.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_search</cref>
    /// </see>
    public class InstagramLocationsResponseBody : InstagramResponseBody<InstagramLocation[]> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramLocationsResponseBody(JObject obj) : base(obj) {
            Data = obj.GetArray("data", InstagramLocation.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramLocationsResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramLocationsResponseBody"/>.</returns>
        public static InstagramLocationsResponseBody Parse(JObject obj) {
            return obj == null ? null : new InstagramLocationsResponseBody(obj);
        }

        #endregion

    }

}