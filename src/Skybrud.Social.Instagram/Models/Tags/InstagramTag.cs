using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Models.Tags {

    /// <summary>
    /// Class representing a tag in the Instagram API.
    /// </summary>
    public class InstagramTag : InstagramObject {

        #region Properties

        /// <summary>
        /// The amount of media using this tag.
        /// </summary>
        public long MediaCount { get; private set; }

        /// <summary>
        /// The name of the tag.
        /// </summary>
        public string Name { get; private set; }

        #endregion

        #region Constructors

        private InstagramTag(JObject obj) : base(obj) {
            MediaCount = obj.GetInt64("media_count");
            Name = obj.GetString("name");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramTag"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramTag"/>.</returns>
        public static InstagramTag Parse(JObject obj) {
            return obj == null ? null : new InstagramTag(obj);
        }

        #endregion

    }

}