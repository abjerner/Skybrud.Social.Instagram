using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Instagram.Graph.Scopes {

    /// <summary>
    /// Class representing a list of scopes for the <strong>Instagram Graph API</strong>.
    /// </summary>
    public class InstagramScopeList {

        #region Private fields

        private readonly List<InstagramScope> _list = new();

        #endregion

        #region Properties

        /// <summary>
        /// Gets an array of all the scopes added to the list.
        /// </summary>
        public IReadOnlyList<InstagramScope> Items => _list;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new list based on the specified <paramref name="array"/> of scopes.
        /// </summary>
        /// <param name="array">Array of scopes.</param>
        public InstagramScopeList(params InstagramScope[] array) {
            _list.AddRange(array);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Adds the specified <paramref name="scope"/> to the list.
        /// </summary>
        /// <param name="scope">The scope to be added.</param>
        public void Add(InstagramScope scope) {
            _list.Add(scope);
        }

        /// <summary>
        /// Returns an array of scopes based on the list.
        /// </summary>
        /// <returns>Array of scopes contained in the location.</returns>
        public InstagramScope[] ToArray() {
            return _list.ToArray();
        }

        /// <summary>
        /// Returns an array of strings representing each scope in the list.
        /// </summary>
        /// <returns>Array of strings representing each scope in the list.</returns>
        public string[] ToStringArray() {
            return (from scope in _list select scope.Name).ToArray();
        }

        /// <summary>
        /// Returns a string representing the scopea added to the list using a comma as a separator.
        /// </summary>
        /// <returns>String of scopes separated by a comma.</returns>
        public override string ToString() {
            return string.Join(" ", from scope in _list select scope.Name);
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Initializes a new list based on a single <paramref name="scope"/>.
        /// </summary>
        /// <param name="scope">The scope the list should be based on.</param>
        /// <returns>A new list based on a single <paramref name="scope"/>.</returns>
        public static implicit operator InstagramScopeList(InstagramScope scope) {
            return new InstagramScopeList(scope);
        }

        /// <summary>
        /// Initializes a new list based on an <paramref name="array"/> of scopes.
        /// </summary>
        /// <param name="array">The array of scopes the list should be based on.</param>
        /// <returns>A new list based on an <paramref name="array"/> of scopes.</returns>
        public static implicit operator InstagramScopeList(InstagramScope[] array) {
            return new InstagramScopeList(array ?? Array.Empty<InstagramScope>());
        }

        /// <summary>
        /// Adds support for adding a <paramref name="scope"/> to the <paramref name="list"/> using the plus operator.
        /// </summary>
        /// <param name="list">The list to which <paramref name="scope"/> will be added.</param>
        /// <param name="scope">The scope to be added to the <paramref name="list"/>.</param>
        public static InstagramScopeList operator +(InstagramScopeList list, InstagramScope scope) {
            list.Add(scope);
            return list;
        }

        #endregion

    }

}