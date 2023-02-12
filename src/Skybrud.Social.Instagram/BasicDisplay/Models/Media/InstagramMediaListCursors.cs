using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Instagram.BasicDisplay.Models.Media {

    /// <summary>
    /// Class representing the <c>cursors</c> of a <c>paging</c> object of a media list.
    /// </summary>
    public class InstagramMediaListCursors : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the cursor for the previous page.
        /// </summary>
        public string? Before { get; }

        /// <summary>
        /// Gets whether the <see cref="Before"/> cursor was present in the response.
        /// </summary>
        [JsonIgnore]
        [MemberNotNullWhen(true, "Before")]
        public bool HasBefore => string.IsNullOrWhiteSpace(Before) == false;

        /// <summary>
        /// Gets the cursor for the next page.
        /// </summary>
        public string? After { get; }

        /// <summary>
        /// Gets whether the <see cref="After"/> cursor was present in the response.
        /// </summary>
        [JsonIgnore]
        [MemberNotNullWhen(true, "After")]
        public bool HasAfter => string.IsNullOrWhiteSpace(After) == false;

        #endregion

        #region Constructors

        private InstagramMediaListCursors(JObject json) : base(json) {
            Before = json.GetString("before");
            After = json.GetString("after");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="InstagramMediaListCursors"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramMediaListCursors"/>.</returns>
        public static InstagramMediaListCursors? Parse(JObject? json) {
            return json == null ? null : new InstagramMediaListCursors(json);
        }

        #endregion

    }

}