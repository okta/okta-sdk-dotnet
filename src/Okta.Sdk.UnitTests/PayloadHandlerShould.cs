// <copyright file="PayloadHandlerShould.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Internal;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class PayloadHandlerShould
    {
        [Fact]
        public void SetHttpMessageContent()
        {
            // the TestPayloadHandler has a ContentType of "foo"
            var testPayloadHandler = new TestPayloadHandler();
            // register the payload handler so that it is found when the ContentType of the request is set. The OktaClient will register payload handlers as appropriate.
            PayloadHandler.TryRegister(testPayloadHandler);
            // set the ContentType of the request to match the ContentType of the TestPayloadHandler so that the request uses the TestPayloadHandler
            var testHttpRequest = new HttpRequest { ContentType = "foo" };

            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Content.Should().BeNull();
            testPayloadHandler.SetHttpRequestMessageContent(testHttpRequest, httpRequestMessage);
            httpRequestMessage.Content.Should().NotBeNull();
        }

        [Fact]
        public void SetHttpMessageContentTransferEncodingHeader()
        {
            // the TestPayloadHandler has a ContentType of "foo"
            var testPayloadHandler = new TestPayloadHandler();
            // register the payload handler so that it is found when the ContentType of the request is set. The OktaClient will register payload handlers as appropriate.
            PayloadHandler.TryRegister(testPayloadHandler);
            // set the ContentType of the request to match the ContentType of the TestPayloadHandler so that the request uses the TestPayloadHandler
            var testHttpRequest = new HttpRequest { ContentType = "foo" };

            var testContentTransferEncoding = "testContentTransferEncoding-fromPayloadHandler";
            testPayloadHandler.SetContentTransferEncoding(testContentTransferEncoding);

            var httpRequestMessage = new HttpRequestMessage();
            testPayloadHandler.SetHttpRequestMessageContent(testHttpRequest, httpRequestMessage);
            httpRequestMessage.Headers.Contains("Content-Transfer-Encoding").Should().BeTrue();

            // if there is no content transfer encoding on the request then the value from the PayloadHandler is used
            httpRequestMessage.Headers.ToString().Should().Be("Content-Transfer-Encoding: testContentTransferEncoding-fromPayloadHandler\r\n");
        }

        [Fact]
        public void SetHttpMessageContentTransferEncodingFromRequestInsteadOfPayloadHandler()
        {
            // the TestPayloadHandler has a ContentType of "foo"
            var testPayloadHandler = new TestPayloadHandler();
            // register the payload handler so that it is found when the ContentType of the request is set
            PayloadHandler.TryRegister(testPayloadHandler);
            // set the ContentType of the request to match the ContentType of the TestPayloadHandler so that the request uses the TestPayloadHandler
            var testHttpRequest = new HttpRequest
            {
                ContentType = "foo",
                ContentTransferEncoding = "testContentTransferEncoding-fromRequest",
            };
            var testContentTransferEncoding = "testContentTransferEncoding-fromPayloadHandler";
            testPayloadHandler.SetContentTransferEncoding(testContentTransferEncoding);

            var httpRequestMessage = new HttpRequestMessage();
            testPayloadHandler.SetHttpRequestMessageContent(testHttpRequest, httpRequestMessage);
            httpRequestMessage.Headers.Contains("Content-Transfer-Encoding").Should().BeTrue();

            // the content transfer encoding set on the request should win over the content transfer encoding set on the payload handler
            httpRequestMessage.Headers.ToString().Should().Be("Content-Transfer-Encoding: testContentTransferEncoding-fromRequest\r\n");
        }
    }
}
