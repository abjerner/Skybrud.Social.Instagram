using System;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Responses {

    /// <summary>
    /// Class representing the response of a call to exchange an authorization code for an access token.
    /// </summary>
    public class InstagramAccessTokenResponse : InstagramResponse<InstagramAccessTokenSummary> {

        #region Constructors

        private InstagramAccessTokenResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramAccessTokenSummary.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramAccessTokenResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramAccessTokenResponse"/> representing the response.</returns>
        public static InstagramAccessTokenResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new InstagramAccessTokenResponse(response);

        }

        #endregion

    }

}