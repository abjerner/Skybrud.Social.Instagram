using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the Instagram API for a resource that couldn't be found.
    /// </summary>
    public class InstagramHttpNotFoundException : InstagramHttpException {

        internal InstagramHttpNotFoundException(SocialHttpResponse response, InstagramMetaData meta) : base(response, meta) { }

    }

}