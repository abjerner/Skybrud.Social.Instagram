﻿using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Instagram.Graph.Models.Paging;

namespace Skybrud.Social.Instagram.Graph.Models.Media {

    /// <summary>
    /// Class representing a list of Instagram media.
    /// </summary>
    public class InstagramMediaList : InstagramObject {

        #region Properties

        /// <summary>
        /// Gets an array of the <see cref="InstagramMedia"/> mkaing up the response body.
        /// </summary>
        public IReadOnlyList<InstagramMedia> Data { get; }

        /// <summary>
        /// Gets pagiging information about the list.
        /// </summary>
        public InstagramPaging Paging { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> objeect.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected InstagramMediaList(JObject json) : base(json) {
            Data = json.GetArrayItems("data", InstagramMedia.Parse);
            Paging = json.GetObject("paging", InstagramPaging.Parse)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="InstagramMediaList"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramMediaList"/>. <paramref name="json"/> is <see langword="null"/>, <see langword="null"/> is returned instead.</returns>
        public static InstagramMediaList? Parse(JObject? json) {
            return json == null ? null : new InstagramMediaList(json);
        }

        #endregion

    }

}