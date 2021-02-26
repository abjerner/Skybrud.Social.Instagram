using System;
using Skybrud.Social.Instagram.Endpoints.Graph;
using Skybrud.Social.Instagram.OAuth;

namespace Skybrud.Social.Instagram {
    
    /// <summary>
    /// Class representing the object oriented implementation of the Instagram API.
    /// </summary>
    public class InstagramService {

        #region Properties

        /// <summary>
        /// Gets a reference to the internal OAuth client for communication with the Instagram API.
        /// </summary>
        public InstagramOAuthClient Client { get; }
        
        /// <summary>
        /// Gets a reference to the <strong>Instagram Graph API</strong> endpoint.
        /// </summary>
        public InstagramGraphEndpoint Graph { get; }

        #endregion

        #region Constructors

        private InstagramService(InstagramOAuthClient client) {
            Client = client;
            Graph = new InstagramGraphEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initializes a new service instance from the specified <paramref name="accessToken"/>. Internally a new
        /// OAuth client will be initialized from the access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        public static InstagramService CreateFromAccessToken(string accessToken) {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));
            return new InstagramService(new InstagramOAuthClient(accessToken));
        }

        /// <summary>
        /// Initializes a new service instance from the specified OAuth <paramref name="client"/>.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        public static InstagramService CreateFromOAuthClient(InstagramOAuthClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return new InstagramService(client);
        }

        #endregion

    }

}