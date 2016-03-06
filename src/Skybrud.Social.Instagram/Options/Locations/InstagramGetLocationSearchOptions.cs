using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Instagram.Options.Locations {
    
    /// <summary>
    /// Class representing the options for for getting a list of locations within a given radius.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_search</cref>
    /// </see>
    public class InstagramGetLocationSearchOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Required: Gets or sets the latitude.
        /// </summary>
        public double Latitude { get; set; }
        
        /// <summary>
        /// Required: Gets or sets the longitude.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Optional: Gets or sets the search distance in meters. If not specified (eg. if zero), the default value of
        /// the Instagram API will be used. The default distance is 1000 meters, while the maximum distance is 5000
        /// meters.
        /// </summary>
        public int Distance { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize a new instance with default options.
        /// </summary>
        public InstagramGetLocationSearchOptions() { }

        /// <summary>
        /// Initializes a new instance from the specified <code>latitude</code> and <code>longitude</code>.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        public InstagramGetLocationSearchOptions(double latitude, double longitude) {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Initializes a new instance from the specified <code>latitude</code> and <code>longitude</code>.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="distance">The search distance (radius) in meters.</param>
        public InstagramGetLocationSearchOptions(double latitude, double longitude, int distance) {
            Latitude = latitude;
            Longitude = longitude;
            Distance = distance;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets an instance of <see cref="SocialQueryString"/> representing the GET parameters.
        /// </summary>
        public SocialQueryString GetQueryString() {
            SocialQueryString qs = new SocialQueryString();
            qs.Add("lat", Latitude);
            qs.Add("lng", Longitude);
            if (Distance > 0) qs.Add("distance", Distance);
            return qs;
        }

        #endregion

    }

}