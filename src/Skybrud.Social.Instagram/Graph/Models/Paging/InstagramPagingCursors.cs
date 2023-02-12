using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Instagram.Graph.Models.Paging {

    /// <summary>
    /// Class with cursors for the previous page and next page respectively.
    /// </summary>
    public class InstagramPagingCursors : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the cursor for the previous page.
        /// </summary>
        public string? Before { get; }

        /// <summary>
        /// Gets whether the <see cref="Before"/> cursor was present in the response.
        /// </summary>
        [MemberNotNullWhen(true, "Before")]
        public bool HasBefore => string.IsNullOrWhiteSpace(Before) == false;

        /// <summary>
        /// Gets the cursor for the next page.
        /// </summary>
        public string? After { get; }

        /// <summary>
        /// Gets whether the <see cref="After"/> cursor was present in the response.
        /// </summary>
        [MemberNotNullWhen(true, "After")]
        public bool HasAfter => string.IsNullOrWhiteSpace(After) == false;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the entry.</param>
        protected InstagramPagingCursors(JObject json) : base(json) {
            Before = json.GetString("before");
            After = json.GetString("after");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="InstagramPagingCursors"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramPagingCursors"/>. <paramref name="json"/> is <see langword="null"/>, <see langword="null"/> is returned instead.</returns>
        [return: NotNullIfNotNull("json")]
        public static InstagramPagingCursors? Parse(JObject? json) {
            return json == null ? null : new InstagramPagingCursors(json);
        }

        #endregion

    }

}