using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Instagram.Graph.Models.Paging;

namespace Skybrud.Social.Instagram.Graph.Models.Comments {

    /// <summary>
    /// Class representing a list of Instagram comments.
    /// </summary>
    public class InstagramCommentList : InstagramObject, IReadOnlyList<InstagramComment> {

        #region Properties

        /// <summary>
        /// Gets the total amount of comments in the list.
        /// </summary>
        public int Count => Data.Count;

        /// <summary>
        /// Gets the comment at the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>An instance of <see cref="InstagramComment"/>.</returns>
        public InstagramComment this[int index] => Data[index];

        /// <summary>
        /// Gets an array of the <see cref="InstagramComment"/> making up the response body.
        /// </summary>
        public IReadOnlyList<InstagramComment> Data { get; }

        /// <summary>
        /// Gets pagiging information about the list.
        /// </summary>
        public InstagramPaging Paging { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected InstagramCommentList(JObject json) : base(json) {
            Data = json.GetArrayItems("data", InstagramComment.Parse);
            Paging = json.GetObject("paging", InstagramPaging.Parse)!;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IEnumerator<InstagramComment> GetEnumerator() {
            return Data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="InstagramCommentList"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramCommentList"/>. <paramref name="json"/> is <see langword="null"/>, <see langword="null"/> is returned instead.</returns>
        [return: NotNullIfNotNull("json")]
        public static InstagramCommentList? Parse(JObject? json) {
            return json == null ? null : new InstagramCommentList(json);
        }

        #endregion

    }

}