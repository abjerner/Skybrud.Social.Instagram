using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Instagram.Objects.Users {

    /// <summary>
    /// Class representing information about the user tagged in a media.
    /// </summary>
    public class InstagramTaggedUser : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the posision of the user in the media.
        /// </summary>
        [JsonProperty("position")]
        public InstagramPosition Position { get; private set; }

        /// <summary>
        /// Gets information about the tagged user.
        /// </summary>
        [JsonProperty("user")]
        public InstagramUserSummary User { get; private set; }

        #endregion

        #region Constructors

        private InstagramTaggedUser(JObject obj) : base(obj) {
            Position = obj.GetObject("position", InstagramPosition.Parse);
            User = obj.GetObject("user", InstagramUserSummary.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramTaggedUser"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramTaggedUser"/>.</returns>
        public static InstagramTaggedUser Parse(JObject obj) {
            return obj == null ? null : new InstagramTaggedUser(obj);
        }

        #endregion

    }

}