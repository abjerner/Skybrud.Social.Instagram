using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.BasicDisplay.Models.Authentication;
using Skybrud.Social.Instagram.Responses;

namespace Skybrud.Social.Instagram.BasicDisplay.Responses.Authentication {

    /// <summary>
    /// Class representing the response of a request to exchange an authorization code for a short-lived access token.
    /// </summary>
    public class InstagramShortLivedTokenResponse : InstagramResponse<InstagramShortLivedToken> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The underlying raw response the instance should be based on.</param>
        public InstagramShortLivedTokenResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramShortLivedToken.Parse);

        }

        #endregion

    }

}