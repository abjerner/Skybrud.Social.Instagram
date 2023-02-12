using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
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
        public InstagramUserType? AccountType { get; }

        /// <summary>
        /// Gets the username of the user.
        /// </summary>
        public string? Username { get; }

        /// <summary>
        /// Gets the media count of the user.
        /// </summary>
        public int? MediaCount { get; }

        /// <summary>
        /// Get a list of media on the user.
        /// </summary>
        public InstagramMediaList? Media { get; }

        #endregion

        #region Constructors

        private InstagramUser(JObject json) : base(json) {
            Id = json.GetInt64("id");
            AccountType = json.GetEnumOrNull<InstagramUserType>("account_type");
            Username = json.GetString("username");
            MediaCount = json.GetInt32OrNull("media_count");
            Media = json.GetObject("media", InstagramMediaList.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="InstagramUser"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramUser"/>.</returns>
        public static InstagramUser? Parse(JObject? json) {
            return json == null ? null : new InstagramUser(json);
        }

        #endregion

    }

}