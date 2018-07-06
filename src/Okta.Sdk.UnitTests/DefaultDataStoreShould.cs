// <copyright file="DefaultDataStoreShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using NSubstitute;
using Okta.Sdk.Internal;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class DefaultDataStoreShould
    {
        [Fact]
        public async Task ThrowForNullExecutorResponseDuringGet()
        {
            // If the RequestExecutor returns a null HttpResponse, throw an informative exception.

            var mockRequestExecutor = Substitute.For<IRequestExecutor>();

            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);
            var request = new HttpRequest { Uri = "https://foo.dev" };

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => dataStore.GetAsync<TestResource>(request, new RequestContext(), CancellationToken.None));
        }

        [Fact]
        public async Task ThrowForNullExecutorResponseDuringGetArray()
        {
            // If the RequestExecutor returns a null HttpResponse, throw an informative exception.

            var mockRequestExecutor = Substitute.For<IRequestExecutor>();

            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);
            var request = new HttpRequest { Uri = "https://foo.dev" };

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => dataStore.GetArrayAsync<TestResource>(request, new RequestContext(), CancellationToken.None));
        }

        [Fact]
        public async Task HandleNullPayloadDuringGet()
        {
            // If the API returns a null payload, it shouldn't cause an error.

            var requestExecutor = new MockedStringRequestExecutor(null, statusCode: 200);
            var dataStore = new DefaultDataStore(requestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);
            var request = new HttpRequest { Uri = "https://foo.dev" };

            var response = await dataStore.GetAsync<TestResource>(request, new RequestContext(), CancellationToken.None);

            response.StatusCode.Should().Be(200);
            response.Payload.Should().NotBeNull(); // typeof(Payload) = TestResource
            response.Payload.Foo.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task HandleEmptyPayloadDuringGet()
        {
            // If the API returns a null or empty payload, it shouldn't cause an error.

            var requestExecutor = new MockedStringRequestExecutor(string.Empty, statusCode: 200);
            var dataStore = new DefaultDataStore(requestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);
            var request = new HttpRequest { Uri = "https://foo.dev" };

            var response = await dataStore.GetAsync<TestResource>(request, new RequestContext(), CancellationToken.None);

            response.StatusCode.Should().Be(200);
            response.Payload.Should().NotBeNull();
            response.Payload.Foo.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task DelegateGetToRequestExecutor()
        {
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            mockRequestExecutor
                .GetAsync(Arg.Any<string>(), Arg.Any<IEnumerable<KeyValuePair<string, string>>>(), Arg.Any<CancellationToken>())
                .Returns(new HttpResponse<string>() { StatusCode = 200 });

            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);
            var request = new HttpRequest { Uri = "https://foo.dev" };

            await dataStore.GetAsync<TestResource>(request, new RequestContext(), CancellationToken.None);

            await mockRequestExecutor.Received().GetAsync(
                "https://foo.dev",
                Arg.Any<IEnumerable<KeyValuePair<string, string>>>(),
                CancellationToken.None);
        }

        [Fact]
        public async Task DelegatePostToRequestExecutor()
        {
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            mockRequestExecutor
                .PostAsync(Arg.Any<string>(), Arg.Any<IEnumerable<KeyValuePair<string, string>>>(), Arg.Any<string>(), Arg.Any<CancellationToken>())
                .Returns(new HttpResponse<string>() { StatusCode = 200 });

            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);
            var request = new HttpRequest { Uri = "https://foo.dev", Payload = new { } };

            await dataStore.PostAsync<TestResource>(request, new RequestContext(), CancellationToken.None);

            await mockRequestExecutor.Received().PostAsync(
                "https://foo.dev",
                Arg.Any<IEnumerable<KeyValuePair<string, string>>>(),
                "{}",
                CancellationToken.None);
        }

        [Fact]
        public async Task DelegatePutToRequestExecutor()
        {
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            mockRequestExecutor
                .PutAsync(Arg.Any<string>(), Arg.Any<IEnumerable<KeyValuePair<string, string>>>(), Arg.Any<string>(), Arg.Any<CancellationToken>())
                .Returns(new HttpResponse<string>() { StatusCode = 200 });

            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);
            var request = new HttpRequest { Uri = "https://foo.dev", Payload = new { } };

            await dataStore.PutAsync<TestResource>(request, new RequestContext(), CancellationToken.None);

            await mockRequestExecutor.Received().PutAsync(
                "https://foo.dev",
                Arg.Any<IEnumerable<KeyValuePair<string, string>>>(),
                "{}",
                CancellationToken.None);
        }

        [Fact]
        public async Task DelegateDeleteToRequestExecutor()
        {
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            mockRequestExecutor
                .DeleteAsync(Arg.Any<string>(), Arg.Any<IEnumerable<KeyValuePair<string, string>>>(), Arg.Any<CancellationToken>())
                .Returns(new HttpResponse<string>() { StatusCode = 200 });

            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);
            var request = new HttpRequest { Uri = "https://foo.dev" };

            await dataStore.DeleteAsync(request, new RequestContext(), CancellationToken.None);

            await mockRequestExecutor.Received().DeleteAsync(
                "https://foo.dev",
                Arg.Any<IEnumerable<KeyValuePair<string, string>>>(),
                CancellationToken.None);
        }

        [Fact]
        public async Task AddUserAgentToRequests()
        {
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            mockRequestExecutor
                .GetAsync(Arg.Any<string>(), Arg.Any<IEnumerable<KeyValuePair<string, string>>>(), Arg.Any<CancellationToken>())
                .Returns(new HttpResponse<string>() { StatusCode = 200 });

            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);
            var request = new HttpRequest { Uri = "https://foo.dev" };

            await dataStore.GetAsync<TestResource>(request, new RequestContext(), CancellationToken.None);

            // Assert that the request sent to the RequestExecutor included the User-Agent header
            await mockRequestExecutor.Received().GetAsync(
                "https://foo.dev",
                Arg.Is<IEnumerable<KeyValuePair<string, string>>>(
                    headers => headers.Any(kvp => kvp.Key == "User-Agent" && kvp.Value.StartsWith("okta-sdk-dotnet/"))),
                CancellationToken.None);
        }

        [Fact]
        public async Task AddContextUserAgentToRequests()
        {
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            mockRequestExecutor
                .GetAsync(Arg.Any<string>(), Arg.Any<IEnumerable<KeyValuePair<string, string>>>(), Arg.Any<CancellationToken>())
                .Returns(new HttpResponse<string>() { StatusCode = 200 });

            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);
            var request = new HttpRequest { Uri = "https://foo.dev" };
            var requestContext = new RequestContext { UserAgent = "sdk-vanillajs/1.1" };

            await dataStore.GetAsync<TestResource>(request, requestContext, CancellationToken.None);

            // Assert that the request sent to the RequestExecutor included the User-Agent header
            await mockRequestExecutor.Received().GetAsync(
                "https://foo.dev",
                Arg.Is<IEnumerable<KeyValuePair<string, string>>>(
                    headers => headers.Any(kvp => kvp.Key == "User-Agent" && kvp.Value.StartsWith("sdk-vanillajs/1.1 okta-sdk-dotnet/"))),
                CancellationToken.None);
        }

        [Fact]
        public async Task AddContextXForwardedToRequests()
        {
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            mockRequestExecutor
                .GetAsync(Arg.Any<string>(), Arg.Any<IEnumerable<KeyValuePair<string, string>>>(), Arg.Any<CancellationToken>())
                .Returns(new HttpResponse<string>() { StatusCode = 200 });

            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);
            var request = new HttpRequest { Uri = "https://foo.dev" };
            var requestContext = new RequestContext
            {
                XForwardedFor = "myapp.com",
                XForwardedPort = "1234",
                XForwardedProto = "https",
            };

            await dataStore.GetAsync<TestResource>(request, requestContext, CancellationToken.None);

            // Assert that the request sent to the RequestExecutor included the User-Agent header
            await mockRequestExecutor.Received().GetAsync(
                "https://foo.dev",
                Arg.Is<IEnumerable<KeyValuePair<string, string>>>(headers =>
                    headers.Any(kvp => kvp.Key == "X-Forwarded-For" && kvp.Value == "myapp.com") &&
                    headers.Any(kvp => kvp.Key == "X-Forwarded-Port" && kvp.Value == "1234") &&
                    headers.Any(kvp => kvp.Key == "X-Forwarded-Proto" && kvp.Value == "https")),
                CancellationToken.None);
        }

        [Fact]
        public async Task PostWithNullBody()
        {
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            mockRequestExecutor
                .PostAsync(Arg.Any<string>(), Arg.Any<IEnumerable<KeyValuePair<string, string>>>(), Arg.Any<string>(), Arg.Any<CancellationToken>())
                .Returns(new HttpResponse<string>() { StatusCode = 200 });

            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);
            var request = new HttpRequest { Uri = "https://foo.dev" }; // Payload = null

            await dataStore.PostAsync<TestResource>(request, new RequestContext(), CancellationToken.None);

            await mockRequestExecutor.Received().PostAsync(
                href: "https://foo.dev",
                headers: Arg.Any<IEnumerable<KeyValuePair<string, string>>>(),
                body: null,
                cancellationToken: CancellationToken.None);
        }
    }
}
