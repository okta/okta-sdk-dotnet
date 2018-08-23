// <copyright file="ApplicationsClientShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Linq;
using FluentAssertions;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class ApplicationsClientShould
    {
        [Fact]
        public void NotReturnNullWhenFeaturesHasNoData()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(GetBookmarkApplicationStubResponse(features: "[]"));
            var client = new TestableOktaClient(mockRequestExecutor);

            var app = client.Applications.GetApplicationAsync<IBookmarkApplication>("foo").Result;

            app.Features.Any().Should().BeFalse();
        }

        [Fact]
        public void ReturnEmptyListWhenFeaturesIsNullInTheResponse()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(GetBookmarkApplicationStubResponse());
            var client = new TestableOktaClient(mockRequestExecutor);

            var app = client.Applications.GetApplicationAsync<IBookmarkApplication>("foo").Result;

            app.Features.Any().Should().BeFalse();
        }

        [Fact]
        public void AddCustomFeaturesToAnEmptyFeaturesList()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(GetBookmarkApplicationStubResponse(features: "[]"));
            var client = new TestableOktaClient(mockRequestExecutor);

            var app = client.Applications.GetApplicationAsync<IBookmarkApplication>("foo").Result;
            app.Features.Any().Should().BeFalse();

            app.Features.Add("custom_feature");
            app.Features.Any().Should().BeTrue();
        }

        [Fact]
        public void AddCustomFeaturesToANonEmptyFeaturesList()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(GetBookmarkApplicationStubResponse(features: "[\"custom_feature1\"]"));
            var client = new TestableOktaClient(mockRequestExecutor);

            var app = client.Applications.GetApplicationAsync<IBookmarkApplication>("foo").Result;
            app.Features.Any().Should().BeTrue();

            app.Features.Add("custom_feature2");
            app.Features.Should().HaveCount(2);
        }

        private string GetBookmarkApplicationStubResponse(string features = "null")
        {
            #region Bookmark Application Stub

            var rawResponse = @"{
                ""id"": ""0oafxqCAJWWGELFTYASJ"",
                ""name"": ""bookmark"",
                ""label"": ""Sample Bookmark App"",
                ""status"": ""ACTIVE"",
                ""lastUpdated"": ""2013-10-01T04:22:31.000Z"",
                ""created"": ""2013-10-01T04:22:27.000Z"",
                ""accessibility"": {
                    ""selfService"": false,
                    ""errorRedirectUrl"": null
                },
                ""visibility"": {
                    ""autoSubmitToolbar"": false,
                    ""hide"": {
                        ""iOS"": false,
                        ""web"": false
                    },
                    ""appLinks"": {
                        ""login"": true
                    }
                },
                ""features"":" + features + @",
                ""signOnMode"": ""BOOKMARK"",
                ""credentials"": {
                    ""userNameTemplate"": {
                        ""template"": ""${source.login}"",
                        ""type"": ""BUILT_IN""
                    }
                },
                ""settings"": {
                    ""app"": {
                        ""requestIntegration"": false,
                        ""url"": ""https://example.com/bookmark.htm""
                    }
                },
            }";
            #endregion

            return rawResponse;
        }
    }
}
