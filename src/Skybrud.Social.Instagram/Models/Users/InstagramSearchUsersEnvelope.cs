using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.Models.Common;

namespace Skybrud.Social.Instagram.Models.Users {
    
    /// <summary>
    /// Class representing the response body of a request for getting a list of users.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_search</cref>
    ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_follows</cref>
    ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_followed_by</cref>
    /// </see>
    public class InstagramSearchUsersEnvelope : InstagramEnvelope<InstagramUserSummary[]> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramSearchUsersEnvelope(JObject obj) : base(obj) {
            Data = obj.GetArray("data", InstagramUserSummary.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramSearchUsersEnvelope"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramSearchUsersEnvelope"/>.</returns>
        public static InstagramSearchUsersEnvelope Parse(JObject obj) {
            return obj == null ? null : new InstagramSearchUsersEnvelope(obj);
        }

        #endregion

    }

}