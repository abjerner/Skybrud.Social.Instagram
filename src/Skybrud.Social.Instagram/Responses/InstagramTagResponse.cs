using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Instagram.Responses {
    
    /// <summary>
    /// Class representing the response of a call for getting information about a given tag.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags</cref>
    /// </see>
    public class InstagramTagResponse : InstagramResponse<InstagramTagResponseBody> {

        #region Constructors

        private InstagramTagResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramTagResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramTagResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramTagResponse"/>.</returns>
        public static InstagramTagResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new InstagramTagResponse(response);

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a call for getting information about a given tag.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags</cref>
    /// </see>
    public class InstagramTagResponseBody : InstagramResponseBody<InstagramTag> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramTagResponseBody(JObject obj) : base(obj) {
            Data = obj.GetObject("data", InstagramTag.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramTagResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramTagResponseBody"/>.</returns>
        public static InstagramTagResponseBody Parse(JObject obj) {
            return obj == null ? null : new InstagramTagResponseBody(obj);
        }

        #endregion

    }

}