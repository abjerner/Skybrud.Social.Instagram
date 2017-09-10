using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Models.Common;
using Skybrud.Social.Instagram.Models.Media;
using Skybrud.Social.Instagram.Models.Pagination;

namespace Skybrud.Social.Instagram.Responses.Users {

    /// <summary>
    /// Class representing the response of a call to the liked media of the authenticated user.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_feed_liked</cref>
    /// </see>
    public class InstagramGetUserLikedMediaResponse : InstagramResponse<InstagramGetUserLikedMediaEnvelope> {

        #region Constructors

        private InstagramGetUserLikedMediaResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramGetUserLikedMediaEnvelope.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramGetUserLikedMediaResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramGetUserLikedMediaResponse"/>.</returns>
        public static InstagramGetUserLikedMediaResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new InstagramGetUserLikedMediaResponse(response);

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a call to the liked media of the authenticated user.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_feed_liked</cref>
    /// </see>
    public class InstagramGetUserLikedMediaEnvelope : InstagramEnvelope<InstagramMedia[]> {

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
        protected InstagramGetUserLikedMediaEnvelope(JObject obj) : base(obj) {
            Pagination = obj.GetObject("pagination", InstagramLikedMediaPagination.Parse);
            Data = obj.GetArray("data", InstagramMedia.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramGetUserLikedMediaEnvelope"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramGetUserLikedMediaEnvelope"/>.</returns>
        public static InstagramGetUserLikedMediaEnvelope Parse(JObject obj) {
            return obj == null ? null : new InstagramGetUserLikedMediaEnvelope(obj);
        }

        #endregion

    }

}