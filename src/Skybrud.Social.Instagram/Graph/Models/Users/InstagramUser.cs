using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.Graph.Fields;
using Skybrud.Social.Instagram.Graph.Models.Media;

// ReSharper disable InconsistentNaming

namespace Skybrud.Social.Instagram.Graph.Models.Users {

    /// <summary>
    /// Class representing an Instagram user.
    /// </summary>
    public class InstagramUser : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the biography of the user.
        /// </summary>
        public string Biography { get; }

        /// <summary>
        /// Gets the amount of users following this user.
        /// </summary>
        public long FollowersCount { get; }

        /// <summary>
        /// Gets the amount of users this user is following.
        /// </summary>
        public long FollowsCount { get; }

        /// <summary>
        /// Gets the Facebook ID of the Instagram user.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the username of the user.
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the total amount of media uploaded by this user.
        /// </summary>
        public long MediaCount { get; }

        /// <summary>
        /// Gets the Instagram ID of the user.
        /// </summary>
        public string InstagramId { get; }

        /// <summary>
        /// Gets the website of the user.
        /// </summary>
        public string Website { get; }

        /// <summary>
        /// Gets the profile URL of the user.
        /// </summary>
        public string ProfilePictureUrl { get; }

        /// <summary>
        /// Gets a reference to the other Instagram user when business disconvery is enabled.
        /// </summary>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/instagram-api/reference/user/business_discovery</cref>
        /// </see>
        public InstagramUser BusinessDiscovery { get; }

        /// <summary>
        /// Gets a list of media of the user. Only part of the response when the <see cref="InstagramUserFields.Media"/> edge is requested.
        /// </summary>
        public InstagramMediaList Media { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the entry.</param>
        protected InstagramUser(JObject obj) : base(obj) {
            Biography = obj.GetString("biography");
            FollowersCount = obj.GetInt64("followers_count");
            FollowsCount = obj.GetInt64("follows_count");
            Id = obj.GetString("id");
            Username = obj.GetString("username");
            Name = obj.GetString("name");
            MediaCount = obj.GetInt64("media_count");
            InstagramId = obj.GetString("ig_id");
            Website = obj.GetString("website");
            ProfilePictureUrl = obj.GetString("profile_picture_url");
            BusinessDiscovery = obj.GetObject("business_discovery", Parse);
            Media = obj.GetObject("media", InstagramMediaList.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramUser"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramUser"/>.</returns>
        public static InstagramUser Parse(JObject obj) {
            return obj == null ? null : new InstagramUser(obj);
        }

        #endregion

    }

}