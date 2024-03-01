---
teaser: Read more about authenticating with the Instagram Graph API.
---

# Authentication

As the Instagram Graph API is an integrated part of the Facebook Graph API, you can use the [**Skybrud.Social.Facebook**](/skybrud.social.facebook/docs/authentication/) package for authenticating with the Facebook Graph API, and then use the obtained access token to make calls to the Instagram Graph API:

```cshtml
@using Skybrud.Social.Instagram.Graph
@{

    // Initialize a new service instance from your access token
    InstagramGraphService service = InstagramGraphService.CreateFromAccessToken("Your Facebook access token here.");

    // do your thing here

}
```