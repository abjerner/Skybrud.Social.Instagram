using System;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Options.Users;

namespace Skybrud.Social.Instagram.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the users endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/</cref>
    /// </see>
    public class InstagramUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram OAuth client.
        /// </summary>
        public InstagramOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal InstagramUsersRawEndpoint(InstagramOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the user with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier of the user.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/users/#get_users</cref>
        /// </see>
        public SocialHttpResponse GetUser(string identifier) {
            if (String.IsNullOrWhiteSpace(identifier)) throw new ArgumentNullException("identifier");
            return Client.DoHttpGetRequest("https://api.instagram.com/v1/users/" + identifier + "/");
        }

        /// <summary>
        /// Gets the feed of the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_feed</cref>
        /// </see>
        public SocialHttpResponse GetUserFeed() {
            return GetUserFeed(new InstagramGetUserFeedOptions());
        }

        /// <summary>
        /// Gets the feed of the authenticated user.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_feed</cref>
        /// </see>
        public SocialHttpResponse GetUserFeed(InstagramGetUserFeedOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoHttpGetRequest("https://api.instagram.com/v1/users/self/feed", options);
        }
        
        /// <summary>
        /// Gets the most recent media of the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_media_recent</cref>
        /// </see>
        public SocialHttpResponse GetRecentMedia() {
            return GetRecentMedia(new InstagramGetUserRecentMediaOptions());
        }

        /// <summary>
        /// Gets the most recent media published by the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_media_recent</cref>
        /// </see>
        public SocialHttpResponse GetRecentMedia(long userId) {
            return GetRecentMedia(new InstagramGetUserRecentMediaOptions(userId));
        }

        /// <summary>
        /// Gets the most recent media published by the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of media to be returned.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_media_recent</cref>
        /// </see>
        public SocialHttpResponse GetRecentMedia(long userId, int count) {
            return GetRecentMedia(new InstagramGetUserRecentMediaOptions(userId, count));
        }

        /// <summary>
        /// Gets the most recent media of the user mathcing the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The search options for the call to the API.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_media_recent</cref>
        /// </see>
        public SocialHttpResponse GetRecentMedia(InstagramGetUserRecentMediaOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoHttpGetRequest("https://api.instagram.com/v1/users/" + (options.UserId == 0 ? "self" : options.UserId + "") + "/media/recent/", options);
        }

        /// <summary>
        /// Gets a list of media liked by the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_feed_liked</cref>
        /// </see>
        public SocialHttpResponse GetLikedMedia() {
            return Client.DoHttpGetRequest("https://api.instagram.com/v1/users/self/media/liked");
        }

        /// <summary>
        /// Gets a list of media liked by the authenticated user.
        /// </summary>
        /// <param name="count">The maximum amount of media to be returned.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_feed_liked</cref>
        /// </see>
        public SocialHttpResponse GetLikedMedia(int count) {
            return GetLikedMedia(new InstagramGetUserLikedMediaOptions {
                Count = count
            });
        }

        /// <summary>
        /// Gets a list of media liked by the authenticated user.
        /// </summary>
        /// <param name="options">The search options with any optional parameters.</param>
        /// <returns>Returns the raw JSON response from the API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_feed_liked</cref>
        /// </see>
        public SocialHttpResponse GetLikedMedia(InstagramGetUserLikedMediaOptions options) {
            return Client.DoHttpGetRequest("https://api.instagram.com/v1/users/self/media/liked", options);
        }

        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="query">A query string.</param>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_search</cref>
        /// </see>
        public SocialHttpResponse Search(string query) {
            return Search(new InstagramGetUserSearchOptions {
                Query = query
            });
        }
        
        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="query">A query string.</param>
        /// <param name="count">The maximum amount of users to be returned.</param>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_search</cref>
        /// </see>
        public SocialHttpResponse Search(string query, int count) {
            return Search(new InstagramGetUserSearchOptions {
                Query = query,
                Count = count
            });
        }
        
        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_search</cref>
        /// </see>
        public SocialHttpResponse Search(InstagramGetUserSearchOptions options) {
            return Client.DoHttpGetRequest("https://api.instagram.com/v1/users/search", options);
        }

        #endregion

    }

}