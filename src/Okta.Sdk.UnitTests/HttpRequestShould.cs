// <copyright file="HttpRequestShould.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using NSubstitute;
using Okta.Sdk.Internal;
using Okta.Sdk.UnitTests.Internal;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class HttpRequestShould
    {
        [Fact]
        public void SetPayloadHandlerWhenContentTypeIsSet()
        {
            // must register PkixCertPayloadHandler for it to be available to the HttpRequest
            // the OktaClient will register the PkixCertPayloadHandler on instantiation.
            PayloadHandler.TryRegister<PkixCertPayloadHandler>();
            var request = new TestHttpRequest();
            request.ContentType.Should().Be("application/json");
            request.GetPayloadHandler().GetType().Should().Be(typeof(JsonPayloadHandler));
            request.ContentType = "application/pkix-cert";
            request.GetPayloadHandler().GetType().Should().Be(typeof(PkixCertPayloadHandler));
        }

        [Fact]
        public void SetContentTransferEncodingHeader()
        {
            var request = new HttpRequest();
            request.ContentTransferEncoding.Should().BeNullOrEmpty();
            request.ContentTransferEncoding = "base64";
            request.Headers.ContainsKey("Content-Transfer-Encoding").Should().BeTrue();
            request.Headers["Content-Transfer-Encoding"].Should().Be("base64");
        }

        [Fact]
        public void CallPayloadHandlerSetHttpRequestMessageContent()
        {
            var testContentType = "testContentType";
            var mockPayloadHandler = Substitute.For<IPayloadHandler>();
            mockPayloadHandler.ContentType.Returns(testContentType);
            var testHttpMessage = new HttpRequestMessage();

            // Registering the payload handler sets it as the handler for its content type; in this case "testContentType"
            PayloadHandler.TryRegister(mockPayloadHandler);
            // Setting ContentType on the request causes the internal payload handler to be set to the PayloadHandler registered for the specified content type
            var testHttpRequest = new TestHttpRequest { ContentType = testContentType };
            testHttpRequest.GetPayloadHandler().GetType().Should().NotBe(typeof(JsonPayloadHandler)); // the actual type is a mock

            testHttpRequest.SetHttpRequestMessageContent(testHttpMessage);
            mockPayloadHandler
                .Received(1)
                .SetHttpRequestMessageContent(Arg.Is(testHttpRequest), Arg.Is(testHttpMessage));
        }
    }
}
