// <copyright file="OktaClientShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class OktaClientShould
    {
        [Fact]
        public async Task GetCollection()
        {
            // Arrange
            var testItems = new[]
            {
                new TestResource { Foo = "foo1" },
                new TestResource { Foo = "foo2", Bar = true },
                new TestResource { Foo = "foo3", Bar = false },
            };
            var mockRequestExecutor = new MockedCollectionRequestExecutor<TestResource>(pageSize: 2, items: testItems);
            var client = new TestableOktaClient(mockRequestExecutor);

            // Act
            var items = await client.GetCollection<TestResource>("https://stuff").ToArray();

            // Assert
            items.Count().Should().Be(3);
            items.ElementAt(0).Foo.Should().Be("foo1");
            items.ElementAt(0).Bar.Should().BeNull();

            items.ElementAt(1).Foo.Should().Be("foo2");
            items.ElementAt(1).Bar.Should().Be(true);

            items.ElementAt(2).Foo.Should().Be("foo3");
            items.ElementAt(2).Bar.Should().Be(false);
        }

        [Fact]
        public async Task ThrowApiExceptionFor4xx()
        {
            var rawErrorResponse = @"
{
    ""errorCode"": ""E0000011"",
    ""errorSummary"": ""Invalid token provided"",
    ""errorLink"": ""E0000011"",
    ""errorId"": ""oaelUIU6UZ_RxuqVbi3pxR1ag"",
    ""errorCauses"": []
}";
            var mockRequestExecutor = new MockedStringRequestExecutor(rawErrorResponse, 400);
            var client = new TestableOktaClient(mockRequestExecutor);

            try
            {
                await client.Users.GetUserAsync("12345");
            }
            catch (OktaApiException apiException)
            {
                apiException.Message.Should().Be("Invalid token provided (400, E0000011)");
                apiException.ErrorCode.Should().Be("E0000011");
                apiException.ErrorSummary.Should().Be("Invalid token provided");
                apiException.ErrorLink.Should().Be("E0000011");
                apiException.ErrorId.Should().Be("oaelUIU6UZ_RxuqVbi3pxR1ag");
                apiException.Error.Should().NotBeNull();
            }
        }

        [Fact]
        public async Task IncludeErrorCausesInApiException()
        {
            var rawErrorResponse = @"
{
    ""errorCode"": ""E0000001"",
    ""errorSummary"": ""Api validation failed"",
    ""errorLink"": ""E0000001"",
    ""errorId"": ""oae3xUDal8cTr-_k3gWnVmXhQ"",
    ""errorCauses"": [
        {
            ""errorSummary"": ""Password requirements were not met.""
        },
        {
            ""errorSummary"": ""Another bad thing that happened""
        }
    ]
}";
            var mockRequestExecutor = new MockedStringRequestExecutor(rawErrorResponse, 500);
            var client = new TestableOktaClient(mockRequestExecutor);

            try
            {
                await client.GetAsync<Resource>("/something");
            }
            catch (OktaApiException apiException)
            {
                var expectedMessage = "Api validation failed (500, E0000001): Password requirements were not met., Another bad thing that happened";
                apiException.Message.Should().Be(expectedMessage);
                apiException.ToString().Should().StartWith($"Okta.Sdk.OktaApiException: {expectedMessage}");

                var causes = apiException.ErrorCauses.ToArray();
                causes.Should().HaveCount(2);
                causes.First().ErrorSummary.Should().Be("Password requirements were not met.");
                causes.Last().ErrorSummary.Should().Be("Another bad thing that happened");

            }
        }

        [Fact]
        public void UsePassedHttpClient()
        {
            var testableClient = new TestableHttpClient();
            var client = new OktaClient(
                TestableOktaClient.DefaultFakeConfiguration,
                testableClient);

            Func<Task> act = async () => await client.Users.GetUserAsync("foobar");

            act.Should().Throw<NotImplementedException>()
                .WithMessage("Used the client!");
        }

        public class TestableHttpClient : System.Net.Http.HttpClient
        {
            public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException("Used the client!");
            }
        }
    }
}
