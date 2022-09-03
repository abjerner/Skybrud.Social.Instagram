using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.Graph.Models.Paging;

namespace Skybrud.Social.Instagram.Graph.Models.Comments {

    /// <summary>
    /// Class representing a list of Instagram comments.
    /// </summary>
    public class InstagramCommentList : InstagramObject {

        #region Properties

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
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the object.</param>
        protected InstagramCommentList(JObject obj) : base(obj) {
            Data = obj.GetArrayItems("data", InstagramComment.Parse);
            Paging = obj.GetObject("paging", InstagramPaging.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramCommentList"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramCommentList"/>.</returns>
        public static InstagramCommentList Parse(JObject obj) {
            return obj == null ? null : new InstagramCommentList(obj);
        }

        #endregion

    }

}