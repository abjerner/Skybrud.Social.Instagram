using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.Models.Common;
using Skybrud.Social.Instagram.Models.Media;
using Skybrud.Social.Instagram.Models.Pagination;

namespace Skybrud.Social.Instagram.Models.Users {
    
    /// <summary>
    /// Class representing the response body of a call for getting a list of recent media.
    /// </summary>
    public class InstagramGetUserRecentMediaEnvelope : InstagramEnvelope<InstagramMedia[]> {

        #region Properties

        /// <summary>
        /// Gets pagination information of the response.
        /// </summary>
        public InstagramIdBasedPagination Pagination { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramGetUserRecentMediaEnvelope(JObject obj) : base(obj) {
            Pagination = obj.GetObject("pagination", InstagramIdBasedPagination.Parse);
            Data = obj.GetArray("data", InstagramMedia.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramGetUserRecentMediaEnvelope"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="InstagramGetUserRecentMediaEnvelope"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramGetUserRecentMediaEnvelope"/>.</returns>
        public static InstagramGetUserRecentMediaEnvelope Parse(JObject obj) {
            return obj == null ? null : new InstagramGetUserRecentMediaEnvelope(obj);
        }

        #endregion

    }

}