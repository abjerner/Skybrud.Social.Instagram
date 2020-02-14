using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.Models.Tags;

namespace Skybrud.Social.Instagram.Responses.Tags {
    
    /// <summary>
    /// Class representing the response of a call for getting a list of tags matching a given query.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags_search</cref>
    /// </see>
    public class InstagramGetTagsResponse : InstagramResponse<InstagramSearchTagsEnvelope> {

        #region Constructors

        private InstagramGetTagsResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramSearchTagsEnvelope.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramGetTagsResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramGetTagsResponse"/>.</returns>
        public static InstagramGetTagsResponse ParseResponse(IHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException(nameof(response));

            // Initialize the response object
            return new InstagramGetTagsResponse(response);

        }

        #endregion

    }

}