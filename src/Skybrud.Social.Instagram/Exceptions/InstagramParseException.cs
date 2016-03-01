using System;

namespace Skybrud.Social.Instagram.Exceptions {
    
    /// <summary>
    /// Exception class thrown when parsing a JSON response from the Insatgram API fails.
    /// </summary>
    public class InstagramParseException : Exception {

        /// <summary>
        /// Initializes a new instance with the specified <code>message</code>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public InstagramParseException(string message) : base(message) { }

    }

}