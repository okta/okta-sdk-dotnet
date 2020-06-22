using System.Net.Http;
using Okta.Sdk.Internal;

namespace Okta.Sdk.UnitTests.Internal
{
    public class TestHttpRequest : HttpRequest
    {
        public IPayloadHandler GetPayloadHandler()
        {
            return PayloadHandler;
        }

        public HttpRequestMessage SentHttpRequestMessage { get; set; }

        public override void SetHttpRequestMessageContent(HttpRequestMessage httpRequestMessage)
        {
            SentHttpRequestMessage = httpRequestMessage;
        }
    }
}