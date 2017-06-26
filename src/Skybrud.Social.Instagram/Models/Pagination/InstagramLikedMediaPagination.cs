using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Models.Pagination {

    /// <summary>
    /// Class representing pagination information.
    /// </summary>
    public class InstagramLikedMediaPagination : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the URL of the next page.
        /// </summary>
        public string NextUrl { get; set; }

        /// <summary>
        /// Gets the ID of the first item og the next page.
        /// </summary>
        public string NextMaxLikeId { get; set; }

        #endregion

        #region Constructors

        private InstagramLikedMediaPagination(JObject obj) : base(obj) {
            NextUrl = obj.GetString("next_url");
            NextMaxLikeId = obj.GetString("next_max_like_id");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramLikedMediaPagination"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramLikedMediaPagination"/>.</returns>
        public static InstagramLikedMediaPagination Parse(JObject obj) {
            return obj == null ? null : new InstagramLikedMediaPagination(obj);
        }

        #endregion

    }

}