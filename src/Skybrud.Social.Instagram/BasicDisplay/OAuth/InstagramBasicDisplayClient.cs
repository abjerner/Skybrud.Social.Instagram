using System.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.Instagram.BasicDisplay.Endpoints;
using Skybrud.Social.Instagram.BasicDisplay.Responses.Authentication;
using Skybrud.Social.Instagram.BasicDisplay.Scopes;

namespace Skybrud.Social.Instagram.BasicDisplay.OAuth {

    /// <summary>
    /// Class representing a client for communicating and handling communication with the <strong>Instagran Basic Display API</strong>.
    /// </summary>
    public class InstagramBasicDisplayClient : HttpClient {

        #region Properties

        /// <summary>
        /// Gets or sets the client ID of your app.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret of your app.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the redirect URI of your app.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets a reference to the raw <strong>Users</strong> endpoint.
        /// </summary>
        public InstagramUsersRawEndpoint Users { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public InstagramBasicDisplayClient() {
            Users = new InstagramUsersRawEndpoint(this);
        }

        /// <summary>
        /// Initialized a new instance based on the specified <paramref name="accessToken"/>.
        /// </summary>
        /// <param name="accessToken"></param>
        public InstagramBasicDisplayClient(string accessToken) : this() {
            AccessToken = accessToken;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an authorization based on the specified <paramref name="state"/> and <paramref name="scope"/>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
        /// <returns>The authorization URL.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/oauth-authorize</cref>
        /// </see>
        public string GetAuthorizationUrl(string state, string scope) {

            // Initialize the query string
            HttpQueryString query = new() {
                { "client_id", ClientId },
                { "redirect_uri", RedirectUri },
                { "response_type", "code" },
                { "scope", scope == null ? string.Empty : string.Join(",", scope) },
                { "state", state }
            };

            // Construct the authorization URL
            return $"https://api.instagram.com/oauth/authorize?{query}";

        }

        /// <summary>
        /// Gets an authorization based on the specified <paramref name="state"/> and <paramref name="scope"/>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
        /// <returns>The authorization URL.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/oauth-authorize</cref>
        /// </see>
        public string GetAuthorizationUrl(string state, string[] scope) {
            return GetAuthorizationUrl(state, scope == null ? string.Empty : string.Join(",", scope));
        }

        /// <summary>
        /// Gets an authorization based on the specified <paramref name="state"/> and <paramref name="scope"/>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
        /// <returns>The authorization URL.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/oauth-authorize</cref>
        /// </see>
        public string GetAuthorizationUrl(string state, params InstagramScope[] scope) {
            return GetAuthorizationUrl(state, scope == null ? null : string.Join(",", from s in scope select s.Alias));
        }

        /// <summary>
        /// Gets an authorization based on the specified <paramref name="state"/> and <paramref name="scope"/>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
        /// <returns>The authorization URL.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/oauth-authorize</cref>
        /// </see>
        public string GetAuthorizationUrl(string state, InstagramScopeList scope) {
            return GetAuthorizationUrl(state, scope?.ToString());
        }

        /// <summary>
        /// Exchanges the specified authorization <paramref name="code"/> for a short-lived access token.
        /// </summary>
        /// <param name="code">The authorization code.</param>
        /// <returns>An instance of <see cref="InstagramShortLivedTokenResponse"/> representing the API response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/oauth-access-token</cref>
        /// </see>
        public InstagramShortLivedTokenResponse GetAccessTokenFromAuthCode(string code) {

            // Initialize the POST data
            HttpPostData post = new() {
                { "client_id", ClientId },
                { "client_secret", ClientSecret },
                { "code", code },
                { "grant_type", "authorization_code" },
                { "redirect_uri", RedirectUri }
            };

            // Make a POST request to the API
            IHttpResponse response = HttpUtils.Requests.Post("https://api.instagram.com/oauth/access_token", post);

            // Wrap the raw response
            return new InstagramShortLivedTokenResponse(response);

        }

        /// <summary>
        /// Exchanges the specified short-lived <paramref name="accessToken"/> for a new long-lived access token.
        /// </summary>
        /// <param name="accessToken">The short-lived access token to be exchanged.</param>
        /// <returns>An instance of <see cref="InstagramLongLivedTokenResponse"/> representing the API response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/access_token</cref>
        /// </see>
        public InstagramLongLivedTokenResponse GetLongLivedAccessToken(string accessToken) {

            // Initialize the query string
            HttpQueryString query = new() {
                { "grant_type", "ig_exchange_token" },
                { "client_secret", ClientSecret },
                { "access_token", accessToken }
            };

            // Make a GET request to the API
            IHttpResponse response = HttpUtils.Requests.Get("https://graph.instagram.com/access_token", query);

            // Wrap the raw response
            return new InstagramLongLivedTokenResponse(response);

        }

        /// <summary>
        /// Exchanges the specified long-lived <paramref name="accessToken"/> for a new long-lived access token.
        /// </summary>
        /// <param name="accessToken">The long-lived access token to be exchanged.</param>
        /// <returns>An instance of <see cref="InstagramLongLivedTokenResponse"/> representing the API response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/refresh_access_token</cref>
        /// </see>
        public InstagramLongLivedTokenResponse RefreshAccessToken(string accessToken) {

            // Initialize the query string
            HttpQueryString query = new() {
                { "grant_type", "ig_refresh_token" },
                { "access_token", accessToken }
            };

            // Make a GET request to the API
            IHttpResponse response = HttpUtils.Requests.Get("https://graph.instagram.com/refresh_access_token", query);

            // Wrap the raw response
            return new InstagramLongLivedTokenResponse(response);

        }

        /// <inheritdoc />
        protected override void PrepareHttpRequest(IHttpRequest request) {

            if (string.IsNullOrWhiteSpace(AccessToken) == false) {
                request.QueryString ??= new HttpQueryString();
                request.QueryString.Set("access_token", AccessToken);
            }

            if (request.Url.StartsWith("/")) {
                request.Url = "https://graph.instagram.com" + request.Url;
            }

        }

        #endregion

    }

}