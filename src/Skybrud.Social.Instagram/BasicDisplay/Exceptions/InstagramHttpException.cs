using System.Diagnostics.CodeAnalysis;
using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Exceptions;
using Skybrud.Social.Instagram.BasicDisplay.Models.Errors;

namespace Skybrud.Social.Instagram.BasicDisplay.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the <strong>Instagram Basic Display API</strong>.
    /// </summary>
    public class InstagramHttpException : InstagramException, IHttpException {

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
        /// Gets the error returned by the <strong>Instagram Basic Display API</strong>.
        /// </summary>
        public InstagramError? Error { get; }

        /// <summary>
        /// Gets whether the error was included in the response.
        /// </summary>
        [MemberNotNullWhen(true, "Error")]
        public bool HasError => Error != null;

        #endregion

        #region Constructors

        private InstagramHttpException(IHttpResponse response, string? message) : base(message ?? $"Invalid response received from the Instagram Basic Display API (status: {(int) response.StatusCode}.") {
            Response = response;
        }

        internal InstagramHttpException(IHttpResponse response) : this(response, default(string)) { }

        internal InstagramHttpException(IHttpResponse response, InstagramError? error) : this(response, error?.Message!) {
            Error = error;
        }

        #endregion

    }

}