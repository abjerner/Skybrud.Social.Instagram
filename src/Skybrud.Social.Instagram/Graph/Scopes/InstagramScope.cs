﻿using System.Collections.Generic;

namespace Skybrud.Social.Instagram.Graph.Scopes {

    /// <summary>
    /// Class representing a scope of the <strong>Instagram Graph API</strong>.
    /// </summary>
    public class InstagramScope {

        #region Private fields

        private static readonly Dictionary<string, InstagramScope> Scopes = new Dictionary<string, InstagramScope>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the name of the scope.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the description of the scope.
        /// </summary>
        public string Description { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default and private constructor.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        public InstagramScope(string name, string description = null) {
            Name = name;
            Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the name of the scope.
        /// </summary>
        /// <returns>Returns the name of the scope.</returns>
        public override string ToString() {
            return Name;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Registers a scope in the internal dictionary.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        internal static InstagramScope RegisterScope(string name, string description = null) {
            InstagramScope scope = new InstagramScope(name, description);
            Scopes.Add(scope.Name, scope);
            return scope;
        }

        /// <summary>
        /// Attempts to get a scope with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <returns>Gets a scope matching the specified <paramref name="name"/>, or <c>null</c> if not found.</returns>
        public static InstagramScope GetScope(string name) {
            return Scopes.TryGetValue(name, out InstagramScope scope) ? scope : null;
        }

        /// <summary>
        /// Gets whether the scope is a known scope.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <returns><c>true</c> if the specified <paramref name="name"/> matches a known scope, otherwise <c>false</c>.</returns>
        public static bool ScopeExists(string name) {
            return Scopes.ContainsKey(name);
        }

        #endregion
        
        #region Operators

        /// <summary>
        /// Adding two instances of <see cref="InstagramScope"/> will result in a <see cref="InstagramScopeList"/> containing both scopes.
        /// </summary>
        /// <param name="left">The left scope.</param>
        /// <param name="right">The right scope.</param>
        public static InstagramScopeList operator +(InstagramScope left, InstagramScope right) {
            return new InstagramScopeList(left, right);
        }

        #endregion

    }

}