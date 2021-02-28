using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.BasicDisplay.Models.Authentication;

namespace Skybrud.Social.Instagram.BasicDisplay.Responses.Authentication {

    /// <summary>
    /// Class representing the response of a request to exchange an authorization code for a short-lived access token.
    /// </summary>
    public class InstagramShortLivedTokenResponse : InstagramResponse<InstagramShortLivedToken> {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public new InstagramShortLivedToken Body { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The underlying raw response the instance should be based on.</param>
        public InstagramShortLivedTokenResponse(IHttpResponse response) : base(response) {
            base.Body = Body = ParseJsonObject(response.Body, InstagramShortLivedToken.Parse);
        }

        #endregion

    }

}