using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.Models;

namespace Skybrud.Social.Instagram.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the Instagram API.
    /// </summary>
    public class InstagramOAuthException : InstagramHttpException {

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/> and <paramref name="meta"/> data.
        /// </summary>
        /// <param name="response">The response the exception should be based on.</param>
        /// <param name="meta">The meta data with information about the exception.</param>
        public InstagramOAuthException(IHttpResponse response, InstagramMetaData meta) : base(response, meta) { }

    }

}