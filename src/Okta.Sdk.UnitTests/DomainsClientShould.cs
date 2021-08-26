// <copyright file="DomainsClientShould.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class DomainsClientShould
    {
        [Fact]
        public async Task VerifyDomain()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);

            var domainsClient = client.Domains;
            await domainsClient.VerifyDomainAsync("domainid");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/domains/domainid/verify");
        }

        [Fact]
        public async Task CreateCertificate()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);

            var privateKeyMock = @"-----BEGIN PRIVATE KEY-----MIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQC5cyk6x63iBJSW-----END PRIVATE KEY-----";

            var certificateMock = @"-----BEGIN CERTIFICATE-----MIIFNzCCBB+gAwIBAgISBAXomJWRama3ypu8TIxdA9wzMA0GCSqGSIb3DQEBCwUA-----END CERTIFICATE-----";

            var domainsClient = client.Domains;
            var domainCertificate = new DomainCertificate
            {
                PrivateKey = privateKeyMock,
                Certificate = certificateMock,
                Type = DomainCertificateType.Pem,
            };
            await domainsClient.CreateCertificateAsync(domainCertificate, "domainId");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/domains/domainId/certificate");
            var expectedBody = $"{{\"privateKey\":\"{privateKeyMock}\",\"certificate\":\"{certificateMock}\",\"type\":\"{domainCertificate.Type}\"}}";
            mockRequestExecutor.ReceivedBody.Should().Be(expectedBody);
        }
    }
}
