using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Responses {

    /// <summary>
    /// Class representing the response of a call for getting a list of users.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_search</cref>
    ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_follows</cref>
    ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_followed_by</cref>
    /// </see>
    public class InstagramUsersResponse : InstagramResponse<InstagramUsersResponseBody> {

        #region Constructors

        private InstagramUsersResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramUsersResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramUsersResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramUsersResponse"/>.</returns>
        public static InstagramUsersResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new InstagramUsersResponse(response);

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a call for getting a list of users.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_search</cref>
    ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_follows</cref>
    ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_followed_by</cref>
    /// </see>
    public class InstagramUsersResponseBody : InstagramResponseBody<InstagramUserSummary[]> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramUsersResponseBody(JObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramUsersResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramUsersResponseBody"/>.</returns>
        public static InstagramUsersResponseBody Parse(JObject obj) {
            return obj == null ? null : new InstagramUsersResponseBody(obj);
        }

        #endregion

    }

}