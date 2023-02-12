using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Instagram.Graph.Fields;
using Skybrud.Social.Instagram.Graph.Models.Media;

namespace Skybrud.Social.Instagram.Graph.Models.Users {

    /// <summary>
    /// Class representing an Instagram user.
    /// </summary>
    public class InstagramUser : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the biography of the user.
        /// </summary>
        public string? Biography { get; }

        /// <summary>
        /// Gets the amount of users following this user.
        /// </summary>
        public long? FollowersCount { get; }

        /// <summary>
        /// Gets the amount of users this user is following.
        /// </summary>
        public long? FollowsCount { get; }

        /// <summary>
        /// Gets the Facebook ID of the Instagram user.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the username of the user.
        /// </summary>
        public string? Username { get; }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// Gets the total amount of media uploaded by this user.
        /// </summary>
        public long? MediaCount { get; }

        /// <summary>
        /// Gets the Instagram ID of the user.
        /// </summary>
        public string? InstagramId { get; }

        /// <summary>
        /// Gets the website of the user.
        /// </summary>
        public string? Website { get; }

        /// <summary>
        /// Gets the profile URL of the user.
        /// </summary>
        public string? ProfilePictureUrl { get; }

        /// <summary>
        /// Gets a reference to the other Instagram user when business disconvery is enabled.
        /// </summary>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-api/reference/user/business_discovery</cref>
        /// </see>
        public InstagramUser? BusinessDiscovery { get; }

        /// <summary>
        /// Gets a list of media of the user. Only part of the response when the <see cref="InstagramUserFields.Media"/> edge is requested.
        /// </summary>
        public InstagramMediaList? Media { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the entry.</param>
        protected InstagramUser(JObject json) : base(json) {
            Biography = json.GetString("biography");
            FollowersCount = json.GetInt64OrNull("followers_count");
            FollowsCount = json.GetInt64OrNull("follows_count");
            Id = json.GetString("id")!;
            Username = json.GetString("username");
            Name = json.GetString("name");
            MediaCount = json.GetInt64OrNull("media_count");
            InstagramId = json.GetString("ig_id");
            Website = json.GetString("website");
            ProfilePictureUrl = json.GetString("profile_picture_url");
            BusinessDiscovery = json.GetObject("business_discovery", Parse);
            Media = json.GetObject("media", InstagramMediaList.Parse)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="InstagramUser"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramUser"/>. <paramref name="json"/> is <see langword="null"/>, <see langword="null"/> is returned instead.</returns>
        [return: NotNullIfNotNull("json")]
        public static InstagramUser? Parse(JObject? json) {
            return json == null ? null : new InstagramUser(json);
        }

        #endregion

    }

}