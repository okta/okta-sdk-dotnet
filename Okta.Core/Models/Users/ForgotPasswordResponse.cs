namespace Okta.Core.Models
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// A response received after making a forgot password request.
    /// </summary>
    public class ForgotPasswordResponse : ApiObject
    {
        /// <summary>
        /// Url for user to reset their password
        /// </summary>
        [JsonProperty("resetPasswordUrl")]
        public Uri ResetPasswordUrl { get; set; }
    }
}