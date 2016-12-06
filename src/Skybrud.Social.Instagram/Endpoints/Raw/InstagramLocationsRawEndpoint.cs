using System;
using Skybrud.Essentials.Common;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Objects.Locations;
using Skybrud.Social.Instagram.Options.Locations;

namespace Skybrud.Social.Instagram.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the locations endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/</cref>
    /// </see>
    public class InstagramLocationsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram OAuth client.
        /// </summary>
        public InstagramOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal InstagramLocationsRawEndpoint(InstagramOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about a location with the specified <code>locationId</code>.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations</cref>
        /// </see>
        public SocialHttpResponse GetLocation(int locationId) {
            return Client.DoHttpGetRequest("https://api.instagram.com/v1/locations/" + locationId);
        }

        /// <summary>
        /// Gets a list of recent media from the specified <code>location</code>.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_media_recent</cref>
        /// </see>
        public SocialHttpResponse GetRecentMedia(InstagramLocation location) {
            if (location == null) throw new ArgumentNullException("location");
            return GetRecentMedia(new InstagramGetLocationRecentMediaOptions(location.Id));
        }

        /// <summary>
        /// Gets a list of recent media from a location with the specified <code>locationId</code>.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_media_recent</cref>
        /// </see>
        public SocialHttpResponse GetRecentMedia(int locationId) {
            return GetRecentMedia(new InstagramGetLocationRecentMediaOptions(locationId));
        }

        /// <summary>
        /// Gets a list of recent media from a location with the specified <code>locationId</code>.
        /// </summary>
        /// <param name="options">The options for the search.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_media_recent</cref>
        /// </see>
        public SocialHttpResponse GetRecentMedia(InstagramGetLocationRecentMediaOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            if (options.LocationId == 0) throw new PropertyNotSetException("options.LocationId");
            return Client.DoHttpGetRequest("https://api.instagram.com/v1/locations/" + options.LocationId + "/media/recent", options);
        }

        /// <summary>
        /// Gets a list of locations with a geographic coordinate within a 1000 metres of the
        /// specified <code>latitude</code> and <code>longitude</code>.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_search</cref>
        /// </see>
        public SocialHttpResponse Search(double latitude, double longitude) {
            return Search(new InstagramGetLocationSearchOptions {
                Latitude = latitude,
                Longitude = longitude
            });
        }

        /// <summary>
        /// Gets a list of locations with a geographic coordinate within <code>distance</code>
        /// meters of the specified <code>latitude</code> and <code>longitude</code>.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="distance">The distance is metres (max: 5000m)</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_search</cref>
        /// </see>
        public SocialHttpResponse Search(double latitude, double longitude, int distance) {
            return Search(new InstagramGetLocationSearchOptions {
                Latitude = latitude,
                Longitude = longitude,
                Distance = distance
            });
        }

        /// <summary>
        /// Gets a list of locations with a geographic coordinate within the radius as described in the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_search</cref>
        /// </see>
        public SocialHttpResponse Search(InstagramGetLocationSearchOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoHttpGetRequest("https://api.instagram.com/v1/locations/search", options);
        }

        #endregion

    }

}