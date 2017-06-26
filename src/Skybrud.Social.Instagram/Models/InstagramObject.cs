using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;

namespace Skybrud.Social.Instagram.Models {

    /// <summary>
    /// Class representing a basic object from the Instagram API derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class InstagramObject : JsonObjectBase {

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the object.</param>
        protected InstagramObject(JObject obj) : base(obj) { }

        #endregion

    }

}