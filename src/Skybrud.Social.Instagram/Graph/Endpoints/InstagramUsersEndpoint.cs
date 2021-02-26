using Skybrud.Social.Instagram.Fields;
using Skybrud.Social.Instagram.Graph.Options.Users;
using Skybrud.Social.Instagram.Graph.Responses.Media;
using Skybrud.Social.Instagram.Graph.Responses.Users;

// ReSharper disable InconsistentNaming

namespace Skybrud.Social.Instagram.Graph.Endpoints {

    /// <summary>
    /// Class representing the implementation of the Instagram <strong>Users</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/instagram-api/reference/user</cref>
    /// </see>
    public class InstagramUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram service.
        /// </summary>
        public InstagramGraphService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public InstagramUsersRawEndpoint Raw => Service.Client.Users;

        #endregion

        #region Constructors

        internal InstagramUsersEndpoint(InstagramGraphService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets metadata about the Instagram user with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the Instagram user.</param>
        /// <returns>An instance of <see cref="InstagramUserResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-api/reference/user/#metadata</cref>
        /// </see>
        public InstagramUserResponse GetUser(string id) {
            return new InstagramUserResponse(Raw.GetUser(id));
        }

        /// <summary>
        /// Gets metadata about the Instagram user with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the Instagram user.</param>
        /// <param name="fields">The fields to be returned by the API.</param>
        /// <returns>An instance of <see cref="InstagramUserResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-api/reference/user/#metadata</cref>
        /// </see>
        public InstagramUserResponse GetUser(string id, InstagramFieldsCollection fields) {
            return new InstagramUserResponse(Raw.GetUser(id, fields));
        }

        /// <summary>
        /// Gets metadata about the Instagram user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">THe options for the request to the API.</param>
        /// <returns>An instance of <see cref="InstagramUserResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-api/reference/user/#metadata</cref>
        /// </see>
        public InstagramUserResponse GetUser(InstagramGetUserOptions options) {
            return new InstagramUserResponse(Raw.GetUser(options));
        }

        /// <summary>
        /// Gets a list of recent media of the Instagram user with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the Instagram user.</param>
        /// <returns>An instance of <see cref="InstagramMediaListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-api/reference/user/media#get-media</cref>
        /// </see>
        public InstagramMediaListResponse GetRecentMedia(string id) {
            return new InstagramMediaListResponse(Raw.GetRecentMedia(id));
        }

        /// <summary>
        /// Gets a list of recent media of the Instagram user with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the Instagram user.</param>
        /// <param name="fields">The fields to be returned by the API.</param>
        /// <returns>An instance of <see cref="InstagramMediaListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-api/reference/user/media#get-media</cref>
        /// </see>
        public InstagramMediaListResponse GetRecentMedia(string id, InstagramFieldsCollection fields) {
            return new InstagramMediaListResponse(Raw.GetRecentMedia(id, fields));
        }

        /// <summary>
        /// Gets a list of recent media of the Instagram user with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the Instagram user.</param>
        /// <param name="limit">The maximum amount of media that should be returned in each page.</param>
        /// <param name="after">The fields to be returned by the API.</param>
        /// <param name="fields">The fields to be returned by the API.</param>
        /// <returns>An instance of <see cref="InstagramMediaListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-api/reference/user/media#get-media</cref>
        /// </see>
        public InstagramMediaListResponse GetRecentMedia(string id, int limit, string after, InstagramFieldsCollection fields) {
            return new InstagramMediaListResponse(Raw.GetRecentMedia(id, limit, after, fields));
        }

        /// <summary>
        /// Gets a list of recent media of the Instagram user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">THe options for the request to the API.</param>
        /// <returns>An instance of <see cref="InstagramMediaListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-api/reference/user/media#get-media</cref>
        /// </see>
        public InstagramMediaListResponse GetRecentMedia(InstagramGetRecentMediaOptions options) {
            return new InstagramMediaListResponse(Raw.GetRecentMedia(options));
        }

        #endregion

    }

}