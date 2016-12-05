using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Instagram.Options.Users {
    
    /// <summary>
    /// Class representing the options for getting a list of media liked by the authenticated user.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_feed_liked</cref>
    /// </see>
    public class InstagramGetUserLikedMediaOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the maximum amount of media to be returned.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Only media before this ID is returned.
        /// </summary>
        public string MaxLikeId { get; set; }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        public IHttpQueryString GetQueryString() {
            SocialHttpQueryString qs = new SocialHttpQueryString();
            if (Count > 0) qs.Add("count", Count);
            if (MaxLikeId != null) qs.Add("max_like_id", MaxLikeId);
            return qs;
        }

        #endregion

    }

}