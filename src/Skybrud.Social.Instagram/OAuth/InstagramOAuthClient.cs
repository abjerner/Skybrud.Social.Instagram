using System;
using System.Collections.Specialized;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Responses.Authentication;
using Skybrud.Social.Instagram.Scopes;

namespace Skybrud.Social.Instagram.OAuth {

    /// <summary>
    /// Class for handling the raw communication with the Instagram API as well as any OAuth 2.0
    /// communication/authentication.
    /// </summary>
    public class InstagramOAuthClient : SocialHttpClient {

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
        /// Gets a reference to the locations endpoint.
        /// </summary>
        public InstagramLocationsRawEndpoint Locations { get; private set; }

        /// <summary>
        /// Gets a reference to the media endpoint.
        /// </summary>
        public InstagramMediaRawEndpoint Media { get; private set; }

        /// <summary>
        /// Gets a reference to the relationships endpoint.
        /// </summary>
        public InstagramRelationshipsRawEndpoint Relationships { get; private set; }

        /// <summary>
        /// Gets a reference to the tags endpoint.
        /// </summary>
        public InstagramTagsRawEndpoint Tags { get; private set; }

        /// <summary>
        /// Gets a reference to the users endpoint.
        /// </summary>
        public InstagramUsersRawEndpoint Users { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an OAuth client with empty information.
        /// </summary>
        public InstagramOAuthClient() {
            Locations = new InstagramLocationsRawEndpoint(this);
            Media = new InstagramMediaRawEndpoint(this);
            Relationships = new InstagramRelationshipsRawEndpoint(this);
            Tags = new InstagramTagsRawEndpoint(this);
            Users = new InstagramUsersRawEndpoint(this);
        }

        /// <summary>
        /// Initializes an OAuth client with the specified <code>accessToken</code>. Using this initializer, the client
        /// will have no information about your app.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public InstagramOAuthClient(string accessToken) {
            AccessToken = accessToken;
        }
        
        /// <summary>
        /// Initializes an OAuth client with the specified <code>clientId</code> and <code>clientSecret</code>.
        /// </summary>
        /// <param name="clientId">The ID of the client/app.</param>
        /// <param name="clientSecret">The secret of the client/app.</param>
        public InstagramOAuthClient(string clientId, string clientSecret) {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified <code>clientId</code>, <code>clientSecret</code> and <code>redirectUri</code>.
        /// </summary>
        /// <param name="clientId">The ID of the client/app.</param>
        /// <param name="clientSecret">The secret of the client/app.</param>
        /// <param name="redirectUri">The return URI of the client/app.</param>
        public InstagramOAuthClient(string clientId, string clientSecret, string redirectUri) {
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets an authorization URL using the specified <code>state</code>. This URL will only make your application
        /// request a basic scope.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        public string GetAuthorizationUrl(string state) {
            return GetAuthorizationUrl(state, InstagramScopes.Basic);
        }

        /// <summary>
        /// Gets an authorization URL using the specified <code>state</code> and request the specified <code>scope</code>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
        public string GetAuthorizationUrl(string state, InstagramScopeCollection scope) {
            return GetAuthorizationUrl(state, scope.ToString());
        }

        /// <summary>
        /// Gets an authorization URL using the specified <code>state</code> and request the specified <code>scope</code>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
        public string GetAuthorizationUrl(string state, params string[] scope) {

            // Do we have a valid "state" ?
            if (String.IsNullOrWhiteSpace(state)) {
                throw new ArgumentNullException("state", "A valid state should be specified as it is part of the security of OAuth 2.0.");
            }

            // Construct the query string
            NameValueCollection query = new NameValueCollection {
                {"client_id", ClientId},
                {"redirect_uri", RedirectUri},
                {"response_type", "code"},
                {"state", state}
            };

            // Append the scope (if specified)
            if (scope != null && scope.Length > 0) {
                query.Add("scope", String.Join(" ", scope));
            }

            // Construct thr authorization URL
            return "https://api.instagram.com/oauth/authorize/?" + SocialUtils.NameValueCollectionToQueryString(query);

        }

        /// <summary>
        /// Makes a call to the Instagram API to exchange the specified <code>authCode</code> for an access token.
        /// </summary>
        /// <param name="authCode">The authorization code obtained from an OAuth 2.0 login flow.</param>
        /// <returns>Returns an instance of <see cref="InstagramTokenResponse"/> representing the response from the server.</returns>
        public InstagramTokenResponse GetAccessTokenFromAuthCode(string authCode) {
        
            // Initialize collection with POST data
            NameValueCollection parameters = new NameValueCollection {
                {"client_id", ClientId},
                {"client_secret", ClientSecret},
                {"grant_type", "authorization_code"},
                {"redirect_uri", RedirectUri},
                {"code", authCode }
            };

            // Make the call to the API
            SocialHttpResponse response = SocialUtils.DoHttpPostRequest("https://api.instagram.com/oauth/access_token", null, parameters);

            // Parse the response
            return InstagramTokenResponse.ParseResponse(response);

        }

        protected override void PrepareHttpRequest(SocialHttpRequest request) {

            // Append either the access token or the client ID to the query string
            if (!String.IsNullOrWhiteSpace(AccessToken)) {
                request.QueryString.Add("access_token", AccessToken);
            } else if (!String.IsNullOrWhiteSpace(ClientId)) {
                request.QueryString.Add("client_id", ClientId);
            }

        }

        #endregion

    }

}