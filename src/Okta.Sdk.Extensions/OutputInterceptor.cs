// <copyright file="OutputInterceptor.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Net;
using System.Text;
using RestSharp;
using RestSharp.Interceptors;

namespace Okta.Sdk.Extensions;

/// <summary>
/// An interceptor that writes request and response details to a given output.
/// </summary>
public class OutputInterceptor : Interceptor
{
    public OutputInterceptor(IOutput output)
    {
        this.Output = output;
    }

    private IOutput Output { get; set; }

    private async ValueTask WriteAsync(string message)
    {
        await Output.WriteAsync(message);
    }
    
    protected virtual async Task<string> GetRestRequestStringAsync(RestRequest request, object state = null)
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
            foreach (Cookie cookie in request.CookieContainer.GetCookies(new Uri(request.Resource)))
            {
                stringBuilder.AppendLine($"{cookie.Name}: {cookie.Value}");
            }
        }

        return stringBuilder.ToString();
    }

    protected virtual async Task<string> GetRestResponseStringAsync(RestResponse response, object state = null, CancellationToken cancellationToken = default)
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

    protected virtual async Task<string> GetHttpRequestStringAsync(HttpRequestMessage requestMessage, object state = null, CancellationToken cancellationToken = default)
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
            stringBuilder.AppendLine(await requestMessage.Content.ReadAsStringAsync());
        }
        return stringBuilder.ToString();
    }
    
    protected virtual async Task<string> GetHttpResponseStringAsync(HttpResponseMessage responseMessage, object state = null,
        CancellationToken cancellationToken = default)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"***{state.GetProperty<string>("Info")}***");
        stringBuilder.AppendLine($"Status: {responseMessage.StatusCode}");
        foreach (KeyValuePair<string, IEnumerable<string>> header in responseMessage.Headers)
        {
            stringBuilder.AppendLine($"{header.Key}: {string.Join(",", header.Value)}");
        }

        stringBuilder.AppendLine(await responseMessage.Content.ReadAsStringAsync());
        return stringBuilder.ToString();
    }

    protected virtual async ValueTask WriteRestRequestAsync(RestRequest request, dynamic state = null, CancellationToken cancellationToken = default)
    {
        string output = await GetRestRequestStringAsync(request, state);
        await WriteAsync(output);
    }

    protected virtual async ValueTask WriteRestResponseAsync(RestResponse response, dynamic state = null, CancellationToken cancellationToken = default)
    {
        string output = await GetRestResponseStringAsync(response, state, cancellationToken);
        await WriteAsync(output);
    }

    protected virtual async ValueTask WriteHttpRequestAsync(HttpRequestMessage requestMessage, dynamic state = null, CancellationToken cancellationToken = default)
    {
        string output = await GetHttpRequestStringAsync(requestMessage, state, cancellationToken);
        await WriteAsync(output);
    }

    protected virtual async ValueTask WriteHttpResponseAsync(HttpResponseMessage responseMessage, dynamic state = null,
        CancellationToken cancellationToken = default)
    {
        string output = await GetHttpResponseStringAsync(responseMessage, state, cancellationToken);
        await WriteAsync(output);
    }
    
    public override async ValueTask BeforeRequest(RestRequest request, CancellationToken cancellationToken)
    {
        await WriteRestRequestAsync(request, new { Info = nameof(BeforeRequest) }, cancellationToken);
    }

    public override async ValueTask AfterRequest(RestResponse response, CancellationToken cancellationToken)
    {
        await WriteRestResponseAsync(response, new { Info = nameof(AfterRequest) }, cancellationToken);
    }

    public override async ValueTask BeforeDeserialization(RestResponse response, CancellationToken cancellationToken)
    {
        await WriteRestResponseAsync(response, new { Info = nameof(BeforeDeserialization) }, cancellationToken);
    }
    
    public override async ValueTask BeforeHttpRequest(HttpRequestMessage requestMessage, CancellationToken cancellationToken)
    {
        await WriteHttpRequestAsync(requestMessage, new { Info = nameof(BeforeHttpRequest) }, cancellationToken);
    }

    public override async ValueTask AfterHttpRequest(HttpResponseMessage responseMessage, CancellationToken cancellationToken)
    {
        await WriteHttpResponseAsync(responseMessage, new { Info = nameof(AfterHttpRequest) }, cancellationToken);
    }
}