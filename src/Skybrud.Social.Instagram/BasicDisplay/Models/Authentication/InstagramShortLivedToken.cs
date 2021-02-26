using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.Models;

namespace Skybrud.Social.Instagram.BasicDisplay.Models.Authentication {
    
    /// <summary>
    /// Class with information about a short-lived access token.
    /// </summary>
    public class InstagramShortLivedToken : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the access token.
        /// </summary>
        public string AccessToken { get; }

        /// <summary>
        /// Gets the ID of the authenticated user.
        /// </summary>
        public long UserId { get; }

        #endregion

        #region Constructors

        private InstagramShortLivedToken(JObject obj) : base(obj)  {
            AccessToken = obj.GetString("access_token");
            UserId = obj.GetInt64("user_id");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramShortLivedToken"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="InstagramLongLivedToken"/>.</returns>
        public static InstagramShortLivedToken Parse(JObject obj) {
            return obj == null ? null : new InstagramShortLivedToken(obj);
        }

        #endregion

    }

}