using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Options.Relationships;
using Skybrud.Social.Instagram.Responses.Users;

namespace Skybrud.Social.Instagram.Endpoints {

    /// <summary>
    /// Class representing the implementation of the relationships endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/relationships/</cref>
    /// </see>
    public class InstagramRelationshipsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram service.
        /// </summary>
        public InstagramService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public InstagramRelationshipsRawEndpoint Raw {
            get { return Service.Client.Relationships; }
        }

        #endregion

        #region Constructors

        internal InstagramRelationshipsEndpoint(InstagramService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get a list of users the authenticated user follows. Requires the <code>follower_list</code> scope.
        /// </summary>
        /// <returns>An instance of <see cref="InstagramGetUsersResponse"/> representing the response.</returns>
        public InstagramGetUsersResponse Follows() {
            return InstagramGetUsersResponse.ParseResponse(Raw.Follows());
        }

        /// <summary>
        /// Get a list of users the user with the specified <paramref name="userId"/> follows. Requires the <code>follower_list</code> scope.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="InstagramGetUsersResponse"/> representing the response.</returns>
        public InstagramGetUsersResponse Follows(long userId) {
            return Follows(new InstagramGetFollowsOptions(userId));
        }

        /// <summary>
        /// Get a list of users the user with the specified <paramref name="userId"/> follows. Requires the <code>follower_list</code> scope.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of users to be returned.</param>
        /// <returns>An instance of <see cref="InstagramGetUsersResponse"/> representing the response.</returns>
        public InstagramGetUsersResponse Follows(long userId, int count) {
            return InstagramGetUsersResponse.ParseResponse(Raw.Follows(userId, count));
        }

        /// <summary>
        /// Get a list of users the user matching the specified <paramref name="options"/> follows. Requires the <code>follower_list</code> scope.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="InstagramGetUsersResponse"/> representing the response.</returns>
        public InstagramGetUsersResponse Follows(InstagramGetFollowsOptions options) {
            return InstagramGetUsersResponse.ParseResponse(Raw.Follows(options));
        }

        /// <summary>
        /// Get the list of users following the authenticated user. Requires the <code>follower_list</code> scope.
        /// </summary>
        /// <returns>An instance of <see cref="InstagramGetUsersResponse"/> representing the response.</returns>
        public InstagramGetUsersResponse FollowedBy() {
            return InstagramGetUsersResponse.ParseResponse(Raw.FollowedBy());
        }

        /// <summary>
        /// Get the list of users following the user with the specified <paramref name="userId"/>. Requires the <code>follower_list</code> scope.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="InstagramGetUsersResponse"/> representing the response.</returns>
        public InstagramGetUsersResponse FollowedBy(long userId) {
            return InstagramGetUsersResponse.ParseResponse(Raw.FollowedBy(userId));
        }

        /// <summary>
        /// Get the list of users following the user with the specified <paramref name="userId"/>. Requires the <code>follower_list</code> scope.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of users to be returned.</param>
        /// <returns>An instance of <see cref="InstagramGetUsersResponse"/> representing the response.</returns>
        public InstagramGetUsersResponse FollowedBy(long userId, int count) {
            return InstagramGetUsersResponse.ParseResponse(Raw.FollowedBy(userId, count));
        }

        /// <summary>
        /// Get a list of users following the user matching the specified <paramref name="options"/>. Requires the <code>follower_list</code> scope.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="InstagramGetUsersResponse"/> representing the response.</returns>
        public InstagramGetUsersResponse FollowedBy(InstagramGetFollowedByOptions options) {
            return InstagramGetUsersResponse.ParseResponse(Raw.FollowedBy(options));
        }

        #endregion

    }

}