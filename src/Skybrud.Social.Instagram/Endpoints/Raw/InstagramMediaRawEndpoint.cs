using System;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Locations;
using Skybrud.Essentials.Maps.Geometry;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Options.Media;

namespace Skybrud.Social.Instagram.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the media endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/media/</cref>
    /// </see>
    public class InstagramMediaRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram OAuth client.
        /// </summary>
        public InstagramOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal InstagramMediaRawEndpoint(InstagramOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the Instagram media with the specified <paramref name="mediaId"/>.
        /// </summary>
        /// <param name="mediaId">The ID of the media.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/media/#get_media</cref>
        /// </see>
        public IHttpResponse GetMedia(string mediaId) {
            if (String.IsNullOrWhiteSpace(mediaId)) throw new ArgumentNullException("mediaId");
            return Client.Get("https://api.instagram.com/v1/media/" + mediaId);
        }

        /// <summary>
        /// Gets information about the Instagram media with the specified <paramref name="shortcode"/>.
        /// </summary>
        /// <param name="shortcode">The shortcode of the media (eg. <code>BSTdNc3Bk2B</code>).</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://www.instagram.com/developer/endpoints/media/#get_media_by_shortcode</cref>
        /// </see>
        public IHttpResponse GetMediaFromShortcode(string shortcode) {
            if (String.IsNullOrWhiteSpace(shortcode)) throw new ArgumentNullException("shortcode");
            return Client.Get("https://api.instagram.com/v1/media/shortcode/" + shortcode);
        }

        /// <summary>
        /// Search for media in a given area. Can return mix of image and video types.
        /// </summary>
        /// <param name="latitude">The latitude of the point.</param>
        /// <param name="longitude">The longitude of the point.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/media/#get_media_search</cref>
        /// </see>
        public IHttpResponse Search(double latitude, double longitude) {
            return Search(new InstagramGetRecentMediaOptions(latitude, longitude));
        }

        /// <summary>
        /// Search for media in a given area. The default time span is set to 5 days. Can return mix of image
        /// and video types.
        /// </summary>
        /// <param name="latitude">The latitude of the point.</param>
        /// <param name="longitude">The longitude of the point.</param>
        /// <param name="distance">The distance/radius in meters. The API allows a maximum radius of 5000 meters.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/media/#get_media_search</cref>
        /// </see>
        public IHttpResponse Search(double latitude, double longitude, int distance) {
            return Search(new InstagramGetRecentMediaOptions(latitude, longitude, distance));
        }

        /// <summary>
        /// Search for media in a given area. Can return mix of image and video types.
        /// </summary>
        /// <param name="location">An instance of <see cref="IPoint"/> representing the point.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/media/#get_media_search</cref>
        /// </see>
        public IHttpResponse Search(IPoint location) {
            if (location == null) throw new ArgumentNullException("location");
            return Search(new InstagramGetRecentMediaOptions(location));
        }

        /// <summary>
        /// Search for media in a given area. Can return mix of image and video types.
        /// </summary>
        /// <param name="location">An instance of <see cref="IPoint"/> representing the point.</param>
        /// <param name="distance">The distance/radius in meters. The API allows a maximum radius of 5000 meters.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/media/#get_media_search</cref>
        /// </see>
        public IHttpResponse Search(IPoint location, int distance) {
            if (location == null) throw new ArgumentNullException("location");
            return Search(new InstagramGetRecentMediaOptions(location));
        }

        /// <summary>
        /// Search for media in a given area. Can return mix of image and video types.
        /// </summary>
        /// <param name="options">The search options.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/media/#get_media_search</cref>
        /// </see>
        public IHttpResponse Search(InstagramGetRecentMediaOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.Get("https://api.instagram.com/v1/media/search", options);
        }

        #endregion

    }

}