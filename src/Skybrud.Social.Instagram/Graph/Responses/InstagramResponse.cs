﻿using System.Net;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.Graph.Exceptions;
using Skybrud.Social.Instagram.Graph.Models.Common;
using Skybrud.Social.Instagram.Graph.Models.Errors;

namespace Skybrud.Social.Instagram.Graph.Responses {

    /// <summary>
    /// Class representing a response from the <strong>Instagram Graph API</strong>.
    /// </summary>
    public class InstagramResponse : HttpResponseBase {

        #region Properties
        
        /// <summary>
        /// Gets information about rate limiting.
        /// </summary>
        public InstagramRateLimiting RateLimiting { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The underlying raw response the instance should be based on.</param>
        protected InstagramResponse(IHttpResponse response) : base(response) {
            RateLimiting = InstagramRateLimiting.GetFromResponse(response);
        }

        #endregion
        
        #region Static methods

        /// <summary>
        /// Validates the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        public static void ValidateResponse(IHttpResponse response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            // Handle errors when the response body isn't JSON
            if (!response.Body.StartsWith("{")) {
                switch (response.StatusCode) {
                    case HttpStatusCode.NotFound:
                        throw new InstagramNotFoundException(response);
                    default:
                        throw new InstagramHttpException(response);
                }
            }

            // Parse the response body
            JObject obj = ParseJsonObject(response.Body);

            if (response.ResponseUri.Host == "graph.facebook.com") {
                InstagramHttpError error = obj.GetObject("error", InstagramHttpError.Parse);
                throw new InstagramHttpException(response, error);
            }

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the <strong>Instagram Graph API</strong>.
    /// </summary>
    public class InstagramResponse<T> : InstagramResponse {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The underlying raw response the instance should be based on.</param>
        protected InstagramResponse(IHttpResponse response) : base(response) { }

        #endregion

    }

}