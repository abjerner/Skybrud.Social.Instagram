using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.BasicDisplay.Models.Authentication;

namespace Skybrud.Social.Instagram.BasicDisplay.Responses.Authentication {

    /// <summary>
    /// Class representing the response of a request to exchange an access token with a new long-lived access token.
    /// </summary>
    public class InstagramLongLivedTokenResponse : InstagramResponse<InstagramLongLivedToken> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The underlying raw response the instance should be based on.</param>
        public InstagramLongLivedTokenResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, InstagramLongLivedToken.Parse);
        }

        #endregion

    }

}