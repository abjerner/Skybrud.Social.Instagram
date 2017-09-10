using System;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Models.Users;

namespace Skybrud.Social.Instagram.Responses.Users {

    /// <summary>
    /// Class representing the response of a call for getting a list of recent media.
    /// </summary>
    public class InstagramGetUserRecentMediaResponse : InstagramResponse<InstagramGetUserRecentMediaEnvelope> {

        #region Constructors

        private InstagramGetUserRecentMediaResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramGetUserRecentMediaEnvelope.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramGetUserRecentMediaResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramGetUserRecentMediaResponse"/>.</returns>
        public static InstagramGetUserRecentMediaResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new InstagramGetUserRecentMediaResponse(response);

        }

        #endregion

    }

}