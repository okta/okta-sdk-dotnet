// <copyright file="RequestResponseCollectingHttpMessageHandler.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Abstractions;

namespace Okta.Sdk.Integration.Tests;

public class RequestResponseCollectingHttpMessageHandler : HttpClientHandler
{
    public RequestResponseCollectingHttpMessageHandler()
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