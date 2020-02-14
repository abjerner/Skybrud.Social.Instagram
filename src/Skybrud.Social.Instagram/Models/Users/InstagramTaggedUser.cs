using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Models.Users {

    /// <summary>
    /// Class representing information about the user tagged in a media.
    /// </summary>
    public class InstagramTaggedUser : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the posision of the user in the media.
        /// </summary>
        [JsonProperty("position")]
        public InstagramPosition Position { get; }

        /// <summary>
        /// Gets information about the tagged user.
        /// </summary>
        [JsonProperty("user")]
        public InstagramUserSummary User { get; }

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