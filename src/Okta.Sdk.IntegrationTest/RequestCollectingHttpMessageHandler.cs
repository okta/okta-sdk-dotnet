using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Abstractions;

namespace Okta.Sdk.Integration.Tests;

public class RequestCollectingHttpMessageHandler : HttpClientHandler
{
    public RequestCollectingHttpMessageHandler()
    {
        this.RequestMessages = new HashSet<HttpRequestMessage>();
        this.ResponseMessages = new HashSet<HttpResponseMessage>();
    }
    
    public HashSet<HttpRequestMessage> RequestMessages { get; set; }
    public HashSet<HttpResponseMessage> ResponseMessages { get; set; }
    
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        this.RequestMessages.Add(request);

        HttpResponseMessage responseMessage = await base.SendAsync(request, cancellationToken);
        this.ResponseMessages.Add(responseMessage);
        return responseMessage;
    }
}