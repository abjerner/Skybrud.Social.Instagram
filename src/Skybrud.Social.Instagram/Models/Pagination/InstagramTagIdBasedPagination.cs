using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Models.Pagination {

    /// <summary>
    /// Class representing pagination information for a tag ID based pagination.
    /// </summary>
    public class InstagramTagIdBasedPagination : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the URL of the next page.
        /// </summary>
        public string NextUrl { get; }

        /// <summary>
        /// Gets the ID of the first item og the next page.
        /// </summary>
        [Obsolete("Use NextMaxTagId instead.")]
        public string NextMaxId { get; }

        /// <summary>
        /// Gets the tag ID of the first item og the next page.
        /// </summary>
        public string NextMaxTagId { get; }

        #endregion

        #region Constructors

        private InstagramTagIdBasedPagination(JObject obj) : base(obj) {
            NextUrl = obj.GetString("next_url");
// ReSharper disable CSharpWarnings::CS0618
            NextMaxId = obj.GetString("next_max_id");
// ReSharper restore CSharpWarnings::CS0618
            NextMaxTagId = obj.GetString("next_max_tag_id");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramTagIdBasedPagination"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="InstagramTagIdBasedPagination"/>.</returns>
        public static InstagramTagIdBasedPagination Parse(JObject obj) {
            return obj == null ? null : new InstagramTagIdBasedPagination(obj);
        }

        #endregion

    }

}