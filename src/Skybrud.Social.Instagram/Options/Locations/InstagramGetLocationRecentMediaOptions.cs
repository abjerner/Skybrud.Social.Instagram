using System;
using Skybrud.Essentials.Time;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects.Locations;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Instagram.Options.Locations {

    /// <summary>
    /// Class representing the options for getting recent media of a location.
    /// </summary>
    public class InstagramGetLocationRecentMediaOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the location.
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of media to be returned.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Only media before this timestamp is returned.
        /// </summary>
        // TODO: Not sure whether this is inclusive or exclusive.
        public EssentialsDateTime MaxTimestamp { get; set; }

        /// <summary>
        /// Only media after this timestamp is returned.
        /// </summary>
        // TODO: Not sure whether this is inclusive or exclusive.
        public EssentialsDateTime MinTimestamp { get; set; }

        /// <summary>
        /// Only media after this ID is returned.
        /// </summary>
        // TODO: Not sure whether this is inclusive or exclusive.
        public string MinId { get; set; }

        /// <summary>
        /// Only media before this ID is returned.
        /// </summary>
        // TODO: Not sure whether this is inclusive or exclusive.
        public string MaxId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize a new instance with default options.
        /// </summary>
        public InstagramGetLocationRecentMediaOptions() { }

        /// <summary>
        /// Initializes a new instance with the specified <code>locationId</code>.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        public InstagramGetLocationRecentMediaOptions(int locationId) {
            LocationId = locationId;
        }

        /// <summary>
        /// Initializes a new instance with the specified <code>location</code>.
        /// </summary>
        /// <param name="location">The location.</param>
        public InstagramGetLocationRecentMediaOptions(InstagramLocation location) {
            if (location == null) throw new ArgumentNullException("location");
            LocationId = location.Id;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        public IHttpQueryString GetQueryString() {
            SocialHttpQueryString qs = new SocialHttpQueryString();
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