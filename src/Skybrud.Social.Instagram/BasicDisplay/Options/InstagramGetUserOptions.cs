using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Social.Instagram.BasicDisplay.Fields;

namespace Skybrud.Social.Instagram.BasicDisplay.Options {
    
    public class InstagramGetUserOptions : IHttpRequestOptions {

        #region Properties

        public long UserId { get; set; }

        public InstagramFieldCollection Fields { get; set; }

        #endregion

        #region Constructors

        public InstagramGetUserOptions() {
            Fields = new InstagramFieldCollection();
        }

        public InstagramGetUserOptions(InstagramFieldCollection fields)  {
            Fields = fields ?? new InstagramFieldCollection();
        }

        public InstagramGetUserOptions(long userId) {
            UserId = userId;
            Fields = new InstagramFieldCollection();
        }

        public InstagramGetUserOptions(long userId, InstagramFieldCollection fields) {
            UserId = userId;
            Fields = fields ?? new InstagramFieldCollection();
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest()  {
            
            IHttpQueryString query = new HttpQueryString();
            if (Fields != null && Fields.Count > 0) query.Add("fields", Fields);

            return HttpRequest.Get($"/{(UserId == 0 ? "me" : UserId.ToString())}", query);

        }

        #endregion

    }

}