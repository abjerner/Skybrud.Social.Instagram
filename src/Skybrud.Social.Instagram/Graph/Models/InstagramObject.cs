using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Json.Newtonsoft;
using Skybrud.Social.Instagram.Graph.Exceptions;

namespace Skybrud.Social.Instagram.Graph.Models {

    /// <summary>
    /// Class representing a basic object from the <strong>Instagram Graph API</strong> derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class InstagramObject : JsonObjectBase {

        #region Properties

        /// <summary>
        /// Gets the internal Newtonsoft.Json.Linq.JObject the object was created from.
        /// </summary>
        [JsonIgnore]
        public new JObject JObject => base.JObject!;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected InstagramObject(JObject json) : base(json) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="value"/> into an instance of <typeparamref name="TEnum"/>. If
        /// <paramref name="value"/> is either null, empty or only contains white space, <see langword="null"/> is
        /// returned instead. If the value does match an enum value of <typeparamref name="TEnum"/>, an exception of
        /// type <see cref="InstagramParseEnumException"/> will be thrown instead.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The string value to be parsed.</param>
        /// <returns>An instance of <typeparamref name="TEnum"/>.</returns>
        /// <exception cref="InstagramParseEnumException">If <paramref name="value"/> has a value but doesn't match an enum value of <typeparamref name="TEnum"/> </exception>
        internal static TEnum? ParseEnumOrThrow<TEnum>(string? value) where TEnum : struct, Enum {
            if (string.IsNullOrWhiteSpace(value)) return null;
            if (EnumUtils.TryParseEnum(value, out TEnum result)) return result;
            throw new InstagramParseEnumException(typeof(TEnum), value!, $"Unknown media type: {value}");
        }

        /// <summary>
        /// Parses the specified <paramref name="value"/> into an instance of <typeparamref name="TEnum"/>. If
        /// <paramref name="value"/> is either null, empty or only contains white space, <see langword="null"/> is
        /// returned instead. If the value does match an enum value of <typeparamref name="TEnum"/>, the default
        /// value of <typeparamref name="TEnum"/> is returned instead.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The string value to be parsed.</param>
        /// <returns>An instance of <typeparamref name="TEnum"/>.</returns>
        public static TEnum? ParseEnumOrDefault<TEnum>(string? value) where TEnum : struct, Enum {
            if (string.IsNullOrWhiteSpace(value)) return null;
            return EnumUtils.TryParseEnum(value, out TEnum result) ? result : default;
        }

        #endregion

    }

}