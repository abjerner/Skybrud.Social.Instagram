using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.BasicDisplay.Fields;
using Skybrud.Social.Instagram.BasicDisplay.Options;
using Skybrud.Social.Instagram.BasicDisplay.Responses.Media;
using Skybrud.Social.Instagram.BasicDisplay.Responses.Users;

namespace Skybrud.Social.Instagram.BasicDisplay.Endpoints {

    /// <summary>
    /// Class representing the implementation of the <strong>Users</strong> endpoint.
    /// </summary>
    public class InstagramUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram OAuth service.
        /// </summary>
        public InstagramBasicDisplayService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public InstagramUsersRawEndpoint Raw => Service.Client.Users;

        #endregion

        #region Constructors

        internal InstagramUsersEndpoint(InstagramBasicDisplayService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get fields and edges on the User whose Instagram User Access Token is being used in the query.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/me</cref>
        /// </see>
        public InstagramUserResponse GetUser() {
            return new InstagramUserResponse(Raw.GetUser());
        }

        /// <summary>
        /// Get fields and edges on the User whose Instagram User Access Token is being used in the query.
        /// </summary>
        /// <param name="fields">The fields that should be returned by the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/me</cref>
        /// </see>
        public InstagramUserResponse GetUser(InstagramFieldList? fields)  {
            return new InstagramUserResponse(Raw.GetUser(fields));
        }

        /// <summary>
        /// Get fields and edges on a User.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="InstagramUserResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/user</cref>
        /// </see>
        public InstagramUserResponse GetUser(long userId) {
            return new InstagramUserResponse(Raw.GetUser(userId));
        }

        /// <summary>
        /// Get fields and edges on a User.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="fields">The fields that should be returned by the API.</param>
        /// <returns>An instance of <see cref="InstagramUserResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/user</cref>
        /// </see>
        public InstagramUserResponse GetUser(long userId, InstagramFieldList? fields) {
            return new InstagramUserResponse(Raw.GetUser(userId, fields));
        }

        /// <summary>
        /// Gets information about the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="InstagramUserResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/user</cref>
        /// </see>
        public InstagramUserResponse GetUser(InstagramGetUserOptions options) {
            return new InstagramUserResponse(Raw.GetUser(options));
        }

        /// <summary>
        /// Gets recent media of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="InstagramMediaListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/user/media</cref>
        /// </see>
        public InstagramMediaListResponse GetMedia(InstagramGetUserMediaOptions options) {
            return new InstagramMediaListResponse(Raw.GetMedia(options));
        }

        #endregion

    }

}