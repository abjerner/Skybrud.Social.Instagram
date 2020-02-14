// ReSharper disable InconsistentNaming

namespace Skybrud.Social.Instagram.Endpoints.Graph {

    /// <summary>
    /// Class representing the implementation of the Instagram Graph API.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/instagram-api/reference</cref>
    /// </see>
    public class InstagramGraphEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram service.
        /// </summary>
        public InstagramService Service { get; }

        /// <summary>
        /// Gets a reference to the <strong>User</strong> endpoint.
        /// </summary>
        public InstagramUsersEndpoint Users { get; }


        #endregion

        #region Constructors

        internal InstagramGraphEndpoint(InstagramService service) {
            Service = service;
            Users = new InstagramUsersEndpoint(service);
        }

        #endregion

    }

}