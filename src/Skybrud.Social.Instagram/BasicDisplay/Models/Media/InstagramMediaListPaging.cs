using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
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
        public string? Next { get; }

        /// <summary>
        /// Gets whether the list has an additional page.
        /// </summary>
        [MemberNotNullWhen(true, "Next")]
        public bool HasNext => string.IsNullOrWhiteSpace(Next) == false;

        #endregion

        #region Constructors

        private InstagramMediaListPaging(JObject json) : base(json) {
            Cursors = json.GetObject("cursors", InstagramMediaListCursors.Parse)!;
            Next = json.GetString("next");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="InstagramMediaListPaging"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramMediaListPaging"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static InstagramMediaListPaging? Parse(JObject? json) {
            return json == null ? null : new InstagramMediaListPaging(json);
        }

        #endregion

    }

}