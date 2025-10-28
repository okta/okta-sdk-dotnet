using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Comprehensive integration tests for API Service Integrations API.
    /// This version discovers available integration types from the org and creates fresh instances.
    /// </summary>
    [Collection(nameof(ApiServiceIntegrationsApiTests))]
    public class ApiServiceIntegrationsApiTests : IAsyncLifetime
    {
        private readonly ApiServiceIntegrationsApi _apiServiceIntegrationsApi = new();
        private readonly List<string> _createdApiServiceIds = [];
        private string _testApiServiceType;

        public async Task InitializeAsync()
        {
            await DiscoverAvailableIntegrationType();
        }

        public async Task DisposeAsync()
        {
            await CleanupTestInstances();
        }

        /// <summary>
        /// Discovers an available API Service Integration type from the org by listing existing instances.
        /// This ensures we use an integration type that's actually available in the test org.
        /// </summary>
        private async Task DiscoverAvailableIntegrationType()
        {
            try
            {
                var existingInstances = await _apiServiceIntegrationsApi.ListApiServiceIntegrationInstances().ToListAsync();
                
                if (existingInstances.Any())
                {
                    _testApiServiceType = existingInstances.First().Type;
                    return;
                }

                var commonTypes = new[] { "datadoghqapiservice", "splunkapiservice", "aws_security_lake_apiservice", "cisco_ise_apiservice" };
                
                foreach (var type in commonTypes)
                {
                    try
                    {
                        var scopes = GetScopesForIntegrationType(type);
                        var testRequest = new PostAPIServiceIntegrationInstanceRequest
                        {
                            Type = type,
                            GrantedScopes = scopes
                        };
                        
                        var testInstance = await _apiServiceIntegrationsApi.CreateApiServiceIntegrationInstanceAsync(testRequest);
                        _createdApiServiceIds.Add(testInstance.Id);
                        _testApiServiceType = type;
                        
                        await _apiServiceIntegrationsApi.DeleteApiServiceIntegrationInstanceAsync(testInstance.Id);
                        _createdApiServiceIds.Remove(testInstance.Id);
                        return;
                    }
                    catch (ApiException)
                    {
                    }
                }
            }
            catch (Exception)
            {
                // Continue with fallback
            }

            if (string.IsNullOrEmpty(_testApiServiceType))
            {
                throw new InvalidOperationException(
                    "No API Service Integration type could be discovered in your org. " +
                    "Please add an API Service Integration from Admin Console > Applications > Browse App Integration Catalog > API Services.");
            }
        }

        private async Task CleanupTestInstances()
        {
            foreach (var instanceId in _createdApiServiceIds.ToList())
            {
                try
                {
                    // Delete any secrets first
                    try
                    {
                        var secrets = await _apiServiceIntegrationsApi.ListApiServiceIntegrationInstanceSecrets(instanceId).ToListAsync();
                        foreach (var secret in secrets)
                        {
                            try
                            {
                                if (secret.Status == APIServiceIntegrationInstanceSecret.StatusEnum.ACTIVE)
                                {
                                    await _apiServiceIntegrationsApi.DeactivateApiServiceIntegrationInstanceSecretAsync(instanceId, secret.Id);
                                    await Task.Delay(500);
                                }
                                await _apiServiceIntegrationsApi.DeleteApiServiceIntegrationInstanceSecretAsync(instanceId, secret.Id);
                            }
                            catch (ApiException) { }
                        }
                    }
                    catch (ApiException) { }

                    await _apiServiceIntegrationsApi.DeleteApiServiceIntegrationInstanceAsync(instanceId);
                    _createdApiServiceIds.Remove(instanceId);
                }
                catch (ApiException)
                {
                }
            }
        }

        private void TrackCreatedInstance(string apiServiceId)
        {
            if (!string.IsNullOrEmpty(apiServiceId) && !_createdApiServiceIds.Contains(apiServiceId))
            {
                _createdApiServiceIds.Add(apiServiceId);
            }
        }

        private List<string> GetScopesForIntegrationType(string integrationType)
        {
            return integrationType.ToLowerInvariant() switch
            {
                _ => ["okta.logs.read"]
            };
        }

        /// <summary>
        /// Comprehensive test covering ALL API Service Integrations API operations.
        /// Tests complete CRUD lifecycle for instances and secrets with all method variants.
        /// 
        /// ENDPOINTS TESTED (9):
        /// 1. POST   /integrations/api/v1/api-services - Create instance
        /// 2. GET    /integrations/api/v1/api-services - List instances
        /// 3. GET    /integrations/api/v1/api-services/{id} - Get instance
        /// 4. DELETE /integrations/api/v1/api-services/{id} - Delete instance
        /// 5. GET    /integrations/api/v1/api-services/{id}/credentials/secrets - List secrets
        /// 6. POST   /integrations/api/v1/api-services/{id}/credentials/secrets - Create secret
        /// 7. POST   /.../secrets/{secretId}/lifecycle/activate - Activate secret
        /// 8. POST   /.../secrets/{secretId}/lifecycle/deactivate - Deactivate secret
        /// 9. DELETE /.../secrets/{secretId} - Delete secret
        ///
        /// METHODS TESTED (18): All base + WithHttpInfo variants
        /// </summary>
        [Fact]
        public async Task GivenApiServiceIntegrations_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            string instanceId1 = null;
            string instanceId2;
            string instanceId3;
            string secret1Instance1;
            string secret2Instance1;

            try
            {
                var scopes = GetScopesForIntegrationType(_testApiServiceType);

                // CREATE INSTANCES
                
                var createRequest1 = new PostAPIServiceIntegrationInstanceRequest
                {
                    Type = _testApiServiceType,
                    GrantedScopes = scopes
                };

                var instance1 = await _apiServiceIntegrationsApi.CreateApiServiceIntegrationInstanceAsync(createRequest1);
                instanceId1 = instance1.Id;
                TrackCreatedInstance(instanceId1);

                instance1.Should().NotBeNull();
                instance1.Id.Should().NotBeNullOrEmpty();
                instance1.Type.Should().Be(_testApiServiceType);
                instance1.Name.Should().NotBeNullOrEmpty();
                instance1.GrantedScopes.Should().BeEquivalentTo(scopes);

                var createRequest2 = new PostAPIServiceIntegrationInstanceRequest
                {
                    Type = _testApiServiceType,
                    GrantedScopes = scopes
                };

                var createResponse2 = await _apiServiceIntegrationsApi.CreateApiServiceIntegrationInstanceWithHttpInfoAsync(createRequest2);
                instanceId2 = createResponse2.Data.Id;
                TrackCreatedInstance(instanceId2);

                createResponse2.StatusCode.Should().Be(HttpStatusCode.Created);
                createResponse2.Data.Id.Should().NotBeNullOrEmpty();

                await Task.Delay(2000); // Wait for propagation

                // GET INSTANCES
                
                var retrievedInstance1 = await _apiServiceIntegrationsApi.GetApiServiceIntegrationInstanceAsync(instanceId1);

                retrievedInstance1.Id.Should().Be(instanceId1);
                retrievedInstance1.Type.Should().Be(_testApiServiceType);

                var getResponse2 = await _apiServiceIntegrationsApi.GetApiServiceIntegrationInstanceWithHttpInfoAsync(instanceId2);

                getResponse2.StatusCode.Should().Be(HttpStatusCode.OK);
                getResponse2.Data.Id.Should().Be(instanceId2);

                // LIST INSTANCES 
                
                var allInstances = await _apiServiceIntegrationsApi.ListApiServiceIntegrationInstances().ToListAsync();

                allInstances.Should().Contain(i => i.Id == instanceId1);
                allInstances.Should().Contain(i => i.Id == instanceId2);

                var listResponse = await _apiServiceIntegrationsApi.ListApiServiceIntegrationInstancesWithHttpInfoAsync();

                listResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                listResponse.Data.Should().Contain(i => i.Id == instanceId1);

                // ==================== PREPARE FOR SECRET TESTS ====================
                
                // Clear any auto-generated secrets from instance1 (keeping at least 1)
                await _apiServiceIntegrationsApi.ListApiServiceIntegrationInstanceSecrets(instanceId1).ToListAsync();
                
                // We'll use the auto-generated secret as our base, then create one more
                // Instance1: will have 2 secrets total (1 auto + 1 we create)
                // Instance2: will have 2 secrets total (1 auto + 1 we create)

                // CREATE SECRETS
                
                var createdSecret1 = await _apiServiceIntegrationsApi.CreateApiServiceIntegrationInstanceSecretAsync(instanceId1);
                secret1Instance1 = createdSecret1.Id;

                createdSecret1.Id.Should().NotBeNullOrEmpty();
                createdSecret1.Status.Should().Be(APIServiceIntegrationInstanceSecret.StatusEnum.ACTIVE);
                createdSecret1.ClientSecret.Should().NotBeNullOrEmpty("Newly created secret should reveal client secret");

                // Create this secret on instance2 to avoid hitting the 2-secret limit on instance1
                var createSecretResponse2 = await _apiServiceIntegrationsApi.CreateApiServiceIntegrationInstanceSecretWithHttpInfoAsync(instanceId2);
                secret2Instance1 = createSecretResponse2.Data.Id;

                createSecretResponse2.StatusCode.Should().Be(HttpStatusCode.Created);
                createSecretResponse2.Data.Id.Should().NotBeNullOrEmpty();

                await Task.Delay(2000);

                // LIST SECRETS
                
                var allSecrets1 = await _apiServiceIntegrationsApi.ListApiServiceIntegrationInstanceSecrets(instanceId1).ToListAsync();

                allSecrets1.Should().Contain(s => s.Id == secret1Instance1);
                allSecrets1.Count.Should().Be(2, "Instance1 should have 2 secrets (1 auto + 1 created)");

                var listSecretsResponse = await _apiServiceIntegrationsApi.ListApiServiceIntegrationInstanceSecretsWithHttpInfoAsync(instanceId2);

                listSecretsResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                listSecretsResponse.Data.Should().Contain(s => s.Id == secret2Instance1);
                listSecretsResponse.Data.Count.Should().Be(2, "Instance2 should have 2 secrets (1 auto + 1 created)");

                // DEACTIVATE SECRETS 
                
                var deactivatedSecret1 = await _apiServiceIntegrationsApi.DeactivateApiServiceIntegrationInstanceSecretAsync(instanceId1, secret1Instance1);

                deactivatedSecret1.Status.Should().Be(APIServiceIntegrationInstanceSecret.StatusEnum.INACTIVE);

                var deactivateResponse2 = await _apiServiceIntegrationsApi.DeactivateApiServiceIntegrationInstanceSecretWithHttpInfoAsync(instanceId2, secret2Instance1);

                deactivateResponse2.StatusCode.Should().Be(HttpStatusCode.OK);
                deactivateResponse2.Data.Status.Should().Be(APIServiceIntegrationInstanceSecret.StatusEnum.INACTIVE);

                await Task.Delay(1000);

                //  ACTIVATE SECRETS
                
                var reactivatedSecret1 = await _apiServiceIntegrationsApi.ActivateApiServiceIntegrationInstanceSecretAsync(instanceId1, secret1Instance1);

                reactivatedSecret1.Status.Should().Be(APIServiceIntegrationInstanceSecret.StatusEnum.ACTIVE);

                var activateResponse2 = await _apiServiceIntegrationsApi.ActivateApiServiceIntegrationInstanceSecretWithHttpInfoAsync(instanceId2, secret2Instance1);

                activateResponse2.StatusCode.Should().Be(HttpStatusCode.OK);
                activateResponse2.Data.Status.Should().Be(APIServiceIntegrationInstanceSecret.StatusEnum.ACTIVE);

                await Task.Delay(1000);

                // DELETE SECRETS
                
                await _apiServiceIntegrationsApi.DeactivateApiServiceIntegrationInstanceSecretAsync(instanceId1, secret1Instance1);
                await Task.Delay(500);

                await _apiServiceIntegrationsApi.DeleteApiServiceIntegrationInstanceSecretAsync(instanceId1, secret1Instance1);

                await _apiServiceIntegrationsApi.DeactivateApiServiceIntegrationInstanceSecretAsync(instanceId2, secret2Instance1);
                await Task.Delay(500);

                var deleteSecretResponse = await _apiServiceIntegrationsApi.DeleteApiServiceIntegrationInstanceSecretWithHttpInfoAsync(instanceId2, secret2Instance1);

                deleteSecretResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

                await Task.Delay(1000);

                // DELETE INSTANCES 
                await _apiServiceIntegrationsApi.DeleteApiServiceIntegrationInstanceAsync(instanceId1);
                _createdApiServiceIds.Remove(instanceId1);

                var deleteResponse = await _apiServiceIntegrationsApi.DeleteApiServiceIntegrationInstanceWithHttpInfoAsync(instanceId2);
                _createdApiServiceIds.Remove(instanceId2);

                deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

                // ERROR HANDLING
                
                var nonExistentId = "0oa_nonexistent_id";
                var getError = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _apiServiceIntegrationsApi.GetApiServiceIntegrationInstanceAsync(nonExistentId));
                getError.ErrorCode.Should().Be(404);

                // Create a fresh instance with one secret
                var tempInstance = await _apiServiceIntegrationsApi.CreateApiServiceIntegrationInstanceAsync(new PostAPIServiceIntegrationInstanceRequest
                {
                    Type = _testApiServiceType,
                    GrantedScopes = scopes
                });
                instanceId3 = tempInstance.Id;
                TrackCreatedInstance(instanceId3);

                var tempSecrets = await _apiServiceIntegrationsApi.ListApiServiceIntegrationInstanceSecrets(instanceId3).ToListAsync();
                var activeSecret = tempSecrets.First(s => s.Status == APIServiceIntegrationInstanceSecret.StatusEnum.ACTIVE);

                var deleteActiveError = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _apiServiceIntegrationsApi.DeleteApiServiceIntegrationInstanceSecretAsync(instanceId3, activeSecret.Id));
                deleteActiveError.Message.Should().Contain("active");

                // Instance3 already has 1 secret, create 2 more (should reach max)
                await _apiServiceIntegrationsApi.CreateApiServiceIntegrationInstanceSecretAsync(instanceId3);
                await Task.Delay(500);
                
                var maxSecretError = await Assert.ThrowsAsync<ApiException>(async () =>
                    await _apiServiceIntegrationsApi.CreateApiServiceIntegrationInstanceSecretAsync(instanceId3));
                maxSecretError.Message.Should().Contain("maximum");

                // Clean up instance3
                await _apiServiceIntegrationsApi.DeleteApiServiceIntegrationInstanceAsync(instanceId3);
                _createdApiServiceIds.Remove(instanceId3);
            }
            finally
            {
                // Ensure cleanup in case of test failure
                if (!string.IsNullOrEmpty(instanceId1) && _createdApiServiceIds.Contains(instanceId1))
                {
                    await CleanupTestInstances();
                }
            }
        }
    }
}
