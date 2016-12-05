using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Objects.Pagination {

    /// <summary>
    /// Class representing pagination information for an ID based pagination.
    /// </summary>
    public class InstagramIdBasedPagination : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the URL of the next page.
        /// </summary>
        public string NextUrl { get; set; }

        /// <summary>
        /// Gets the ID of the first item og the next page.
        /// </summary>
        public string NextMaxId { get; set; }

        #endregion

        #region Constructors

        private InstagramIdBasedPagination(JObject obj) : base(obj) {
            NextUrl = obj.GetString("next_url");
            NextMaxId = obj.GetString("next_max_id");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramIdBasedPagination"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramIdBasedPagination"/>.</returns>
        public static InstagramIdBasedPagination Parse(JObject obj) {
            return obj == null ? null : new InstagramIdBasedPagination(obj);
        }

        #endregion

    }

}