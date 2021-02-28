using System;
using System.Net;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.BasicDisplay.Exceptions;
using Skybrud.Social.Instagram.BasicDisplay.Models.Errors;

namespace Skybrud.Social.Instagram.BasicDisplay.Responses {

    /// <summary>
    /// Class representing a response from the <strong>Instagram Basic Display API</strong>.
    /// </summary>
    public class InstagramResponse : HttpResponseBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The underlying raw response the instance should be based on.</param>
        protected InstagramResponse(IHttpResponse response) : base(response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            // Handle errors when the response body isn't JSON
            if (!response.Body.StartsWith("{")) throw new InstagramHttpException(response);

            JObject body = null;
            try {

                // Parse the response body
                body = ParseJsonObject(response.Body);

                // Get the error type (only OAuth errors seem to have this property)
                string errorType = body.GetString("error_type");

                switch (errorType) {

                    case "OAuthException":

                        // Throw the exception
                        throw new InstagramOAuthException(response, InstagramError.Parse(body));

                    default:

                        // Get details about the error
                        InstagramError error = body.GetObject("error", InstagramError.Parse);

                        // Throw the exception
                        throw new InstagramHttpException(response, error);

                }

            } catch (Exception ex) when (!(ex is InstagramHttpException)) {

                throw new InstagramParseException("Failed parsing Instagram error response.", response, body, ex);

            }

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the Instagram API.
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