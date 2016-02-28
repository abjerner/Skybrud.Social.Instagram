using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Instagram.Objects {
    
    /// <summary>
    /// Class representing the response body of a call to exchange an authorization code for an access token.
    /// </summary>
    public class InstagramAccessTokenSummary : InstagramObject {

        #region Properties
        
        /// <summary>
        /// Gets the access token.
        /// </summary>
        public string AccessToken { get; private set; }
        
        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        public InstagramUser User { get; private set; }

        #endregion

        #region Constructors

        private InstagramAccessTokenSummary(JObject obj) : base(obj) {
            AccessToken = obj.GetString("access_token");
            User = obj.GetObject("user", InstagramUser.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="InstagramAccessTokenSummary"/> from the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>Returns an instance of <see cref="InstagramAccessTokenSummary"/>.</returns>
        public static InstagramAccessTokenSummary Parse(JObject obj) {
            return obj == null ? null : new InstagramAccessTokenSummary(obj);
        }

        #endregion

    }

}