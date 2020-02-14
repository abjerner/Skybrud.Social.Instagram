using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.Models.Users;

namespace Skybrud.Social.Instagram.Responses.Users {
    
    /// <summary>
    /// Class representing the response of a call for getting information about a given user.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users</cref>
    /// </see>
    public class InstagramGetUserResponse : InstagramResponse<InstagramGetUserEnvelope> {

        #region Constructors

        private InstagramGetUserResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramGetUserEnvelope.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="InstagramGetUserResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="InstagramGetUserResponse"/>.</returns>
        public static InstagramGetUserResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new InstagramGetUserResponse(response);
        }

        #endregion

    }

}