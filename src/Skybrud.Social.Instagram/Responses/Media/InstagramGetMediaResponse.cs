using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects.Common;
using Skybrud.Social.Instagram.Objects.Media;

namespace Skybrud.Social.Instagram.Responses.Media {
    
    /// <summary>
    /// Class representing the response of a call for getting information about a given media.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/media/#get_media</cref>
    /// </see>
    public class InstagramGetMediaResponse : InstagramResponse<InstagramMediaResponseBody> {

        #region Constructors

        private InstagramGetMediaResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramMediaResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramGetMediaResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramGetMediaResponse"/>.</returns>
        public static InstagramGetMediaResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new InstagramGetMediaResponse(response);

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a call for getting information of a given media.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/media/#get_media</cref>
    /// </see>
    public class InstagramMediaResponseBody : InstagramEnvelope<InstagramMedia> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramMediaResponseBody(JObject obj) : base(obj) {
            Data = obj.GetObject("data", InstagramMedia.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramMediaResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramMediaResponseBody"/>.</returns>
        public static InstagramMediaResponseBody Parse(JObject obj) {
            return obj == null ? null : new InstagramMediaResponseBody(obj);
        }

        #endregion

    }

}