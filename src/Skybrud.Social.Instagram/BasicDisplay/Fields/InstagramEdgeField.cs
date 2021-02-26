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
        public InstagramFieldCollection Fields { get; set; }

        /// <summary>
        /// Gets or sets the limit of the edge.
        /// </summary>
        public int Limit { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new field with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the field.</param>
        public InstagramEdgeField(string name) : base(name) {
            Fields = new InstagramFieldCollection();
        }

        /// <summary>
        /// Initializes a new edge field based on the specified <paramref name="name"/> and <paramref name="fields"/>.
        /// </summary>
        /// <param name="name">The name of the edge field.</param>
        /// <param name="fields">The fields that should be requested from the edge.</param>
        public InstagramEdgeField(string name, InstagramFieldCollection fields) : base(name)  {
            Fields = fields ?? new InstagramFieldCollection();
        }

        /// <summary>
        /// Initializes a new edge field based on the specified <paramref name="name"/> and <paramref name="limit"/>.
        /// </summary>
        /// <param name="name">The name of the edge field.</param>
        /// <param name="limit">The limit of the edge.</param>
        public InstagramEdgeField(string name, int limit) : base(name)  {
            Limit = limit;
            Fields = new InstagramFieldCollection();
        }

        /// <summary>
        /// Initializes a new edge field based on the specified <paramref name="name"/>, <paramref name="limit"/> and <paramref name="fields"/>.
        /// </summary>
        /// <param name="name">The name of the edge field.</param>
        /// <param name="limit">The limit of the edge.</param>
        /// <param name="fields">The fields that should be requested from the edge.</param>
        public InstagramEdgeField(string name, int limit, InstagramFieldCollection fields) : base(name)  {
            Limit = limit;
            Fields = fields ?? new InstagramFieldCollection();
        }

        /// <summary>
        /// Initializes a new edge field based on the specified <paramref name="field"/>.
        /// </summary>
        /// <param name="field">The field.</param>
        public InstagramEdgeField(InstagramField field) : base(field.Name) {
            Fields = new InstagramFieldCollection();
        }
        
        /// <summary>
        /// Initializes a new field with the name of <paramref name="field"/> and based on the specified <paramref name="fields"/>.
        /// </summary>
        /// <param name="field">The field the this field should be based on.</param>
        /// <param name="fields">The fields that should be requested from the edge.</param>
        public InstagramEdgeField(InstagramField field, InstagramFieldCollection fields) : base(field.Name)  {
            Fields = fields ?? new InstagramFieldCollection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field">The field the this field should be based on.</param>
        /// <param name="limit">The limit of the edge.</param>
        public InstagramEdgeField(InstagramField field, int limit) : base(field.Name)  {
            Limit = limit;
            Fields = new InstagramFieldCollection();
        }

        /// <summary>
        /// Initializes a new field with the name of <paramref name="field"/> and based on the specified <paramref name="fields"/>.
        /// </summary>
        /// <param name="field">The field the this field should be based on.</param>
        /// <param name="limit">The limit of the edge.</param>
        /// <param name="fields">The fields that should be requested from the edge.</param>
        public InstagramEdgeField(InstagramField field, int limit, InstagramFieldCollection fields) : base(field.Name)  {
            Limit = limit;
            Fields = fields ?? new InstagramFieldCollection();
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
            return Name + (Limit > 0 ? ".limit(" + Limit + ")" : string.Empty) + (Fields != null && Fields.Count > 0 ? "{" + Fields + "}" : string.Empty);
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