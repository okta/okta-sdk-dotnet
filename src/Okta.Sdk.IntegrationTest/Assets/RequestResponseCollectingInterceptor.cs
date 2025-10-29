// <copyright file="RequestResponseCollectingInterceptor.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using RestSharp;
using RestSharp.Interceptors;

namespace Okta.Sdk.UnitTest.Internal;

public class RequestResponseCollectingInterceptor : Interceptor
{
    public RequestResponseCollectingInterceptor()
    {
        this.RestRequests = new HashSet<RestRequest>();
        this.RestResponses = new HashSet<RestResponse>();
        
        this.RequestMessages = new HashSet<HttpRequestMessage>();
        this.ResponseMessages = new HashSet<HttpResponseMessage>();
    }
    
    public HashSet<RestRequest> RestRequests { get; set; }
    public HashSet<RestResponse> RestResponses { get; set; }
    
    public HashSet<HttpRequestMessage> RequestMessages { get; set; }
    public HashSet<HttpResponseMessage> ResponseMessages { get; set; }
    
    public override ValueTask BeforeRequest(RestRequest request, CancellationToken cancellationToken)
    {
        RestRequests.Add(request);
        return base.BeforeRequest(request, cancellationToken);
    }

    public override ValueTask BeforeHttpRequest(HttpRequestMessage requestMessage, CancellationToken cancellationToken)
    {
        RequestMessages.Add(requestMessage);
        return base.BeforeHttpRequest(requestMessage, cancellationToken);
    }

    public override ValueTask AfterRequest(RestResponse response, CancellationToken cancellationToken)
    {
        RestResponses.Add(response);
        return base.AfterRequest(response, cancellationToken);
    }

    public override ValueTask AfterHttpRequest(HttpResponseMessage responseMessage, CancellationToken cancellationToken)
    {
        ResponseMessages.Add(responseMessage);
        return base.AfterHttpRequest(responseMessage, cancellationToken);
    }

    public override ValueTask BeforeDeserialization(RestResponse response, CancellationToken cancellationToken)
    {
        RestResponses.Add(response);
        return base.BeforeDeserialization(response, cancellationToken);
    }
}