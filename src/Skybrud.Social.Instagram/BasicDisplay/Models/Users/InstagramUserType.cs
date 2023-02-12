namespace Skybrud.Social.Instagram.BasicDisplay.Models.Users {

    /// <summary>
    /// Enum class representing the type of a user.
    /// </summary>
    public enum InstagramUserType {

        /// <summary>
        /// Indiciates a user type that is currently not supported by this package.
        /// </summary>
        Unknown,

        /// <summary>
        /// Indicates tat the user is a business account.
        /// </summary>
        Business,

        /// <summary>
        /// Indicates tat the user is a media creator account.
        /// </summary>
        MediaCreator,

        /// <summary>
        /// Indicates tat the user is a personal account.
        /// </summary>
        Personal

    }

}