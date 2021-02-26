using Skybrud.Essentials.Http;

namespace Skybrud.Social.Instagram.BasicDisplay.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the <strong>Instagram Basic Display API</strong> for a resource that couldn't be found.
    /// </summary>
    public class InstagramNotFoundException : InstagramHttpException {

        internal InstagramNotFoundException(IHttpResponse response) : base(response) { }

    }

}