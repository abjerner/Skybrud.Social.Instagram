using System;

namespace Skybrud.Social.Instagram.BasicDisplay.Exceptions {

    /// <summary>
    /// Exception class thrown when parsing a JSON response from the <strong>Instagram Basic Display API</strong> fails.
    /// </summary>
    public abstract class InstagramParseException : InstagramException {

        #region Constructors

        /// <summary>
        /// Initializes a new instance with the specified <c>message</c>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        protected InstagramParseException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance with the specified <c>message</c>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        /// <param name="innerException">The inner exception.</param>
        protected InstagramParseException(string message, Exception? innerException) : base(message, innerException) { }

        #endregion

    }

}