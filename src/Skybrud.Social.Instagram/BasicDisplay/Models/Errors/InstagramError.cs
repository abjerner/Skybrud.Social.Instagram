using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.BasicDisplay.Models.Errors {

    /// <summary>
    /// Class representing details about an error returned by the <strong>Instagram Basic Display API</strong>.
    /// </summary>
    public class InstagramError : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the message of the error.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Gets the type of the error.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the code of the error.
        /// </summary>
        public int Code { get; }

        /// <summary>
        /// Gets the subcode of the error.
        /// </summary>
        public int ErrorSubcode { get; }

        #endregion

        #region Constructors

        private InstagramError(JObject obj) : base(obj) {
            Message = obj.GetString("message") ?? obj.GetString("error_message");
            Type = obj.GetString("type") ?? obj.GetString("error_type");
            Code = obj.GetInt32("code");
            ErrorSubcode = obj.GetInt32("error_subcode");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="InstagramError"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramError"/>.</returns>
        public static InstagramError Parse(JObject obj) {
            return obj == null ? null : new InstagramError(obj);
        }

        #endregion

    }

}