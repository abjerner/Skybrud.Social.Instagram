using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;

namespace Skybrud.Social.Instagram.BasicDisplay.Exceptions {

    /// <summary>
    /// Exception class thrown when parsing a JSON response from the <strong>Instagram Basic Display API</strong> fails.
    /// </summary>
    public class InstagramParseException : InstagramException {

        #region Properties

        /// <summary>
        /// Gets a reference to the response that triggered the exception.
        /// </summary>
        public IHttpResponse Response { get; }

        /// <summary>
        /// Gets a reference to the <see cref="JToken"/> that could not be parsed.
        /// </summary>
        public JToken Token { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with the specified <c>message</c>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public InstagramParseException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance with the specified <c>message</c>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        /// <param name="token">The token.</param>
        public InstagramParseException(string message, JToken token) : base(message)  {
            Token = token;
        }

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="message"/>, <paramref name="response"/>, <paramref name="token"/> and <paramref name="innerException"/>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        /// <param name="response">The response that triggered the exception.</param>
        /// <param name="token">The JSON token.</param>
        /// <param name="innerException">The inner exception.</param>
        public InstagramParseException(string message, IHttpResponse response, JToken token, Exception innerException) : base(message, innerException) {
            Response = response;
            Token = token;
        }

        #endregion

    }

}