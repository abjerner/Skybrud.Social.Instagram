using System;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;
using Skybrud.Social.Instagram.Graph.Endpoints;

namespace Skybrud.Social.Instagram.Graph.OAuth {

    /// <summary>
    /// Class for handling the raw communication with the <strong>Instagram Graph API</strong>.
    /// </summary>
    public class InstagramOAuthClient : HttpClient {

        #region Properties

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string? AccessToken { get; set; }

        /// <summary>
        /// Gets a reference to the raw <strong>Users</strong> endpoint.
        /// </summary>
        public InstagramUsersRawEndpoint Users { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an OAuth client with empty information.
        /// </summary>
        public InstagramOAuthClient() {
            Users = new InstagramUsersRawEndpoint(this);
        }

        /// <summary>
        /// Initializes an OAuth client with the specified <paramref name="accessToken"/>. Using this initializer, the
        /// client will have no information about your app.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public InstagramOAuthClient(string accessToken) : this() {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));
            AccessToken = accessToken;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Virtual method that can be used for configuring a request.
        /// </summary>
        /// <param name="request">The instance of <see cref="IHttpRequest"/> representing the request.</param>
        protected override void PrepareHttpRequest(IHttpRequest request) {

            // Append either the access token or the client ID to the query string
            if (!string.IsNullOrWhiteSpace(AccessToken)) {
                request.QueryString.Add("access_token", AccessToken!);
            }

            // If the URL starts with a forward slash, it must be an relative URL for the Instagram Graph API
            if (request.Url.StartsWith("/")) {
                // TODO: Add support for API versioning
                request.Url = $"https://graph.facebook.com{request.Url}";
            }

        }

        #endregion

    }

}