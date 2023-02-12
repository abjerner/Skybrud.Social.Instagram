using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Instagram.Graph.Models.Errors {

    /// <summary>
    /// Class representing an error received through the <strong>Instagram Graph API</strong>.
    /// </summary>
    public class InstagramHttpError : InstagramObject {

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

        /// <summary>
        /// Gets the Facebook trace ID of the error.
        /// </summary>
        public string TraceId { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/>.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the entry.</param>
        protected InstagramHttpError(JObject json) : base(json) {
            Message = json.GetString("message")!;
            Type = json.GetString("type")!;
            Code = json.GetInt32("code")!;
            ErrorSubcode = json.GetInt32("error_subcode");
            TraceId = json.GetString("fbtrace_id")!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="InstagramHttpError"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramHttpError"/>. <paramref name="json"/> is <see langword="null"/>, <see langword="null"/> is returned instead.</returns>
        [return: NotNullIfNotNull("json")]
        public static InstagramHttpError? Parse(JObject? json) {
            return json == null ? null : new InstagramHttpError(json);
        }

        #endregion

    }

}