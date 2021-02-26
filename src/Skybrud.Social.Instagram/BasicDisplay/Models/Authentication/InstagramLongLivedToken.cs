using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.Models;

namespace Skybrud.Social.Instagram.BasicDisplay.Models.Authentication {
    
    /// <summary>
    /// Class with information about a long-lived access token.
    /// </summary>
    public class InstagramLongLivedToken : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the access token.
        /// </summary>
        public string AccessToken { get; }

        /// <summary>
        /// Gets the type of the token. Most likely this will always be <c>bearer</c>.
        /// </summary>
        public string TokenType { get; }

        /// <summary>
        /// Gets an instance of <see cref="TimeSpan"/> representing the time until the access token will expire.
        /// </summary>
        public TimeSpan ExpiresIn { get; }

        #endregion

        #region Constructors

        private InstagramLongLivedToken(JObject obj) : base(obj)  {
            AccessToken = obj.GetString("access_token");
            TokenType = obj.GetString("token_type");
            ExpiresIn = obj.GetDouble("expires_in", TimeSpan.FromSeconds);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramLongLivedToken"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="InstagramLongLivedToken"/>.</returns>
        public static InstagramLongLivedToken Parse(JObject obj) {
            return obj == null ? null : new InstagramLongLivedToken(obj);
        }

        #endregion

    }

}