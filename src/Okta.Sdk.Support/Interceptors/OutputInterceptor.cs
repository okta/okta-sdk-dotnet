using System.Net;
using System.Text;
using RestSharp;
using RestSharp.Interceptors;

namespace Okta.Sdk.UnitTest.Interceptors;

public class OutputInterceptor : Interceptor
{
    public OutputInterceptor(IOutput output)
    {
        this.Output = output;
    }

    protected IOutput Output { get; set; }
    
    protected async ValueTask WriteAsync(string message)
    {
        await Output.WriteAsync(message);
    }
    
    protected virtual async Task<string> GetStringAsync(RestRequest request, object state = null, CancellationToken cancellationToken = default)
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"***{state.GetProperty<string>("Info")}***");
        stringBuilder.AppendLine($"{request.Method} {request.Resource}");

        stringBuilder.AppendLine("**Parameters**");
        foreach (Parameter parameter in request.Parameters)
        {
            stringBuilder.AppendLine($"Type={parameter.Type}, Name={parameter.Name}, ContentType={parameter.ContentType}, Value={parameter.Value}");
        }

        if (request.CookieContainer != null)
        {
            stringBuilder.AppendLine("**Cookies**");
            foreach (Cookie cookie in request.CookieContainer.GetAllCookies())
            {
                stringBuilder.AppendLine($"{cookie.Name}: {cookie.Value}");
            }
        }

        return stringBuilder.ToString();
    }

    protected virtual async Task<string> GetStringAsync(RestResponse response, object state = null, CancellationToken cancellationToken = default)
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"***{state.GetProperty<string>("Info")}***");
        stringBuilder.AppendLine($"Server: {response.Server}");
        stringBuilder.AppendLine($"Status: {response.StatusCode} {response.StatusDescription}");

        if (response.Headers != null)
        {
            foreach (HeaderParameter header in response.Headers)
            {
                stringBuilder.AppendLine($"{header.Name}: {header.Value}");
            }
        }

        if (response.Content != null)
        {
            stringBuilder.AppendLine();
            stringBuilder.AppendLine(response.Content);
        }
        return stringBuilder.ToString();
    }

    protected virtual async Task<string> GetStringAsync(HttpRequestMessage requestMessage, object state = null, CancellationToken cancellationToken = default)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"***{state.GetProperty<string>("Info")}***");
        stringBuilder.AppendLine($"{requestMessage.Method} {requestMessage.RequestUri}");

        foreach (KeyValuePair<string, IEnumerable<string>> header in requestMessage.Headers)
        {
            stringBuilder.AppendLine($"{header.Key}: {string.Join(",", header.Value)}");
        }

        if (requestMessage.Content != null)
        {
            stringBuilder.AppendLine();
            stringBuilder.AppendLine(await requestMessage.Content.ReadAsStringAsync(cancellationToken));
        }
        return stringBuilder.ToString();
    }
    
    protected virtual async Task<string> GetStringAsync(HttpResponseMessage responseMessage, object state = null,
        CancellationToken cancellationToken = default)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"***{state.GetProperty<string>("Info")}***");
        stringBuilder.AppendLine($"Status: {responseMessage.StatusCode}");
        foreach (KeyValuePair<string, IEnumerable<string>> header in responseMessage.Headers)
        {
            stringBuilder.AppendLine($"{header.Key}: {string.Join(",", header.Value)}");
        }

        stringBuilder.AppendLine(await responseMessage.Content.ReadAsStringAsync(cancellationToken));
        return stringBuilder.ToString();
    }

    protected virtual async ValueTask WriteAsync(RestRequest request, dynamic state = null, CancellationToken cancellationToken = default)
    {
        string output = await GetStringAsync(request, state, cancellationToken);
        await WriteAsync(output);
    }

    protected virtual async ValueTask WriteAsync(RestResponse response, dynamic state = null, CancellationToken cancellationToken = default)
    {
        string output = await GetStringAsync(response, state, cancellationToken);
        await WriteAsync(output);
    }

    protected virtual async ValueTask WriteAsync(HttpRequestMessage requestMessage, dynamic state = null, CancellationToken cancellationToken = default)
    {
        string output = await GetStringAsync(requestMessage, state, cancellationToken);
        await WriteAsync(output);
    }

    protected virtual async ValueTask WriteAsync(HttpResponseMessage responseMessage, dynamic state = null,
        CancellationToken cancellationToken = default)
    {
        string output = await GetStringAsync(responseMessage, state, cancellationToken);
        await WriteAsync(output);
    }
    
    public override async ValueTask BeforeRequest(RestRequest request, CancellationToken cancellationToken)
    {
        await WriteAsync(request, new { Info = nameof(BeforeRequest) }, cancellationToken);
    }

    public override async ValueTask AfterRequest(RestResponse response, CancellationToken cancellationToken)
    {
        await WriteAsync(response, new { Info = nameof(AfterRequest) }, cancellationToken);
    }

    public override async ValueTask BeforeDeserialization(RestResponse response, CancellationToken cancellationToken)
    {
        await WriteAsync(response, new { Info = nameof(BeforeDeserialization) }, cancellationToken);
    }
    
    public override async ValueTask BeforeHttpRequest(HttpRequestMessage requestMessage, CancellationToken cancellationToken)
    {
        await WriteAsync(requestMessage, new { Info = nameof(BeforeHttpRequest) }, cancellationToken);
    }

    public override async ValueTask AfterHttpRequest(HttpResponseMessage responseMessage, CancellationToken cancellationToken)
    {
        await WriteAsync(responseMessage, new { Info = nameof(AfterHttpRequest) }, cancellationToken);
    }
}