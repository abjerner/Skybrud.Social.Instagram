using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.BasicDisplay.Models.Media;

namespace Skybrud.Social.Instagram.BasicDisplay.Responses.Media {

    /// <summary>
    /// Class representing the response with a list of Instagram media.
    /// </summary>
    public class InstagramMediaListResponse : InstagramResponse<InstagramMediaList> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public InstagramMediaListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, InstagramMediaList.Parse)!;
        }

    }

}