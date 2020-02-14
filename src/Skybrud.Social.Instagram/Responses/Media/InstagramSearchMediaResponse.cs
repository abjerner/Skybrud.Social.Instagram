using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.Models.Media;

namespace Skybrud.Social.Instagram.Responses.Media {

    /// <summary>
    /// Class representing the response of a call for getting a list of recent media.
    /// </summary>
    public class InstagramSearchMediaResponse : InstagramResponse<InstagramSearchMediaEnvelope> {

        #region Constructors

        private InstagramSearchMediaResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramSearchMediaEnvelope.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramSearchMediaResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramSearchMediaResponse"/>.</returns>
        public static InstagramSearchMediaResponse ParseResponse(IHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new InstagramSearchMediaResponse(response);

        }

        #endregion

    }
}