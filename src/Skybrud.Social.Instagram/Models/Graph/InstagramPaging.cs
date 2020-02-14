using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Models.Graph {

    /// <summary>
    /// Class with pagination information about an Instagram list.
    /// </summary>
    public class InstagramPaging : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the URL for the next page.
        /// </summary>
        public string Next { get; }

        /// <summary>
        /// Gets the <see cref="Next"/> property was specified in the response.
        /// </summary>
        public bool HasNext => string.IsNullOrWhiteSpace(Next) == false;

        /// <summary>
        /// Gets the URL for the previous page.
        /// </summary>
        public string Previous { get; set; }

        /// <summary>
        /// Gets the <see cref="Previous"/> property was specified in the response.
        /// </summary>
        public bool HasPrevious => string.IsNullOrWhiteSpace(Previous) == false;

        /// <summary>
        /// Gets a reference to the cursors for the next and previous page correspondingly.
        /// </summary>
        public InstagramPagingCursors Cursors { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the entry.</param>
        protected InstagramPaging(JObject obj) : base(obj) {
            Cursors = obj.GetObject("cursors", InstagramPagingCursors.Parse);
            Next = obj.GetString("next");
            Previous = obj.GetString("previous");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramPaging"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramPaging"/>.</returns>
        public static InstagramPaging Parse(JObject obj) {
            return obj == null ? null : new InstagramPaging(obj);
        }

        #endregion

    }

}