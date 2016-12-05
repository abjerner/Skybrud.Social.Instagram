using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Locations;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Objects.Locations {
    
    /// <summary>
    /// Class representing the location of where a media (image or video) was taken. Some media may not have a location.
    /// </summary>
    public class InstagramLocation : InstagramObject, ILocation {

        #region Properties

        /// <summary>
        /// Gets the ID of the location.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// The name of the location.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the latitude of the location. The latitude specifies the north-south position of a
        /// point on the Earth's surface.
        /// </summary>
        public double Latitude { get; private set; }

        /// <summary>
        /// Gets the longitude of the location. The longitude specifies the east-west position of a
        /// point on the Earth's surface.
        /// </summary>
        public double Longitude { get; private set; }

        #endregion

        #region Constructors

        private InstagramLocation(JObject obj) : base(obj) {
            Id = obj.GetInt32("id");
            Name = obj.GetString("name");
            Latitude = obj.GetDouble("latitude");
            Longitude = obj.GetDouble("longitude");
        }

        #endregion

        #region Static methods
        
        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramLocation"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramLocation"/>.</returns>
        public static InstagramLocation Parse(JObject obj) {
            return obj == null ? null : new InstagramLocation(obj);
        }

        #endregion

    }

}