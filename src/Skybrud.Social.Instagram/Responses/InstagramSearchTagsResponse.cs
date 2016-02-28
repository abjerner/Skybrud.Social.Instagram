using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Instagram.Responses {
    
    /// <summary>
    /// Class representing the response of a call for getting a list of tags matching a given query.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags_search</cref>
    /// </see>
    public class InstagramSearchTagsResponse : InstagramResponse<InstagramSearchTagsResponseBody> {

        #region Constructors

        private InstagramSearchTagsResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramSearchTagsResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramSearchTagsResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramSearchTagsResponse"/>.</returns>
        public static InstagramSearchTagsResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new InstagramSearchTagsResponse(response);

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a call for getting a list of tags matching a given query.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags_search</cref>
    /// </see>
    public class InstagramSearchTagsResponseBody : InstagramResponseBody<InstagramTag[]> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramSearchTagsResponseBody(JObject obj) : base(obj) {
            Data = obj.GetArray("data", InstagramTag.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramSearchTagsResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramSearchTagsResponseBody"/>.</returns>
        public static InstagramSearchTagsResponseBody Parse(JObject obj) {
            return obj == null ? null : new InstagramSearchTagsResponseBody(obj);
        }

        #endregion

    }

}