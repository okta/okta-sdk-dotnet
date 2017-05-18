using System.Collections.Generic;

namespace Okta.Sdk.Abstractions
{
    public class HttpResponseWrapper
    {
        public int StatusCode { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Headers { get; set; }

        public string Body { get; set; }
    }
}