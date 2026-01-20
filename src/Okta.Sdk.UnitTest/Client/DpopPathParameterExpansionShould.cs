// <copyright file="DpopPathParameterExpansionShould.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using RestSharp;
using Xunit;

namespace Okta.Sdk.UnitTest.Client
{
    /// <summary>
    /// Tests for path parameter expansion in DPoP htu claim.
    /// When using private key authentication with DPoP, the htu claim must use
    /// the expanded path (e.g., /api/v1/groups/00g123/users) instead of the 
    /// template path (e.g., /api/v1/groups/{groupId}/users).
    /// </summary>
    public class DpopPathParameterExpansionShould
    {
        [Theory]
        [InlineData("/api/v1/groups/{groupId}/users", "groupId", "00g123abc", "/api/v1/groups/00g123abc/users")]
        [InlineData("/api/v1/users/{userId}", "userId", "00u456def", "/api/v1/users/00u456def")]
        [InlineData("/api/v1/apps/{appId}/users/{userId}", "appId", "0oa789ghi", "/api/v1/apps/0oa789ghi/users/{userId}")]
        public void ExpandSinglePathParameter(string templatePath, string paramName, string paramValue, string expectedPath)
        {
            // Arrange
            var pathParameters = new Dictionary<string, string> { { paramName, paramValue } };

            // Act - This is the exact expansion logic used in OktaPagedCollectionEnumerator
            var expandedPath = pathParameters.Aggregate(templatePath, 
                (current, param) => current.Replace("{" + param.Key + "}", param.Value));

            // Assert
            expandedPath.Should().Be(expectedPath);
        }

        [Fact]
        public void ExpandMultiplePathParameters()
        {
            // Arrange
            var templatePath = "/api/v1/apps/{appId}/users/{userId}";
            var pathParameters = new Dictionary<string, string>
            {
                { "appId", "0oa789ghi" },
                { "userId", "00u456def" }
            };

            // Act
            var expandedPath = pathParameters.Aggregate(templatePath, 
                (current, param) => current.Replace("{" + param.Key + "}", param.Value));

            // Assert
            expandedPath.Should().Be("/api/v1/apps/0oa789ghi/users/00u456def");
            expandedPath.Should().NotContain("{");
            expandedPath.Should().NotContain("}");
        }

        [Fact]
        public void ExpandPathParametersFromRestSharpRequest()
        {
            // Arrange - Simulates how RestSharp stores path parameters as UrlSegment
            var templatePath = "/api/v1/groups/{groupId}/users";
            var request = new RestRequest(templatePath);
            request.AddUrlSegment("groupId", "00g123abc");

            // Act - This is the exact expansion logic used in ApiClient and DefaultOAuthTokenProvider
            var expandedPath = request.Parameters
                .Where(p => p.Type == ParameterType.UrlSegment)
                .Aggregate(request.Resource, 
                    (current, param) => current.Replace("{" + param.Name + "}", param.Value?.ToString() ?? string.Empty));

            // Assert
            expandedPath.Should().Be("/api/v1/groups/00g123abc/users");
        }

        [Fact]
        public void CreateCorrectAbsoluteUriForDpopHtu()
        {
            // Arrange
            var oktaDomain = "https://example.okta.com";
            var templatePath = "/api/v1/groups/{groupId}/users";
            var request = new RestRequest(templatePath);
            request.AddUrlSegment("groupId", "00g123abc");

            // Act - Simulates the full URI construction used for DPoP htu
            var expandedResource = request.Parameters
                .Where(p => p.Type == ParameterType.UrlSegment)
                .Aggregate(request.Resource, 
                    (current, param) => current.Replace("{" + param.Name + "}", param.Value?.ToString() ?? string.Empty));
            var absoluteUri = new System.Uri(new System.Uri(oktaDomain, System.UriKind.Absolute), 
                new System.Uri(expandedResource, System.UriKind.RelativeOrAbsolute)).AbsoluteUri;

            // Assert
            absoluteUri.Should().Be("https://example.okta.com/api/v1/groups/00g123abc/users");
            absoluteUri.Should().NotContain("{groupId}");
        }

        [Fact]
        public void HandleEmptyPathParameters()
        {
            // Arrange
            var templatePath = "/api/v1/users";
            var pathParameters = new Dictionary<string, string>();

            // Act
            var expandedPath = pathParameters.Aggregate(templatePath, 
                (current, param) => current.Replace("{" + param.Key + "}", param.Value));

            // Assert
            expandedPath.Should().Be("/api/v1/users");
        }

        [Fact]
        public void HandlePathWithNoPlaceholders()
        {
            // Arrange
            var path = "/api/v1/users";
            var pathParameters = new Dictionary<string, string> { { "unusedParam", "value" } };

            // Act
            var expandedPath = pathParameters.Aggregate(path, 
                (current, param) => current.Replace("{" + param.Key + "}", param.Value));

            // Assert
            expandedPath.Should().Be("/api/v1/users");
        }
    }
}
