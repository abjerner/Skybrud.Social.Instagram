using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Instagram.Options.Users {
    
    /// <summary>
    /// Class representing the options for getting recent media of a given user.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_media_recent</cref>
    /// </see>
    public class InstagramGetUserRecentMediaOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the user. If the ID is set to <code>0</code>, the recent media of the authenticated
        /// user will be returned.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of media to be returned.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the maximum timestamp for the search. Only media before this timestamp is returned.
        /// </summary>
        public DateTime? MaxTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the minimum timestamp for the search. Only media after this timestamp is returned.
        /// </summary>
        public DateTime? MinTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the minimum media ID for the search. Only media after this ID is returned.
        /// </summary>
        public string MinId { get; set; }

        /// <summary>
        /// Gets or sets the maximum media ID for the search. Only media before this ID is returned.
        /// </summary>
        public string MaxId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public InstagramGetUserRecentMediaOptions() { }

        public InstagramGetUserRecentMediaOptions(long userId) {
            UserId = userId;
        }

        public InstagramGetUserRecentMediaOptions(long userId, int count) {
            UserId = userId;
            Count = count;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="SocialQueryString"/> representing the GET parameters.
        /// </summary>
        public SocialQueryString GetQueryString() {
            SocialQueryString qs = new SocialQueryString();
            if (Count > 0) qs.Add("count", Count);
            if (MaxTimestamp != null) qs.Add("max_timestamp", SocialUtils.GetUnixTimeFromDateTime(MaxTimestamp.Value));
            if (MinTimestamp != null) qs.Add("min_timestamp", SocialUtils.GetUnixTimeFromDateTime(MinTimestamp.Value));
            if (MinId != null) qs.Add("min_id", MinId);
            if (MaxId != null) qs.Add("max_id", MaxId);
            return qs;
        }

        #endregion

    }

}