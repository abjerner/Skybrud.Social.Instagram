using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;

namespace Skybrud.Social.Instagram.Graph.Models {

    /// <summary>
    /// Class representing a basic object from the <strong>Instagram Graph API</strong> derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class InstagramObject : JsonObjectBase {

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected InstagramObject(JObject json) : base(json) { }

        #endregion

    }

}