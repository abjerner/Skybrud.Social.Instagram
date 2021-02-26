using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Graph.Models.Paging {

    /// <summary>
    /// Class with cursors for the previous page and next page respectively.
    /// </summary>
    public class InstagramPagingCursors : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the cursor for the previous page.
        /// </summary>
        public string Before { get; }

        /// <summary>
        /// Gets whether the <see cref="Before"/> cursor was present in the response.
        /// </summary>
        public bool HasBefore => string.IsNullOrWhiteSpace(Before) == false;

        /// <summary>
        /// Gets the cursor for the next page.
        /// </summary>
        public string After { get; }

        /// <summary>
        /// Gets whether the <see cref="After"/> cursor was present in the response.
        /// </summary>
        public bool HasAfter => string.IsNullOrWhiteSpace(After) == false;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the entry.</param>
        protected InstagramPagingCursors(JObject obj) : base(obj) {
            Before = obj.GetString("before");
            After = obj.GetString("after");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramPagingCursors"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramPagingCursors"/>.</returns>
        public static InstagramPagingCursors Parse(JObject obj) {
            return obj == null ? null : new InstagramPagingCursors(obj);
        }

        #endregion

    }

}