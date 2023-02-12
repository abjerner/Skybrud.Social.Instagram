using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Instagram.BasicDisplay.Models.Errors {

    /// <summary>
    /// Class representing details about an error returned by the <strong>Instagram Basic Display API</strong>.
    /// </summary>
    public class InstagramError : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets the message of the error.
        /// </summary>
        public string? Message { get; }

        /// <summary>
        /// Gets the type of the error.
        /// </summary>
        public string? Type { get; }

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

        private InstagramError(JObject json) : base(json) {
            Message = json.GetString("message") ?? json.GetString("error_message");
            Type = json.GetString("type") ?? json.GetString("error_type");
            Code = json.GetInt32("code");
            ErrorSubcode = json.GetInt32("error_subcode");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="InstagramError"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramError"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static InstagramError? Parse(JObject? json) {
            return json == null ? null : new InstagramError(json);
        }

        #endregion

    }

}