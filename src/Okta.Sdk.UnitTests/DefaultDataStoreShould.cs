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
using Newtonsoft.Json;
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
                .PostAsync(Arg.Any<HttpRequest>(), Arg.Any<CancellationToken>())
                .Returns(new HttpResponse<string>() { StatusCode = 200 });

            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);
            var request = new HttpRequest { Uri = "https://foo.dev", Payload = new { } };

            await dataStore.PostAsync<TestResource>(request, new RequestContext(), CancellationToken.None);

            await mockRequestExecutor.Received().PostAsync(
                Arg.Is<HttpRequest>(httpRequest => httpRequest.Uri.Equals("https://foo.dev")),
                CancellationToken.None);
        }

        [Fact]
        public async Task DeserializeObjectUsingCustomSettings()
        {
            var mockResponse = @"{  
               ""id"":""foo"",
               ""status"":""ACTIVE"",
               ""created"":""2019-05-09T15:37:44.000Z"",
               ""activated"":""2019-05-09T15:37:44.000Z"",
               ""statusChanged"":""2019-05-09T18:29:29.000Z"",
               ""lastLogin"":""2019-08-09T07:49:51.000Z"",
               ""lastUpdated"":""2019-08-09T17:20:28.000Z"",
               ""passwordChanged"":""2019-05-09T18:29:29.000Z"",
               ""profile"":{  
                  ""firstName"":""John"",
                  ""lastName"":""Coder"",
                  ""mobilePhone"":null,
                  ""userType"":""test"",
                  ""login"":""john.coder@dotnettest.com"",
                  ""startDate"":""2016-06-07T00:00:00.000"",
                  ""email"":""john.coder@test.com"",
                  ""employeeNumber"":""000012345"",
                  ""type"":""null"",
               },
            }";

            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            mockRequestExecutor
                .GetAsync(Arg.Any<string>(), Arg.Any<IEnumerable<KeyValuePair<string, string>>>(), Arg.Any<CancellationToken>())
                .Returns(new HttpResponse<string>() { StatusCode = 200, Payload = mockResponse });

            // DateParseHandling.None: Date formatted strings are not parsed to a date type and are read as strings.
            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(new JsonSerializerSettings() { DateParseHandling = DateParseHandling.None }), new ResourceFactory(null, null), NullLogger.Instance);
            var request = new HttpRequest { Uri = "https://foo.dev", Payload = new { } };
            var response = await dataStore.GetAsync<User>(request, new RequestContext(), CancellationToken.None);
            response.Payload.Profile["startDate"].GetType().Should().Be(typeof(string));
            response.Payload.Profile["startDate"].Should().Be("2016-06-07T00:00:00.000");

            // DateParseHandling.DateTimeOffset: Date formatted strings, e.g. "\/Date(1198908717056)\/" and "2012-03-21T05:40Z", are parsed to DateTimeOffset.
            dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(new JsonSerializerSettings() { DateParseHandling = DateParseHandling.DateTimeOffset }), new ResourceFactory(null, null), NullLogger.Instance);
            response = await dataStore.GetAsync<User>(request, new RequestContext(), CancellationToken.None);
            response.Payload.Profile["startDate"].GetType().Should().Be(typeof(DateTimeOffset));
            var dateTimeOffset = DateTimeOffset.Parse("2016-06-07T00:00:00.000");
            response.Payload.Profile["startDate"].Should().Be(dateTimeOffset);
        }

        [Fact]
        public async Task DeserializeDateCustomPropertyAsString()
        {
            var mockResponse = @"{  
               ""id"":""foo"",
               ""status"":""ACTIVE"",
               ""created"":""2019-05-09T15:37:44.000Z"",
               ""activated"":""2019-05-09T15:37:44.000Z"",
               ""statusChanged"":""2019-05-09T18:29:29.000Z"",
               ""lastLogin"":""2019-08-09T07:49:51.000Z"",
               ""lastUpdated"":""2019-08-09T17:20:28.000Z"",
               ""passwordChanged"":""2019-05-09T18:29:29.000Z"",
               ""profile"":{  
                  ""firstName"":""John"",
                  ""lastName"":""Coder"",
                  ""mobilePhone"":null,
                  ""userType"":""test"",
                  ""login"":""john.coder@dotnettest.com"",
                  ""startDate"":""2016-06-07T00:00:00.000"",
                  ""email"":""john.coder@test.com"",
                  ""employeeNumber"":""000012345"",
                  ""type"":""null"",
               },
            }";

            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            mockRequestExecutor
                .GetAsync(Arg.Any<string>(), Arg.Any<IEnumerable<KeyValuePair<string, string>>>(), Arg.Any<CancellationToken>())
                .Returns(new HttpResponse<string>() { StatusCode = 200, Payload = mockResponse });

            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);
            var request = new HttpRequest { Uri = "https://foo.dev", Payload = new { } };
            var response = await dataStore.GetAsync<User>(request, new RequestContext(), CancellationToken.None);
            response.Payload.Profile["startDate"].GetType().Should().Be(typeof(string));
            response.Payload.Profile["startDate"].Should().Be("2016-06-07T00:00:00.000");
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
        public async Task AddContextAcceptToRequests()
        {
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            mockRequestExecutor
                .GetAsync(Arg.Any<string>(), Arg.Any<IEnumerable<KeyValuePair<string, string>>>(), Arg.Any<CancellationToken>())
                .Returns(new HttpResponse<string>() { StatusCode = 200 });

            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);
            var request = new HttpRequest { Uri = "https://foo.dev" };
            var requestContext = new RequestContext { Accept = "application/pkcs10" };

            await dataStore.GetAsync<TestResource>(request, requestContext, CancellationToken.None);

            // Assert that the request sent to the RequestExecutor included the User-Agent header
            await mockRequestExecutor.Received().GetAsync(
                "https://foo.dev",
                Arg.Is<IEnumerable<KeyValuePair<string, string>>>(
                    headers => headers.Any(kvp => kvp.Key == "Accept" && kvp.Value == "application/pkcs10")),
                CancellationToken.None);
        }

        [Fact]
        public async Task AddContextContentTransferEncodingToRequests()
        {
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            mockRequestExecutor
                .GetAsync(Arg.Any<string>(), Arg.Any<IEnumerable<KeyValuePair<string, string>>>(), Arg.Any<CancellationToken>())
                .Returns(new HttpResponse<string>() { StatusCode = 200 });

            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);
            var request = new HttpRequest { Uri = "https://foo.dev" };
            var requestContext = new RequestContext { ContentTransferEncoding = "base64" };

            await dataStore.GetAsync<TestResource>(request, requestContext, CancellationToken.None);

            // Assert that the request sent to the RequestExecutor included the User-Agent header
            await mockRequestExecutor.Received().GetAsync(
                "https://foo.dev",
                Arg.Is<IEnumerable<KeyValuePair<string, string>>>(
                    headers => headers.Any(kvp => kvp.Key == "Content-Transfer-Encoding" && kvp.Value == "base64")),
                CancellationToken.None);
        }

        [Fact]
        public async Task AddContextAcceptLanguageToRequests()
        {
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            mockRequestExecutor
                .GetAsync(Arg.Any<string>(), Arg.Any<IEnumerable<KeyValuePair<string, string>>>(), Arg.Any<CancellationToken>())
                .Returns(new HttpResponse<string>() { StatusCode = 200 });

            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);
            var request = new HttpRequest { Uri = "https://foo.dev" };
            var requestContext = new RequestContext { AcceptLanguage = "de" };

            await dataStore.GetAsync<TestResource>(request, requestContext, CancellationToken.None);

            // Assert that the request sent to the RequestExecutor included the User-Agent header
            await mockRequestExecutor.Received().GetAsync(
                "https://foo.dev",
                Arg.Is<IEnumerable<KeyValuePair<string, string>>>(
                    headers => headers.Any(kvp => kvp.Key == "Accept-Language" && kvp.Value == "de")),
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
        public async Task SetPayloadHandlerContentTypeOnPostAsync()
        {
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            mockRequestExecutor
                .PostAsync(Arg.Any<HttpRequest>(), Arg.Any<CancellationToken>())
                .Returns(new HttpResponse<string>() { StatusCode = 200 });

            var testPayloadHandler = new TestPayloadHandler();
            PayloadHandler.TryRegister(testPayloadHandler);

            var request = new TestHttpRequest();
            request.ContentType.Should().Be("application/json");
            request.GetPayloadHandler().ContentType.Should().Be("application/json");

            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);
            await dataStore.PostAsync<TestResource>(request, new RequestContext { ContentType = "foo" }, CancellationToken.None);

            request.ContentType.Should().Be("foo");
            request.GetPayloadHandler().ContentType.Should().Be("foo");
        }

        [Fact]
        public async Task CallRequestExecutorPostAsyncOnPostAsync()
        {
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            mockRequestExecutor
                .PostAsync(Arg.Any<HttpRequest>(), Arg.Any<CancellationToken>())
                .Returns(new HttpResponse<string>() { StatusCode = 200 });
            var defaultDataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);
            var testRequest = new HttpRequest();
            var testRequestContext = new RequestContext();

            await defaultDataStore.PostAsync<Resource>(testRequest, testRequestContext, CancellationToken.None);
            await mockRequestExecutor
                .Received(1)
                .PostAsync(Arg.Is(testRequest), Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task PostWithNullBody()
        {
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            mockRequestExecutor
                .PostAsync(Arg.Any<HttpRequest>(),  Arg.Any<CancellationToken>())
                .Returns(new HttpResponse<string>() { StatusCode = 200 });

            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);
            var request = new HttpRequest { Uri = "https://foo.dev" }; // Payload = null

            await dataStore.PostAsync<TestResource>(request, new RequestContext(), CancellationToken.None);

            await mockRequestExecutor.Received().PostAsync(
                request: Arg.Is<HttpRequest>(httpRequest => httpRequest.Uri.Equals("https://foo.dev")),
                cancellationToken: CancellationToken.None);
        }
    }
}
