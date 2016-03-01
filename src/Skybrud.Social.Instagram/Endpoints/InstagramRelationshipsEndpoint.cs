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
        /// Get the list of users this user follows.
        /// 
        /// Required scope: <code>relationships</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public InstagramGetUsersResponse Follows(long userId) {
            return Follows(new InstagramGetFollowsOptions(userId));
        }

        /// <summary>
        /// Get the list of users this user follows.
        /// 
        /// Required scope: <code>relationships</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of users to return.</param>
        public InstagramGetUsersResponse Follows(long userId, int count) {
            return Follows(new InstagramGetFollowsOptions(userId, count));
        }

        /// <summary>
        /// Get the list of users this user follows.
        /// 
        /// Required scope: <code>relationships</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public InstagramGetUsersResponse Follows(InstagramGetFollowsOptions options) {
            return InstagramGetUsersResponse.ParseResponse(Raw.Follows(options));
        }

        /// <summary>
        /// Get the list of users this user is followed by.
        /// 
        /// Required scope: <code>relationships</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public InstagramGetUsersResponse FollowedBy(long userId) {
            return FollowedBy(new InstagramGetFollowedByOptions(userId));
        }

        /// <summary>
        /// Get the list of users this user is followed by.
        /// 
        /// Required scope: <code>relationships</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of users to return.</param>
        public InstagramGetUsersResponse FollowedBy(long userId, int count) {
            return FollowedBy(new InstagramGetFollowedByOptions(userId, count));
        }

        /// <summary>
        /// Get the list of users this user is followed by.
        /// 
        /// Required scope: <code>relationships</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public InstagramGetUsersResponse FollowedBy(InstagramGetFollowedByOptions options) {
            return InstagramGetUsersResponse.ParseResponse(Raw.FollowedBy(options));
        }

        #endregion

    }

}