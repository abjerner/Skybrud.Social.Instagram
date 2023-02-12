using System;
using System.Net;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Json.Newtonsoft;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
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
            ValidateResponse(response);
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
                throw response.StatusCode switch {
                    HttpStatusCode.NotFound => new InstagramNotFoundException(response),
                    _ => new InstagramHttpException(response)
                };
            }

            // Parse the response body
            JObject obj = ParseJsonObject(response.Body);

            if (response.ResponseUri.Host == "graph.facebook.com") {
                InstagramHttpError? error = obj.GetObject("error", InstagramHttpError.Parse);
                throw new InstagramHttpException(response, error);
            }

        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="response">The response containing the body.</param>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into an instance of <typeparamref name="T"/>.</param>
        /// <returns>An instance of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
        protected static T ParseJsonObject<T>(IHttpResponse response, string json, Func<JObject, T> func) {

            try {

                // Try to parse the raw JSON, If this fails, it will not throw an InstagramParseJsonException, but
                // rather an InstagramParseResponseException. This could potentially change in the future with a more
                // specific exception
                JObject obj = JsonUtils.ParseJsonObject(json);

                try {

                    // Convert the JObject into T
                    return func(obj);

                } catch (Exception ex) {

                    throw new InstagramParseJsonException(obj, ex);

                }


            } catch (Exception ex) {

                throw new InstagramParseResponseException(response, ex);

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
        public T Body { get; protected set; } = default!;

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