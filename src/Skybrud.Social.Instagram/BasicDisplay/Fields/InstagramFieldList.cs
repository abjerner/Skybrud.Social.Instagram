using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Instagram.BasicDisplay.Fields {

    /// <summary>
    /// Class representing a list of fields in the Instagram Basic Display API.
    /// </summary>
    public class InstagramFieldList : IReadOnlyList<InstagramField> {

        #region Private fields

        private readonly List<InstagramField> _list = new();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the total number of fields added to the list.
        /// </summary>
        public int Count => _list.Count;

        /// <summary>
        /// Gets the field at the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>An instance of <see cref="InstagramField"/>.</returns>
        public InstagramField this[int index] => _list[index];

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new list based on the specified <paramref name="array"/> of fields.
        /// </summary>
        /// <param name="array">Array of fields.</param>
        public InstagramFieldList(params InstagramField[] array) {
            _list.AddRange(array);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Adds the specified <paramref name="field"/> to the list.
        /// </summary>
        /// <param name="field">The field to be added.</param>
        public void Add(InstagramField field) {
            _list.Add(field);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the list.
        /// </summary>
        /// <returns>An instance of <see cref="IEnumerator{InstagramField}"/>.</returns>
        public IEnumerator<InstagramField> GetEnumerator() {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Returns a string representing the fields added to the list using a comma as a separator.
        /// </summary>
        /// <returns>String of fields separated by a comma.</returns>
        public override string ToString() {
            return string.Join(",", from field in _list select field);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Operators

        /// <summary>
        /// Initializes a new list based on the specified string of <paramref name="fields"/>.
        /// </summary>
        /// <param name="fields">The string of fields the list should be based on.</param>
        /// <returns>A new list based on a string of <paramref name="fields"/>.</returns>
        public static implicit operator InstagramFieldList(string? fields) {
            InstagramFieldList list = new();
            foreach (string alias in (fields ?? string.Empty).Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) {
                list.Add(alias);
            }
            return list;
        }

        /// <summary>
        /// Initializes a new list based on the specified array of fields.
        /// </summary>
        /// <param name="fields">The array of fields the list should be based on.</param>
        /// <returns>A new list based on an array of <paramref name="fields"/>.</returns>
        public static implicit operator InstagramFieldList(string[] fields) {
            InstagramFieldList list = new();
            foreach (string alias in fields) {
                list.Add(alias);
            }
            return list;
        }

        /// <summary>
        /// Initializes a new list based on the specified <paramref name="field"/>.
        /// </summary>
        /// <param name="field">The field the list should be based on.</param>
        /// <returns>A new list based on a single <paramref name="field"/>.</returns>
        public static implicit operator InstagramFieldList(InstagramField field) {
            return new InstagramFieldList(field);
        }

        /// <summary>
        /// Initializes a new list based on the specified array of <paramref name="fields"/>.
        /// </summary>
        /// <param name="fields">The fields the list should be based on.</param>
        /// <returns>A new list based on an array of <paramref name="fields"/>.</returns>
        public static implicit operator InstagramFieldList(InstagramField[] fields) {
            return new InstagramFieldList(fields);
        }

        /// <summary>
        /// Adds support for adding a <paramref name="field"/> to the <paramref name="list"/> using the plus
        /// operator.
        /// </summary>
        /// <param name="list">The list to which <paramref name="field"/> will be added.</param>
        /// <param name="field">The field to be added to the <paramref name="list"/>.</param>
        public static InstagramFieldList operator +(InstagramFieldList list, InstagramField field) {
            list.Add(field);
            return list;
        }

        #endregion

    }

}