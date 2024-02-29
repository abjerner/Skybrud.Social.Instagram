# Getting recent media of a user

To get the most recent media of the authenticated user, you code can look something like the snippet below.

By default, Instagram will only return the IDs of each media, so we need to specify the fields that should be returned by the API. The `InstagramMediaFields` class contains constants for known media fields.

Eg. if we're to create a small thumbnail gallery with the most recent media, we'd need the permalink (link to the media on Instagram), as well as the media URL and thumbnail URL.

For videos, the media URL will be the video file, whereas the thumbnail URL will be for a thumbnail of the video. The thumbnail URL is not available for other media types.

```cshtml
@using Skybrud.Social.Instagram.BasicDisplay.Fields
@using Skybrud.Social.Instagram.BasicDisplay.Options
@using Skybrud.Social.Instagram.BasicDisplay.Responses.Media
@inherits WebViewPage<Skybrud.Social.Instagram.BasicDisplay.InstagramBasicDisplayService>

@{

    // Initialize the options for the request
    InstagramGetUserMediaOptions options = new InstagramGetUserMediaOptions {
        Fields = new InstagramFieldList {
            InstagramMediaFields.Permalink,
            InstagramMediaFields.MediaUrl,
            InstagramMediaFields.ThumbnailUrl
        },
        Limit = 50
    };

    // Make the request to the API
    InstagramMediaListResponse response = Model.Users.GetMedia(options);

    // Iterate through the list of returned media
    foreach (InstagramMedia media in response.Body) {
        <a href="@media.Permalink" target="_blank" rel="noopener">
            <img src="@(media.ThumbnailUrl ?? media.MediaUrl)" width="200" />
        </a>
    }

}
```