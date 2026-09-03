// <copyright file="OktaPagedCollectionEnumeratorShould.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Okta.Sdk.UnitTest.Internal;
using Xunit;

namespace Okta.Sdk.UnitTest.Client
{
    /// <summary>
    /// Covers how the enumerator builds the request for the second and later pages.
    /// Most Okta endpoints echo the original filters back into the `next` link, but some
    /// (notably the group members endpoint, see issue #897) omit them, which silently widened
    /// the result set once enumeration moved past the first page.
    /// </summary>
    public class OktaPagedCollectionEnumeratorShould
    {
        private const string Path = "/api/v1/groups/00g123456789abcdef/users";
        private const string UsersJson = @"[{""id"":""00u1"",""status"":""STAGED""}]";

        private static Configuration NewConfiguration() => new Configuration
        {
            OktaDomain = "https://test.okta.com",
            Token = "foo",
        };

        private static Queue<MockResponseInfo> TwoPages(string firstPageNextLink) => new Queue<MockResponseInfo>(new[]
        {
            new MockResponseInfo
            {
                ReturnThis = UsersJson,
                StatusCode = HttpStatusCode.OK,
                ReceivedHeaders = new Multimap<string, string> { { "Link", $"<{firstPageNextLink}>; rel=\"next\"" } },
            },

            // The second page carries no `next` link, so enumeration stops here.
            new MockResponseInfo
            {
                ReturnThis = UsersJson,
                StatusCode = HttpStatusCode.OK,
                ReceivedHeaders = new Multimap<string, string>(),
            },
        });

        private static OktaPagedCollectionEnumerator<User> NewEnumerator(
            MockAsyncClient client,
            Multimap<string, string> queryParameters)
        {
            var requestOptions = new RequestOptions { QueryParameters = queryParameters };

            return new OktaPagedCollectionEnumerator<User>(
                requestOptions, Path, client, NewConfiguration(), NullOAuthTokenProvider.Instance);
        }

        [Fact]
        public async Task CarryForwardSearchWhenTheNextLinkOmitsIt()
        {
            var client = new MockAsyncClient(TwoPages(
                "https://test.okta.com/api/v1/groups/00g123456789abcdef/users?after=00u1&limit=2"));

            var enumerator = NewEnumerator(client, new Multimap<string, string>
            {
                { "search", "status eq \"STAGED\"" },
                { "limit", "2" },
            });

            await enumerator.MoveNextAsync();
            await enumerator.MoveNextAsync();

            client.ReceivedQueryParams.Should().ContainKey("search",
                "because the next link dropped the filter, so it has to be re-applied");
            client.ReceivedQueryParams["search"].Should().Contain("status eq \"STAGED\"");
        }

        [Fact]
        public async Task NotDuplicateSearchWhenTheNextLinkAlreadyCarriesIt()
        {
            var client = new MockAsyncClient(TwoPages(
                "https://test.okta.com/api/v1/users?after=00u1&limit=2&search=status+eq+%22STAGED%22"));

            var enumerator = NewEnumerator(client, new Multimap<string, string>
            {
                { "search", "status eq \"STAGED\"" },
                { "limit", "2" },
            });

            await enumerator.MoveNextAsync();
            await enumerator.MoveNextAsync();

            client.ReceivedQueryParams.Should().NotContainKey("search",
                "because the link is already self-contained and re-adding the filter would send it twice");
        }

        [Fact]
        public async Task NotCarryForwardTheLimitWhenTheNextLinkAlreadyCarriesIt()
        {
            var client = new MockAsyncClient(TwoPages(
                "https://test.okta.com/api/v1/groups/00g123456789abcdef/users?after=00u1&limit=2"));

            var enumerator = NewEnumerator(client, new Multimap<string, string> { { "limit", "2" } });

            await enumerator.MoveNextAsync();
            await enumerator.MoveNextAsync();

            client.ReceivedQueryParams.Should().NotContainKey("limit");
        }

        [Fact]
        public async Task NeverCarryForwardThePaginationCursor()
        {
            // The caller supplied its own starting cursor. The link is authoritative for the
            // cursor, so the original value must not be re-applied even though the link's query
            // string is parsed the same way as any other parameter.
            var client = new MockAsyncClient(TwoPages(
                "https://test.okta.com/api/v1/groups/00g123456789abcdef/users?limit=2"));

            var enumerator = NewEnumerator(client, new Multimap<string, string>
            {
                { "after", "00uCallerSupplied" },
                { "search", "status eq \"STAGED\"" },
            });

            await enumerator.MoveNextAsync();
            await enumerator.MoveNextAsync();

            client.ReceivedQueryParams.Should().NotContainKey("after",
                "because re-sending the caller's cursor would re-request a page already served");
            client.ReceivedQueryParams.Should().ContainKey("search");
        }

        [Fact]
        public async Task RequestNoQueryParametersWhenTheInitialRequestHadNone()
        {
            var client = new MockAsyncClient(TwoPages(
                "https://test.okta.com/api/v1/groups/00g123456789abcdef/users?after=00u1"));

            var enumerator = NewEnumerator(client, new Multimap<string, string>());

            await enumerator.MoveNextAsync();
            await enumerator.MoveNextAsync();

            client.ReceivedQueryParams.Should().BeEmpty();
        }

        [Fact]
        public async Task FollowTheNextLinkAsTheRequestPath()
        {
            const string nextLink = "https://test.okta.com/api/v1/groups/00g123456789abcdef/users?after=00u1&limit=2";
            var client = new MockAsyncClient(TwoPages(nextLink));

            var enumerator = NewEnumerator(client, new Multimap<string, string> { { "limit", "2" } });

            await enumerator.MoveNextAsync();
            client.ReceivedPath.Should().Be(Path);

            await enumerator.MoveNextAsync();
            client.ReceivedPath.Should().Be(nextLink);
        }

        [Fact]
        public async Task StopWhenThereIsNoNextLink()
        {
            var client = new MockAsyncClient(new Queue<MockResponseInfo>(new[]
            {
                new MockResponseInfo
                {
                    ReturnThis = UsersJson,
                    StatusCode = HttpStatusCode.OK,
                    ReceivedHeaders = new Multimap<string, string>(),
                },
            }));

            var enumerator = NewEnumerator(client, new Multimap<string, string> { { "search", "status eq \"STAGED\"" } });

            (await enumerator.MoveNextAsync()).Should().BeTrue();
            (await enumerator.MoveNextAsync()).Should().BeFalse();
        }

        [Fact]
        public async Task NameTheFailingEndpointWhenAPageRequestFails()
        {
            // Issue #795: the error named the enumerator class, which told the caller nothing about
            // which call had failed.
            var enumerator = NewEnumerator(new MockAsyncClient(Forbidden()), new Multimap<string, string>());

            var exception = await Assert.ThrowsAsync<ApiException>(() => enumerator.MoveNextAsync());

            exception.ErrorCode.Should().Be(403);
            exception.Message.Should().StartWith($"Error calling {Path}:");
            exception.Message.Should().NotContain(nameof(OktaPagedCollectionEnumerator<User>));
            exception.Message.Should().Contain("insufficient_scope",
                "because the reason is only carried in the WWW-Authenticate header on an empty body");
        }

        [Fact]
        public async Task NameTheOriginalEndpointWhenALaterPageFails()
        {
            // Errors past the first page must still name the endpoint the caller asked for, not the
            // absolute 'next' link the enumerator happens to be following.
            var responses = new Queue<MockResponseInfo>(new[]
            {
                new MockResponseInfo
                {
                    ReturnThis = UsersJson,
                    StatusCode = HttpStatusCode.OK,
                    ReceivedHeaders = new Multimap<string, string>
                    {
                        { "Link", "<https://test.okta.com/api/v1/groups/00g123456789abcdef/users?after=00u1>; rel=\"next\"" },
                    },
                },
                Forbidden().Dequeue(),
            });

            var enumerator = NewEnumerator(new MockAsyncClient(responses), new Multimap<string, string>());

            await enumerator.MoveNextAsync();
            var exception = await Assert.ThrowsAsync<ApiException>(() => enumerator.MoveNextAsync());

            exception.Message.Should().StartWith($"Error calling {Path}:");
        }

        /// <summary>
        /// A 403 shaped the way Okta returns authorization failures: no body, with the reason
        /// carried only in the WWW-Authenticate header.
        /// </summary>
        private static Queue<MockResponseInfo> Forbidden() => new Queue<MockResponseInfo>(new[]
        {
            new MockResponseInfo
            {
                ReturnThis = string.Empty,
                StatusCode = HttpStatusCode.Forbidden,
                ReceivedHeaders = new Multimap<string, string>
                {
                    { "WWW-Authenticate", "Bearer error=\"insufficient_scope\", error_description=\"The access token must provide access to at least one of these scopes - okta.users.read\"" },
                },
            },
        });
    }
}
