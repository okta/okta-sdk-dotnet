// <copyright file="UrlFormatterShould.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using FluentAssertions;
using Okta.Sdk.Abstractions;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class UrlFormatterShould
    {
        [Fact]
        public void NotMutatePath()
        {
            var request = new HttpRequest { Uri = "/foobar" };

            var updatedPath = UrlFormatter.ApplyParametersToPath(request);

            updatedPath.Should().Be("/foobar");
        }

        [Fact]
        public void ApplyPathParameters()
        {
            var request = new HttpRequest
            {
                Uri = "/foobar/{id}/test",
                PathParams = new Dictionary<string, object>()
                {
                    ["id"] = "abc123",
                },
            };

            var updatedPath = UrlFormatter.ApplyParametersToPath(request);

            updatedPath.Should().Be("/foobar/abc123/test");
        }

        [Fact]
        public void IgnoreExtraPathParameters()
        {
            var request = new HttpRequest
            {
                Uri = "/foobar/{one}",
                PathParams = new Dictionary<string, object>()
                {
                    ["one"] = 1,
                    ["two"] = 2,
                },
            };

            var updatedPath = UrlFormatter.ApplyParametersToPath(request);

            updatedPath.Should().Be("/foobar/1");
        }

        [Fact]
        public void ApplyQueryParameters()
        {
            var request = new HttpRequest
            {
                Uri = "/foobar",
                QueryParams = new Dictionary<string, object>()
                {
                    ["create"] = true,
                    ["id"] = 1234,
                },
            };

            var updatedPath = UrlFormatter.ApplyParametersToPath(request);

            updatedPath.Should().Be("/foobar?create=true&id=1234");
        }

        [Fact]
        public void AddToExistingQueryParameters()
        {
            var request = new HttpRequest
            {
                Uri = "/foobar?existing=stuff",
                QueryParams = new Dictionary<string, object>()
                {
                    ["strings"] = "things",
                },
            };

            var updatedPath = UrlFormatter.ApplyParametersToPath(request);

            updatedPath.Should().Be("/foobar?existing=stuff&strings=things");
        }

        [Fact]
        public void UrlEncodeQueryParameters()
        {
            var request = new HttpRequest
            {
                Uri = "/foobar",
                QueryParams = new Dictionary<string, object>()
                {
                    ["q"] = "Encoding works?",
                },
            };

            var updatedPath = UrlFormatter.ApplyParametersToPath(request);

            updatedPath.Should().Be("/foobar?q=Encoding+works%3F");
        }

        [Fact]
        public void ApplyBothQueryAndPathParameters()
        {
            var request = new HttpRequest
            {
                Uri = "/foobar/{id}?limit=1",
                PathParams = new Dictionary<string, object>()
                {
                    ["id"] = "xyz789",
                },
                QueryParams = new Dictionary<string, object>()
                {
                    ["create"] = true,
                },
            };

            var updatedPath = UrlFormatter.ApplyParametersToPath(request);

            updatedPath.Should().Be("/foobar/xyz789?limit=1&create=true");
        }
    }
}
