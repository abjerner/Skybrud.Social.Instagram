using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.Graph.Models.Paging;

namespace Skybrud.Social.Instagram.Graph.Models.Media {

    /// <summary>
    /// Class representing a list of Instagram media.
    /// </summary>
    public class InstagramMediaList : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets an array of the <see cref="InstagramMedia"/> mkaing up the response body.
        /// </summary>
        public InstagramMedia[] Data { get; }

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
        protected InstagramMediaList(JObject obj) : base(obj) {
            Data = obj.GetArrayItems("data", InstagramMedia.Parse);
            Paging = obj.GetObject("paging", InstagramPaging.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramMediaList"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramMediaList"/>.</returns>
        public static InstagramMediaList Parse(JObject obj) {
            return obj == null ? null : new InstagramMediaList(obj);
        }

        #endregion

    }

}