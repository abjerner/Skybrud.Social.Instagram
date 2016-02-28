using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Objects.Media;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Instagram.Responses.Media {
    
    /// <summary>
    /// Class representing the response of a call for getting the feed of the autenticated user.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_feed</cref>
    /// </see>
    public class InstagramUserFeedResponse : InstagramResponse<InstagramUserFeedResponseBody> {

        #region Constructors

        private InstagramUserFeedResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramUserFeedResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramUserFeedResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramUserFeedResponse"/>.</returns>
        public static InstagramUserFeedResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new InstagramUserFeedResponse(response);

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a call for getting the feed of the autenticated user.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_feed</cref>
    /// </see>
    public class InstagramUserFeedResponseBody : InstagramResponseBody<InstagramMedia[]> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramUserFeedResponseBody(JObject obj) : base(obj) {
            Data = obj.GetArray("data", InstagramMedia.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramUserFeedResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramUserFeedResponseBody"/>.</returns>
        public static InstagramUserFeedResponseBody Parse(JObject obj) {
            return obj == null ? null : new InstagramUserFeedResponseBody(obj);
        }

        #endregion

    }

}