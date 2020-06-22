using System.Net.Http;

namespace Okta.Sdk.Internal
{
    public interface IHttpRequestMessageProvider
    {
        HttpRequestMessage CreateHttpRequestMessage(HttpRequest request, string relativePath);
    }
}