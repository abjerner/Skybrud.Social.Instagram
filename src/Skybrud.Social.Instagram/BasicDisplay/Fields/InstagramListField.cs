using System.Collections;
using System.Collections.Generic;

namespace Skybrud.Social.Instagram.BasicDisplay.Fields {

    public class InstagramListField : InstagramField, IEnumerable<InstagramField> {

        #region Properties

        public InstagramFieldsCollection Fields { get; set; }

        public int Limit { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new field with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the field.</param>
        public InstagramListField(string name) : base(name) {
            Fields = new InstagramFieldsCollection();
        }
        
        public InstagramListField(string name, InstagramFieldsCollection fields) : base(name)  {
            Fields = fields ?? new InstagramFieldsCollection();
        }
        
        public InstagramListField(string name, int limit) : base(name)  {
            Limit = limit;
            Fields = new InstagramFieldsCollection();
        }
        
        public InstagramListField(string name, int limit, InstagramFieldsCollection fields) : base(name)  {
            Limit = limit;
            Fields = fields ?? new InstagramFieldsCollection();
        }
        
        public InstagramListField(InstagramField field) : base(field.Name) {
            Fields = new InstagramFieldsCollection();
        }
        
        public InstagramListField(InstagramField field, InstagramFieldsCollection fields) : base(field.Name)  {
            Fields = fields ?? new InstagramFieldsCollection();
        }
        
        public InstagramListField(InstagramField field, int limit) : base(field.Name)  {
            Limit = limit;
            Fields = new InstagramFieldsCollection();
        }
        
        public InstagramListField(InstagramField field, int limit, InstagramFieldsCollection fields) : base(field.Name)  {
            Limit = limit;
            Fields = fields ?? new InstagramFieldsCollection();
        }

        #endregion

        #region Member methods

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