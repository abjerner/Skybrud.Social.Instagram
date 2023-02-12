using System;

namespace Skybrud.Social.Instagram.BasicDisplay.Exceptions {

    /// <summary>
    /// Class representing an exception related to the implementation for the <strong>Instagram Basic Display API</strong>.
    /// </summary>
    public class InstagramException : Exception {

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public InstagramException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="message"/> and <paramref name="innerException"/>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        /// <param name="innerException">The inner exception.</param>
        public InstagramException(string message, Exception? innerException) : base(message, innerException) { }

    }

}