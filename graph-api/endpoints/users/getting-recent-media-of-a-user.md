# Getting recent media of a user

To get the most recent media of a given user, you code can look something like the snippet below:

```cshtml
@using Skybrud.Social.Instagram.Graph
@using Skybrud.Social.Instagram.Graph.Fields
@using Skybrud.Social.Instagram.Graph.Models.Media
@using Skybrud.Social.Instagram.Graph.Responses.Media
@inherits WebViewPage<InstagramGraphService>

@{

    // Declare the fields to be returned by the API
    InstagramFieldList fields = "caption,thumbnail_url,id,ig_id,like_count,media_type,media_url,permalink,owner,username,comments_count";

    // Make the request to the Graph API
    InstagramMediaListResponse response = Model.Users.GetRecentMedia("1234", fields);

    foreach (InstagramMedia media in response.Body.Data) {

        <pre>@media.MediaUrl</pre>

    }

}
```

Notice how the snippet specifies the fields that should be returned by the Graph API. If left out, only the ID of each media will be returned.