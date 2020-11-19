// <copyright file="PayloadHandlerShould.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Linq;
using System.Net.Http;
using System.Text;
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
            httpRequestMessage.Content.GetType().Should().Be(typeof(StringContent));
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
            httpRequestMessage.Headers.ToString().Should().BeOneOf(
                "Content-Transfer-Encoding: testContentTransferEncoding-fromPayloadHandler\n",
                "Content-Transfer-Encoding: testContentTransferEncoding-fromPayloadHandler\r\n");
            httpRequestMessage.Content.Should().NotBeNull();
            httpRequestMessage.Content.GetType().Should().Be(typeof(StringContent));
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
            httpRequestMessage.Headers.ToString().Should().BeOneOf(
                "Content-Transfer-Encoding: testContentTransferEncoding-fromRequest\n",
                "Content-Transfer-Encoding: testContentTransferEncoding-fromRequest\r\n");
            httpRequestMessage.Content.Should().NotBeNull();
            httpRequestMessage.Content.GetType().Should().Be(typeof(StringContent));
        }

        [Fact]
        public void SetPkixCertContent()
        {
            var pkixCertPayloadHandler = new PkixCertPayloadHandler();
            PayloadHandler.TryRegister(pkixCertPayloadHandler);
            var testHttpRequest = new TestHttpRequest
            {
                ContentType = "application/pkix-cert", // this must match the ContentType of the PkixCertPayloadHandler for this test
                Payload = "testPayload",
            };
            testHttpRequest.GetPayloadHandler().GetType().Should().Be(typeof(PkixCertPayloadHandler));

            var httpRequestMessage = new HttpRequestMessage();
            pkixCertPayloadHandler.SetHttpRequestMessageContent(testHttpRequest, httpRequestMessage);
            httpRequestMessage.Content.Should().NotBeNull();
            httpRequestMessage.Content.GetType().Should().Be(typeof(StringContent));
            httpRequestMessage.Content.Headers.Contains("Content-Type");
            httpRequestMessage.Content.Headers.ContentType.ToString().Should().Be("application/pkix-cert; charset=utf-8");
        }

        [Fact]
        public void SetPemCertContent()
        {
            var pkixCertPayloadHandler = new PemFilePayloadHandler();
            PayloadHandler.TryRegister(pkixCertPayloadHandler);
            var testHttpRequest = new TestHttpRequest
            {
                ContentType = "application/x-pem-file", // this must match the ContentType of the PemFilePayloadHandler for this test
                Payload = Encoding.UTF8.GetBytes("testPayload"),
            };
            testHttpRequest.GetPayloadHandler().GetType().Should().Be(typeof(PemFilePayloadHandler));

            var httpRequestMessage = new HttpRequestMessage();
            pkixCertPayloadHandler.SetHttpRequestMessageContent(testHttpRequest, httpRequestMessage);
            httpRequestMessage.Content.Should().NotBeNull();
            httpRequestMessage.Content.GetType().Should().Be(typeof(ByteArrayContent));
            httpRequestMessage.Content.Headers.Contains("Content-Type");
            httpRequestMessage.Content.Headers.ContentType.ToString().Should().Be("application/x-pem-file");
        }

        [Fact]
        public void SetX509CertContent()
        {
            var pkixCertPayloadHandler = new X509CaCertPayloadHandler();
            PayloadHandler.TryRegister(pkixCertPayloadHandler);
            var testHttpRequest = new TestHttpRequest
            {
                ContentType = "application/x-x509-ca-cert", // this must match the ContentType of the X509CaCertPayloadHandler for this test
                Payload = Encoding.UTF8.GetBytes("testPayload"),
            };
            testHttpRequest.GetPayloadHandler().GetType().Should().Be(typeof(X509CaCertPayloadHandler));

            var httpRequestMessage = new HttpRequestMessage();
            pkixCertPayloadHandler.SetHttpRequestMessageContent(testHttpRequest, httpRequestMessage);
            httpRequestMessage.Content.Should().NotBeNull();
            httpRequestMessage.Content.GetType().Should().Be(typeof(ByteArrayContent));
            httpRequestMessage.Content.Headers.Contains("Content-Type");
            httpRequestMessage.Content.Headers.ContentType.ToString().Should().Be("application/x-x509-ca-cert");
        }
    }
}
