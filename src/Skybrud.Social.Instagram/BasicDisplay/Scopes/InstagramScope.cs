using System.Collections.Generic;

namespace Skybrud.Social.Instagram.BasicDisplay.Scopes {

    /// <summary>
    /// Class representing a scope of the <strong>Instagram Basic Display API</strong>.
    /// </summary>
    public class InstagramScope {

        #region Private fields

        private static readonly Dictionary<string, InstagramScope> _scopes = new();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the name of the scope.
        /// </summary>
        public string Alias { get; }

        /// <summary>
        /// Gets the name of the scope.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the description of the scope.
        /// </summary>
        public string? Description { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default and private constructor.
        /// </summary>
        /// <param name="alias">The alias of the scope.</param>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        public InstagramScope(string alias, string name, string? description = null) {
            Alias = alias;
            Name = name;
            Description = string.IsNullOrWhiteSpace(description) ? null : description!.Trim();
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the alias of the scope.
        /// </summary>
        /// <returns>Returns the alias of the scope.</returns>
        public override string ToString() {
            return Alias;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Registers a scope in the internal dictionary.
        /// </summary>
        /// <param name="alias">The alias of the scope.</param>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        internal static InstagramScope RegisterScope(string alias, string name, string? description = null) {
            InstagramScope scope = new(alias, name, description);
            _scopes.Add(scope.Alias, scope);
            return scope;
        }

        /// <summary>
        /// Attempts to get a scope with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The alias of the scope.</param>
        /// <returns>Gets a scope matching the specified <paramref name="alias"/>, or <c>null</c> if not found.</returns>
        public static InstagramScope? GetScope(string alias) {
            return _scopes.TryGetValue(alias, out InstagramScope? scope) ? scope : null;
        }

        /// <summary>
        /// Gets whether the scope is a known scope.
        /// </summary>
        /// <param name="alias">The alias of the scope.</param>
        /// <returns><c>true</c> if the specified <paramref name="alias"/> matches a known scope, otherwise <c>false</c>.</returns>
        public static bool ScopeExists(string alias) {
            return _scopes.ContainsKey(alias);
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