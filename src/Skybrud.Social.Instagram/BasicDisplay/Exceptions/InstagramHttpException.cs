using System;
using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Exceptions;
using Skybrud.Social.Instagram.BasicDisplay.Models.Errors;

namespace Skybrud.Social.Instagram.BasicDisplay.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the <strong>Instagram Basic Display API</strong>.
    /// </summary>
    public class InstagramHttpException : Exception, IHttpException {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="IHttpResponse"/>.
        /// </summary>
        public IHttpResponse Response { get; }

        /// <summary>
        /// Gets the status code of the response.
        /// </summary>
        public HttpStatusCode StatusCode => Response.StatusCode;

        /// <summary>
        /// Gets the error returned by the <strong>Instagram Graph API</strong>.
        /// </summary>
        public InstagramError Error { get; }

        /// <summary>
        /// Gets whether the error was included in the response.
        /// </summary>
        public bool HasError => Error != null;

        #endregion

        #region Constructors

        internal InstagramHttpException(IHttpResponse response) : base($"Invalid response received from the Instagram Basic Display API (Status: {(int) response.StatusCode}).") {
            Response = response;
        }

        internal InstagramHttpException(IHttpResponse response, InstagramError error) : base(error.Message) {
            Response = response;
            Error = error;
        }

        #endregion

    }

}