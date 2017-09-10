using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.Models.Common;

namespace Skybrud.Social.Instagram.Models.Tags {
    
    /// <summary>
    /// Class representing the response body of a call for getting a list of tags matching a given query.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags_search</cref>
    /// </see>
    public class InstagramSearchTagsEnvelope : InstagramEnvelope<InstagramTag[]> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramSearchTagsEnvelope(JObject obj) : base(obj) {
            Data = obj.GetArray("data", InstagramTag.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramSearchTagsEnvelope"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramSearchTagsEnvelope"/>.</returns>
        public static InstagramSearchTagsEnvelope Parse(JObject obj) {
            return obj == null ? null : new InstagramSearchTagsEnvelope(obj);
        }

        #endregion

    }

}