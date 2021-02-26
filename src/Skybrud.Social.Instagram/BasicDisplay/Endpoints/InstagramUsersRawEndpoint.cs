using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.BasicDisplay.Fields;
using Skybrud.Social.Instagram.BasicDisplay.OAuth;
using Skybrud.Social.Instagram.BasicDisplay.Options;

namespace Skybrud.Social.Instagram.BasicDisplay.Endpoints {

    /// <summary>
    /// Class representing the raw implementation of the <strong>Users</strong> endpoint.
    /// </summary>
    public class InstagramUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram OAuth client.
        /// </summary>
        public InstagramBasicDisplayClient Client { get; }

        #endregion

        #region Constructors

        internal InstagramUsersRawEndpoint(InstagramBasicDisplayClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get fields and edges on the User whose Instagram User Access Token is being used in the query.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/me</cref>
        /// </see>
        public IHttpResponse GetUser() {
            return GetUser(new InstagramGetUserOptions());
        }

        /// <summary>
        /// Get fields and edges on the User whose Instagram User Access Token is being used in the query.
        /// </summary>
        /// <param name="fields">The fields that should be returned by the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/me</cref>
        /// </see>
        public IHttpResponse GetUser(InstagramFieldList fields) {
            return GetUser(new InstagramGetUserOptions(fields));
        }

        /// <summary>
        /// Get fields and edges on a User.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/user</cref>
        /// </see>
        public IHttpResponse GetUser(long userId) {
            return GetUser(new InstagramGetUserOptions(userId));
        }

        /// <summary>
        /// Get fields and edges on a User.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="fields">The fields that should be returned by the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/user</cref>
        /// </see>
        public IHttpResponse GetUser(long userId, InstagramFieldList fields) {
            return GetUser(new InstagramGetUserOptions(userId, fields));
        }

        /// <summary>
        /// Gets information about the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/user</cref>
        /// </see>
        public IHttpResponse GetUser(InstagramGetUserOptions options)  {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets recent media of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/user/media</cref>
        /// </see>
        public IHttpResponse GetMedia(InstagramGetUserMediaOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}