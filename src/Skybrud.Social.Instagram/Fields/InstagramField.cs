namespace Skybrud.Social.Instagram.Fields {
    
    /// <summary>
    /// Class representing a field in the Instagram Graph API.
    /// </summary>
    public class InstagramField {

        #region Properties

        /// <summary>
        /// Gets the name of the field.
        /// </summary>
        public string Name { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new field with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the field.</param>
        public InstagramField(string name) {
            Name = name;
        }

        #endregion

        #region Operators

        /// <summary>
        /// Initializes a new field based on the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the field.</param>
        public static implicit operator InstagramField(string name) {
            return new InstagramField(name);
        }

        /// <summary>
        /// Adding two instances of <see cref="InstagramField"/> will result in a <see cref="InstagramFieldsCollection"/> containing both fields.
        /// </summary>
        /// <param name="left">The left field.</param>
        /// <param name="right">The right field.</param>
        public static InstagramFieldsCollection operator +(InstagramField left, InstagramField right) {
            return new InstagramFieldsCollection(left, right);
        }

        #endregion

    }

}