using System;
using Skybrud.Social.Instagram.Graph.Endpoints;
using Skybrud.Social.Instagram.Graph.OAuth;

namespace Skybrud.Social.Instagram.Graph {

    /// <summary>
    /// Class representing the object oriented implementation of the <strong>Instagram Graph API</strong>.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/instagram-api</cref>
    /// </see>
    public class InstagramGraphService {

        #region Properties

        /// <summary>
        /// Gets a reference to the internal OAuth client for communication with the <strong>Instagram Graph API</strong>.
        /// </summary>
        public InstagramOAuthClient Client { get; }

        /// <summary>
        /// Gets a reference to the <strong>User</strong> endpoint.
        /// </summary>
        public InstagramUsersEndpoint Users { get; }

        #endregion

        #region Constructors

        private InstagramGraphService(InstagramOAuthClient client) {
            Client = client;
            Users = new InstagramUsersEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initializes a new service instance from the specified <paramref name="accessToken"/>. Internally a new
        /// OAuth client will be initialized from the access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        public static InstagramGraphService CreateFromAccessToken(string accessToken) {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));
            return new InstagramGraphService(new InstagramOAuthClient(accessToken));
        }

        /// <summary>
        /// Initializes a new service instance from the specified OAuth <paramref name="client"/>.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        public static InstagramGraphService CreateFromOAuthClient(InstagramOAuthClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return new InstagramGraphService(client);
        }

        #endregion

    }

}