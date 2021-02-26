﻿using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Instagram.BasicDisplay.Models.Users;
using Skybrud.Social.Instagram.Models;

namespace Skybrud.Social.Instagram.BasicDisplay.Models.Media {

    public class InstagramMediaListPaging : InstagramObject {

        #region Properties

        public InstagramMediaListCursors Cursors { get; }

        public string Next { get; }

        public bool HasNext => string.IsNullOrWhiteSpace(Next) == false;

        #endregion

        #region Constructors

        private InstagramMediaListPaging(JObject obj) : base(obj) {
            Cursors = obj.GetObject("cursors", InstagramMediaListCursors.Parse);
            Next = obj.GetString("next");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="InstagramUser"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="InstagramUser"/>.</returns>
        public static InstagramMediaListPaging Parse(JObject obj) {
            return obj == null ? null : new InstagramMediaListPaging(obj);
        }

        #endregion

    }

}