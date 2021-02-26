using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.BasicDisplay.Models.Users;
using Skybrud.Social.Instagram.Models;

namespace Skybrud.Social.Instagram.BasicDisplay.Models.Media {
    
    /// <summary>
    /// Class representing a list of media.
    /// </summary>
    public class InstagramMediaList : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets an array with the media of the list.
        /// </summary>
        public InstagramMedia[] Data { get; }

        /// <summary>
        /// Gets paging information about the media list.
        /// </summary>
        public InstagramMediaListPaging Paging { get; }

        #endregion

        #region Constructors

        private InstagramMediaList(JObject obj) : base(obj) {
            Data = obj.GetArrayItems("data", InstagramMedia.Parse);
            Paging = obj.GetObject("paging", InstagramMediaListPaging.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="InstagramUser"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramUser"/>.</returns>
        public static InstagramMediaList Parse(JObject obj) {
            return obj == null ? null : new InstagramMediaList(obj);
        }

        #endregion

    }

}