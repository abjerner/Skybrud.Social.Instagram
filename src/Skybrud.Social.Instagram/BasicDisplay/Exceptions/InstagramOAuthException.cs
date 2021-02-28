using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.BasicDisplay.Models.Errors;

namespace Skybrud.Social.Instagram.BasicDisplay.Exceptions {

    /// <summary>
    /// Class representing an OAuth exception/error returned by the <strong>Instagram Basic Display API</strong>.
    /// </summary>
    public class InstagramOAuthException : InstagramHttpException {

        #region Constructors

        internal InstagramOAuthException(IHttpResponse response) : base(response) { }

        internal InstagramOAuthException(IHttpResponse response, InstagramError error) : base(response, error) { }

        #endregion

    }

}