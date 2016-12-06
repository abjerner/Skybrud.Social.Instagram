using Skybrud.Social.Http;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Options.Tags;

namespace Skybrud.Social.Instagram.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the tags endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/tags/</cref>
    /// </see>
    public class InstagramTagsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram OAuth client.
        /// </summary>
        public InstagramOAuthClient Client { get; private set; }

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
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags</cref>
        /// </see>
        public SocialHttpResponse GetTagInfo(string tag) {
            return Client.DoHttpGetRequest("https://api.instagram.com/v1/tags/" + tag);
        }

        /// <summary>
        /// Gets the raw JSON response from the Instagram API with media from the specified <code>tag</code>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        /// <param name="minTagId">The minimum tag ID. Only media before this ID will be returned.</param>
        /// <param name="maxTagId">The maximum tag ID. Only media after this ID will be returned.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags_media_recent</cref>
        /// </see>
        public SocialHttpResponse GetRecentMedia(string tag, string minTagId = null, string maxTagId = null) {
            return GetRecentMedia(tag, new InstagramGetTagRecentMediaOptions {
                MinTagId = minTagId,
                MaxTagId = maxTagId
            });
        }

        /// <summary>
        /// Gets the raw JSON response from the Instagram API with media from the specified <code>tag</code>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        /// <param name="count">The maximum amount of media to be returned.</param>
        /// <param name="minTagId">The minimum tag ID. Only media before this ID will be returned.</param>
        /// <param name="maxTagId">The maximum tag ID. Only media after this ID will be returned.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags_media_recent</cref>
        /// </see>
        public SocialHttpResponse GetRecentMedia(string tag, int count, string minTagId = null, string maxTagId = null) {
            return GetRecentMedia(tag, new InstagramGetTagRecentMediaOptions {
                Count = count,
                MinTagId = minTagId,
                MaxTagId = maxTagId
            });
        }

        /// <summary>
        /// Gets the raw JSON response from the Instagram API with media from the specified <code>tag</code>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags_media_recent</cref>
        /// </see>
        public SocialHttpResponse GetRecentMedia(string tag, InstagramGetTagRecentMediaOptions options) {
            return Client.DoHttpGetRequest("https://api.instagram.com/v1/tags/" + tag + "/media/recent", options);
        }

        /// <summary>
        /// Search for tags by name. Results are ordered first as an exact match, then by popularity. Short tags will be treated as exact matches.
        /// </summary>
        /// <param name="tag">A valid tag name without a leading #. (eg. <code>snowy</code>, <code>nofilter</code>)</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags_search</cref>
        /// </see>
        public SocialHttpResponse Search(string tag) {

            // Declare the query string
            SocialHttpQueryString qs = new SocialHttpQueryString();
            qs.Add("q", tag);

            // Perform the call to the API
            return Client.DoHttpGetRequest("https://api.instagram.com/v1/tags/search", qs);

        }

        #endregion

    }

}