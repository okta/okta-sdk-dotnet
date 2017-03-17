namespace Okta.Core
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// An <see cref="OktaException"/> thrown for authentication issues
    /// </summary>
    public class OktaAuthenticationException : OktaException
    {
        [JsonConstructor]
        public OktaAuthenticationException()
        { }
        public OktaAuthenticationException(string message) : base(message) { }
        public OktaAuthenticationException(string message, Exception exception) : base(message, exception) { }
        public OktaAuthenticationException(OktaException oktaException) : base(oktaException) { }
    }
}
