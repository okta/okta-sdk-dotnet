// <copyright file="OktaPagedCollectionEnumeratorAuthorizationShould.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Okta.Sdk.UnitTest.Internal;
using Polly;
using RestSharp;
using Xunit;

namespace Okta.Sdk.UnitTest.Client
{
    /// <summary>
    /// Covers which authorization header the enumerator sends on the second and later pages.
    /// The calling list method stamps the header into the initial request once and the header
    /// collection is carried forward, so before issue #817 an enumeration that outlived its
    /// access token kept sending the token the first page was issued with.
    /// </summary>
    public class OktaPagedCollectionEnumeratorAuthorizationShould
    {
        private const string Path = "/api/v1/users";
        private const string UsersJson = @"[{""id"":""00u1"",""status"":""ACTIVE""}]";

        [Fact]
        public async Task RereadTheAccessTokenOnEveryPageInBearerTokenMode()
        {
            // The scenario from issue #817: a caller refreshes the access token from a background
            // timer because the enumeration runs for longer than the token's one hour lifetime.
            var configuration = BearerTokenConfiguration("first-token");
            var client = new MockAsyncClient(ThreePages());
            var enumerator = NewEnumerator(client, configuration, NullOAuthTokenProvider.Instance);

            await enumerator.MoveNextAsync();

            configuration.AccessToken = "second-token";
            await enumerator.MoveNextAsync();

            configuration.AccessToken = "third-token";
            await enumerator.MoveNextAsync();

            AuthorizationHeaderPerPage(client).Should().Equal(
                new[] { "Bearer first-token", "Bearer second-token", "Bearer third-token" },
                "because each page has to be sent with the token that is configured when it is requested");
        }

        [Fact]
        public async Task SendExactlyOneAuthorizationHeaderAfterRefreshingTheAccessToken()
        {
            // The header collection appends on Add, so a refresh has to replace the stale value
            // rather than sit alongside it.
            var configuration = BearerTokenConfiguration("first-token");
            var client = new MockAsyncClient(ThreePages());
            var enumerator = NewEnumerator(client, configuration, NullOAuthTokenProvider.Instance);

            await enumerator.MoveNextAsync();
            configuration.AccessToken = "second-token";
            await enumerator.MoveNextAsync();

            var secondPageHeaders = client.ReceivedHeadersQueue.ToArray()[1];

            secondPageHeaders["Authorization"].Should().HaveCount(1,
                "because two authorization headers would be sent as a single comma joined value and rejected");
            secondPageHeaders["Authorization"].Single().Should().Be("Bearer second-token");
        }

        [Fact]
        public async Task KeepSendingTheSameAccessTokenWhenTheCallerNeverRefreshesIt()
        {
            var configuration = BearerTokenConfiguration("only-token");
            var client = new MockAsyncClient(ThreePages());
            var enumerator = NewEnumerator(client, configuration, NullOAuthTokenProvider.Instance);

            await enumerator.MoveNextAsync();
            await enumerator.MoveNextAsync();
            await enumerator.MoveNextAsync();

            AuthorizationHeaderPerPage(client).Should().Equal(
                new[] { "Bearer only-token", "Bearer only-token", "Bearer only-token" },
                "because re-reading an unchanged configuration must not alter what is sent");
        }

        [Fact]
        public async Task LeaveTheSswsHeaderUntouchedWhenPaging()
        {
            // An SSWS API token does not expire, so this header must be carried forward exactly as
            // the calling method set it. This is the regression guard for the change made for #817.
            var configuration = new Configuration
            {
                OktaDomain = "https://test.okta.com",
                Token = "an-api-token",
                AuthorizationMode = AuthorizationMode.SSWS,
            };

            var client = new MockAsyncClient(ThreePages());
            var initialRequest = new RequestOptions { QueryParameters = new Multimap<string, string>() };
            initialRequest.HeaderParameters.Add("Authorization", "SSWS an-api-token");

            var enumerator = new OktaPagedCollectionEnumerator<User>(
                initialRequest, Path, client, configuration, NullOAuthTokenProvider.Instance);

            await enumerator.MoveNextAsync();
            await enumerator.MoveNextAsync();
            await enumerator.MoveNextAsync();

            AuthorizationHeaderPerPage(client).Should().Equal(
                new[] { "SSWS an-api-token", "SSWS an-api-token", "SSWS an-api-token" },
                "because SSWS paging behaviour must be unchanged");
        }

        [Fact]
        public async Task NotSendAnAuthorizationHeaderInBearerTokenModeWithoutAnAccessToken()
        {
            // The calling list method omits the header when no token is configured, so the
            // enumerator must not invent an empty 'Bearer ' value on the later pages.
            var configuration = new Configuration
            {
                OktaDomain = "https://test.okta.com",
                AuthorizationMode = AuthorizationMode.BearerToken,
            };

            var client = new MockAsyncClient(ThreePages());
            var initialRequest = new RequestOptions { QueryParameters = new Multimap<string, string>() };

            var enumerator = new OktaPagedCollectionEnumerator<User>(
                initialRequest, Path, client, configuration, NullOAuthTokenProvider.Instance);

            await enumerator.MoveNextAsync();
            await enumerator.MoveNextAsync();

            client.ReceivedHeadersQueue.Should().OnlyContain(headers => !headers.ContainsKey("Authorization"));
        }

        [Fact]
        public async Task PickUpAnAccessTokenThatArrivesAfterEnumerationStarted()
        {
            // A caller may build the request before its first token has been fetched. Once the
            // token is configured the enumeration has to start sending it.
            var configuration = new Configuration
            {
                OktaDomain = "https://test.okta.com",
                AuthorizationMode = AuthorizationMode.BearerToken,
            };

            var client = new MockAsyncClient(ThreePages());
            var initialRequest = new RequestOptions { QueryParameters = new Multimap<string, string>() };

            var enumerator = new OktaPagedCollectionEnumerator<User>(
                initialRequest, Path, client, configuration, NullOAuthTokenProvider.Instance);

            await enumerator.MoveNextAsync();

            configuration.AccessToken = "late-token";
            await enumerator.MoveNextAsync();

            var pages = client.ReceivedHeadersQueue.ToArray();
            pages[0].ContainsKey("Authorization").Should().BeFalse();
            pages[1]["Authorization"].Single().Should().Be("Bearer late-token");
        }

        [Fact]
        public async Task RereadTheAccessTokenWhenEnumeratingWithAwaitForeach()
        {
            // The same guarantee has to hold through the collection client, which is what a caller
            // gets back from a generated list method and what 'await foreach' and LINQ go through.
            var configuration = BearerTokenConfiguration("first-token");
            var client = new MockAsyncClient(ThreePages());
            var initialRequest = new RequestOptions { QueryParameters = new Multimap<string, string>() };
            initialRequest.HeaderParameters.Add("Authorization", "Bearer " + configuration.AccessToken);

            var collectionClient = new OktaCollectionClient<User>(
                initialRequest, Path, client, configuration, NullOAuthTokenProvider.Instance);

            var usersSeen = 0;
            await foreach (var user in collectionClient)
            {
                usersSeen++;
                configuration.AccessToken = $"token-{usersSeen + 1}";
            }

            usersSeen.Should().Be(3, "because each of the three pages carries one user");
            AuthorizationHeaderPerPage(client).Should().Equal(
                new[] { "Bearer first-token", "Bearer token-2", "Bearer token-3" });
        }

        [Fact]
        public async Task LetTheTokenProviderOwnTheHeaderInPrivateKeyMode()
        {
            // Private key mode already refreshed per page through the token provider. The bearer
            // token branch must not interfere with it.
            var configuration = new Configuration
            {
                OktaDomain = "https://test.okta.com",
                AuthorizationMode = AuthorizationMode.PrivateKey,
                AccessToken = "a-stale-configured-token",
            };

            var client = new MockAsyncClient(ThreePages());
            var enumerator = NewEnumerator(client, configuration, new StubOAuthTokenProvider());

            await enumerator.MoveNextAsync();
            await enumerator.MoveNextAsync();
            await enumerator.MoveNextAsync();

            AuthorizationHeaderPerPage(client).Should().Equal(
                new[] { "Bearer provider-token-1", "Bearer provider-token-2", "Bearer provider-token-3" },
                "because the token provider remains the authority in private key mode");
        }

        private static Configuration BearerTokenConfiguration(string accessToken) => new Configuration
        {
            OktaDomain = "https://test.okta.com",
            AuthorizationMode = AuthorizationMode.BearerToken,
            AccessToken = accessToken,
        };

        /// <summary>
        /// Builds an enumerator whose initial request already carries the authorization header that
        /// the generated list method would have stamped into it.
        /// </summary>
        private static OktaPagedCollectionEnumerator<User> NewEnumerator(
            MockAsyncClient client,
            IReadableConfiguration configuration,
            IOAuthTokenProvider oAuthTokenProvider)
        {
            var initialRequest = new RequestOptions { QueryParameters = new Multimap<string, string>() };

            if (!string.IsNullOrEmpty(configuration.AccessToken))
            {
                initialRequest.HeaderParameters.Add("Authorization", "Bearer " + configuration.AccessToken);
            }

            return new OktaPagedCollectionEnumerator<User>(
                initialRequest, Path, client, configuration, oAuthTokenProvider);
        }

        private static IEnumerable<string> AuthorizationHeaderPerPage(MockAsyncClient client) =>
            client.ReceivedHeadersQueue
                .Select(headers => headers.ContainsKey("Authorization") ? string.Join(",", headers["Authorization"]) : null)
                .ToArray();

        /// <summary>
        /// Three pages, so that re-reading is proven on every page rather than only on the second.
        /// </summary>
        private static Queue<MockResponseInfo> ThreePages() => new Queue<MockResponseInfo>(new[]
        {
            PageWithNextLink($"https://test.okta.com{Path}?after=00u1"),
            PageWithNextLink($"https://test.okta.com{Path}?after=00u2"),
            new MockResponseInfo
            {
                ReturnThis = UsersJson,
                StatusCode = HttpStatusCode.OK,
                ReceivedHeaders = new Multimap<string, string>(),
            },
        });

        private static MockResponseInfo PageWithNextLink(string nextLink) => new MockResponseInfo
        {
            ReturnThis = UsersJson,
            StatusCode = HttpStatusCode.OK,
            ReceivedHeaders = new Multimap<string, string> { { "Link", $"<{nextLink}>; rel=\"next\"" } },
        };

        /// <summary>
        /// Stands in for <c>DefaultOAuthTokenProvider</c>, handing out a different token on each
        /// call so that a stale header is visible in the assertion.
        /// </summary>
        private class StubOAuthTokenProvider : IOAuthTokenProvider
        {
            private int _calls;

            public Task<OAuthTokenResponse> GetAccessTokenResponseAsync(bool forceRenew = false, CancellationToken cancellationToken = default)
                => Task.FromResult(new OAuthTokenResponse());

            public AsyncPolicy<RestResponse> GetOAuthRetryPolicy(Func<DelegateResult<RestResponse>, int, Context, Task> onRetryAsyncFunc = null)
                => Polly.Policy.NoOpAsync<RestResponse>();

            public Task AddOrUpdateAuthorizationHeader(RequestOptions requestOptions, string requestUri, string httpMethod, CancellationToken cancellationToken = default)
            {
                foreach (var staleAuthorizationHeader in requestOptions.HeaderParameters.Where(p => p.Key.Equals("Authorization", StringComparison.OrdinalIgnoreCase)).ToArray())
                {
                    requestOptions.HeaderParameters.Remove(staleAuthorizationHeader.Key);
                }

                requestOptions.HeaderParameters.Add("Authorization", $"Bearer provider-token-{++_calls}");
                return Task.CompletedTask;
            }

            public string GetDpopProofJwt(string nonce = null, string httpMethod = null, string uri = null, string accessToken = null)
                => string.Empty;
        }
    }
}
