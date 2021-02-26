using System.Net;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.BasicDisplay.Exceptions;
using Skybrud.Social.Instagram.BasicDisplay.Models.Errors;
using Skybrud.Social.Instagram.Models.Errors;

namespace Skybrud.Social.Instagram.BasicDisplay.Responses {

    /// <summary>
    /// Class representing a response from the Instagram Basic Display API.
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

            // Parse the response body
            JObject obj = ParseJsonObject(response.Body);

            // Get details about the error
            InstagramError error = obj.GetObject("error", InstagramError.Parse);

            // Throw the exception
            throw new InstagramHttpException(response, error);

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