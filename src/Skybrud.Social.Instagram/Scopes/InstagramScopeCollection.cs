using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Instagram.Scopes {
    
    /// <summary>
    /// Class representing a collection of scopes for the Instagram API.
    /// </summary>
    public class InstagramScopeCollection {

        #region Private fields

        private readonly List<InstagramScope> _list = new List<InstagramScope>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets an array of all the scopes added to the collection.
        /// </summary>
        public InstagramScope[] Items => _list.ToArray();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new collection based on the specified <code>array</code> of scopes.
        /// </summary>
        /// <param name="array">Array of scopes.</param>
        public InstagramScopeCollection(params InstagramScope[] array) {
            _list.AddRange(array);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Adds the specified <code>scope</code> to the collection.
        /// </summary>
        /// <param name="scope">The scope to be added.</param>
        public void Add(InstagramScope scope) {
            _list.Add(scope);
        }

        /// <summary>
        /// Returns an array of scopes based on the collection.
        /// </summary>
        /// <returns>Array of scopes contained in the location.</returns>
        public InstagramScope[] ToArray() {
            return _list.ToArray();
        }

        /// <summary>
        /// Returns an array of strings representing each scope in the collection.
        /// </summary>
        /// <returns>Array of strings representing each scope in the collection.</returns>
        public string[] ToStringArray() {
            return (from scope in _list select scope.Name).ToArray();
        }

        /// <summary>
        /// Returns a string representing the scopea added to the collection using a comma as a separator.
        /// </summary>
        /// <returns>String of scopes separated by a comma.</returns>
        public override string ToString() {
            return string.Join(" ", from scope in _list select scope.Name);
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Initializes a new collection based on a single <code>scope</code>.
        /// </summary>
        /// <param name="scope">The scope the collection should be based on.</param>
        /// <returns>Returns a new collection based on a single <code>scope</code>.</returns>
        public static implicit operator InstagramScopeCollection(InstagramScope scope) {
            return new InstagramScopeCollection(scope);
        }

        /// <summary>
        /// Initializes a new collection based on an <code>array</code> of scopes.
        /// </summary>
        /// <param name="array">The array of scopes the collection should be based on.</param>
        /// <returns>Returns a new collection based on an <code>array</code> of scopes.</returns>
        public static implicit operator InstagramScopeCollection(InstagramScope[] array) {
            return new InstagramScopeCollection(array ?? new InstagramScope[0]);
        }

        /// <summary>
        /// Adds support for adding a <code>scope</code> to the <code>collection</code> using the plus operator.
        /// </summary>
        /// <param name="collection">The collection to which <code>scope</code> will be added.</param>
        /// <param name="scope">The scope to be added to the <code>collection</code>.</param>
        public static InstagramScopeCollection operator +(InstagramScopeCollection collection, InstagramScope scope) {
            collection.Add(scope);
            return collection;
        }

        #endregion

    }

}