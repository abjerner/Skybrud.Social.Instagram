using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.BasicDisplay.Models.Users;

namespace Skybrud.Social.Instagram.BasicDisplay.Responses.Users {

    /// <summary>
    /// Class representing the response with information about an Instagram user.
    /// </summary>
    public class InstagramUserResponse : InstagramResponse<InstagramUser> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public InstagramUserResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, InstagramUser.Parse);
        }

    }

}