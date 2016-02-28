using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Objects.Users;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Instagram.Responses.Users {
    
    /// <summary>
    /// Class representing the response of a call for getting information about a given user.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users</cref>
    /// </see>
    public class InstagramUserResponse : InstagramResponse<InstagramUserResponseBody> {

        #region Constructors

        private InstagramUserResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramUserResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramUserResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramUserResponse"/>.</returns>
        public static InstagramUserResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new InstagramUserResponse(response);

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response of a call for getting information about a given user.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users</cref>
    /// </see>
    public class InstagramUserResponseBody : InstagramResponseBody<InstagramUser> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramUserResponseBody(JObject obj) : base(obj) {
            Data = obj.GetObject("data", InstagramUser.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramUserResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramUserResponseBody"/>.</returns>
        public static InstagramUserResponseBody Parse(JObject obj) {
            return obj == null ? null : new InstagramUserResponseBody(obj);
        }

        #endregion

    }

}