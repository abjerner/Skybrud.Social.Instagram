# Skybrud.Social.Instagram [![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.md) [![NuGet](https://img.shields.io/nuget/v/Skybrud.Social.Instagram.svg)](https://www.nuget.org/packages/Skybrud.Social.Instagram) [![NuGet](https://img.shields.io/nuget/dt/Skybrud.Social.Instagram.svg)](https://www.nuget.org/packages/Skybrud.Social.Instagram)

**Skybrud.Social.Instagram** is a .NET wrapper and API implementation for the [**Instagram Basic Display API**](https://developers.facebook.com/docs/instagram-basic-display-api) and [**Instagram Graph API**](https://developers.facebook.com/docs/instagram-api).

The package helps handling some of the underlying authentication as well as communicating with both APIs in a strongly typed way.



<br /><br />

### Target Frameworks

.NET Standard 1.3, .NET Standard 2.0 and .NET 7 ([read more](https://www.nuget.org/packages/Skybrud.Social.Instagram#supportedframeworks-body-tab)).



<br /><br />

### Installation

Install the <a href="https://www.nuget.org/packages/Skybrud.Social.Instagram/1.0.0-beta008" target="_blank">NuGet package</a> - either via the .NET CLI:

```
dotnet add package Skybrud.Social.Instagram --version 1.0.0-beta008
```

or the NuGet package manager:

```
Install-Package Skybrud.Social.Instagram -Version 1.0.0-beta008
```


<br /><br />

### Found a bug? Have a question?

* Please feel free to [**create an issue**][Issues], and I will get back to you ;)


<br /><br />

### Changelog

The [**releases page**][Releases] lists all releases, and each there will be some information for each release on the most significant changes.


<br /><br />

### Documentation

You can find documentation and examples on how to use this package at the [**Skybrud.Social website**][Website].


<br /><br />

#### Usage

##### Initializing a new OAuth client

The `InstagramOAuthClient` class is responsible for the raw communication with the Instagram API as well as authentication using OAuth 2.0. The class can be initialized with one of the constructors, or simply by setting the properties like in the examples below:

```C#
// Initialize and configure the OAuth client
InstagramOAuthClient client = new InstagramOAuthClient {
    AccessToken = "Insert your access token here"
};
```

or:

```C#
// Initialize and configure the OAuth client
InstagramOAuthClient client = new InstagramOAuthClient {
    ClientId = "Insert your client ID here",
    ClientSecret = "Insert your client secret here",
    RedirectUri = "http://social.abjerner/instagram/oauth"
};
```

Authentication requires that you specify the client ID, client secret and redirect URI of your app (client).

* [**Register a new client** *at www.instagram.com*](https://www.instagram.com/developer/clients/register/)
* [**Manage existing clients** *at www.instagram.com*](https://www.instagram.com/developer/clients/manage/)


##### Generating the authorization URL / getting an authorization code

To start authenticating the user, you should generate and redirect the user to the authorization URL. The authorization URL is constructed of the client ID and redirect URI of the OAuth client as well as a state (random value for security purposes) and the scope (permissions) which your user should grant your app.

If you just need an authorization URL with the default scope, your code could look like:

```C#
// Generate the authorization URL (with default scope)
string authorizationUrl = client.GetAuthorizationUrl(state);
```

If you instead need the `basic` (granted by default) and `public_content` scopes, your code could look like:

```C#
// Generate the authorization URL
string authorizationUrl = client.GetAuthorizationUrl(state, InstagramScopes.Basic + InstagramScopes.PublicContent);
```

When the user is redirected to the authentication URL, he/she will be prompted to accept the scope that you have specified.





##### Obtaining an access token

The access token can be obtained using the `GetAccessTokenFromAuthCode` method, where the response body will reveil the access token as well information about the authenticated user.

For the example below, the `authCode` parameter is the authorization code received when the user has succesfully logged in through the Windows Live login dialog, and been redirected back to your site. At this point, the `code` parameter in the query string will contain the authorization code.

```C#
// Exchange the authorization code for an access token
InstagramTokenResponse response = client.GetAccessTokenFromAuthCode(authCode);

// Get the access token from the response body
string accessToken = response.Body.AccessToken;
```





##### Initializing an instance of InstagramService

Once you have obtained an access token, you can initialize a new instance of the `InstagramService` class as shown in the exampel below:

```C#
// Initialize a new service instance from an access token
InstagramService service = InstagramService.CreateFromAccessToken("Insert your access token here");
```

The `InstagramService` class serves as your starting point to making calls to the Instagram API.



##### Complete example

In the example below, I've tried to demonstrate how a login page can be implemented (involving the steps explained above).

Notice that the example generates a `state` that is saved to the user's session. When redirecting the user to Instagram's authentication page, we supply the state, and once the user completes (or cancels) the authentication, the same `state` is specified in the URL the user is redirected back to (at your site). We can then check whether the `state` is saved in the user session to make sure it's still the same user making the request.

```C#
@using Skybrud.Social.Instagram.OAuth
@using Skybrud.Social.Instagram.Responses.Authentication
@using Skybrud.Social.Instagram.Scopes

@{

    // Initialize a new OAuth client with the information from your app
    InstagramOAuthClient client = new InstagramOAuthClient {
        ClientId = "Your client ID",
        ClientSecret = "Your client secret",
        RedirectUri = "http://social.abjerner/instagram/oauth/"
    };

    if (Request.QueryString["do"] == "login") {

        // Generate a random scope
        string state = Guid.NewGuid().ToString();

        // Generate the session key for the state
        string stateKey = "InstagramOAuthState_" + state;

        // Store the state in the session of the user
        Session[stateKey] = Request.RawUrl;

        // Generate the authorization URL
        string authorizationUrl = client.GetAuthorizationUrl(state, InstagramScopes.PublicContent);

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
                <a class="btn btn-default" href="/instagram/oauth?do=login">Re-try login</a>
            </p>
            return;
        }

        InstagramTokenResponse response = client.GetAccessTokenFromAuthCode(code);

        <div class="box">
            <p>Hi <strong>@(response.Body.User.FullName ?? response.Body.User.Username)</strong></p>
            <p>Id: @response.Body.User.Id</p>
            <p>Username: @response.Body.User.Username</p>
            @if (!String.IsNullOrWhiteSpace(response.Body.User.ProfilePicture)) {
                <img src="@response.Body.User.ProfilePicture" />
            }
        </div>

        <br />

        <div>Access Token:</div>
        <pre>@response.Body.AccessToken</pre>

        return;

    }

    <p>
        <a class="btn btn-default" href="/instagram/oauth?do=login">Login with Instagram</a>
    </p>

}
```





[Website]: http://social.skybrud.dk/instagram/
[NuGetPackage]: https://www.nuget.org/packages/Skybrud.Social.Instagram
[GitHubRelease]: https://github.com/abjerner/Skybrud.Social.Instagram/releases/latest
[Releases]: https://github.com/abjerner/Skybrud.Social.Instagram/releases
[Issues]: https://github.com/abjerner/Skybrud.Social.Instagram/issues
