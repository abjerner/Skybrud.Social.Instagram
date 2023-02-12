using System;

namespace Skybrud.Social.Instagram.Graph.Exceptions {

    /// <summary>
    /// Exception class thrown when parsing an enum value received from the <strong>Instagram Graph API</strong> fails.
    /// </summary>
    public class InstagramParseEnumException : InstagramParseException {

        #region Properties

        /// <summary>
        /// Gets a reference to the enum type.
        /// </summary>
        public Type EnumType { get; }

        /// <summary>
        /// Gets the value that could not be recognized.
        /// </summary>
        public string Value { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="enumType"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="enumType">The enum type.</param>
        /// <param name="value">The value that could not be recognized.</param>
        public InstagramParseEnumException(Type enumType, string value) : this(enumType, value, null) { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="enumType"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="enumType">The enum type.</param>
        /// <param name="value">The value that could not be recognized.</param>
        /// <param name="message">The exception message.</param>
        public InstagramParseEnumException(Type enumType, string value, string? message) : base(message ?? $"Unknown value for enum of type {enumType.Name}.") {
            EnumType = enumType;
            Value = value;
        }

        #endregion

    }

}