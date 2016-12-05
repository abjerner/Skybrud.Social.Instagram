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
        /// Gets the filter used for this media.
        /// </summary>
        public string Filter { get; internal set; }

        /// <summary>
        /// Specifies the time of creation in UTC/GMT 0.
        /// </summary>
        public EssentialsDateTime Created { get; internal set; }

        /// <summary>
        /// Gets the link (URL) of the page on instagram.com for the media.
        /// </summary>
        public string Link { get; internal set; }

        /// <summary>
        /// Gets the amount of likes the media has received. This equals calling <code>Likes.Count</code>.
        /// </summary>
        public int LikeCount { get; internal set; }

        /// <summary>
        /// Gets the amount of comments the media has received. This equals calling <code>Comments.Count</code>.
        /// </summary>
        public int CommentCount { get; internal set; }

        /// <summary>
        /// Gets an array of comments of the media. If the media has received many comments, this array may just be a
        /// subset of all the comments.
        /// </summary>
        public InstagramComment[] Comments { get; internal set; }

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
        /// Gets the caption text of the media, or <code>null</code> if not specified.
        /// </summary>
        public string CaptionText {
            get { return Caption == null ? null : Caption.Text; }
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
        /// Gets an array of users tagged in the photo.
        /// </summary>
        public InstagramTaggedUser[] UsersInPhoto { get; private set; }

        /// <summary>
        /// Gets the creation date of the media. This property is just an alias of the <see cref="Created"/> property.
        /// </summary>
        public EssentialsDateTime Date {
            get { return Created; }
        }

        /// <summary>
        /// Gets an array of likes of the media. If the media has received many likes, this array may just be a subset
        /// of all the likes.
        /// </summary>
        public InstagramUserSummary[] Likes { get; internal set; }

        /// <summary>
        /// Gets the creation date of the media. This property is just an alias of the <see cref="Created"/> property.
        /// </summary>
        public DateTime SortDate {
            get { return Date.DateTime; }
        }

        #endregion

        #region Constructors

        internal InstagramMedia(JObject obj) : base(obj) {

            JObject comments = obj.GetObject("comments");
            JObject likes = obj.GetObject("likes");

            Id = obj.GetString("id");
            Type = obj.GetString("type");
            Tags = obj.GetStringArray("tags");
            Created = obj.GetInt64("created_time", EssentialsDateTime.FromUnixTimestamp);
            Link = obj.GetString("link");
            Filter = obj.GetString("filter");
            CommentCount = comments.GetInt32("count");
            Comments = comments.GetArray("data", InstagramComment.Parse);
            LikeCount = likes.GetInt32("count");
            Likes = likes.GetArray("data", InstagramUserSummary.Parse);
            Images = obj.GetObject("images", InstagramImageSummary.Parse);
            Caption = obj.GetObject("caption", InstagramComment.Parse);
            User = obj.GetObject("user", InstagramUser.Parse);
            Location = obj.GetObject("location", InstagramLocation.Parse);
            UsersInPhoto = obj.GetArray("users_in_photo", InstagramTaggedUser.Parse);
        
        }

        #endregion

        #region Static methods
        
        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramMedia"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramMedia"/>.</returns>
        public static InstagramMedia Parse(JObject obj) {
            if (obj == null) return null;
            string type = obj.GetString("type");
            switch (type) {
                case "image": return new InstagramImage(obj);
                case "video": return new InstagramVideo(obj);
                default: throw new InstagramParseException("Unknown media type: " + type);
            }
        }

        #endregion

    }

}