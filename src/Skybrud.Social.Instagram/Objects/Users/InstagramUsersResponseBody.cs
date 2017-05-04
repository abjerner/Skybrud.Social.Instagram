using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.Objects.Common;

namespace Skybrud.Social.Instagram.Objects.Users {
    
    /// <summary>
    /// Class representing the response body of a request for getting a list of users.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_search</cref>
    ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_follows</cref>
    ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_followed_by</cref>
    /// </see>
    public class InstagramUsersResponseBody : InstagramEnvelope<InstagramUserSummary[]> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramUsersResponseBody(JObject obj) : base(obj) {
            Data = obj.GetArray("data", InstagramUserSummary.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramUsersResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramUsersResponseBody"/>.</returns>
        public static InstagramUsersResponseBody Parse(JObject obj) {
            return obj == null ? null : new InstagramUsersResponseBody(obj);
        }

        #endregion

    }

}