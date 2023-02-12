using System.Diagnostics;
using System.Reflection;

namespace Skybrud.Social.Instagram {

    /// <summary>
    /// Static class with various information and constants about the package.
    /// </summary>
    public static class InstagramPackage {

        /// <summary>
        /// Gets the alias of the package.
        /// </summary>
        public const string Alias = "Skybrud.Social.Instagram";

#if NETSTANDARD2_0_OR_GREATER || NET7_0_OR_GREATER

        /// <summary>
        /// Gets the version of the package.
        /// </summary>
        /// <returns>A <see cref="string"/> representing the version.</returns>
        public static string GetVersion() {
            return typeof(InstagramPackage).Assembly.GetName().Version!.ToString();
        }

        /// <summary>
        /// Gets the informational version of the package.
        /// </summary>
        /// <returns>A <see cref="string"/> representing the informational version.</returns>
        public static string GetInformationVersion() {
            Assembly assembly = typeof(InstagramPackage).Assembly;
            return FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion!;
        }

        /// <summary>
        /// Gets the file version of the package.
        /// </summary>
        /// <returns>A <see cref="string"/> representing the file version.</returns>
        public static string GetFileVersion() {
            Assembly assembly = typeof(InstagramPackage).Assembly;
            return FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion!;
        }

#endif

        /// <summary>
        /// Gets the URL of the GitHub repository for this package.
        /// </summary>
        public const string GitHubUrl = "https://github.com/abjerner/Skybrud.Social.Instagram";

        /// <summary>
        /// Gets the URL of the issue tracker for this package.
        /// </summary>
        public const string IssuesUrl = "https://github.com/abjerner/Skybrud.Social.Instagram/issues";

        /// <summary>
        /// Gets the URL of the documentation for this package.
        /// </summary>
        public const string DocumentationUrl = "https://social.skybrud.dk/instagram/";

    }

}