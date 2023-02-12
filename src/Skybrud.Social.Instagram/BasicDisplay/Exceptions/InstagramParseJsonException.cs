using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Instagram.BasicDisplay.Exceptions {

    /// <summary>
    /// Exception class thrown when parsing a JSON object or array received from the <strong>Instagram Basic Display API</strong> fails.
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
        /// Initializes a new instance with the specified <c>message</c>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        /// <param name="token">The token.</param>
        public InstagramParseJsonException(JToken token, string message) : base(message) {
            Token = token;
        }

        #endregion

    }

}