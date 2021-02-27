using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.Graph.Fields;
using Skybrud.Social.Instagram.Graph.OAuth;
using Skybrud.Social.Instagram.Graph.Options.Users;

// ReSharper disable InconsistentNaming

namespace Skybrud.Social.Instagram.Graph.Endpoints {

    /// <summary>
    /// Class representing the raw implementation of the Instagram <strong>User</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/instagram-api/reference/user</cref>
    /// </see>
    public class InstagramUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public InstagramOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal InstagramUsersRawEndpoint(InstagramOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets metadata about the Instagram user with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the Instagram user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-api/reference/user/#metadata</cref>
        /// </see>
        public IHttpResponse GetUser(string id) {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
            return GetUser(new InstagramGetUserOptions(id));
        }

        /// <summary>
        /// Gets metadata about the Instagram user with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the Instagram user.</param>
        /// <param name="fields">The fields to be returned by the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-api/reference/user/#metadata</cref>
        /// </see>
        public IHttpResponse GetUser(string id, InstagramFieldList fields) {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
            return GetUser(new InstagramGetUserOptions(id, fields));
        }

        /// <summary>
        /// Gets metadata about the Instagram user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">THe options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-api/reference/user/#metadata</cref>
        /// </see>
        public IHttpResponse GetUser(InstagramGetUserOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets a list of recent media of the Instagram user with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the Instagram user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-api/reference/user/media#get-media</cref>
        /// </see>
        public IHttpResponse GetRecentMedia(string id) {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
            return GetRecentMedia(new InstagramGetRecentMediaOptions(id));
        }

        /// <summary>
        /// Gets a list of recent media of the Instagram user with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the Instagram user.</param>
        /// <param name="fields">The fields to be returned by the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-api/reference/user/media#get-media</cref>
        /// </see>
        public IHttpResponse GetRecentMedia(string id, InstagramFieldList fields) {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
            return GetRecentMedia(new InstagramGetRecentMediaOptions(id, fields));
        }

        /// <summary>
        /// Gets a list of recent media of the Instagram user with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the Instagram user.</param>
        /// <param name="limit">The maximum amount of media that should be returned in each page.</param>
        /// <param name="after">The fields to be returned by the API.</param>
        /// <param name="fields">The fields to be returned by the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-api/reference/user/media#get-media</cref>
        /// </see>
        public IHttpResponse GetRecentMedia(string id, int limit, string after, InstagramFieldList fields) {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
            return GetRecentMedia(new InstagramGetRecentMediaOptions(id, limit, after, fields));
        }

        /// <summary>
        /// Gets a list of recent media of the Instagram user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">THe options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-api/reference/user/media#get-media</cref>
        /// </see>
        public IHttpResponse GetRecentMedia(InstagramGetRecentMediaOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}