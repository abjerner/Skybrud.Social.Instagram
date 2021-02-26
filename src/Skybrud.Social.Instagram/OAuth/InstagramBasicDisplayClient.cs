using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.Instagram.BasicDisplay.Endpoints;
using Skybrud.Social.Instagram.BasicDisplay.Responses.Authentication;

namespace Skybrud.Social.Instagram.OAuth {
    
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

        public InstagramBasicDisplayClient() {
            Users = new InstagramUsersRawEndpoint(this);
        }

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
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/guides/getting-access-tokens-and-permissions#step-1--get-authorization</cref>
        /// </see>
        public string GetAuthorizationUrl(string state, string scope) {

            // Initialize the query string
            IHttpQueryString query = new HttpQueryString {
                { "client_id", ClientId },
                { "redirect_uri", RedirectUri },
                { "response_type", "code" },
                { "scope", scope == null ? string.Empty : string.Join(",", scope) },
                { "state", state }
            };

            // Construct the authorization URL
            return "https://api.instagram.com/oauth/authorize?" + query;

        }

        /// <summary>
        /// Gets an authorization based on the specified <paramref name="state"/> and <paramref name="scope"/>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
        /// <returns>The authorization URL.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/guides/getting-access-tokens-and-permissions#step-1--get-authorization</cref>
        /// </see>
        public string GetAuthorizationUrl(string state, string[] scope) {
            return GetAuthorizationUrl(state, scope == null ? string.Empty : string.Join(",", scope));
        }

        /// <summary>
        /// Exchanges the specified authorization <paramref name="code"/> for a short-lived access token.
        /// </summary>
        /// <param name="code">The authorization code.</param>
        /// <returns></returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/guides/getting-access-tokens-and-permissions#step-2--exchange-the-code-for-a-token</cref>
        /// </see>
        public InstagramShortLivedTokenResponse GetAccessTokenFromAuthCode(string code) {

            // Initialize the POST data
            IHttpPostData post = new HttpPostData {
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
        /// Exchanges the specified <paramref name="accessToken"/> for a new long-lived access token.
        /// </summary>
        /// <param name="accessToken">The access token to be exchanged.</param>
        /// <returns></returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/guides/long-lived-access-tokens#get-a-long-lived-token</cref>
        /// </see>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/guides/long-lived-access-tokens#refresh-a-long-lived-token</cref>
        /// </see>
        public InstagramLongLivedTokenResponse GetLongLivedAccessToken(string accessToken) {

            // Initialize the POST data
            IHttpPostData post = new HttpPostData {
                { "grant_type", "ig_exchange_token" },
                { "client_secret", ClientSecret },
                { "access_token", accessToken }
            };

            // Make a POST request to the API
            IHttpResponse response = HttpUtils.Requests.Post("https://api.instagram.com/oauth/access_token", post);

            // Wrap the raw response
            return new InstagramLongLivedTokenResponse(response);

        }

        /// <inheritdoc />
        protected override void PrepareHttpRequest(IHttpRequest request) {

            if (string.IsNullOrWhiteSpace(AccessToken) == false)  {
                if (request.QueryString == null) request.QueryString = new HttpQueryString();
                request.QueryString.Set("access_token", AccessToken);
            }

            if (request.Url.StartsWith("/")) {
                request.Url = "https://graph.instagram.com" + request.Url;
            }

        }

        #endregion

    }

}