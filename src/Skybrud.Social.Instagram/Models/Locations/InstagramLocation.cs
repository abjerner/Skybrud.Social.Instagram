using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Maps.Geometry;

namespace Skybrud.Social.Instagram.Models.Locations {
    
    /// <summary>
    /// Class representing the location of where a media (image or video) was taken. Some media may not have a location.
    /// </summary>
    public class InstagramLocation : InstagramObject, IPoint {

        #region Properties

        /// <summary>
        /// Gets the ID of the location.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// The name of the location.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the latitude of the location. The latitude specifies the north-south position of a
        /// point on the Earth's surface.
        /// </summary>
        public double Latitude { get; }

        /// <summary>
        /// Gets the longitude of the location. The longitude specifies the east-west position of a
        /// point on the Earth's surface.
        /// </summary>
        public double Longitude { get; }

        #endregion

        #region Constructors

        private InstagramLocation(JObject obj) : base(obj) {
            Id = obj.GetInt64("id");
            Name = obj.GetString("name");
            Latitude = obj.GetDouble("latitude");
            Longitude = obj.GetDouble("longitude");
        }

        #endregion

        #region Static methods
        
        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramLocation"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="InstagramLocation"/>.</returns>
        public static InstagramLocation Parse(JObject obj) {
            return obj == null ? null : new InstagramLocation(obj);
        }

        #endregion

    }

}