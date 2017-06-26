using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Models {

    /// <summary>
    /// Class representing the meta data returned by the Instagram API.
    /// </summary>
    public class InstagramMetaData : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the status code of the call.
        /// </summary>
        public int Code { get; private set; }

        /// <summary>
        /// Gets the type of the error or <code>null</code> if not specified.
        /// </summary>
        public string ErrorType { get; private set; }

        /// <summary>
        /// Gets the message of the error or <code>null</code> if not specified.
        /// </summary>
        public string ErrorMessage { get; private set; }

        #endregion

        #region Constructors

        private InstagramMetaData(JObject obj) : base(obj) {
            Code = obj.GetInt32("code");
            ErrorType = obj.GetString("error_type");
            ErrorMessage = obj.GetString("error_message");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramMetaData"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramMetaData"/>.</returns>
        public static InstagramMetaData Parse(JObject obj) {
            return obj == null ? null : new InstagramMetaData(obj);
        }

        #endregion

    }

}