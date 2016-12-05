using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Instagram.Options.Users {
    
    /// <summary>
    /// Class representing the options for getting the feed of the authenticated user.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_feed</cref>
    /// </see>
    public class InstagramGetUserFeedOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the maximum amount of media to be returned.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the minimum media ID for the search. Only media after this ID is returned.
        /// </summary>
        public string MinId { get; set; }

        /// <summary>
        /// Gets or sets the maximum media ID for the search. Only media before this ID is returned.
        /// </summary>
        public string MaxId { get; set; }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        public IHttpQueryString GetQueryString() {
            SocialHttpQueryString qs = new SocialHttpQueryString();
            if (Count > 0) qs.Add("count", Count);
            if (MinId != null) qs.Add("min_id", MinId);
            if (MaxId != null) qs.Add("max_id", MaxId);
            return qs;
        }

        #endregion

    }

}