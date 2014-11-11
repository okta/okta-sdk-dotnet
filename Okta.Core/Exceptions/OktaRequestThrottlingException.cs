using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Okta.Core
{
    /// <summary>
    /// An <see cref="OktaException"/> thrown for rate limiting issues
    /// </summary>
    public class OktaRequestThrottlingException : OktaException
    {
        [JsonConstructor]
        public OktaRequestThrottlingException() : base() { }
        public OktaRequestThrottlingException(string message) : base(message) { }
        public OktaRequestThrottlingException(string message, Exception exception) : base(message, exception) { }
        public OktaRequestThrottlingException(OktaException oktaException) : base(oktaException) { }
    }
}
