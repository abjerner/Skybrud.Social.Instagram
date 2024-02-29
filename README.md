# Instagram

While the Instagram API mainly focuses on media, is also has methods for accessing locations, users and similar.

The Instagram API is divided into multiple endpoints serving different purposes - eg. media, users and locations. Skybrud.Social follows the same structure as the API, so head over to the [list of endpoints](./platform-api/endpoints/) for more information. This is also where you will find  examples for the various endpoints / methods in the Instagram API.



## Installation

{{installation}}



## Structure

The Instagram API is divided into multiple endpoints serving different purposes - eg. media, users and locations. Skybrud.Social follows the same structure as the API, so head over to the [list of endpoints](./platform-api/endpoints/) for more information. This is also where you will find  examples for the various endpoints / methods in the Instagram API.

{{endpoints}}



## Authentication

To get data from the Instagram API, you either need an access token (on behalf of a user) or a client ID (on behalf of your app). Information about obtaining either of these can be found on the [authentication page](./platform-api/authentication/).



## Rate limiting

The Instagram API enforces rate limiting - meaning that you can only make a certain amount of request over a given time. Most methods have rather high limit, while a few methods has a very low limit. Instagram.com has a good description of <a href="https://instagram.com/developer/limits/" target="_blank">limits</a>.



## Making calls to the API

To make requests to the Instagram API, you must initialize an instance of the `InstagramService` class. As described on the [authentication page](./platform-api/authentication/), you should obtain an access token to access the API on behalf of your users.

So to initialize the class using an obtained access token, your code could look as:

```csharp
// Initialize a new service instance from an access token
InstagramService service = InstagramService.CreateFromAccessToken(accessToken);
```

The `InstagramService` class builds on top of the `InstagramClient` class, so you can also specify an instance of this class instead:

```csharp
// Initialize a new service instance from an OAuth client
InstagramService service = InstagramService.CreateFromOAuthClient(new InstagramOAuthClient {
    AccessToken = accessToken
});
```

The `InstagramService` class then has properties for each supported endpoint. As an example, you can get information about the authenticated user as:

```csharp
// Make the call to the API
InstagramUserResponse response = service.Users.GetSelf();

// Get the user object from the response
InstagramUser user = response.Body.Data;
```

You can find a list of all supported endpoints at the the [endpoints page](./platform-api/endpoints/).



## Error handling

If you make a request to the Instagram API, and the server responds with an error, you can handle this by catching exception of the type `InstagramException`. An example of an error returned by the API, is if you make a request for a user that doesn't exist. You you make a request with an invalid access token or client ID, this will also trigger an error.

Some errors/exceptions are represented by their own exception class (extending the`InstagramException` class). These are currently:

* `InstagramNotFoundException`
* `InstagramOAuthException`
* `InstagramOAuthAccessTokenException`