using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Options.Relationships;

namespace Skybrud.Social.Instagram.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the relationships endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/relationships/</cref>
    /// </see>
    public class InstagramRelationshipsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram OAuth client.
        /// </summary>
        public InstagramOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal InstagramRelationshipsRawEndpoint(InstagramOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get a list of users the authenticated user follows. Requires the <code>follower_list</code> scope.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_follows</cref>
        /// </see>
        public IHttpResponse Follows() {
            return Client.Get("https://api.instagram.com/v1/users/self/follows");
        }

        /// <summary>
        /// Get a list of users the user with the specified <paramref name="userId"/> follows. Requires the <code>follower_list</code> scope.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_follows</cref>
        /// </see>
        public IHttpResponse Follows(long userId) {
            return Follows(new InstagramGetFollowsOptions(userId));
        }

        /// <summary>
        /// Get a list of users the user with the specified <paramref name="userId"/> follows. Requires the <code>follower_list</code> scope.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of users to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_follows</cref>
        /// </see>
        public IHttpResponse Follows(long userId, int count) {
            return Follows(new InstagramGetFollowsOptions(userId, count));
        }

        /// <summary>
        /// Get a list of users the user matching the specified <paramref name="options"/> follows. Requires the <code>follower_list</code> scope.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_follows</cref>
        /// </see>
        public IHttpResponse Follows(InstagramGetFollowsOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.Get("https://api.instagram.com/v1/users/" + options.Identifier + "/follows", options);
        }

        /// <summary>
        /// Get the list of users following the authenticated user. Requires the <code>follower_list</code> scope.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_followed_by</cref>
        /// </see>
        public IHttpResponse FollowedBy() {
            return Client.Get("https://api.instagram.com/v1/users/self/followed-by");
        }

        /// <summary>
        /// Get the list of users following the user with the specified <paramref name="userId"/>. Requires the <code>follower_list</code> scope.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_followed_by</cref>
        /// </see>
        public IHttpResponse FollowedBy(long userId) {
            return FollowedBy(new InstagramGetFollowedByOptions(userId));
        }

        /// <summary>
        /// Get the list of users following the user with the specified <paramref name="userId"/>. Requires the <code>follower_list</code> scope.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of users to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_followed_by</cref>
        /// </see>
        public IHttpResponse FollowedBy(long userId, int count) {
            return FollowedBy(new InstagramGetFollowedByOptions(userId, count));
        }

        /// <summary>
        /// Get a list of users following the user matching the specified <paramref name="options"/>. Requires the <code>follower_list</code> scope.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_followed_by</cref>
        /// </see>
        public IHttpResponse FollowedBy(InstagramGetFollowedByOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.Get("https://api.instagram.com/v1/users/" + options.Identifier + "/followed-by", options);
        }

        #endregion

    }

}