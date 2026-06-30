// <copyright file="RoleCollectionExtensionsTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.UnitTest.Internal;
using Xunit;

namespace Okta.Sdk.UnitTest.Api
{
    // Regression tests for https://github.com/okta/okta-sdk-dotnet/issues/862.
    // The Role* List operations return wrapped collection DTOs ({ items, _links.next }) instead of
    // IOktaCollectionClient<T>, so callers had to follow _links.next by hand. The ListAll*Async
    // extension methods auto-page by following that cursor and yielding every item.
    public class RoleCollectionExtensionsTests
    {
        private const string BaseUrl = "https://test.okta.com";

        [Fact]
        public async Task ListAllResourceSetsAsync_FollowsLinksNextCursorAcrossPages()
        {
            // page 1 advertises a next page via _links.next (with an `after` cursor); page 2 has none.
            var page1 = @"{""resource-sets"":[{""id"":""rs1""},{""id"":""rs2""}],""_links"":{""next"":{""href"":""https://test.okta.com/api/v1/iam/resource-sets?after=CURSOR2""}}}";
            var page2 = @"{""resource-sets"":[{""id"":""rs3""}],""_links"":{""self"":{""href"":""https://test.okta.com/api/v1/iam/resource-sets""}}}";

            var responses = new Queue<MockResponseInfo>();
            responses.Enqueue(new MockResponseInfo { ReturnThis = page1, StatusCode = HttpStatusCode.OK });
            responses.Enqueue(new MockResponseInfo { ReturnThis = page2, StatusCode = HttpStatusCode.OK });
            var mockClient = new MockAsyncClient(responses);
            var api = new RoleCResourceSetApi(mockClient, new Configuration { BasePath = BaseUrl });

            var ids = new List<string>();
            await foreach (var rs in api.ListAllResourceSetsAsync())
            {
                ids.Add(rs.Id);
            }

            // All items from both pages, in order — no manual cursor handling by the caller.
            ids.Should().Equal("rs1", "rs2", "rs3");
        }

        [Fact]
        public async Task ListAllResourceSetsAsync_StopsAfterSinglePageWhenNoNextLink()
        {
            // Only one response is queued; if the helper attempted a second page it would throw
            // (empty queue), so reaching the end proves it stopped at the single page.
            var page = @"{""resource-sets"":[{""id"":""only""}],""_links"":{""self"":{""href"":""https://test.okta.com/api/v1/iam/resource-sets""}}}";
            var responses = new Queue<MockResponseInfo>();
            responses.Enqueue(new MockResponseInfo { ReturnThis = page, StatusCode = HttpStatusCode.OK });
            var mockClient = new MockAsyncClient(responses);
            var api = new RoleCResourceSetApi(mockClient, new Configuration { BasePath = BaseUrl });

            var ids = new List<string>();
            await foreach (var rs in api.ListAllResourceSetsAsync())
            {
                ids.Add(rs.Id);
            }

            ids.Should().Equal("only");
        }
    }
}
