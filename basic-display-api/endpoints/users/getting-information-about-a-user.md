# Getting information about a user

You may specify the ID of a specific user, but most likely you won't have access to request information about other users that the authenticated user. By not specifying a user ID (or setting it to `0`), equals requesting information about the authenticated user.

```cshtml
@using Skybrud.Social.Instagram.BasicDisplay.Exceptions
@using Skybrud.Social.Instagram.BasicDisplay.Fields
@using Skybrud.Social.Instagram.BasicDisplay.Options
@using Skybrud.Social.Instagram.BasicDisplay.Responses.Users
@inherits WebViewPage<Skybrud.Social.Instagram.BasicDisplay.InstagramBasicDisplayService>

@{

    try {

        // Initialize the options for the request
        InstagramGetUserOptions options = new InstagramGetUserOptions {
            UserId = 1234,
            Fields = new InstagramFieldList {
                InstagramUserFields.Username,
                InstagramUserFields.AccountType,
                InstagramUserFields.MediaCount
            }
        };

        // Make the request to the API
        InstagramUserResponse response = Model.Users.GetUser(options);

        <table class="table details">
            <tr>
                <th>ID</th>
                <td>@response.Body.Id</td>
            </tr>
            <tr>
                <th>Username</th>
                <td>@response.Body.Username</td>
            </tr>
            <tr>
                <th>Account type</th>
                <td>@response.Body.AccountType</td>
            </tr>
            <tr>
                <th>Media count</th>
                <td>@response.Body.MediaCount</td>
            </tr>
        </table>

    } catch (Exception ex) {

        <pre>@ex.GetType()</pre>

        if (ex is InstagramHttpException http) {

            <pre>@((int) http.Response.StatusCode) @http.Response.StatusCode</pre>

            <pre>@http.Error.Type</pre>
            <pre>@http.Error.Message</pre>

        }

    }

}
```