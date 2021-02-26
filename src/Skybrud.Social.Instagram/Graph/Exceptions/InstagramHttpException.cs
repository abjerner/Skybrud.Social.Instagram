using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.Graph.Models.Common;
using Skybrud.Social.Instagram.Graph.Models.Errors;

namespace Skybrud.Social.Instagram.Graph.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the <strong>Instagram Graph API</strong>.
    /// </summary>
    public class InstagramHttpException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="IHttpResponse"/>.
        /// </summary>
        public IHttpResponse Response { get; }

        /// <summary>
        /// Gets information about rate limiting.
        /// </summary>
        public InstagramRateLimiting RateLimiting { get; }

        /// <summary>
        /// Gets whether rate limiting information was included in the response.
        /// </summary>
        public bool HasRateLimiting => RateLimiting.Limit > 0;

        /// <summary>
        /// Gets the error returned by the <strong>Instagram Graph API</strong>.
        /// </summary>
        public InstagramHttpError Error { get; }

        /// <summary>
        /// Gets whether the error was included in the response.
        /// </summary>
        public bool HasError => Error != null;

        #endregion

        #region Constructors

        internal InstagramHttpException(IHttpResponse response) : base($"Invalid response received from the Instagram Graph API (Status: {(int) response.StatusCode}.") {
            Response = response;
            RateLimiting = InstagramRateLimiting.GetFromResponse(response);
        }

        internal InstagramHttpException(IHttpResponse response, InstagramHttpError error) : base(error.Message) {
            Response = response;
            RateLimiting = InstagramRateLimiting.GetFromResponse(response);
            Error = error;
        }

        #endregion

    }

}