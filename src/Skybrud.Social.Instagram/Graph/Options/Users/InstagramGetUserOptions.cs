using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Social.Instagram.Graph.Fields;

namespace Skybrud.Social.Instagram.Graph.Options.Users {

    /// <summary>
    /// Options for getting information about an Instagram user.
    /// </summary>
    public class InstagramGetUserOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the Instagram user.
        /// </summary>
#if NET7_0_OR_GREATER
        public required string Id { get; set; }
#else
        public string? Id { get; set; }
#endif

        /// <summary>
        /// Gets or sets the fields to be returned.
        /// </summary>
        public InstagramFieldList Fields { get; set; } = new();

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
#if NET7_0_OR_GREATER
        [SetsRequiredMembers]
#endif
        public InstagramGetUserOptions(string id) {
            Id = id;
            Fields = new InstagramFieldList();
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the Instagram user.</param>
        /// <param name="fields">The fields to be returned by the API.</param>
#if NET7_0_OR_GREATER
        [SetsRequiredMembers]
#endif
        public InstagramGetUserOptions(string id, InstagramFieldList fields) {
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
            HttpQueryString query = new();

            // Convert the collection of fields to a string
            string fields = Fields.ToString().Trim();

            // Update the query string
            if (string.IsNullOrWhiteSpace(fields) == false) query.Set("fields", fields);

            // Initialize a new GET request
            return HttpRequest.Get($"/{Id}", query);

        }

        #endregion

    }

}