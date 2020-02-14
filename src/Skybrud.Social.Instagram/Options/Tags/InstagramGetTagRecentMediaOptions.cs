using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Instagram.Options.Tags {
    
    /// <summary>
    /// Class representing the options for getting a list of recent media of a given tag.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags_media_recent</cref>
    /// </see>
    public class InstagramGetTagRecentMediaOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the name of the tag.
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of media to return.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the minimum tag ID. Only media before this ID will be returned.
        /// </summary>
        public string MinTagId { get; set; }

        /// <summary>
        /// Gets or sets the maximum tag ID. Only media after this ID will be returned.
        /// </summary>
        public string MaxTagId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an instance with default options.
        /// </summary>
        public InstagramGetTagRecentMediaOptions() { }

        /// <summary>
        /// Initializes an instance with the specified <paramref name="tag"/>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        public InstagramGetTagRecentMediaOptions(string tag) {
            Tag = tag;
        }

        /// <summary>
        /// Initializes an instance with the specified <paramref name="tag"/> and <paramref name="count"/>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        /// <param name="count">The maximum amount of users to be returned.</param>
        public InstagramGetTagRecentMediaOptions(string tag, int count) {
            Tag = tag;
            Count = count;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="tag"/>, <paramref name="count"/> and<paramref name="maxTagId"/>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        /// <param name="count">The maximum amount of users to be returned.</param>
        /// <param name="maxTagId">The maximum tag ID. Only media after this ID will be returned.</param>
        public InstagramGetTagRecentMediaOptions(string tag, int count, string maxTagId) {
            Tag = tag;
            Count = count;
            MaxTagId = maxTagId;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        public IHttpQueryString GetQueryString() {
            IHttpQueryString qs = new HttpQueryString();
            if (Count > 0) qs.Add("count", Count);
            if (!string.IsNullOrWhiteSpace(MinTagId)) qs.Add("min_tag_id", MinTagId);
            if (!string.IsNullOrWhiteSpace(MaxTagId)) qs.Add("max_tag_id", MaxTagId);
            return qs;
        }

        #endregion

    }

}