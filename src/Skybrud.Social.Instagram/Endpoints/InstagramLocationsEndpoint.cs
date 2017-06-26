using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Models.Locations;
using Skybrud.Social.Instagram.Options.Locations;
using Skybrud.Social.Instagram.Responses.Locations;

namespace Skybrud.Social.Instagram.Endpoints {

    /// <summary>
    /// Class representing the implementation of the locations endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/</cref>
    /// </see>
    public class InstagramLocationsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram service.
        /// </summary>
        public InstagramService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public InstagramLocationsRawEndpoint Raw {
            get { return Service.Client.Locations; }
        }

        #endregion

        #region Constructors

        internal InstagramLocationsEndpoint(InstagramService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about a location with the specified ID. If a location isn't found, an exception will be thrown.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations</cref>
        /// </see>
        public InstagramGetLocationResponse GetLocation(long locationId) {
            return InstagramGetLocationResponse.ParseResponse(Raw.GetLocation(locationId));
        }

        /// <summary>
        /// Gets a list of recent media from the specified <paramref name="location"/>.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns>An instance of <see cref="InstagramGetLocationRecentMediaResponse"/> representing the response from the Instagram API.</returns>
        public InstagramGetLocationRecentMediaResponse GetRecentMedia(InstagramLocation location) {
            return InstagramGetLocationRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(location));
        }

        /// <summary>
        /// Gets a list of recent media from the specified <paramref name="location"/>.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="count">The maximum amount of media to be returned.</param>
        /// <returns>An instance of <see cref="InstagramGetLocationRecentMediaResponse"/> representing the response from the Instagram API.</returns>
        public InstagramGetLocationRecentMediaResponse GetRecentMedia(InstagramLocation location, int count) {
            return InstagramGetLocationRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(location, count));
        }

        /// <summary>
        /// Gets a list of recent media from a location with the specified <paramref name="locationId"/>.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        /// <returns>An instance of <see cref="InstagramGetLocationRecentMediaResponse"/> representing the response from the Instagram API.</returns>
        public InstagramGetLocationRecentMediaResponse GetRecentMedia(long locationId) {
            return InstagramGetLocationRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(locationId));
        }

        /// <summary>
        /// Gets a list of recent media from a location with the specified <paramref name="locationId"/>.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        /// <param name="count">The maximum amount of media to be returned.</param>
        /// <returns>An instance of <see cref="InstagramGetLocationRecentMediaResponse"/> representing the response from the Instagram API.</returns>
        public InstagramGetLocationRecentMediaResponse GetRecentMedia(long locationId, int count) {
            return InstagramGetLocationRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(locationId));
        }

        /// <summary>
        /// Gets a list of recent media from a location matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the search.</param>
        /// <returns>An instance of <see cref="InstagramGetLocationRecentMediaResponse"/> representing the response from the Instagram API.</returns>
        public InstagramGetLocationRecentMediaResponse GetRecentMedia(InstagramGetLocationRecentMediaOptions options) {
            return InstagramGetLocationRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(options));
        }

        /// <summary>
        /// Search for a location by geographic coordinate within a 1000 meters.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_search</cref>
        /// </see>
        public InstagramGetLocationsResponse Search(double latitude, double longitude) {
            return InstagramGetLocationsResponse.ParseResponse(Raw.Search(latitude, longitude));
        }

        /// <summary>
        /// Search for a location by geographic coordinate.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="distance">The distance is meters (max: 5000m)</param>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_search</cref>
        /// </see>
        public InstagramGetLocationsResponse Search(double latitude, double longitude, int distance) {
            return InstagramGetLocationsResponse.ParseResponse(Raw.Search(latitude, longitude, distance));
        }

        /// <summary>
        /// Search for a location by geographic coordinate.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_search</cref>
        /// </see>
        public InstagramGetLocationsResponse Search(InstagramGetLocationSearchOptions options) {
            return InstagramGetLocationsResponse.ParseResponse(Raw.Search(options));
        }

        #endregion

    }

}