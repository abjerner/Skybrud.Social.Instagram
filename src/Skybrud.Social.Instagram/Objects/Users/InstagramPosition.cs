using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Objects.Users {
    
    /// <summary>
    /// Class describing the position of a tagged user in a photo.
    /// </summary>
    public class InstagramPosition : InstagramObject {

        #region Properties

        /// <summary>
        /// The Y coordinate of the position.
        /// </summary>
        [JsonProperty("y")]
        public double Y { get; private set; }

        /// <summary>
        /// The X coordinate of the position.
        /// </summary>
        [JsonProperty("x")]
        public double X { get; private set; }

        #endregion

        #region Constructors

        private InstagramPosition(JObject obj) : base(obj) {
            X = obj.GetDouble("x");
            Y = obj.GetDouble("y");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramPosition"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramPosition"/>.</returns>
        public static InstagramPosition Parse(JObject obj) {
            return obj == null ? null : new InstagramPosition(obj);
        }

        #endregion

    }

}