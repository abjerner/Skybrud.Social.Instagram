using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.Models.Common;
using Skybrud.Social.Instagram.Models.Media;
using Skybrud.Social.Instagram.Models.Pagination;

namespace Skybrud.Social.Instagram.Models.Tags {
    
    /// <summary>
    /// Class representing the response body of a call for getting a list of recent media.
    /// </summary>
    public class InstagramGetTagRecentMediaEnvelope : InstagramEnvelope<InstagramMedia[]> {

        #region Properties

        /// <summary>
        /// Gets pagination information of the response.
        /// </summary>
        public InstagramTagIdBasedPagination Pagination { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramGetTagRecentMediaEnvelope(JObject obj) : base(obj) {
            Pagination = obj.GetObject("pagination", InstagramTagIdBasedPagination.Parse);
            Data = obj.GetArray("data", InstagramMedia.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramGetTagRecentMediaEnvelope"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="InstagramGetTagRecentMediaEnvelope"/>.</returns>
        public static InstagramGetTagRecentMediaEnvelope Parse(JObject obj) {
            return obj == null ? null : new InstagramGetTagRecentMediaEnvelope(obj);
        }

        #endregion

    }

}