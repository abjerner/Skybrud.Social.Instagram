using Skybrud.Social.Instagram.OAuth;

// ReSharper disable InconsistentNaming

namespace Skybrud.Social.Instagram.Endpoints.Graph {

    /// <summary>
    /// Class representing the raw implementation of the Instagram Graph API.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/instagram-api/reference</cref>
    /// </see>
    public class InstagramGraphRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public InstagramOAuthClient Client { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>User</strong> endpoint.
        /// </summary>
        public InstagramUsersRawEndpoint Users { get; }

        #endregion

        #region Constructors

        internal InstagramGraphRawEndpoint(InstagramOAuthClient client) {
            Client = client;
            Users = new InstagramUsersRawEndpoint(client);
        }

        #endregion

    }

}