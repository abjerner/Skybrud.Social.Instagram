using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.Models.Tags;

namespace Skybrud.Social.Instagram.Responses.Tags {

    /// <summary>
    /// Class representing the response of a call for getting a list of recent media.
    /// </summary>
    public class InstagramGetTagRecentMediaResponse : InstagramResponse<InstagramGetTagRecentMediaEnvelope> {

        #region Constructors

        private InstagramGetTagRecentMediaResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramGetTagRecentMediaEnvelope.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="InstagramGetTagRecentMediaResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="InstagramGetTagRecentMediaResponse"/>.</returns>
        public static InstagramGetTagRecentMediaResponse ParseResponse(IHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new InstagramGetTagRecentMediaResponse(response);

        }

        #endregion

    }

}