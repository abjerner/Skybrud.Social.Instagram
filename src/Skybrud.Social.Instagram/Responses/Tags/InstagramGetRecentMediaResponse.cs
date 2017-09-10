using System;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Models.Tags;

namespace Skybrud.Social.Instagram.Responses.Tags {

    /// <summary>
    /// Class representing the response of a call for getting a list of recent media.
    /// </summary>
    public class InstagramGetRecentMediaResponse : InstagramResponse<InstagramRecentMediaEnvelope> {

        #region Constructors

        private InstagramGetRecentMediaResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramRecentMediaEnvelope.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="InstagramGetRecentMediaResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="InstagramGetRecentMediaResponse"/>.</returns>
        public static InstagramGetRecentMediaResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new InstagramGetRecentMediaResponse(response);

        }

        #endregion

    }

}