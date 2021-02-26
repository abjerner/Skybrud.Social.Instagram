﻿using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Social.Instagram.BasicDisplay.Fields;

namespace Skybrud.Social.Instagram.BasicDisplay.Options {
    
    /// <summary>
    /// Options for getting recent media of a given Instagram user.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/instagram-basic-display-api/reference/user/media</cref>
    /// </see>
    public class InstagramGetUserMediaOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the user. Indicates the authenticated user if <c>0</c> (default).
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets a collection fo fields that should be returned by the API.
        /// </summary>
        public InstagramFieldsCollection Fields { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of media to be returned.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Gets or sets the cursor that points to the end of the page of data that has been returned.
        /// </summary>
        public string After { get; set; }

        /// <summary>
        /// Gets or sets the cursor that points to the start of the page of data that has been returned.
        /// </summary>
        public string Before { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public InstagramGetUserMediaOptions() {
            Fields = new InstagramFieldsCollection();
        }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="fields"/>.
        /// </summary>
        /// <param name="fields">A collection fo fields that should be returned by the API.</param>
        public InstagramGetUserMediaOptions(InstagramFieldsCollection fields)  {
            Fields = fields ?? new InstagramFieldsCollection();
        }
        
        /// <summary>
        /// Initializes a new instance with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public InstagramGetUserMediaOptions(long userId) {
            UserId = userId;
            Fields = new InstagramFieldsCollection();
        }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="userId"/> and <paramref name="fields"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="fields">A collection fo fields that should be returned by the API.</param>
        public InstagramGetUserMediaOptions(long userId, InstagramFieldsCollection fields) {
            UserId = userId;
            Fields = fields ?? new InstagramFieldsCollection();
        }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="userId"/>, <paramref name="fields"/> and
        /// <paramref name="after"/>.
        /// </summary>
        /// <param name="userId">The ID of the user. Use <c>0</c> to indicate the authenticated user.</param>
        /// <param name="limit">The maximum amount of media to be returned.</param>
        /// <param name="after"></param>
        public InstagramGetUserMediaOptions(long userId, int limit, string after) {
            UserId = userId;
            Limit = limit;
            After = after;
            Fields = new InstagramFieldsCollection();
        }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="userId"/>, <paramref name="fields"/>,
        /// <paramref name="after"/> and <paramref name="fields"/>.
        /// </summary>
        /// <param name="userId">The ID of the user. Use <c>0</c> to indicate the authenticated user.</param>
        /// <param name="limit">The maximum amount of media to be returned.</param>
        /// <param name="after"></param>
        /// <param name="fields"></param>
        public InstagramGetUserMediaOptions(long userId, int limit, string after, InstagramFieldsCollection fields) {
            UserId = userId;
            Limit = limit;
            After = after;
            Fields = fields ?? new InstagramFieldsCollection();
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest()  {
            
            IHttpQueryString query = new HttpQueryString();
            if (Fields != null && Fields.Count > 0) query.Add("fields", Fields);
            if (Limit > 0) query.Add("limit", Limit);
            if (string.IsNullOrWhiteSpace(After) == false) query.Add("after", After);
            if (string.IsNullOrWhiteSpace(Before) == false) query.Add("before", Before);

            return HttpRequest.Get($"/{(UserId == 0 ? "me" : UserId.ToString())}/media", query);

        }

        #endregion

    }

}