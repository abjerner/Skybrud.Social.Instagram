using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Models.Users {

    /// <summary>
    /// Class representing a summary of an Instagram user.
    /// </summary>
    public class InstagramUserSummary : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the user.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets the username of the user.
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// Gets the full name of the users.
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Gets the profile picture of the user.
        /// </summary>
        public string ProfilePicture { get; }

        /// <summary>
        /// Gets whether the user has specified a full name.
        /// </summary>
        public bool HasFullName => !string.IsNullOrWhiteSpace(FullName);

        /// <summary>
        /// Gets whether the user has uploaded a profile picture.
        /// </summary>
        public bool HasProfilePicture => !string.IsNullOrWhiteSpace(ProfilePicture);

        #endregion

        #region Constructors

        private InstagramUserSummary(JObject obj) : base(obj) {
            Id = obj.GetInt64("id");
            Username = obj.GetString("username");
            FullName = obj.GetString("full_name");
            ProfilePicture = obj.GetString("profile_picture");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="InstagramUserSummary"/> from the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>Returns an instance of <see cref="InstagramUserSummary"/>.</returns>
        public static InstagramUserSummary Parse(JObject obj) {
            return obj == null ? null : new InstagramUserSummary(obj);
        }

        #endregion

    }

}