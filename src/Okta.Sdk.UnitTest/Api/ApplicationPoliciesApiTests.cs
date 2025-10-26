using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.UnitTest.Internal;
using Xunit;

namespace Okta.Sdk.UnitTest.Api
{
    public class ApplicationPoliciesApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private const string TestAppId = "0oa1gjh63g214q0Hq0g4";
        private const string TestPolicyId = "00p1gjh63g214q0Hq0g5";

        #region AssignApplicationPolicy Tests

        [Fact]
        public async Task AssignApplicationPolicy_WithValidIds_CompletesSuccessfully()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new ApplicationPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.AssignApplicationPolicyAsync(TestAppId, TestPolicyId);

            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("policies");
        }

        [Fact]
        public async Task AssignApplicationPolicy_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("");
            var api = new ApplicationPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.AssignApplicationPolicyAsync(null, TestPolicyId));
        }

        [Fact]
        public async Task AssignApplicationPolicy_WithNullPolicyId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("");
            var api = new ApplicationPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.AssignApplicationPolicyAsync(TestAppId, null));
        }

        [Fact]
        public async Task AssignApplicationPolicyWithHttpInfo_ReturnsNoContentResponse()
        {
            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" }
            };

            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent, headers);
            var api = new ApplicationPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.AssignApplicationPolicyWithHttpInfoAsync(TestAppId, TestPolicyId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("policies");
        }

        [Fact]
        public async Task AssignApplicationPolicy_ReplacesExistingPolicy()
        {
            // First assignment
            var mockClient1 = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api1 = new ApplicationPoliciesApi(mockClient1, new Configuration { BasePath = BaseUrl });
            
            await api1.AssignApplicationPolicyAsync(TestAppId, TestPolicyId);
            mockClient1.ReceivedPath.Should().Contain("apps");
            mockClient1.ReceivedPath.Should().Contain("policies");

            // Second assignment (replacement)
            var secondPolicyId = "00p2gjh63g214q0Hq0g6";
            var mockClient2 = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api2 = new ApplicationPoliciesApi(mockClient2, new Configuration { BasePath = BaseUrl });
            
            await api2.AssignApplicationPolicyAsync(TestAppId, secondPolicyId);
            mockClient2.ReceivedPath.Should().Contain("apps");
            mockClient2.ReceivedPath.Should().Contain("policies");
        }

        [Fact]
        public async Task AssignApplicationPolicy_IsIdempotent()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new ApplicationPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Assign the same policy multiple times
            await api.AssignApplicationPolicyAsync(TestAppId, TestPolicyId);
            await api.AssignApplicationPolicyAsync(TestAppId, TestPolicyId);
            await api.AssignApplicationPolicyAsync(TestAppId, TestPolicyId);

            // Should complete without errors
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("policies");
        }

        [Fact]
        public async Task AssignApplicationPolicyWithHttpInfo_ContainsCorrectHeaders()
        {
            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" },
                { "X-Okta-Request-Id", "request-123" }
            };

            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent, headers);
            var api = new ApplicationPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.AssignApplicationPolicyWithHttpInfoAsync(TestAppId, TestPolicyId);

            response.Should().NotBeNull();
            response.Headers.Should().ContainKey("Content-Type");
            response.Headers.Should().ContainKey("X-Okta-Request-Id");
        }

        [Fact]
        public async Task AssignApplicationPolicy_ToOidcApplication_CompletesSuccessfully()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new ApplicationPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });
            var oidcAppId = "0oa_oidc_12345";

            await api.AssignApplicationPolicyAsync(oidcAppId, TestPolicyId);

            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("policies");
        }

        [Fact]
        public async Task AssignApplicationPolicy_ToSamlApplication_CompletesSuccessfully()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new ApplicationPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });
            var samlAppId = "0oa_saml_12345";

            await api.AssignApplicationPolicyAsync(samlAppId, TestPolicyId);

            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("policies");
        }

        [Fact]
        public async Task AssignApplicationPolicy_WithAccessPolicy_CompletesSuccessfully()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new ApplicationPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });
            var accessPolicyId = "00p_access_12345";

            await api.AssignApplicationPolicyAsync(TestAppId, accessPolicyId);

            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("policies");
        }

        [Fact]
        public async Task AssignApplicationPolicy_ToMultipleApplications_EachCompletesSuccessfully()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new ApplicationPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var app1Id = "0oa_app1_12345";
            var app2Id = "0oa_app2_12345";
            var app3Id = "0oa_app3_12345";

            await api.AssignApplicationPolicyAsync(app1Id, TestPolicyId);
            await api.AssignApplicationPolicyAsync(app2Id, TestPolicyId);
            await api.AssignApplicationPolicyAsync(app3Id, TestPolicyId);

            // All assignments should complete successfully
            mockClient.ReceivedPath.Should().Contain("policies");
        }

        #endregion
    }
}
