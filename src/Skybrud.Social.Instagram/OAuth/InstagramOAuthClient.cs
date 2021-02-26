using System;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;
using Skybrud.Social.Instagram.Endpoints.Graph;

namespace Skybrud.Social.Instagram.OAuth {

    /// <summary>
    /// Class for handling the raw communication with the Instagram API as well as any OAuth 2.0
    /// communication/authentication.
    /// </summary>
    public class InstagramOAuthClient : HttpClient {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the app/client.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the secret of the app/client.
        /// </summary>
        public string ClientSecret { get; set; }
        
        /// <summary>
        /// Gets or sets the redirect URI of your application.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets a reference to the raw <strong>Instagram Graph API</strong> endpoint.
        /// </summary>
        public InstagramGraphRawEndpoint Graph { get; }

        /// <summary>
        /// Gets or sets whether signed requests should be enabled.
        /// </summary>
        /// <see>
        ///     <cref>https://www.instagram.com/developer/secure-api-requests/#enforce-signed-requests</cref>
        /// </see>
        public bool SignedRequests { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an OAuth client with empty information.
        /// </summary>
        public InstagramOAuthClient() {
            Graph = new InstagramGraphRawEndpoint(this);
        }

        /// <summary>
        /// Initializes an OAuth client with the specified <paramref name="accessToken"/>. Using this initializer, the
        /// client will have no information about your app.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public InstagramOAuthClient(string accessToken) : this() {

            // Some input validation
            if (string.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));

            AccessToken = accessToken;
        
        }
        
        /// <summary>
        /// Initializes an OAuth client with the specified <paramref name="clientId"/> and
        /// <paramref name="clientSecret"/>.
        /// </summary>
        /// <param name="clientId">The ID of the client/app.</param>
        /// <param name="clientSecret">The secret of the client/app.</param>
        public InstagramOAuthClient(string clientId, string clientSecret) : this() {

            // Some input validation
            if (string.IsNullOrWhiteSpace(clientId)) throw new ArgumentNullException(nameof(clientId));
            if (string.IsNullOrWhiteSpace(clientSecret)) throw new ArgumentNullException(nameof(clientSecret));
            
            ClientId = clientId;
            ClientSecret = clientSecret;
        
        }

        /// <summary>
        /// Initializes an OAuth client with the specified <paramref name="clientId"/>, <paramref name="clientSecret"/>
        /// and <paramref name="redirectUri"/>.
        /// </summary>
        /// <param name="clientId">The ID of the client/app.</param>
        /// <param name="clientSecret">The secret of the client/app.</param>
        /// <param name="redirectUri">The return URI of the client/app.</param>
        public InstagramOAuthClient(string clientId, string clientSecret, string redirectUri) : this() {

            // Some input validation
            if (string.IsNullOrWhiteSpace(clientId)) throw new ArgumentNullException(nameof(clientId));
            if (string.IsNullOrWhiteSpace(clientSecret)) throw new ArgumentNullException(nameof(clientSecret));
            if (string.IsNullOrWhiteSpace(redirectUri)) throw new ArgumentNullException(nameof(redirectUri));
            
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        
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
                request.QueryString.Add("access_token", AccessToken);
            } else if (!string.IsNullOrWhiteSpace(ClientId)) {
                request.QueryString.Add("client_id", ClientId);
            }

            // If the URL starts with a forward slash, it must be an relative URL for the Instagram Graph API
            if (request.Url.StartsWith("/")) {
                // TODO: Add support for API versioning
                request.Url = "https://graph.facebook.com" + request.Url;
            }

        }

        #endregion

    }

}