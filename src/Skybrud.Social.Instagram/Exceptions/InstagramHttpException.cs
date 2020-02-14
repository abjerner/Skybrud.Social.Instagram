using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.Models;
using Skybrud.Social.Instagram.Models.Common;

namespace Skybrud.Social.Instagram.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the Instagram API.
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
        /// Gets the meta data of the response.
        /// </summary>
        public InstagramMetaData Meta { get; }

        /// <summary>
        /// Gets whether meta data was included in the response.
        /// </summary>
        public bool HasMeta => Meta != null;

        #endregion

        #region Constructors

        internal InstagramHttpException(IHttpResponse response) : base("Invalid response received from the Instagram API (Status: " + ((int) response.StatusCode) + ")") {
            Response = response;
            RateLimiting = InstagramRateLimiting.GetFromResponse(response);
        }

        internal InstagramHttpException(IHttpResponse response, InstagramMetaData meta) : base(meta.ErrorMessage) {
            Response = response;
            RateLimiting = InstagramRateLimiting.GetFromResponse(response);
            Meta = meta;
        }

        #endregion

    }

}