using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Social.Instagram.Fields;

namespace Skybrud.Social.Instagram.Graph.Options.Users {

    /// <summary>
    /// Options for getting information about an Instagram user.
    /// </summary>
    public class InstagramGetUserOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the Instagram user.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the fields to be returned.
        /// </summary>
        public InstagramFieldsCollection Fields { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public InstagramGetUserOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the Instagram user.</param>
        public InstagramGetUserOptions(string id) {
            Id = id;
            Fields = new InstagramFieldsCollection();
        }
        
        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the Instagram user.</param>
        /// <param name="fields">The fields to be returned by the API.</param>
        public InstagramGetUserOptions(string id, InstagramFieldsCollection fields) {
            Id = id;
            Fields = fields;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            // Validate required properties
            if (string.IsNullOrWhiteSpace(Id)) throw new PropertyNotSetException(nameof(Id));

            // Initialize a new query string
            IHttpQueryString query = new HttpQueryString();

            // Convert the collection of fields to a string
            string fields = (Fields == null ? string.Empty : Fields.ToString()).Trim();

            // Update the query string
            if (string.IsNullOrWhiteSpace(fields) == false) query.Set("fields", fields);

            // Initialize a new GET request
            return HttpRequest.Get($"/{Id}", query);

        }

        #endregion

    }

}