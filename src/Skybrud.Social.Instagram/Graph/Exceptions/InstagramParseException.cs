using System;

namespace Skybrud.Social.Instagram.Graph.Exceptions {

    /// <summary>
    /// Exception class thrown when parsing a JSON response from the <strong>Instagram Graph API</strong> fails.
    /// </summary>
    public class InstagramParseException : InstagramException {

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public InstagramParseException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        /// <param name="innerException">The inner exception.</param>
        public InstagramParseException(string message, Exception? innerException) : base(message, innerException) { }

    }

}