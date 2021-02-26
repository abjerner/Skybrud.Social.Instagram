using Skybrud.Essentials.Http;

namespace Skybrud.Social.Instagram.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the Instagram API for a resource that couldn't be found.
    /// </summary>
    public class InstagramNotFoundException : InstagramHttpException {

        internal InstagramNotFoundException(IHttpResponse response) : base(response) { }

    }

}