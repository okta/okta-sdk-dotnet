using System.Net.Http;
using Okta.Sdk.Internal;

namespace Okta.Sdk.UnitTests.Internal
{
    public class TestHttpRequest : HttpRequest
    {
        public IPayloadHandler GetPayLoadHandler()
        {
            return PayloadHandler;
        }

        public HttpRequestMessage HttpRequestMessage { get; set; }

        public override void SetMessageContent(HttpRequestMessage httpRequestMessage)
        {
            HttpRequestMessage = httpRequestMessage;
        }
    }
}