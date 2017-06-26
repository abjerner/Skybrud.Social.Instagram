using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Models;

namespace Skybrud.Social.Instagram.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the Instagram API for a resource that couldn't be found.
    /// </summary>
    public class InstagramNotFoundException : InstagramHttpException {

        internal InstagramNotFoundException(SocialHttpResponse response, InstagramMetaData meta) : base(response, meta) { }

    }

}