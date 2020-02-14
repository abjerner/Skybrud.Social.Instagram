using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Instagram.Models.Media;

namespace Skybrud.Social.Instagram.Responses.Media {
    
    /// <summary>
    /// Class representing the response of a call for getting information about a given media.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/media/#get_media</cref>
    /// </see>
    public class InstagramGetMediaResponse : InstagramResponse<InstagramGetMediaEnvelope> {

        #region Constructors

        private InstagramGetMediaResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramGetMediaEnvelope.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramGetMediaResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramGetMediaResponse"/>.</returns>
        public static InstagramGetMediaResponse ParseResponse(IHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException(nameof(response));

            // Initialize the response object
            return new InstagramGetMediaResponse(response);

        }

        #endregion

    }
}