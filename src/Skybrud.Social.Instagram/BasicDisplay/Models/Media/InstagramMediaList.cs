using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Instagram.BasicDisplay.Models.Users;

namespace Skybrud.Social.Instagram.BasicDisplay.Models.Media {

    /// <summary>
    /// Class representing a list of media.
    /// </summary>
    public class InstagramMediaList : InstagramObject, IEnumerable<InstagramMedia> {

        #region Properties

        /// <summary>
        /// Gets an array with the media of the list.
        /// </summary>
        public IReadOnlyList<InstagramMedia> Data { get; }

        /// <summary>
        /// Gets paging information about the media list.
        /// </summary>
        public InstagramMediaListPaging Paging { get; }

        #endregion

        #region Constructors

        private InstagramMediaList(JObject json) : base(json) {
            Data = json.GetArrayItems("data", InstagramMedia.Parse);
            Paging = json.GetObject("paging", InstagramMediaListPaging.Parse)!;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IEnumerator<InstagramMedia> GetEnumerator() {
            return Data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="InstagramMediaList"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramUser"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static InstagramMediaList? Parse(JObject? json) {
            return json == null ? null : new InstagramMediaList(json);
        }

        #endregion


    }

}