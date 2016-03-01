using System;
using Skybrud.Social.Exceptions;
using Skybrud.Social.Http;
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
        /// Get the list of users this user follows.
        /// 
        /// Required scope: relationships
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_follows</cref>
        /// </see>
        public SocialHttpResponse Follows(InstagramGetFollowsOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            if (options.UserId == 0) throw new PropertyNotSetException("options.UserId");
            return Client.DoHttpGetRequest("https://api.instagram.com/v1/users/" + options.UserId + "/follows", options);
        }

        /// <summary>
        /// Get the list of users this user is followed by.
        /// 
        /// Required scope: relationships
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_followed_by</cref>
        /// </see>
        public SocialHttpResponse FollowedBy(InstagramGetFollowedByOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            if (options.UserId == 0) throw new PropertyNotSetException("options.UserId");
            return Client.DoHttpGetRequest("https://api.instagram.com/v1/users/" + options.UserId + "/followed-by", options);
        }

        #endregion

    }

}