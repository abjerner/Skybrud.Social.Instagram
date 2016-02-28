using System;
using Skybrud.Social.Instagram.Objects.Locations;
using Skybrud.Social.Instagram.Options.Common;

namespace Skybrud.Social.Instagram.Options.Locations {

    /// <summary>
    /// Class representing the options for getting recent media of a location.
    /// </summary>
    public class InstagramLocationRecentMediaOptions : InstagramRecentMediaOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the location.
        /// </summary>
        public int LocationId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize a new instance with default options.
        /// </summary>
        public InstagramLocationRecentMediaOptions() { }

        /// <summary>
        /// Initializes a new instance with the specified <code>locationId</code>.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        public InstagramLocationRecentMediaOptions(int locationId) {
            LocationId = locationId;
        }

        /// <summary>
        /// Initializes a new instance with the specified <code>location</code>.
        /// </summary>
        /// <param name="location">The location.</param>
        public InstagramLocationRecentMediaOptions(InstagramLocation location) {
            if (location == null) throw new ArgumentNullException("location");
            LocationId = location.Id;
        }

        #endregion

    }

}