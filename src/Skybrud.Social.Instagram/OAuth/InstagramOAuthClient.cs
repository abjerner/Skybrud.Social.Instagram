using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Responses.Authentication;
using Skybrud.Social.Instagram.Scopes;

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
            Locations = new InstagramLocationsRawEndpoint(this);
            Media = new InstagramMediaRawEndpoint(this);
            Relationships = new InstagramRelationshipsRawEndpoint(this);
            Tags = new InstagramTagsRawEndpoint(this);
            Users = new InstagramUsersRawEndpoint(this);
        }

        /// <summary>
        /// Initializes an OAuth client with the specified <paramref name="accessToken"/>. Using this initializer, the
        /// client will have no information about your app.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public InstagramOAuthClient(string accessToken) : this() {

            // Some input validation
            if (String.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException("accessToken");

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
            if (String.IsNullOrWhiteSpace(clientId)) throw new ArgumentNullException("clientId");
            if (String.IsNullOrWhiteSpace(clientSecret)) throw new ArgumentNullException("clientSecret");
            
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
            if (String.IsNullOrWhiteSpace(clientId)) throw new ArgumentNullException("clientId");
            if (String.IsNullOrWhiteSpace(clientSecret)) throw new ArgumentNullException("clientSecret");
            if (String.IsNullOrWhiteSpace(redirectUri)) throw new ArgumentNullException("redirectUri");
            
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets an authorization URL using the specified <paramref name="state"/>. This URL will only make your
        /// application request a basic scope.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <returns>The authorization URL.</returns>
        public virtual string GetAuthorizationUrl(string state) {
            return GetAuthorizationUrl(state, InstagramScopes.Basic);
        }

        /// <summary>
        /// Gets an authorization URL using the specified <paramref name="state"/> and request the specified
        /// <paramref name="scope"/>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
        /// <returns>The authorization URL.</returns>
        public virtual string GetAuthorizationUrl(string state, InstagramScopeCollection scope) {
            return GetAuthorizationUrl(state, scope.ToString());
        }

        /// <summary>
        /// Gets an authorization URL using the specified <paramref name="state"/> and request the specified
        /// <paramref name="scope"/>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
        /// <returns>The authorization URL.</returns>
        public virtual string GetAuthorizationUrl(string state, params string[] scope) {

            // Some validation
            if (String.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException("ClientId");
            if (String.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException("RedirectUri");

            // Do we have a valid "state" ?
            if (String.IsNullOrWhiteSpace(state)) {
                throw new ArgumentNullException("state", "A valid state should be specified as it is part of the security of OAuth 2.0.");
            }

            // Construct the query string
            IHttpQueryString query = new HttpQueryString();
            query.Add("client_id", ClientId);
            query.Add("redirect_uri", RedirectUri);
            query.Add("response_type", "code");
            query.Add("state", state);
            
            // Append the scope (if specified)
            if (scope != null && scope.Length > 0) {
                query.Add("scope", String.Join(" ", scope));
            }

            // Construct the authorization URL
            return "https://api.instagram.com/oauth/authorize/?" + query.ToString();

        }

        /// <summary>
        /// Makes a call to the Instagram API to exchange the specified <paramref name="authCode"/> for an access token.
        /// </summary>
        /// <param name="authCode">The authorization code obtained from an OAuth 2.0 login flow.</param>
        /// <returns>An instance of <see cref="InstagramTokenResponse"/> representing the response from the server.</returns>
        public virtual InstagramTokenResponse GetAccessTokenFromAuthCode(string authCode) {

            // Some validation
            if (String.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException("ClientId");
            if (String.IsNullOrWhiteSpace(ClientSecret)) throw new PropertyNotSetException("ClientSecret");
            if (String.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException("RedirectUri");
            if (String.IsNullOrWhiteSpace(authCode)) throw new ArgumentNullException("authCode");
        
            // Initialize collection with POST data
            IHttpPostData parameters = new HttpPostData();
            parameters.Add("client_id", ClientId);
            parameters.Add("client_secret", ClientSecret);
            parameters.Add("grant_type", "authorization_code");
            parameters.Add("redirect_uri", RedirectUri);
            parameters.Add("code", authCode);

            // Make the call to the API
            IHttpResponse response = HttpUtils.Requests.Post("https://api.instagram.com/oauth/access_token", null, parameters);

            // Parse the response
            return InstagramTokenResponse.ParseResponse(response);

        }

        /// <summary>
        /// Virtual method that can be used for configuring a request.
        /// </summary>
        /// <param name="request">The instance of <see cref="IHttpRequest"/> representing the request.</param>
        protected override void PrepareHttpRequest(IHttpRequest request) {

            // Append either the access token or the client ID to the query string
            if (!String.IsNullOrWhiteSpace(AccessToken)) {
                request.QueryString.Add("access_token", AccessToken);
            } else if (!String.IsNullOrWhiteSpace(ClientId)) {
                request.QueryString.Add("client_id", ClientId);
            }

            if (SignedRequests) {

                // Get the endpoint from the URL
                string endpoint = request.Url.Replace("https://api.instagram.com/v1/", "/");

                // Append the signature to the request
                request.QueryString.Add("sig", GenerateSignature(endpoint, request.QueryString));
            
            }

        }
        
        /// <summary>
        /// Generates the signature value based on the specified <paramref name="endpoint"/> and
        /// <paramref name="parameters"/>.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The signature value.</returns>
        /// <see>
        ///     <cref>https://www.instagram.com/developer/secure-api-requests/#enforce-signed-requests</cref>
        /// </see>
        public string GenerateSignatureValue(string endpoint, IHttpQueryString parameters) {

            // Some validation
            if (String.IsNullOrWhiteSpace(endpoint)) throw new ArgumentNullException("endpoint");
            if (parameters == null) throw new ArgumentNullException("parameters");
            if (String.IsNullOrWhiteSpace(ClientSecret)) throw new PropertyNotSetException("ClientSecret");

            // Initialize the signature value
            string signatureValue = endpoint;

            // Append the parameters (sorted by the key in alphabetic order)
            foreach (string key in parameters.Keys.OrderBy(x => x)) {
                signatureValue += "|" + key + "=" + parameters[key];
            }

            return signatureValue;

        }

        /// <summary>
        /// Generates a HMAC signature using the SHA256 hasing algorithm.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The HMAC signature.</returns>
        /// <see>
        ///     <cref>https://www.instagram.com/developer/secure-api-requests/#enforce-signed-requests</cref>
        /// </see>
        public string GenerateSignature(string endpoint, IHttpQueryString parameters) {

            // Some validation
            if (String.IsNullOrWhiteSpace(endpoint)) throw new ArgumentNullException("endpoint");
            if (parameters == null) throw new ArgumentNullException("parameters");
            if (String.IsNullOrWhiteSpace(ClientSecret)) throw new PropertyNotSetException("ClientSecret");

            // Initialize the signature value
            string signatureValue = GenerateSignatureValue(endpoint, parameters);

            // The Instagram documentation doesn't explicitly mentain any
            // encoding, but the Python examples uses UTF-8
            Encoding encoding = Encoding.UTF8;

            // Initialize the HMAC SHA256 hasher
            HMACSHA256 hasher = new HMACSHA256(encoding.GetBytes(ClientSecret));

            // Generate the HMAC SHA256 hash
            byte[] hash = hasher.ComputeHash(encoding.GetBytes(signatureValue));

            // Convert the hash back to a string
            return BitConverter.ToString(hash).Replace("-", "").ToLower();

        }

        #endregion

    }

}