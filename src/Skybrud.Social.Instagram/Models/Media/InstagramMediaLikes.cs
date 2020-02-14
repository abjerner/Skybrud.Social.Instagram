using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Models.Media {

    /// <summary>
    /// Class representing the <code>likes</code> object of an Instagram media.
    /// </summary>
    public class InstagramMediaLikes : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the amount of likes the media has received.
        /// </summary>
        public int Count { get; }

        #endregion

        #region Constructors

        private InstagramMediaLikes(JObject obj) : base(obj) {
            Count = obj.GetInt32("count");
        }

        #endregion

        #region Static methods
        
        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramMediaLikes"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="InstagramMediaLikes"/>.</returns>
        public static InstagramMediaLikes Parse(JObject obj) {
            return obj == null ? null : new InstagramMediaLikes(obj);
        }

        #endregion

    }

}