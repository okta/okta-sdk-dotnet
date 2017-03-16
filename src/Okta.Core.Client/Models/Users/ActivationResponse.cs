namespace Okta.Core.Models
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// A response received after attempting to activate a <see cref="User"/>
    /// </summary>
    public class ActivationResponse : ApiObject
    {
        /// <summary>
        /// Url for user to activate their account
        /// </summary>
        [JsonProperty("activationUrl")]
        public Uri ActivationUrl { get; set; }
    }
}