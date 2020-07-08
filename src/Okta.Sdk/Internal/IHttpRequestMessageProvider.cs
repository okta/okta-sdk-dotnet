// <copyright file="C:\src\repos\Okta.Net\okta-sdk-dotnet\src\Okta.Sdk\Internal\IHttpRequestMessageProvider.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Net.Http;

namespace Okta.Sdk.Internal
{
    public interface IHttpRequestMessageProvider
    {
        HttpRequestMessage CreateHttpRequestMessage(HttpRequest request, string relativePath);
    }
}
