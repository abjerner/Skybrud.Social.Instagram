# Getting information about a user

Assuming the access token you're using has the necessary permissions, you can get information about an Instagram business account via the `GetUser` method, where the first parameter is the Facebook ID of the Instagram user (which is not the same as the Instagram ID of the user). The second parameter is a collection of fields that should be returned by the API.

```csharp
@using Skybrud.Social.Instagram.Graph
@using Skybrud.Social.Instagram.Graph.Exceptions
@using Skybrud.Social.Instagram.Graph.Fields
@using Skybrud.Social.Instagram.Graph.Models.Users
@using Skybrud.Social.Instagram.Graph.Responses.Users
@inherits WebViewPage<InstagramGraphService>

@{

    try {

        // Declare the fields to be returned by the API
        InstagramFieldList fields = "biography,followers_count,follows_count,id,ig_id,media_count,name,profile_picture_url,username,website";

        // Make the request to the API
        InstagramUserResponse response = Model.Users.GetUser("1234", fields);

        // Get the user from the response
        InstagramUser user = response.Body;

    } catch (InstagramHttpException ex) {

        <pre>@ex.Error.Message</pre>

        return;

    }

}
```

Given the above example was executed successfully, you can write out some basic information about the user:

```cshtml
<table class="table details">
    <tbody>
    <tr>
        <th>Biography</th>
        <td>@user.Biography</td>
    </tr>
    <tr>
        <th>FollowersCount</th>
        <td>@user.FollowersCount</td>
    </tr>
    <tr>
        <th>FollowsCount</th>
        <td>@user.FollowsCount</td>
    </tr>
    <tr>
        <th>Facebook Id</th>
        <td>@user.Id</td>
    </tr>
    <tr>
        <th>Instagram Id</th>
        <td>@user.InstagramId</td>
    </tr>
    <tr>
        <th>MediaCount</th>
        <td>@user.MediaCount</td>
    </tr>
    <tr>
        <th>Name</th>
        <td>@user.Name</td>
    </tr>
    <tr>
        <th>ProfilePictureUrl</th>
        <td>@user.ProfilePictureUrl</td>
    </tr>
    <tr>
        <th>Username</th>
        <td>@user.Username</td>
    </tr>
    <tr>
        <th>Website</th>
        <td>@user.Website</td>
    </tr>
    </tbody>
</table>
```