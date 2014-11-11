using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Okta.Core
{
    /// <summary>
    /// An Okta-specific exception
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class OktaException : Exception
    {
        [JsonConstructor]
        public OktaException() : base() { }
        public OktaException(string message) : base(message) { }
        public OktaException(string message, Exception exception) : base(message, exception) { }
        public OktaException(OktaException oktaException) {
            this.ErrorCode = oktaException.ErrorCode;
            this.ErrorSummary = oktaException.ErrorSummary;
            this.ErrorLink = oktaException.ErrorLink;
            this.ErrorId = oktaException.ErrorId;
            this.ErrorCauses = oktaException.ErrorCauses;
            this.HttpStatusCode = oktaException.HttpStatusCode;
        }

        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("errorSummary")]
        public string ErrorSummary { get; set; }

        [JsonProperty("errorLink")]
        public string ErrorLink { get; set; }

        [JsonProperty("errorId")]
        public string ErrorId { get; set; }

        [JsonProperty("errorCauses")]
        public ErrorCause[] ErrorCauses { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }

    /// <summary>
    /// Further explanation for why an <see cref="OktaException"/> occurred
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ErrorCause
    {
        [JsonProperty("errorSummary")]
        public string ErrorSummary { get; set; }
    }
}
