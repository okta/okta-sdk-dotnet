using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Okta.Core
{
    /// <summary>
    /// An <see cref="OktaException"/> thrown for authentication issues
    /// </summary>
    public class OktaAuthenticationException : OktaException
    {
        [JsonConstructor]
        public OktaAuthenticationException() : base() { }
        public OktaAuthenticationException(string message) : base(message) { }
        public OktaAuthenticationException(string message, Exception exception) : base(message, exception) { }
        public OktaAuthenticationException(OktaException oktaException) : base(oktaException) { }
    }
}
