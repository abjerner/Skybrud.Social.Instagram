---
teaser: See examples for setting up an authentication page in a Razor view.
---

# Authentication Page

When using the **Skybrud.Social.Instagram** package, the `InstagramBasicDisplayClient` helps you with much of the authentication.

If you already have your app ID and app secret, you can initialize a new `InstagramBasicDisplayClient` instance like in the example below. Notice that in OAuth 2.0 terminology, the app is referred to as a client.

```csharp
// Initialize a new OAuth client
InstagramBasicDisplayClient client = new InstagramBasicDisplayClient {
    ClientId = "Your Instagram app ID",
    ClientSecret = "Your Instagram app secret",
    RedirectUri = "https://localhost/instagram/basic/oauth"
};
```

This instance then serves as the basis for the next steps. Notice that the redirect URI must match one of the redirect URIs that you have specified for your Instagram app while also matching your authentication page.



## Getting an authorization URL

The next step is to redirect the user to Instagram's authorization page where the user can confirm (or cancel) whether they want to allow your app access to their Instagram account.

The URL to Instagram's authorization page contains a number of different parameters, including the information you've entered for the `InstagramBasicDisplayClient` instance, a random state, and the scope of your app.

### State  
The state is a security counter measure, so we the state in the user's ASP.NET session on the server, and validate the state again once the user is redirected back to our authentication.

### Scope  
The scope is the permissions that your app will request from the user, and the user then has to confirm via the authorization page.

```csharp
// Generate a random scope
string state = Guid.NewGuid().ToString();

// Generate the session key for the state
string stateKey = "InstagramOAuthState_" + state;

// Store the state in the session of the user
Session[stateKey] = Request.RawUrl;

// Generate the authorization URL
string authorizationUrl = client.GetAuthorizationUrl(state, InstagramScopes.UserMedia, InstagramScopes.UserProfile);

// Redirect the user
Response.Redirect(authorizationUrl);
```



## Getting an access token

Once the user grants your app access to their account, the user is redirected back to the specified `RedirectUri`(which should be your authentication page). The query string includes a `state` parameter, which is the one you specified for the `GetAuthorizationUrl` method earlier, as well as a `code` parameter that represents an authorization code we've received for the user.

As mentioned a bit earlier, it's important to validate the user once they are redirected back to your authentication page. In the previous step, we added a value to the user's server side session where the key is a mix of `InstagramOAuthState_` and the state. You should now be able to validate that the key still exists in the session. If not, it could mean that someone tried to tamper with the request, but also just that the session expired. In either case, we can show an error message to the user.

If the key still exist in the session, we can continue and exchange the authorization code for a new access token. This is done via the `GetAccessTokenFromAuthCode` on the `client` instance:

```csharp
// Get a new access token from the authorization code
InstagramShortLivedTokenResponse response1 = client.GetAccessTokenFromAuthCode(code);
```

The `response` variable then holds the overall response from the Instagram Basic Display API. You can access the access token via `response1.Body.AccessToken` and the ID of the authenticated user via `response1.Body.UserId`.

Notice that the access token only lives for a short amount of time. This would be fine if you only need to access the API as the user is logging in, but not at a later point in time.



## Getting a long lived access token

If you do need to access the API later on as well - eg. if you're setting up an Instagram feed on your website or similar - you need to exchange the short lived access token for a long lived access token.

This can be done via the `GetLongLivedAccessToken` method:

```csharp
// Get a long lived access token from another access token
InstagramLongLivedTokenResponse response2 = client.GetLongLivedAccessToken(response.Body.AccessToken);
```

Like before, you can get the access token via `response2.Body.AccessToken`. You can also check when the access token expires via the `response2.Body.ExpiresIn` property.

Notice that the value of this property doesn't represent an exact point in time, but a `TimeSpan` value representing roughly 60 days. So if you to know when the access token expires, it might be a good idea to also save a timestamp for the time the access token was received from the Basic Display API. Eg. `DateTime.Now.Add(response2.Body.ExpiresIn)` or `EssentialsTime.Now.Add(response2.Body.ExpiresIn)`.

If you still need to access the API beyond the 60 days, you should repeat this step right before the access token expires. You can still use the `GetLongLivedAccessToken` method for this, as the `accessToken` parameter doesn't have to a short lived access token, but any valid access token.



## Full example

To better demonstrate how the different parts work together, the example below is a Razor view that initially will show a **Login with Instagram**, but then also handle the rest of the authentication as the user proceeds through the various steps.

Since this is just an example, it will write access token to the output page. Ideally you should never do this in real world scenarios, but instead save the access tokens somewhere save so you can use it for later, without disclosing the access token to the user.

```cshtml
@using Skybrud.Essentials.Time
@using Skybrud.Social.Instagram.BasicDisplay.Exceptions
@using Skybrud.Social.Instagram.BasicDisplay.OAuth
@using Skybrud.Social.Instagram.BasicDisplay.Responses.Authentication
@using Skybrud.Social.Instagram.BasicDisplay.Scopes
@inherits WebViewPage

@{

    // Initialize a new OAuth client
    InstagramBasicDisplayClient client = new InstagramBasicDisplayClient {
        ClientId = "Your Instagram app ID",
        ClientSecret = "Your Instagram app secret",
        RedirectUri = "https://localhost/instagram/basic/oauth"
    };

    if (Request.QueryString["do"] == "login") {

        // Generate a random scope
        string state = Guid.NewGuid().ToString();

        // Generate the session key for the state
        string stateKey = "InstagramOAuthState_" + state;

        // Store the state in the session of the user
        Session[stateKey] = Request.RawUrl;

        // Generate the authorization URL
        string authorizationUrl = client.GetAuthorizationUrl(state, InstagramScopes.UserMedia, InstagramScopes.UserProfile);

        // Redirect the user
        Response.Redirect(authorizationUrl);

    } else if (Request.QueryString["code"] != null) {

        // Get the state from the query string
        string state = Request.QueryString["state"];

        // Get the code from the query string
        string code = Request.QueryString["code"];

        // Generate the session key for the state
        string stateKey = "InstagramOAuthState_" + state;

        if (Session[stateKey] == null) {
            <p>Has your session expired?</p>
            <p>
                <a class="btn btn-default" href="@(client.RedirectUri)?do=login">Re-try login</a>
            </p>
            return;
        }

        InstagramShortLivedTokenResponse response = client.GetAccessTokenFromAuthCode(code);

        <h4>Short Lived Access Token</h4>

        <div>Access Token:</div>
        <pre>@response.Body.AccessToken</pre>

        <div>User ID:</div>
        <pre>@response.Body.UserId</pre>


        <h4>Long Lived Access Token</h4>
        try {

            InstagramLongLivedTokenResponse response2 = client.GetLongLivedAccessToken(response.Body.AccessToken);

            string longLiveAccessToken = response2.Body.AccessToken;

            <table class="table details">
                <tr>
                    <th>Token type</th>
                    <td>@response2.Body.TokenType</td>
                </tr>
                <tr>
                    <th>Expires in</th>
                    <td>@response2.Body.ExpiresIn</td>
                </tr>
                <tr>
                    <th>Expires at</th>
                    <td>@EssentialsTime.Now.Add(response2.Body.ExpiresIn)</td>
                </tr>
            </table>

        } catch (InstagramParseException ex) {

            <div class="alert alert-danger">
                <strong>@ex.GetType().Name</strong><br />
                @ex.Message
            </div>

            <pre>@ex.Response.Body</pre>
            <pre>@ex</pre>

            return;

        } catch (InstagramHttpException ex) {

            <div class="alert alert-danger">
                <strong>@ex.GetType().Name</strong><br />
                @ex.Message
            </div>

            <pre>@ex.Response.Body</pre>
            <pre>@ex</pre>

            return;

        }

        return;

    }

    <p>
        <a class="btn btn-default" href="@(client.RedirectUri)?do=login">Login with Instagram</a>
    </p>

}
```