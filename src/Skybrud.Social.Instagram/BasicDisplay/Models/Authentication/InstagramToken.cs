using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.BasicDisplay.Models.Authentication {

    /// <summary>
    /// Class with information about an Instagram access token.
    /// </summary>
    public class InstagramToken : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the access token.
        /// </summary>
        public string AccessToken { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected InstagramToken(JObject json) : base(json) {
            AccessToken = json.GetString("access_token");
        }

        #endregion

    }

}