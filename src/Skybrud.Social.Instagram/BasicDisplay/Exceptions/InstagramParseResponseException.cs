using Skybrud.Essentials.Http;

namespace Skybrud.Social.Instagram.BasicDisplay.Exceptions {

    /// <summary>
    /// Exception class thrown when parsing a JSON response from the <strong>Instagram Basic Display API</strong> fails.
    /// </summary>
    public class InstagramParseResponseException : InstagramParseException {

        #region Properties

        /// <summary>
        /// Gets a reference to the response that triggered the exception.
        /// </summary>
        public IHttpResponse Response { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/> and <paramref name="message"/>.
        /// </summary>
        /// <param name="response">The response that triggered the exception.</param>
        /// <param name="message">The message of the exception.</param>
        public InstagramParseResponseException(IHttpResponse response, string message) : base(message) {
            Response = response;
        }

        #endregion

    }

}