// <copyright file="HttpRequestMessageProviderShould.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using NSubstitute;
using Okta.Sdk.Internal;
using System.Net.Http;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class HttpRequestMessageProviderShould
    {
        [Fact]
        public void CallSetHttpRequestMessageContent()
        {
            var httpRequestMessageProvider = HttpRequestMessageProvider.Default;
            var testHttpRequest = Substitute.For<HttpRequest>();
            httpRequestMessageProvider.CreateHttpRequestMessage(testHttpRequest, "api/v1");
            testHttpRequest
                .Received(1)
                .SetHttpRequestMessageContent(Arg.Any<HttpRequestMessage>());
        }
    }
}
