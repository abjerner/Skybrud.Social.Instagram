using System;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Locations;
using Skybrud.Essentials.Maps.Geometry;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Instagram.Options.Media {
    
    /// <summary>
    /// Class representing the search options for getting recent media within a given radius of the location identifier
    /// by the <see cref="Latitude"/> and <see cref="Longitude"/> properties.
    /// </summary>
    /// <see>
    ///     <cref>https://www.instagram.com/developer/endpoints/media/#get_media_search</cref>
    /// </see>
    public class InstagramGetRecentMediaOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the latitude of the center search coordinate.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the center search coordinate.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the search distance/radius, specified in meters. Default is <code>1000m</code>, while the max
        /// distance is <code>5000m</code>.
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of media to be returned. Default is <code>20</code>, while the maximum
        /// amount is <code>100</code>.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the minimum timestamp. All media returned will be taken later than this timestamp.
        /// </summary>
        public EssentialsDateTime MinTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the maximum timestamp. All media returned will be taken earlier than this timestamp.
        /// </summary>
        public EssentialsDateTime MaxTimestamp { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public InstagramGetRecentMediaOptions() { }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="latitude"/> and <paramref name="longitude"/>.
        /// </summary>
        /// <param name="latitude">The latitude of the point.</param>
        /// <param name="longitude">The longitude of the point.</param>
        public InstagramGetRecentMediaOptions(double latitude, double longitude) {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="latitude"/>, <paramref name="longitude"/> and
        /// <paramref name="distance"/>.
        /// </summary>
        /// <param name="latitude">The latitude of the point.</param>
        /// <param name="longitude">The longitude of the point.</param>
        /// <param name="distance">The distance/radius in meters. The API allows a maximum radius of 5000 metres.</param>
        public InstagramGetRecentMediaOptions(double latitude, double longitude, int distance) {
            Latitude = latitude;
            Longitude = longitude;
            Distance = distance;
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="location"/>.
        /// </summary>
        /// <param name="location">An instance of <see cref="ILocation"/> representing the point.</param>
        public InstagramGetRecentMediaOptions(IPoint location) {
            if (location == null) throw new ArgumentNullException("location");
            Latitude = location.Latitude;
            Longitude = location.Longitude;
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="location"/> and <paramref name="distance"/>.
        /// </summary>
        /// <param name="location">An instance of <see cref="ILocation"/> representing the point.</param>
        /// <param name="distance">The distance/radius in meters. The API allows a maximum radius of 5000 metres.</param>
        public InstagramGetRecentMediaOptions(IPoint location, int distance) {
            if (location == null) throw new ArgumentNullException("location");
            Latitude = location.Latitude;
            Longitude = location.Longitude;
            Distance = distance;
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="location"/>, <paramref name="distance"/> and <paramref name="count"/>.
        /// </summary>
        /// <param name="location">An instance of <see cref="ILocation"/> representing the point.</param>
        /// <param name="distance">The distance/radius in meters. The API allows a maximum radius of 5000 metres.</param>
        /// <param name="count">The maximum amount of media to be returned. Max is <code>100</code>.</param>
        public InstagramGetRecentMediaOptions(IPoint location, int distance, int count) {
            if (location == null) throw new ArgumentNullException("location");
            Latitude = location.Latitude;
            Longitude = location.Longitude;
            Distance = distance;
            Count = count;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        public IHttpQueryString GetQueryString() {
            
            // Declare the query string
            IHttpQueryString qs = new HttpQueryString();
            qs.Add("lat", Latitude);
            qs.Add("lng", Longitude);

            // Optinal options
            if (Distance > 0) qs.Add("distance", Distance);
            if (Count > 0) qs.Add("count", Count);
            if (MinTimestamp != null) qs.Add("min_timestamp", MinTimestamp.UnixTimestamp);
            if (MaxTimestamp != null) qs.Add("max_timestamp", MaxTimestamp.UnixTimestamp);

            return qs;

        }

        #endregion
    
    }

}