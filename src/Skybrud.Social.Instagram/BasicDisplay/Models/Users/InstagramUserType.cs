using Skybrud.Social.Instagram.BasicDisplay.Fields;

namespace Skybrud.Social.Instagram.BasicDisplay.Models.Users {

    /// <summary>
    /// Enum class representing the type of a user.
    /// </summary>
    public enum InstagramUserType {

        /// <summary>
        /// Indicates that the type is unspecified - eg. if the <see cref="InstagramUserFields.AccountType"/> isn't requested or returned by the API.
        /// </summary>
        Unspecified,
        
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