namespace Okta.Core
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// An <see cref="OktaException"/> thrown for rate limiting issues
    /// </summary>
    public class OktaRequestThrottlingException : OktaException
    {
        [JsonConstructor]
        public OktaRequestThrottlingException()
        { }
        public OktaRequestThrottlingException(string message) : base(message) { }
        public OktaRequestThrottlingException(string message, Exception exception) : base(message, exception) { }
        public OktaRequestThrottlingException(OktaException oktaException) : base(oktaException) { }
    }
}
