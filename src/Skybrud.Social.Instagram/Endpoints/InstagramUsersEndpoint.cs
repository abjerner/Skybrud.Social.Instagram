using System.Globalization;
using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Options.Users;
using Skybrud.Social.Instagram.Responses.Users;

namespace Skybrud.Social.Instagram.Endpoints {

    /// <summary>
    /// Class representing the implementation of the users endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/</cref>
    /// </see>
    public class InstagramUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram service.
        /// </summary>
        public InstagramService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public InstagramUsersRawEndpoint Raw {
            get { return Service.Client.Users; }
        }

        #endregion

        #region Constructors

        internal InstagramUsersEndpoint(InstagramService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        public InstagramGetUserResponse GetSelf() {
            return InstagramGetUserResponse.ParseResponse(Raw.GetUser("self"));
        }
        
        /// <summary>
        /// Gets information about the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public InstagramGetUserResponse GetUser(long userId) {
            return InstagramGetUserResponse.ParseResponse(Raw.GetUser(userId.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Gets the the most recent media of the authenticated user.
        /// </summary>
        public InstagramGetUserRecentMediaResponse GetRecentMedia() {
            return InstagramGetUserRecentMediaResponse.ParseResponse(Raw.GetRecentMedia());
        }

        /// <summary>
        /// Gets the most recent media of the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public InstagramGetUserRecentMediaResponse GetRecentMedia(long userId) {
            return InstagramGetUserRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(userId));
        }

        /// <summary>
        /// Gets the most recent media of the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of media to be returned.</param>
        public InstagramGetUserRecentMediaResponse GetRecentMedia(long userId, int count) {
            return InstagramGetUserRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(userId, count));
        }

        /// <summary>
        /// Gets the most recent media of the user matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The search options for the call to the API.</param>
        public InstagramGetUserRecentMediaResponse GetRecentMedia(InstagramGetUserRecentMediaOptions options) {
            return InstagramGetUserRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(options));
        }

        /// <summary>
        /// Gets a list of media liked by the authenticated user.
        /// </summary>
        public InstagramGetUserLikedMediaResponse GetLikedMedia() {
            return InstagramGetUserLikedMediaResponse.ParseResponse(Raw.GetLikedMedia());
        }

        /// <summary>
        /// Gets a list of media liked by the authenticated user.
        /// </summary>
        /// <param name="count">The maximum amount of media to be returned.</param>
        public InstagramGetUserLikedMediaResponse GetLikedMedia(int count) {
            return InstagramGetUserLikedMediaResponse.ParseResponse(Raw.GetLikedMedia(count));
        }

        /// <summary>
        /// Gets a list of media liked by the authenticated user.
        /// </summary>
        /// <param name="options">The search options with any optional parameters.</param>
        public InstagramGetUserLikedMediaResponse GetLikedMedia(InstagramGetUserLikedMediaOptions options) {
            return InstagramGetUserLikedMediaResponse.ParseResponse(Raw.GetLikedMedia(options));
        }

        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="query">A query string.</param>
        public InstagramSearchUsersResponse Search(string query) {
            return InstagramSearchUsersResponse.ParseResponse(Raw.Search(query));
        }

        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="query">A query string.</param>
        /// <param name="count">The maximum amount of users to be returned.</param>
        public InstagramSearchUsersResponse Search(string query, int count) {
            return InstagramSearchUsersResponse.ParseResponse(Raw.Search(query, count));
        }

        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public InstagramSearchUsersResponse Search(InstagramGetUserSearchOptions options) {
            return InstagramSearchUsersResponse.ParseResponse(Raw.Search(options));
        }

        #endregion

    }

}