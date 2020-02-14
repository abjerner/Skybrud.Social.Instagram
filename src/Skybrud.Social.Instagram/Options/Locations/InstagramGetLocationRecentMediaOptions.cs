using System;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Time;
using Skybrud.Social.Instagram.Models.Locations;

namespace Skybrud.Social.Instagram.Options.Locations {

    /// <summary>
    /// Class representing the options for getting recent media of a location.
    /// </summary>
    public class InstagramGetLocationRecentMediaOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the location.
        /// </summary>
        public long LocationId { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of media to be returned.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Only media before this timestamp is returned.
        /// </summary>
        public EssentialsDateTime MaxTimestamp { get; set; }

        /// <summary>
        /// Only media after this timestamp is returned.
        /// </summary>
        public EssentialsDateTime MinTimestamp { get; set; }

        /// <summary>
        /// Only media after this ID is returned.
        /// </summary>
        public string MinId { get; set; }

        /// <summary>
        /// Only media before this ID is returned.
        /// </summary>
        public string MaxId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize a new instance with default options.
        /// </summary>
        public InstagramGetLocationRecentMediaOptions() { }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="locationId"/>.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        public InstagramGetLocationRecentMediaOptions(long locationId) {
            LocationId = locationId;
        }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="locationId"/>.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        /// <param name="count">The maximum amount of media to be returned.</param>
        public InstagramGetLocationRecentMediaOptions(long locationId, int count) {
            LocationId = locationId;
            Count = count;
        }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="location"/>.
        /// </summary>
        /// <param name="location">The location.</param>
        public InstagramGetLocationRecentMediaOptions(InstagramLocation location) {
            if (location == null) throw new ArgumentNullException("location");
            LocationId = location.Id;
        }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="location"/>.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="count">The maximum amount of media to be returned.</param>
        public InstagramGetLocationRecentMediaOptions(InstagramLocation location, int count) {
            if (location == null) throw new ArgumentNullException("location");
            LocationId = location.Id;
            Count = count;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        public IHttpQueryString GetQueryString() {
            IHttpQueryString qs = new HttpQueryString();
            if (Count > 0) qs.Add("count", Count);
            if (MaxTimestamp != null) qs.Add("max_timestamp", MaxTimestamp.UnixTimestamp);
            if (MinTimestamp != null) qs.Add("min_timestamp", MinTimestamp.UnixTimestamp);
            if (MinId != null) qs.Add("min_id", MinId);
            if (MaxId != null) qs.Add("max_id", MaxId);
            return qs;
        }

        #endregion

    }

}