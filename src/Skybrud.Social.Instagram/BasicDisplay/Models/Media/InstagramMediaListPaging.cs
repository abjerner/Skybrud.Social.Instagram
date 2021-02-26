using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.BasicDisplay.Models.Users;

namespace Skybrud.Social.Instagram.BasicDisplay.Models.Media {

    /// <summary>
    /// Class representing the <c>paging</c> object of a media list.
    /// </summary>
    public class InstagramMediaListPaging : InstagramObject {

        #region Properties

        /// <summary>
        /// gets a reference to the cursors of the list.
        /// </summary>
        public InstagramMediaListCursors Cursors { get; }

        /// <summary>
        /// Gets the URL of the next page in the list.
        /// </summary>
        public string Next { get; }

        /// <summary>
        /// Gets whether the list has an additional page.
        /// </summary>
        public bool HasNext => string.IsNullOrWhiteSpace(Next) == false;

        #endregion

        #region Constructors

        private InstagramMediaListPaging(JObject obj) : base(obj) {
            Cursors = obj.GetObject("cursors", InstagramMediaListCursors.Parse);
            Next = obj.GetString("next");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="InstagramUser"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramUser"/>.</returns>
        public static InstagramMediaListPaging Parse(JObject obj) {
            return obj == null ? null : new InstagramMediaListPaging(obj);
        }

        #endregion

    }

}