using System.Collections;
using System.Collections.Generic;

namespace Skybrud.Social.Instagram.BasicDisplay.Fields {

    /// <summary>
    /// Class representing a collection of fields for a given edge.
    /// </summary>
    public class InstagramEdgeField : InstagramField, IEnumerable<InstagramField> {

        #region Properties

        /// <summary>
        /// Gets or sets the fields that should be requested from the edge.
        /// </summary>
        public InstagramFieldList Fields { get; set; }

        /// <summary>
        /// Gets or sets the limit of the edge.
        /// </summary>
        public int Limit { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new field with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The name of the field.</param>
        public InstagramEdgeField(string alias) : base(alias) {
            Fields = new InstagramFieldList();
        }

        /// <summary>
        /// Initializes a new edge field based on the specified <paramref name="alias"/> and <paramref name="fields"/>.
        /// </summary>
        /// <param name="alias">The name of the edge field.</param>
        /// <param name="fields">The fields that should be requested from the edge.</param>
        public InstagramEdgeField(string alias, InstagramFieldList? fields) : base(alias)  {
            Fields = fields ?? new InstagramFieldList();
        }

        /// <summary>
        /// Initializes a new edge field based on the specified <paramref name="alias"/> and <paramref name="limit"/>.
        /// </summary>
        /// <param name="alias">The name of the edge field.</param>
        /// <param name="limit">The limit of the edge.</param>
        public InstagramEdgeField(string alias, int limit) : base(alias)  {
            Limit = limit;
            Fields = new InstagramFieldList();
        }

        /// <summary>
        /// Initializes a new edge field based on the specified <paramref name="alias"/>, <paramref name="limit"/> and <paramref name="fields"/>.
        /// </summary>
        /// <param name="alias">The name of the edge field.</param>
        /// <param name="limit">The limit of the edge.</param>
        /// <param name="fields">The fields that should be requested from the edge.</param>
        public InstagramEdgeField(string alias, int limit, InstagramFieldList? fields) : base(alias)  {
            Limit = limit;
            Fields = fields ?? new InstagramFieldList();
        }

        /// <summary>
        /// Initializes a new edge field based on the specified <paramref name="field"/>.
        /// </summary>
        /// <param name="field">The field.</param>
        public InstagramEdgeField(InstagramField field) : base(field.Alias) {
            Fields = new InstagramFieldList();
        }

        /// <summary>
        /// Initializes a new field with the name of <paramref name="field"/> and based on the specified <paramref name="fields"/>.
        /// </summary>
        /// <param name="field">The field the this field should be based on.</param>
        /// <param name="fields">The fields that should be requested from the edge.</param>
        public InstagramEdgeField(InstagramField field, InstagramFieldList? fields) : base(field.Alias)  {
            Fields = fields ?? new InstagramFieldList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="field">The field the this field should be based on.</param>
        /// <param name="limit">The limit of the edge.</param>
        public InstagramEdgeField(InstagramField field, int limit) : base(field.Alias)  {
            Limit = limit;
            Fields = new InstagramFieldList();
        }

        /// <summary>
        /// Initializes a new field with the name of <paramref name="field"/> and based on the specified <paramref name="fields"/>.
        /// </summary>
        /// <param name="field">The field the this field should be based on.</param>
        /// <param name="limit">The limit of the edge.</param>
        /// <param name="fields">The fields that should be requested from the edge.</param>
        public InstagramEdgeField(InstagramField field, int limit, InstagramFieldList? fields) : base(field.Alias)  {
            Limit = limit;
            Fields = fields ?? new InstagramFieldList();
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Adds the specified <paramref name="field"/> to the collection.
        /// </summary>
        /// <param name="field">The field to be added.</param>
        public void Add(InstagramField field) {
            Fields.Add(field);
        }

        /// <inheritdoc />
        public override string ToString()  {
            return Alias + (Limit > 0 ? $".limit({Limit})" : string.Empty) + (Fields is { Count: > 0 } ? $"{{{Fields}}}" : string.Empty);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the fields.
        /// </summary>
        /// <returns>An instance of <see cref="IEnumerator{InstagramField}"/>.</returns>
        public IEnumerator<InstagramField> GetEnumerator() {
            return Fields.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

    }

}