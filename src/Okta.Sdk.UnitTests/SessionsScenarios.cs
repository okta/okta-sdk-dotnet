// <copyright file="SessionsScenarios.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
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
    /// <summary>
    /// For integration tests purposes, Sessions require a complex setup which involves AuthN api, for this reason they are not provided.
    /// In these tests, we make sure that the SDK produce the expected HTTP call (URL, body) when using a Sessions API method
    /// and, the SDK correctly deserialize the expected response from the Sessions API.
    /// </summary>
    public class SessionsScenarios
    {
        [Fact]
        public async Task DelegateAValidPostToRequestExecutorGivenACreateSessionRequest()
        {
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            mockRequestExecutor
                .PostAsync(Arg.Any<string>(), Arg.Any<IEnumerable<KeyValuePair<string, string>>>(), Arg.Any<string>(), Arg.Any<CancellationToken>())
                .Returns(new HttpResponse<string>() { StatusCode = 200 });

            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);

            var createSessionRequest = new CreateSessionRequest()
            {
                SessionToken = "foo",
            };

            var client = new TestableOktaClient(mockRequestExecutor);
            await client.Sessions.CreateSessionAsync(createSessionRequest);

            await mockRequestExecutor.Received().PostAsync(
                "/api/v1/sessions",
                Arg.Any<IEnumerable<KeyValuePair<string, string>>>(),
                "{\"sessionToken\":\"foo\"}",
                CancellationToken.None);
        }

        [Fact]
        public async Task DelegateAValidGetToRequestExecutor()
        {
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            mockRequestExecutor
                .GetAsync(Arg.Any<string>(), Arg.Any<IEnumerable<KeyValuePair<string, string>>>(), Arg.Any<CancellationToken>())
                .Returns(new HttpResponse<string>() { StatusCode = 200 });

            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);

            var client = new TestableOktaClient(mockRequestExecutor);
            await client.Sessions.GetSessionAsync("foo");

            await mockRequestExecutor.Received().GetAsync(
                "/api/v1/sessions/foo",
                Arg.Any<IEnumerable<KeyValuePair<string, string>>>(),
                CancellationToken.None);
        }

        [Fact]
        public async Task DelegateAValidPostToRequestExecutorWhenRefreshingSession()
        {
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            mockRequestExecutor
            .PostAsync(Arg.Any<string>(), Arg.Any<IEnumerable<KeyValuePair<string, string>>>(), Arg.Any<string>(), Arg.Any<CancellationToken>())
            .Returns(new HttpResponse<string>() { StatusCode = 200 });

            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);

            var client = new TestableOktaClient(mockRequestExecutor);
            await client.Sessions.RefreshSessionAsync("foo");

            await mockRequestExecutor.Received().PostAsync(
                "/api/v1/sessions/foo/lifecycle/refresh",
                Arg.Any<IEnumerable<KeyValuePair<string, string>>>(),
                null,
                CancellationToken.None);
        }

        [Fact]
        public async Task DelegateAValidDeleteToRequestExecutorWhenEndingSession()
        {
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            mockRequestExecutor
               .DeleteAsync(Arg.Any<string>(), Arg.Any<IEnumerable<KeyValuePair<string, string>>>(), Arg.Any<CancellationToken>())
               .Returns(new HttpResponse<string>() { StatusCode = 200 });

            var dataStore = new DefaultDataStore(mockRequestExecutor, new DefaultSerializer(), new ResourceFactory(null, null), NullLogger.Instance);

            var client = new TestableOktaClient(mockRequestExecutor);
            await client.Sessions.EndSessionAsync("foo");

            await mockRequestExecutor.Received().DeleteAsync(
                "/api/v1/sessions/foo",
                Arg.Any<IEnumerable<KeyValuePair<string, string>>>(),
                CancellationToken.None);
        }
    }
}
