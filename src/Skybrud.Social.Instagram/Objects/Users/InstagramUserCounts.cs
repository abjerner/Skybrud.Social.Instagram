using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Objects.Users {

    /// <summary>
    /// Class with various statistics about a user.
    /// </summary>
    public class InstagramUserCounts : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the amount of media the user has uploaded.
        /// </summary>
        public int Media { get; private set; }

        /// <summary>
        /// Gets the amount of other users following the user.
        /// </summary>
        public int FollowedBy { get; private set; }

        /// <summary>
        /// Gets the amount of other users followed by the user.
        /// </summary>
        public int Follows { get; private set; }

        #endregion

        #region Constructors

        private InstagramUserCounts(JObject obj) : base(obj) {
            Media = obj.GetInt32("media");
            FollowedBy = obj.GetInt32("followed_by");
            Follows = obj.GetInt32("follows");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="InstagramUserCounts"/> from the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>Returns an instance of <see cref="InstagramUserCounts"/>.</returns>
        public static InstagramUserCounts Parse(JObject obj) {
            return obj == null ? null : new InstagramUserCounts(obj);
        }

        #endregion

    }

}