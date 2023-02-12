namespace Skybrud.Social.Instagram.BasicDisplay.Fields {

    /// <summary>
    /// Class representing a field in the Instagram Basic Display API.
    /// </summary>
    public class InstagramField {

        #region Properties

        /// <summary>
        /// Gets the alias of the field.
        /// </summary>
        public string Alias { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new field with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The alias of the field.</param>
        public InstagramField(string alias) {
            Alias = alias;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override string ToString()  {
            return Alias;
        }

        #endregion

        #region Operators

        /// <summary>
        /// Initializes a new field based on the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The alias of the field.</param>
        public static implicit operator InstagramField(string alias) {
            return new InstagramField(alias);
        }

        /// <summary>
        /// Adding two instances of <see cref="InstagramField"/> will result in a <see cref="InstagramFieldList"/> containing both fields.
        /// </summary>
        /// <param name="left">The left field.</param>
        /// <param name="right">The right field.</param>
        public static InstagramFieldList operator +(InstagramField left, InstagramField right) {
            return new InstagramFieldList(left, right);
        }

        #endregion

    }

}