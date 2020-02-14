using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Instagram.Options.Relationships {
    
    /// <summary>
    /// Class representing the options for getting a list of followers of a given user.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_followed_by</cref>
    /// </see>
    public class InstagramGetFollowedByOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of users to be returned.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets the identifier of the user. The identifier will be a textual representing of <see cref="UserId"/>, or
        /// <code>self</code> if <see cref="UserId"/> has not been specified.
        /// </summary>
        public string Identifier => (UserId == 0 ? "self" : UserId + string.Empty);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public InstagramGetFollowedByOptions() { }

        /// <summary>
        /// Initializes a new instance with specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public InstagramGetFollowedByOptions(long userId) {
            UserId = userId;
        }

        /// <summary>
        /// Initializes an instance with the specified <paramref name="userId"/> and <paramref name="count"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of users to be returned.</param>
        public InstagramGetFollowedByOptions(long userId, int count) {
            UserId = userId;
            Count = count;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        public IHttpQueryString GetQueryString() {
            HttpQueryString qs = new HttpQueryString();
            if (Count > 0) qs.Add("count", Count);
            return qs;
        }

        #endregion

    }

}