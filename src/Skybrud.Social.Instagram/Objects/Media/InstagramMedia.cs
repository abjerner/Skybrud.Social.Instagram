using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Time;
using Skybrud.Social.Instagram.Exceptions;
using Skybrud.Social.Instagram.Objects.Comments;
using Skybrud.Social.Instagram.Objects.Locations;
using Skybrud.Social.Instagram.Objects.Users;
using Skybrud.Social.Interfaces;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Instagram.Objects.Media {
    
    /// <summary>
    /// Abstract class representing an Instagram media. Concrete classes are <see cref="InstagramImage"/> and <see cref="InstagramVideo"/>.
    /// </summary>
    public abstract class InstagramMedia : InstagramObject, ISocialTimelineEntry {

        #region Properties

        // A photo/media may specify an attribution property, but the Instagram documentation has
        // no information regarding this property. However this Google Groups discussion sheds a
        // little light on what attribution is:
        //
        // https://groups.google.com/forum/#!topic/instagram-api-developers/KvGH1cnjljQ
        //
        // However since I haven't been able to find any media with the attribution property, and
        // that the official documentation doesn't have any information about this property, it is
        // currently not supported in Skybrud.Social.

        /// <summary>
        /// Gets the ID of the media.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// Gets the type of the media.
        /// </summary>
        public string Type { get; internal set; }

        /// <summary>
        /// Gets an array of tags used with this media.
        /// </summary>
        public string[] Tags { get; internal set; }

        /// <summary>
        /// Gets whether any tags has been specified for the media.
        /// </summary>
        public bool HasTags {
            get { return Tags.Length > 0; }
        }

        /// <summary>
        /// Gets the filter used for this media.
        /// </summary>
        public string Filter { get; internal set; }

        /// <summary>
        /// Specifies the time of creation in UTC/GMT 0.
        /// </summary>
        public EssentialsDateTime CreatedTime { get; internal set; }

        /// <summary>
        /// Gets the link (URL) of the page on instagram.com for the media.
        /// </summary>
        public string Link { get; internal set; }

        /// <summary>
        /// Gets the amount of likes the media has received. This equals calling <code>Likes.Count</code>.
        /// </summary>
        public int LikeCount { get; internal set; }

        /// <summary>
        /// Gets a summary about the likes the media has received.
        /// </summary>
        public InstagramMediaLikes Likes { get; private set; }

        /// <summary>
        /// Gets whether the media has received any likes.
        /// </summary>
        public bool HasLikes {
            get { return LikeCount > 0; }
        }

        /// <summary>
        /// Gets the amount of comments the media has received. This equals calling <code>Comments.Count</code>.
        /// </summary>
        public int CommentCount { get; internal set; }

        /// <summary>
        /// Gets a summary about the comments the media has received.
        /// </summary>
        public InstagramMediaComments Comments { get; internal set; }

        /// <summary>
        /// Gets whether the media has received any comments.
        /// </summary>
        public bool HasComments {
            get { return CommentCount > 0; }
        }

        /// <summary>
        /// Gets a summary of the image formats available for this Instagram media. The image formats are available
        /// for both images and videos.
        /// </summary>
        public InstagramImageSummary Images { get; private set; }

        /// <summary>
        /// Gets the URL of the low resolution format. This equals calling <code>Images.LowResolution.Url</code>.
        /// </summary>
        public string LowRes {
            get { return Images.LowResolution.Url; }
        }
        
        /// <summary>
        /// Gets the URL of the thumbnail format. This equals calling <code>Images.Thumbnail.Url</code>.
        /// </summary>
        public string Thumbnail {
            get { return Images.Thumbnail.Url; }
        }

        /// <summary>
        /// Gets the URL of the standard resolution format. This equals calling <code>Images.StandardResolution.Url</code>.
        /// </summary>
        public string Standard {
            get { return Images.StandardResolution.Url; }
        }

        /// <summary>
        /// Gets the comment representing the caption of the media.
        /// </summary>
        public InstagramComment Caption { get; set; }

        /// <summary>
        /// Gets the caption text of the media, or <see cref="String.Empty"/> if not specified.
        /// </summary>
        public string CaptionText {
            get { return Caption == null ? String.Empty : Caption.Text; }
        }

        /// <summary>
        /// Gets whether a caption has been specified for the media.
        /// </summary>
        public bool HasCaption {
            get { return Caption != null; }
        }

        /// <summary>
        /// Gets an object with information about the user who posted the media.
        /// </summary>
        public InstagramUser User { get; private set; }

        /// <summary>
        /// Gets the location of the media, or <code>null</code> if not specified.
        /// </summary>
        public InstagramLocation Location { get; private set; }

        /// <summary>
        /// Gets whether a location has been specified for the media.
        /// </summary>
        public bool HasLocation {
            get { return Location != null; }
        }

        /// <summary>
        /// Gets an array of users tagged in the photo.
        /// </summary>
        public InstagramTaggedUser[] UsersInPhoto { get; private set; }

        /// <summary>
        /// Gets whether the authenticated user has liked the media.
        /// </summary>
        public bool UserHasLiked { get; private set; }

        /// <summary>
        /// Gets whether the authenticated user has liked the media. Alias of <see cref="UserHasLiked"/>.
        /// </summary>
        public bool HasUserLiked {
            get { return UserHasLiked; }
        }

        /// <summary>
        /// Gets the creation date of the media. This property is just an alias of the <see cref="CreatedTime"/> property.
        /// </summary>
        public DateTime SortDate {
            get { return CreatedTime.DateTime; }
        }

        #endregion

        #region Constructors

        internal InstagramMedia(JObject obj) : base(obj) {
            Id = obj.GetString("id");
            Type = obj.GetString("type");
            Tags = obj.GetStringArray("tags");
            CreatedTime = obj.GetInt64("created_time", EssentialsDateTime.FromUnixTimestamp);
            Link = obj.GetString("link");
            Filter = obj.GetString("filter");
            CommentCount = obj.GetInt32("comments.count");
            Comments = obj.GetObject("comments", InstagramMediaComments.Parse);
            LikeCount = obj.GetInt32("likes.count");
            Likes = obj.GetObject("likes", InstagramMediaLikes.Parse);
            Images = obj.GetObject("images", InstagramImageSummary.Parse);
            Caption = obj.GetObject("caption", InstagramComment.Parse);
            User = obj.GetObject("user", InstagramUser.Parse);
            Location = obj.GetObject("location", InstagramLocation.Parse);
            UsersInPhoto = obj.GetArray("users_in_photo", InstagramTaggedUser.Parse);
            UserHasLiked = obj.GetBoolean("user_has_liked");
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets whether the media is an image - AKA an instance of <see cref="InstagramImage"/>.
        /// </summary>
        /// <returns><code>true</code> if this media is an instance of <see cref="InstagramImage"/>, otherwise <code>false</code>.</returns>
        public bool IsImage() {
            return this is InstagramImage;
        }

        /// <summary>
        /// Gets whether the media is an image - AKA an instance of <see cref="InstagramImage"/>.
        /// </summary>
        /// <param name="image">The instance of <see cref="InstagramImage"/> if an image, otherwise <code>null</code>.</param>
        /// <returns><code>true</code> if this media is an instance of <see cref="InstagramImage"/>, otherwise <code>false</code>.</returns>
        public bool IsImage(out InstagramImage image) {
            image = this as InstagramImage;
            return image != null;
        }

        /// <summary>
        /// Gets whether the media is a video - AKA an instance of <see cref="InstagramVideo"/>.
        /// </summary>
        /// <returns><code>true</code> if this media is an instance of <see cref="InstagramVideo"/>, otherwise <code>false</code>.</returns>
        public bool IsVideo() {
            return this is InstagramVideo;
        }

        /// <summary>
        /// Gets whether the media is a video - AKA an instance of <see cref="InstagramVideo"/>.
        /// </summary>
        /// <param name="video">The instance of <see cref="InstagramVideo"/> if a video, otherwise <code>null</code>.</param>
        /// <returns><code>true</code> if this media is an instance of <see cref="InstagramVideo"/>, otherwise <code>false</code>.</returns>
        public bool IsVideo(out InstagramVideo video) {
            video = this as InstagramVideo;
            return video != null;
        }

        /// <summary>
        /// Gets whether the media is a carousel - AKA an instance of <see cref="InstagramCarousel"/>.
        /// </summary>
        /// <returns><code>true</code> if this media is an instance of <see cref="InstagramCarousel"/>, otherwise <code>false</code>.</returns>
        public bool IsCarousel() {
            return this is InstagramCarousel;
        }

        /// <summary>
        /// Gets whether the media is a carousel - AKA an instance of <see cref="InstagramCarousel"/>.
        /// </summary>
        /// <param name="carousel">The instance of <see cref="InstagramCarousel"/> if a video, otherwise <code>null</code>.</param>
        /// <returns><code>true</code> if this media is an instance of <see cref="InstagramCarousel"/>, otherwise <code>false</code>.</returns>
        public bool IsCarousel(out InstagramCarousel carousel) {
            carousel = this as InstagramCarousel;
            return carousel != null;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="InstagramMedia"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="InstagramMedia"/>.</returns>
        public static InstagramMedia Parse(JObject obj) {
            if (obj == null) return null;
            string type = obj.GetString("type");
            switch (type) {
                case "image": return new InstagramImage(obj);
                case "video": return new InstagramVideo(obj);
                case "carousel": return new InstagramCarousel(obj);
                default: throw new InstagramParseException("Unknown media type: " + type);
            }
        }

        #endregion

    }

}