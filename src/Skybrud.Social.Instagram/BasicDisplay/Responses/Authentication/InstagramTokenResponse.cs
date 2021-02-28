using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.BasicDisplay.Models.Authentication;

namespace Skybrud.Social.Instagram.BasicDisplay.Responses.Authentication {

    /// <summary>
    /// Class representing the response with information about an access token.
    /// </summary>
    public class InstagramTokenResponse : InstagramResponse<InstagramToken> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The underlying raw response the instance should be based on.</param>
        protected InstagramTokenResponse(IHttpResponse response) : base(response) { }

        #endregion

    }

}