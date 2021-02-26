using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Social.Instagram.BasicDisplay.Fields;

namespace Skybrud.Social.Instagram.BasicDisplay.Options {
    
    /// <summary>
    /// Class representing the options for a request to get information about an Instagram user.
    /// </summary>
    public class InstagramGetUserOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the user to request information about. If not specified, information about the authenticated user will be requested instead.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the fields to be returned by the API.
        /// </summary>
        public InstagramFieldList Fields { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public InstagramGetUserOptions() {
            Fields = new InstagramFieldList();
        }

        /// <summary>
        /// Initializes a instance based on the specified <paramref name="fields"/>.
        /// </summary>
        /// <param name="fields">The fields to be returned by the API.</param>
        public InstagramGetUserOptions(InstagramFieldList fields)  {
            Fields = fields ?? new InstagramFieldList();
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public InstagramGetUserOptions(long userId) {
            UserId = userId;
            Fields = new InstagramFieldList();
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="userId"/> and <paramref name="fields"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="fields">The fields to be returned by the API.</param>
        public InstagramGetUserOptions(long userId, InstagramFieldList fields) {
            UserId = userId;
            Fields = fields ?? new InstagramFieldList();
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest()  {
            
            IHttpQueryString query = new HttpQueryString();
            if (Fields != null && Fields.Count > 0) query.Add("fields", Fields);

            return HttpRequest.Get($"/{(UserId == 0 ? "me" : UserId.ToString())}", query);

        }

        #endregion

    }

}