using Skybrud.Essentials.Maps.Geometry;
using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Options.Media;
using Skybrud.Social.Instagram.Responses.Media;

namespace Skybrud.Social.Instagram.Endpoints {

    /// <summary>
    /// Class representing the implementation of the media endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/media/</cref>
    /// </see>
    public class InstagramMediaEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram service.
        /// </summary>
        public InstagramService Service { get; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public InstagramMediaRawEndpoint Raw => Service.Client.Media;

        #endregion

        #region Constructors

        internal InstagramMediaEndpoint(InstagramService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the Instagram media with the specified <paramref name="mediaId"/>.
        /// </summary>
        /// <param name="mediaId">The ID of the media (eg <code>1482657170024975745_653220932</code>).</param>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/media/#get_media</cref>
        /// </see>
        /// <returns>An instance of <see cref="InstagramGetMediaResponse"/> representing the response from the Instagram API.</returns>
        public InstagramGetMediaResponse GetMedia(string mediaId) {
            return InstagramGetMediaResponse.ParseResponse(Raw.GetMedia(mediaId));
        }

        /// <summary>
        /// Gets information about the Instagram media with the specified <paramref name="shortcode"/>.
        /// </summary>
        /// <param name="shortcode">The shortcode of the media (eg. <code>BSTdNc3Bk2B</code>).</param>
        /// <returns>An instance of <see cref="InstagramGetMediaResponse"/> representing the response from the Instagram API.</returns>
        public InstagramGetMediaResponse GetMediaFromShortcode(string shortcode) {
            return InstagramGetMediaResponse.ParseResponse(Raw.GetMediaFromShortcode(shortcode));
        }

        /// <summary>
        /// Search for media in a given area. Can return mix of image
        /// and video types.
        /// </summary>
        /// <param name="latitude">The latitude of the point.</param>
        /// <param name="longitude">The longitude of the point.</param>
        /// <returns>An instance of <see cref="InstagramSearchMediaResponse"/> representing the response from the Instagram API.</returns>
        public InstagramSearchMediaResponse Search(double latitude, double longitude) {
            return InstagramSearchMediaResponse.ParseResponse(Raw.Search(latitude, longitude));
        }

        /// <summary>
        /// Search for media in a given area. Can return mix of image
        /// and video types.
        /// </summary>
        /// <param name="latitude">The latitude of the point.</param>
        /// <param name="longitude">The longitude of the point.</param>
        /// <param name="distance">The distance/radius in meters. The API allows a maximum radius of 5000 meters.</param>
        /// <returns>An instance of <see cref="InstagramSearchMediaResponse"/> representing the response from the Instagram API.</returns>
        public InstagramSearchMediaResponse Search(double latitude, double longitude, int distance) {
            return InstagramSearchMediaResponse.ParseResponse(Raw.Search(latitude, longitude, distance));
        }

        /// <summary>
        /// Search for media in a given area. Can return mix of image
        /// and video types.
        /// </summary>
        /// <param name="location">An instance of <see cref="IPoint"/> representing the point.</param>
        /// <returns>An instance of <see cref="InstagramSearchMediaResponse"/> representing the response from the Instagram API.</returns>
        public InstagramSearchMediaResponse Search(IPoint location) {
            return InstagramSearchMediaResponse.ParseResponse(Raw.Search(location));
        }

        /// <summary>
        /// Search for media in a given area. Can return mix of image
        /// and video types.
        /// </summary>
        /// <param name="location">An instance of <see cref="IPoint"/> representing the point.</param>
        /// <param name="distance">The distance/radius in meters. The API allows a maximum radius of 5000 meters.</param>
        /// <returns>An instance of <see cref="InstagramSearchMediaResponse"/> representing the response from the Instagram API.</returns>
        public InstagramSearchMediaResponse Search(IPoint location, int distance) {
            return InstagramSearchMediaResponse.ParseResponse(Raw.Search(location, distance));
        }

        /// <summary>
        /// Search for media in a given area. Can return mix of image and video types.
        /// </summary>
        /// <param name="options">The search options.</param>
        /// <returns>An instance of <see cref="InstagramSearchMediaResponse"/> representing the response from the Instagram API.</returns>
        public InstagramSearchMediaResponse Search(InstagramGetRecentMediaOptions options) {
            return InstagramSearchMediaResponse.ParseResponse(Raw.Search(options));
        }

        #endregion

    }

}