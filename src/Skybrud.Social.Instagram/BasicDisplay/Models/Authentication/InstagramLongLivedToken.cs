using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Instagram.BasicDisplay.Models.Authentication {

    /// <summary>
    /// Class with information about a long-lived access token.
    /// </summary>
    public class InstagramLongLivedToken : InstagramToken {

        #region Properties

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

        private InstagramLongLivedToken(JObject json) : base(json)  {
            TokenType = json.GetString("token_type")!;
            ExpiresIn = json.GetDouble("expires_in", TimeSpan.FromSeconds);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="InstagramLongLivedToken"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="InstagramLongLivedToken"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static InstagramLongLivedToken? Parse(JObject? json) {
            return json == null ? null : new InstagramLongLivedToken(json);
        }

        #endregion

    }

}