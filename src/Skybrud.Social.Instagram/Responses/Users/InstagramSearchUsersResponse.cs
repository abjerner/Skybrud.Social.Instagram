using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.Models.Users;

namespace Skybrud.Social.Instagram.Responses.Users {

    /// <summary>
    /// Class representing the response of a call for getting a list of users.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_search</cref>
    ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_follows</cref>
    ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_followed_by</cref>
    /// </see>
    public class InstagramSearchUsersResponse : InstagramResponse<InstagramSearchUsersEnvelope> {

        #region Constructors

        private InstagramSearchUsersResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramSearchUsersEnvelope.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="InstagramSearchUsersResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="InstagramSearchUsersResponse"/>.</returns>
        public static InstagramSearchUsersResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException("response");
            return new InstagramSearchUsersResponse(response);
        }

        #endregion

    }

}