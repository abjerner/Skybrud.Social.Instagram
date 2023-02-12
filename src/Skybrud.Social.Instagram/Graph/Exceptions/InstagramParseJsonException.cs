using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Social.Instagram.Graph.Exceptions {

    /// <summary>
    /// Exception class thrown when parsing a JSON object or array received from the <strong>Instagram Graph API</strong> fails.
    /// </summary>
    public class InstagramParseJsonException : InstagramParseException {

        #region Properties

        /// <summary>
        /// Gets a reference to the <see cref="JToken"/> that could not be parsed.
        /// </summary>
        public JToken Token { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="token"/> and <paramref name="message"/>.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="message">The message of the exception.</param>
        public InstagramParseJsonException(JToken token, string? message) : this(token, message, null) {
            Token = token;
        }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="token"/> and <paramref name="innerException"/>.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="innerException">The inner exception.</param>
        public InstagramParseJsonException(JToken token, Exception? innerException) : this(token, null, innerException) {
            Token = token;
        }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="token"/>, <paramref name="message"/> and <paramref name="innerException"/>.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="message">The message of the exception.</param>
        /// <param name="innerException">The inner exception.</param>
        public InstagramParseJsonException(JToken token, string? message, Exception? innerException) : base(message ?? $"Failed parsing JSON {token.Type.ToLower()}.", innerException) {
            Token = token;
        }

        #endregion

    }

}