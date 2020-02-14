using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Options.Tags;

namespace Skybrud.Social.Instagram.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the tags endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/tags/</cref>
    ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags</cref>
    ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags_media_recent</cref>
    ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags_search</cref>
    /// </see>
    public class InstagramTagsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram OAuth client.
        /// </summary>
        public InstagramOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal InstagramTagsRawEndpoint(InstagramOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the raw JSON response from the Instagram API with information about the specified <code>tag</code>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        /// <returns>Returns an instance of <see cref="IHttpResponse"/> representing the response from the Instagram API.</returns>
        public IHttpResponse GetTag(string tag) {
            return Client.Get("https://api.instagram.com/v1/tags/" + tag);
        }

        /// <summary>
        /// Gets a list of recent media from the specified <paramref name="tag"/>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Instagram API.</returns>
        public IHttpResponse GetRecentMedia(string tag) {
            return GetRecentMedia(new InstagramGetTagRecentMediaOptions(tag));
        }

        /// <summary>
        /// Gets a list of recent media from the specified <paramref name="tag"/>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        /// <param name="count">The maximum amount of media to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Instagram API.</returns>
        public IHttpResponse GetRecentMedia(string tag, int count) {
            return GetRecentMedia(new InstagramGetTagRecentMediaOptions(tag, count));
        }

        /// <summary>
        /// Gets a list of recent media from the specified <paramref name="tag"/>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        /// <param name="count">The maximum amount of media to be returned.</param>
        /// <param name="maxTagId">The maximum tag ID. Only media after this ID will be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Instagram API.</returns>
        public IHttpResponse GetRecentMedia(string tag, int count, string maxTagId) {
            return GetRecentMedia(new InstagramGetTagRecentMediaOptions(tag, count, maxTagId));
        }

        /// <summary>
        /// Gets a list of recent media from the tag matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Instagram API.</returns>
        public IHttpResponse GetRecentMedia(InstagramGetTagRecentMediaOptions options) {
            if (string.IsNullOrWhiteSpace(options.Tag)) throw new PropertyNotSetException(nameof(options.Tag));
            return Client.Get("https://api.instagram.com/v1/tags/" + options.Tag + "/media/recent", options);
        }

        /// <summary>
        /// Search for tags by name. Results are ordered first as an exact match, then by popularity. Short tags will be treated as exact matches.
        /// </summary>
        /// <param name="tag">A valid tag name without a leading <code>#</code> (eg. <code>snowy</code>, <code>nofilter</code>).</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Instagram API.</returns>
        public IHttpResponse Search(string tag) {

            // Declare the query string
            IHttpQueryString qs = new HttpQueryString();
            qs.Add("q", tag);

            // Perform the call to the API
            return Client.Get("https://api.instagram.com/v1/tags/search", qs);

        }

        #endregion

    }

}