using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.Models.Common;

namespace Skybrud.Social.Instagram.Models.Users {
    
    /// <summary>
    /// Class representing the response of a request for getting information about a given user.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users</cref>
    /// </see>
    public class InstagramGetUserEnvelope : InstagramEnvelope<InstagramUser> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramGetUserEnvelope(JObject obj) : base(obj) {
            Data = obj.GetObject("data", InstagramUser.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramGetUserEnvelope"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramGetUserEnvelope"/>.</returns>
        public static InstagramGetUserEnvelope Parse(JObject obj) {
            return obj == null ? null : new InstagramGetUserEnvelope(obj);
        }

        #endregion

    }

}