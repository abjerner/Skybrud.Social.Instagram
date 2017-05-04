using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Objects.Common {
   
    /// <summary>
    /// Class representing the response body of a response from the Instagram API.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InstagramEnvelope<T> : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets meta data about the response.
        /// </summary>
        public InstagramMetaData Meta { get; private set; }
        
        /// <summary>
        /// Gets the data of the response.
        /// </summary>
        public T Data { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        /// <returns>An instance of <see cref="InstagramMetaData"/>.</returns>
        protected InstagramEnvelope(JObject obj) : base(obj) {
            Meta = obj.GetObject("meta", InstagramMetaData.Parse);
        }

        #endregion

    }

}