using System;
using Skybrud.Essentials.Http;

namespace Skybrud.Social.Instagram.Graph.Exceptions {

    /// <summary>
    /// Exception class thrown when parsing a JSON response from the <strong>Instagram Graph API</strong> fails.
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
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response that triggered the exception.</param>
        public InstagramParseResponseException(IHttpResponse response) : this(response, null, null) {
            Response = response;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/> and <paramref name="message"/>.
        /// </summary>
        /// <param name="response">The response that triggered the exception.</param>
        /// <param name="message">The message of the exception.</param>
        public InstagramParseResponseException(IHttpResponse response, string? message) : this(response, message, null) {
            Response = response;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response that triggered the exception.</param>
        /// <param name="innerException">The inner exception.</param>
        public InstagramParseResponseException(IHttpResponse response, Exception? innerException) : this(response, null, innerException) {
            Response = response;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/> and <paramref name="message"/>.
        /// </summary>
        /// <param name="response">The response that triggered the exception.</param>
        /// <param name="message">The message of the exception.</param>
        /// <param name="innerException">The inner exception.</param>
        public InstagramParseResponseException(IHttpResponse response, string? message, Exception? innerException) : base(message ?? "Failed parsing response from the Instagram Graph API.", innerException) {
            Response = response;
        }

        #endregion

    }

}