using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.Models;

namespace Skybrud.Social.Instagram.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the Instagram API for a resource that couldn't be found.
    /// </summary>
    public class InstagramNotFoundException : InstagramHttpException {

        internal InstagramNotFoundException(IHttpResponse response) : base(response) { }

        internal InstagramNotFoundException(IHttpResponse response, InstagramMetaData meta) : base(response, meta) { }

    }

}