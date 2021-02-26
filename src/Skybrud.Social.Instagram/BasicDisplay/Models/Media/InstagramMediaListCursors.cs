using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.BasicDisplay.Models.Users;

namespace Skybrud.Social.Instagram.BasicDisplay.Models.Media {

    /// <summary>
    /// Class representing the <c>cursors</c> of a <c>paging</c> object of a media list.
    /// </summary>
    public class InstagramMediaListCursors : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the cursor for the previous page.
        /// </summary>
        public string Before { get; }

        /// <summary>
        /// Gets the cursor for the next page.
        /// </summary>
        public string After { get; }

        #endregion

        #region Constructors

        private InstagramMediaListCursors(JObject obj) : base(obj) {
            Before = obj.GetString("before");
            After = obj.GetString("after");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="InstagramMediaListCursors"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramUser"/>.</returns>
        public static InstagramMediaListCursors Parse(JObject obj) {
            return obj == null ? null : new InstagramMediaListCursors(obj);
        }

        #endregion

    }

}