using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.BasicDisplay.Models.Media;

namespace Skybrud.Social.Instagram.BasicDisplay.Models.Users {

    /// <summary>
    /// Class representing an Instagram user.
    /// </summary>
    public class InstagramUser : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the user.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets the type of the user.
        /// </summary>
        public InstagramUserType AccountType { get; }

        /// <summary>
        /// Gets the username of the user.
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// Gets the media count of the user.
        /// </summary>
        public int MediaCount { get; }

        /// <summary>
        /// Get a list of media on the user.
        /// </summary>
        public InstagramMediaList Media { get; }

        #endregion

        #region Constructors

        private InstagramUser(JObject obj) : base(obj) {
            Id = obj.GetInt64("id");
            AccountType = obj.GetEnum("account_type", InstagramUserType.Unspecified);
            Username = obj.GetString("username");
            MediaCount = obj.GetInt32("media_count");
            Media = obj.GetObject("media", InstagramMediaList.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="InstagramUser"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramUser"/>.</returns>
        public static InstagramUser Parse(JObject obj) {
            return obj == null ? null : new InstagramUser(obj);
        }

        #endregion

    }

}