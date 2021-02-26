using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.BasicDisplay.Models.Users;
using Skybrud.Social.Instagram.Responses;

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

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramUser.Parse);

        }

    }

}