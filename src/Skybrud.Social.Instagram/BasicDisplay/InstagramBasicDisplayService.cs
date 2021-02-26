using System;
using Skybrud.Social.Instagram.BasicDisplay.Endpoints;
using Skybrud.Social.Instagram.OAuth;

namespace Skybrud.Social.Instagram.BasicDisplay {

    /// <summary>
    /// Class representing the object oriented implementation of the <strong>Instagram Basic Display API</strong>.
    /// </summary>
    public class InstagramBasicDisplayService {

        #region Properties

        /// <summary>
        /// Gets a reference to the internal OAuth client for communication with the <strong>Instagram Basic Display API</strong>.
        /// </summary>
        public InstagramBasicDisplayClient Client { get; }

        /// <summary>
        /// Gets a reference to the <strong>Users</strong> endpoint.
        /// </summary>
        public InstagramUsersEndpoint Users { get; }

        #endregion

        #region Constructors

        private InstagramBasicDisplayService(InstagramBasicDisplayClient client) {
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
        public static InstagramBasicDisplayService CreateFromAccessToken(string accessToken) {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));
            return new InstagramBasicDisplayService(new InstagramBasicDisplayClient(accessToken));
        }

        /// <summary>
        /// Initializes a new service instance from the specified OAuth <paramref name="client"/>.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        public static InstagramBasicDisplayService CreateFromOAuthClient(InstagramBasicDisplayClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return new InstagramBasicDisplayService(client);
        }

        #endregion

    }

}