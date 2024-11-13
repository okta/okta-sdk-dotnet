using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Model;

namespace Okta.Sdk.UnitTest.Internal;

public class TestHttpMessageHandler : HttpMessageHandler
{
    public TestHttpMessageHandler(HttpResponseMessage responseMessage)
    {
        ResponseMessage = responseMessage;
    }
    public HttpResponseMessage ResponseMessage { get; set; }
    public HttpRequestMessage ReceivedRequestMessage { get; set; }
    public CancellationToken ReceivedCancellationToken { get; set; }
    public bool ReceivedCall { get; set; }
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        ReceivedCall = true;
        ReceivedRequestMessage = request;
        ReceivedCancellationToken = cancellationToken;
        
        return ResponseMessage;
    }
}