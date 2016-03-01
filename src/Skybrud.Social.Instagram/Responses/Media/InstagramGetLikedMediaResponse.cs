using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects.Media;
using Skybrud.Social.Instagram.Objects.Pagination;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Instagram.Responses.Media {

    /// <summary>
    /// Class representing the response of a call to the liked media of the authenticated user.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_feed_liked</cref>
    /// </see>
    public class InstagramGetLikedMediaResponse : InstagramResponse<InstagramLikedMediaResponseBody> {

        #region Constructors

        private InstagramGetLikedMediaResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramLikedMediaResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramGetLikedMediaResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramGetLikedMediaResponse"/>.</returns>
        public static InstagramGetLikedMediaResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new InstagramGetLikedMediaResponse(response);

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a call to the liked media of the authenticated user.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_feed_liked</cref>
    /// </see>
    public class InstagramLikedMediaResponseBody : InstagramResponseBody<InstagramMedia[]> {

        #region Properties

        /// <summary>
        /// Gets pagination information of the response.
        /// </summary>
        public InstagramLikedMediaPagination Pagination { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramLikedMediaResponseBody(JObject obj) : base(obj) {
            Pagination = obj.GetObject("pagination", InstagramLikedMediaPagination.Parse);
            Data = obj.GetArray("data", InstagramMedia.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramLikedMediaResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramLikedMediaResponseBody"/>.</returns>
        public static InstagramLikedMediaResponseBody Parse(JObject obj) {
            return obj == null ? null : new InstagramLikedMediaResponseBody(obj);
        }

        #endregion

    }

}