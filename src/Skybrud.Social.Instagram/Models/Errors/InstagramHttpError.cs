using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Models.Errors {

    /// <summary>
    /// Class representing an error received through the Instagram Graph API.
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
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the entry.</param>
        protected InstagramHttpError(JObject obj) : base(obj) {
            Message = obj.GetString("message");
            Type = obj.GetString("type");
            Code = obj.GetInt32("code");
            ErrorSubcode = obj.GetInt32("error_subcode");
            TraceId = obj.GetString("fbtrace_id");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramHttpError"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramHttpError"/>.</returns>
        public static InstagramHttpError Parse(JObject obj) {
            return obj == null ? null : new InstagramHttpError(obj);
        }

        #endregion

    }

}