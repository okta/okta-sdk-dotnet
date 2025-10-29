// <copyright file="TestHttpMessageHandler.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

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
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        ReceivedCall = true;
        ReceivedRequestMessage = request;
        ReceivedCancellationToken = cancellationToken;
        
        return Task.FromResult(ResponseMessage);
    }
}