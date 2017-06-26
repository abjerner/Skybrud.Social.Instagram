using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Models.Media {

    /// <summary>
    /// Class representing the <code>comments</code> object of an Instagram media.
    /// </summary>
    public class InstagramMediaComments : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the amount of comments the media has received.
        /// </summary>
        public int Count { get; private set; }

        #endregion

        #region Constructors

        private InstagramMediaComments(JObject obj) : base(obj) {
            Count = obj.GetInt32("count");
        }

        #endregion

        #region Static methods
        
        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramMediaComments"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="InstagramMediaComments"/>.</returns>
        public static InstagramMediaComments Parse(JObject obj) {
            return obj == null ? null : new InstagramMediaComments(obj);
        }

        #endregion

    }

}