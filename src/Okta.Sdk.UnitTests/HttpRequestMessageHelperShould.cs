// <copyright file="HttpRequestMessageHelperShould.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class HttpRequestMessageHelperShould
    {
        [Fact]
        public async Task SkipAuthorizationHeader()
        {
            var request = new HttpRequestMessage();
            request.Headers.TryAddWithoutValidation ("User-Agent", "Test Agent");
            request.Headers.TryAddWithoutValidation ("Authorization", "Bearer OldBearerToken");

            // default parameters
            var clonedRequest = await HttpRequestMessageHelper.CloneHttpRequestMessageAsync(request);
            clonedRequest.Headers.Should().Contain(h => h.Key.Equals("Authorization"));
            clonedRequest.Headers.Should().Contain(h => h.Key.Equals("User-Agent"));
            clonedRequest.Headers.Authorization.Scheme.Should().Be("Bearer");
            clonedRequest.Headers.Authorization.Parameter.Should().Be("OldBearerToken");

            // skip authorization
            clonedRequest = await HttpRequestMessageHelper.CloneHttpRequestMessageAsync(request, skipAuthorizationHeader: true);
            clonedRequest.Headers.Should().Contain(h => h.Key.Equals("User-Agent"));
            clonedRequest.Headers.Should().NotContain(h => h.Key.Equals("Authorization"));
        }
    }
}
