using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Models.Users {

    /// <summary>
    /// Class representing an Instagram user.
    /// </summary>
    public class InstagramUser : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the user.
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        /// Gets the username of the user.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Gets the full name of the user. A user may not have specified a full name.
        /// </summary>
        public string FullName { get; private set; }

        /// <summary>
        /// Gets the profile picture of the user.
        /// </summary>
        public string ProfilePicture { get; private set; }

        /// <summary>
        /// Gets the website of the user. A user may not have specified a website.
        /// </summary>
        public string Website { get; private set; }

        /// <summary>
        /// Gets the bio of the user. A user may not have specified a bio.
        /// </summary>
        public string Bio { get; private set; }

        /// <summary>
        /// Gets a reference to various statistics about the user.
        /// </summary>
        public InstagramUserCounts Counts { get; private set; }

        /// <summary>
        /// Gets whether the user has specified a full name.
        /// </summary>
        public bool HasFullName {
            get { return !String.IsNullOrWhiteSpace(FullName); }
        }

        /// <summary>
        /// Gets whether the user has uploaded a profile picture.
        /// </summary>
        public bool HasProfilePicture {
            get { return !String.IsNullOrWhiteSpace(ProfilePicture); }
        }

        /// <summary>
        /// Gets whether the user has specified a website.
        /// </summary>
        public bool HasWebsite {
            get { return !String.IsNullOrWhiteSpace(Website); }
        }

        /// <summary>
        /// Gets whether the user has specified a bio.
        /// </summary>
        public bool HasBio {
            get { return !String.IsNullOrWhiteSpace(Bio); }
        }

        #endregion

        #region Constructors

        private InstagramUser(JObject obj) : base(obj) {
            Id = obj.GetInt64("id");
            Username = obj.GetString("username");
            FullName = obj.GetString("full_name");
            ProfilePicture = obj.GetString("profile_picture");
            Website = obj.GetString("website");
            Bio = obj.GetString("bio");
            Counts = obj.GetObject("counts", InstagramUserCounts.Parse);
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