using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Options.Tags;
using Skybrud.Social.Instagram.Responses.Tags;

namespace Skybrud.Social.Instagram.Endpoints {
    
    /// <summary>
    /// Class representing the implementation of the tags endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/tags/</cref>
    /// </see>
    public class InstagramTagsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram service.
        /// </summary>
        public InstagramService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public InstagramTagsRawEndpoint Raw {
            get { return Service.Client.Tags; }
        }

        #endregion

        #region Constructors

        internal InstagramTagsEndpoint(InstagramService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the specified <paramref name="tag"/>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        public InstagramGetTagResponse GetTag(string tag) {
            return InstagramGetTagResponse.ParseResponse(Raw.GetTag(tag));
        }

        /// <summary>
        /// Gets a list of recent media from the specified <paramref name="tag"/>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        /// <returns>An instance of <see cref="InstagramGetRecentMediaResponse"/> representing the response from the Instagram API.</returns>
        public InstagramGetRecentMediaResponse GetRecentMedia(string tag) {
            return InstagramGetRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(tag));
        }

        /// <summary>
        /// Gets a list of recent media from the specified <paramref name="tag"/>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        /// <param name="count">The maximum amount of media to be returned.</param>
        /// <returns>An instance of <see cref="InstagramGetRecentMediaResponse"/> representing the response from the Instagram API.</returns>
        public InstagramGetRecentMediaResponse GetRecentMedia(string tag, int count) {
            return InstagramGetRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(tag, count));
        }

        /// <summary>
        /// Gets a list of recent media from the specified <paramref name="tag"/>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        /// <param name="count">The maximum amount of media to be returned.</param>
        /// <param name="maxTagId">The maximum tag ID. Only media after this ID will be returned.</param>
        /// <returns>An instance of <see cref="InstagramGetRecentMediaResponse"/> representing the response from the Instagram API.</returns>
        public InstagramGetRecentMediaResponse GetRecentMedia(string tag, int count, string maxTagId) {
            return InstagramGetRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(tag, count, maxTagId));
        }

        /// <summary>
        /// Gets a list of recent media from the tag matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="InstagramGetRecentMediaResponse"/> representing the response from the Instagram API.</returns>
        public InstagramGetRecentMediaResponse GetRecentMedia(InstagramGetTagRecentMediaOptions options) {
            return InstagramGetRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(options));
        }

        /// <summary>
        /// Search for tags by name. Results are ordered first as an exact match, then by popularity. Short tags will be treated as exact matches.
        /// </summary>
        /// <param name="tag">A valid tag name without a leading <code>#</code> (eg. <code>snowy</code>, <code>nofilter</code>).</param>
        /// <returns>An instance of <see cref="InstagramGetTagsResponse"/> representing the response from the Instagram API.</returns>
        public InstagramGetTagsResponse Search(string tag) {
            return InstagramGetTagsResponse.ParseResponse(Raw.Search(tag));
        }

        #endregion

    }

}