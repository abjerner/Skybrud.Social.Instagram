using System;
using Skybrud.Essentials.Http;

namespace Skybrud.Social.Instagram.Models.Common {
    
    /// <summary>
    /// Class with rate-limiting information about a response from the Instagram API.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/limits/</cref>
    /// </see>
    public class InstagramRateLimiting {

        #region Properties

        /// <summary>
        /// Gets the total number of calls allowed within the current 1-hour window.
        /// </summary>
        public int Limit { get; }

        /// <summary>
        /// Gets the remaining number of calls available to your app within the current 1-hour window.
        /// </summary>
        public int Remaining { get; }

        #endregion

        #region Constructors

        private InstagramRateLimiting(int limit, int remaining) {
            Limit = limit;
            Remaining = remaining;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses rate-limiting information from the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The response that holds the rate-limiting information.</param>
        /// <returns>Returns an instance of <see cref="InstagramRateLimiting"/>.</returns>
        public static InstagramRateLimiting GetFromResponse(IHttpResponse response) {

            if (!int.TryParse(response.Headers["X-Ratelimit-Limit"] ?? string.Empty, out int limit)) {
                limit = -1;
            }

            if (!int.TryParse(response.Headers["X-Ratelimit-Remaining"] ?? string.Empty, out int remaining)) {
                remaining = -1;
            }

            return new InstagramRateLimiting(limit, remaining);

        }

        #endregion

    }

}