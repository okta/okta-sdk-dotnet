using System.Net.Http;
using Okta.Sdk.Internal;

namespace Okta.Sdk.UnitTests.Internal
{
    public class TestPayloadHandler : PayloadHandler
    {
        public TestPayloadHandler()
        {
            ContentType = "foo";
        }

        protected override HttpContent GetContent(HttpRequest httpRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}