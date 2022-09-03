using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.BasicDisplay.Models.Authentication {

    /// <summary>
    /// Class with information about a short-lived access token.
    /// </summary>
    public class InstagramShortLivedToken : InstagramToken {

        #region Properties

        /// <summary>
        /// Gets the ID of the authenticated user.
        /// </summary>
        public long UserId { get; }

        #endregion

        #region Constructors

        private InstagramShortLivedToken(JObject json) : base(json) {
            UserId = json.GetInt64("user_id");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="InstagramShortLivedToken"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="InstagramLongLivedToken"/>.</returns>
        public static InstagramShortLivedToken Parse(JObject json) {
            return json == null ? null : new InstagramShortLivedToken(json);
        }

        #endregion

    }

}