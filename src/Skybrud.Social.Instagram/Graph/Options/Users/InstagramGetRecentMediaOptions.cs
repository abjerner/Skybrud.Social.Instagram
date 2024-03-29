﻿// ReSharper disable InconsistentNaming

using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Social.Instagram.Graph.Fields;

namespace Skybrud.Social.Instagram.Graph.Options.Users {

    /// <summary>
    /// Class with options for getting recent media of an Instagram user.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/instagram-api/reference/user/media#get-media</cref>
    /// </see>
    public class InstagramGetRecentMediaOptions : IHttpRequestOptions {

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
        /// Gets or sets the maximum amount of media that should be returned in each page.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Gets or sets the cursor that points to the start of the page of data that has been returned.
        /// </summary>
        public string? Before { get; set; }

        /// <summary>
        /// Gets or sets the cursor that points to the end of the page of data that has been returned.
        /// </summary>
        public string? After { get; set; }

        /// <summary>
        /// Gets or sets the fields to be returned.
        /// </summary>
        public InstagramFieldList Fields { get; set; } = new();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public InstagramGetRecentMediaOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the Instagram user.</param>
#if NET7_0_OR_GREATER
        [SetsRequiredMembers]
#endif
        public InstagramGetRecentMediaOptions(string id) {
            Id = id;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the Instagram user.</param>
        /// <param name="fields">The fields to be returned by the API.</param>
#if NET7_0_OR_GREATER
        [SetsRequiredMembers]
#endif
        public InstagramGetRecentMediaOptions(string id, InstagramFieldList? fields) {
            Id = id;
            Fields = fields ?? Fields;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="id"/> and <paramref name="limit"/>.
        /// </summary>
        /// <param name="id">The ID of the Instagram user.</param>
        /// <param name="limit">The maximum amount of media that should be returned in each page.</param>
#if NET7_0_OR_GREATER
        [SetsRequiredMembers]
#endif
        public InstagramGetRecentMediaOptions(string id, int? limit) {
            Id = id;
            Limit = limit;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="id"/>, <paramref name="limit"/> and <paramref name="after"/>.
        /// </summary>
        /// <param name="id">The ID of the Instagram user.</param>
        /// <param name="limit">The maximum amount of media that should be returned in each page.</param>
        /// <param name="after">The cursor that points to the end of the page of data that has been returned.</param>
#if NET7_0_OR_GREATER
        [SetsRequiredMembers]
#endif
        public InstagramGetRecentMediaOptions(string id, int? limit, string? after) {
            Id = id;
            Limit = limit;
            After = after;
            Fields = new InstagramFieldList();
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="id"/>, <paramref name="limit"/> and <paramref name="after"/>.
        /// </summary>
        /// <param name="id">The ID of the Instagram user.</param>
        /// <param name="limit">The maximum amount of media that should be returned in each page.</param>
        /// <param name="after">The cursor that points to the end of the page of data that has been returned.</param>
        /// <param name="fields">The fields to be returned by the API.</param>
#if NET7_0_OR_GREATER
        [SetsRequiredMembers]
#endif
        public InstagramGetRecentMediaOptions(string id, int? limit, string? after, InstagramFieldList? fields) {
            Id = id;
            Limit = limit;
            After = after;
            Fields = fields ?? Fields;
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
            if (Limit != null) query.Set("limit", Limit.Value);
            if (string.IsNullOrWhiteSpace(After) == false) query.Set("after", After);
            if (string.IsNullOrWhiteSpace(Before) == false) query.Set("before", Before);

            // Initialize a new GET request
            return HttpRequest.Get($"/{Id}/media", query);

        }

        #endregion

    }

}