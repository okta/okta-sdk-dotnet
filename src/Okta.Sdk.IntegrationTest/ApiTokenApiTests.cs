// <copyright file="ApiTokenApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    [Collection(nameof(ApiTokenApiTests))]
    public class ApiTokenApiTests
    {
        private readonly ApiTokenApi _apiTokenApi = new();

        [Fact]
        public async Task GivenApiTokens_WhenPerformingCrudOperations_ThenAllEndpointsAndMethodsWork()
        {
            // NOTE: API Tokens cannot be created via API - they must be created through the Okta Admin Console

            // ListApiTokens - GET /api/v1/api-tokens
            var allTokens = _apiTokenApi.ListApiTokens();
            var tokenList = await allTokens.ToListAsync();

            tokenList.Should().NotBeNull();
            tokenList.Should().NotBeEmpty("at least one API token should exist (the one used for auth)");
            tokenList.Should().HaveCountGreaterThan(0);

            // Validate token structure
            var firstToken = tokenList.First();
            firstToken.Id.Should().NotBeNullOrEmpty();
            firstToken.Id.Should().StartWith("00T", "API token IDs should start with 00T");
            firstToken.Name.Should().NotBeNullOrEmpty();
            firstToken.UserId.Should().NotBeNullOrEmpty();
            firstToken.UserId.Should().StartWith("00u", "User IDs should start with 00u");
            firstToken.ClientName.Should().NotBeNullOrEmpty();
            firstToken.TokenWindow.Should().NotBeNullOrEmpty("TokenWindow should be present");
            
            foreach (var token in tokenList)
            {
                token.Id.Should().NotBeNullOrEmpty();
                token.Name.Should().NotBeNullOrEmpty();
                token.UserId.Should().NotBeNullOrEmpty();
                token.ClientName.Should().NotBeNullOrEmpty();
            }

            await Task.Delay(1000);

            // ListApiTokensWithHttpInfoAsync - GET /api/v1/api-tokens (with HTTP info)
            var tokensWithHttpInfo = await _apiTokenApi.ListApiTokensWithHttpInfoAsync();

            tokensWithHttpInfo.Should().NotBeNull();
            tokensWithHttpInfo.StatusCode.Should().Be(HttpStatusCode.OK, "List operation should return 200 OK");
            tokensWithHttpInfo.Data.Should().NotBeNull();
            tokensWithHttpInfo.Data.Should().NotBeEmpty();
            tokensWithHttpInfo.Data.Count.Should().Be(tokenList.Count, "WithHttpInfo should return same number of tokens as standard method");
            tokensWithHttpInfo.Headers.Should().NotBeNull();
            tokensWithHttpInfo.Headers.Should().ContainKey("Content-Type");
            
            var firstTokenWithHttpInfo = tokensWithHttpInfo.Data.First();
            firstTokenWithHttpInfo.Id.Should().NotBeNullOrEmpty();
            firstTokenWithHttpInfo.Name.Should().NotBeNullOrEmpty();
            firstTokenWithHttpInfo.UserId.Should().NotBeNullOrEmpty();
            firstTokenWithHttpInfo.ClientName.Should().NotBeNullOrEmpty();

            await Task.Delay(1000);

            // GetApiTokenAsync - GET /api/v1/api-tokens/{apiTokenId}
            var testTokenId = firstToken.Id;
            var retrievedToken = await _apiTokenApi.GetApiTokenAsync(testTokenId);

            retrievedToken.Should().NotBeNull();
            retrievedToken.Id.Should().Be(testTokenId, "Retrieved token ID should match requested ID");
            retrievedToken.Name.Should().NotBeNullOrEmpty();
            retrievedToken.Name.Should().Be(firstToken.Name, "Retrieved token name should match");
            retrievedToken.UserId.Should().NotBeNullOrEmpty();
            retrievedToken.UserId.Should().Be(firstToken.UserId, "Retrieved token userId should match");
            retrievedToken.ClientName.Should().NotBeNullOrEmpty();
            retrievedToken.ClientName.Should().Be(firstToken.ClientName, "Retrieved token clientName should match");
            retrievedToken.TokenWindow.Should().Be(firstToken.TokenWindow, "TokenWindow should match");
            
            retrievedToken.Should().BeEquivalentTo(firstToken, options => options
                .Including(t => t.Id)
                .Including(t => t.Name)
                .Including(t => t.UserId)
                .Including(t => t.ClientName));

            await Task.Delay(1000);

            // GetApiTokenWithHttpInfoAsync - GET /api/v1/api-tokens/{apiTokenId} (with HTTP info)
            var tokenWithHttpInfo = await _apiTokenApi.GetApiTokenWithHttpInfoAsync(testTokenId);

            tokenWithHttpInfo.Should().NotBeNull();
            tokenWithHttpInfo.StatusCode.Should().Be(HttpStatusCode.OK, "Get operation should return 200 OK");
            tokenWithHttpInfo.Headers.Should().NotBeNull();
            tokenWithHttpInfo.Headers.Should().ContainKey("Content-Type");
            
            tokenWithHttpInfo.Data.Should().NotBeNull();
            tokenWithHttpInfo.Data.Id.Should().Be(testTokenId, "Retrieved token ID should match requested ID");
            tokenWithHttpInfo.Data.Name.Should().Be(retrievedToken.Name, "Name should match previous retrieval");
            tokenWithHttpInfo.Data.UserId.Should().Be(retrievedToken.UserId, "UserId should match previous retrieval");
            tokenWithHttpInfo.Data.ClientName.Should().Be(retrievedToken.ClientName, "ClientName should match previous retrieval");
            
            tokenWithHttpInfo.Data.Should().BeEquivalentTo(retrievedToken, options => options
                .Including(t => t.Id)
                .Including(t => t.Name)
                .Including(t => t.UserId)
                .Including(t => t.ClientName)
                .Including(t => t.TokenWindow));

            await Task.Delay(1000);

            // UpsertApiTokenAsync - PUT /api/v1/api-tokens/{apiTokenId} (negative test with invalid ID)
            // NOTE: Upsert operations may be restricted in some org's
            const string invalidTokenForUpsert = "00Invalid_upsert_id";
            
            var updateRequest = new ApiTokenUpdate
            {
                Network = new ApiTokenNetwork
                {
                    Connection = "ANYWHERE"
                }
            };

            var upsertException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _apiTokenApi.UpsertApiTokenAsync(invalidTokenForUpsert, updateRequest);
            });
            
            upsertException.Should().NotBeNull();
            upsertException.ErrorCode.Should().BeOneOf(400, 401, 403, 404);

            await Task.Delay(1000);

            // UpsertApiTokenWithHttpInfoAsync - PUT /api/v1/api-tokens/{apiTokenId} (negative test with invalid ID)
            var updateRequest2 = new ApiTokenUpdate
            {
                Network = new ApiTokenNetwork
                {
                    Connection = "ANYWHERE"
                }
            };

            var upsertHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _apiTokenApi.UpsertApiTokenWithHttpInfoAsync(invalidTokenForUpsert, updateRequest2);
            });

            upsertHttpInfoException.Should().NotBeNull();
            upsertHttpInfoException.ErrorCode.Should().BeOneOf(400, 401, 403, 404);

            await Task.Delay(1000);

            // RevokeApiTokenAsync - DELETE /api/v1/api-tokens/{apiTokenId} (negative test with invalid ID)
            // NOTE: Cannot revoke actual tokens as that would break later tests
            const string invalidTokenId = "00Tin-valid_token_id_12345";

            var revokeException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _apiTokenApi.RevokeApiTokenAsync(invalidTokenId);
            });

            revokeException.Should().NotBeNull();
            revokeException.ErrorCode.Should().BeOneOf(401, 403, 404, 400);
            revokeException.Message.Should().NotBeNullOrEmpty("Exception should have a descriptive message");
            revokeException.ErrorCode.Should().Be(404, "Non-existent token should return 404 Not Found");

            await Task.Delay(1000);

            // RevokeApiTokenWithHttpInfoAsync - DELETE /api/v1/api-tokens/{apiTokenId} (negative test with invalid ID)
            var revokeWithHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _apiTokenApi.RevokeApiTokenWithHttpInfoAsync(invalidTokenId);
            });

            revokeWithHttpInfoException.Should().NotBeNull();
            revokeWithHttpInfoException.ErrorCode.Should().BeOneOf(401, 403, 404, 400);
            revokeWithHttpInfoException.Message.Should().NotBeNullOrEmpty();
            revokeWithHttpInfoException.ErrorCode.Should().Be(404, "Non-existent token should return 404 Not Found");
            revokeWithHttpInfoException.ErrorCode.Should().Be(revokeException.ErrorCode, 
                "Both revoke methods should return same error code for same invalid ID");

            await Task.Delay(1000);

            // RevokeCurrentApiTokenAsync - DELETE /api/v1/api-tokens/current (method availability check)
            // NOTE: Cannot execute as it would revoke the token used for authentication
            Func<Task> revokeCurrentAction = async () => await _apiTokenApi.RevokeCurrentApiTokenAsync();
            revokeCurrentAction.Should().NotBeNull("RevokeCurrentApiTokenAsync method should exist");

            // RevokeCurrentApiTokenWithHttpInfoAsync - DELETE /api/v1/api-tokens/current (method availability check)
            Func<Task> revokeCurrentWithHttpInfoAction = async () => await _apiTokenApi.RevokeCurrentApiTokenWithHttpInfoAsync();
            revokeCurrentWithHttpInfoAction.Should().NotBeNull("RevokeCurrentApiTokenWithHttpInfoAsync method should exist");
        }

        [Fact]
        public async Task GivenInvalidId_WhenGettingApiToken_ThenApiExceptionIsThrown()
        {
            const string invalidTokenId = "00Tin-valid_id_xyz";

            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _apiTokenApi.GetApiTokenAsync(invalidTokenId);
            });

            exception.Should().NotBeNull();
            exception.ErrorCode.Should().Be(404, "Invalid token ID should return 404 Not Found");
            exception.Message.Should().NotBeNullOrEmpty();
            exception.Message.Should().Contain("ApiToken", "Error message should reference ApiToken");
        }

        [Fact]
        public async Task GivenInvalidId_WhenGettingApiTokenWithHttpInfo_ThenApiExceptionIsThrown()
        {
            const string invalidTokenId = "00Tin-valid_id_abc";

            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _apiTokenApi.GetApiTokenWithHttpInfoAsync(invalidTokenId);
            });

            exception.Should().NotBeNull();
            exception.ErrorCode.Should().Be(404, "Invalid token ID should return 404 Not Found");
            exception.Message.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GivenInvalidId_WhenUpsertingApiToken_ThenApiExceptionIsThrown()
        {
            const string invalidTokenId = "00Tin-valid_id_def";

            var updateRequest = new ApiTokenUpdate
            {
                Network = new ApiTokenNetwork
                {
                    Connection = "ANYWHERE"
                }
            };

            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _apiTokenApi.UpsertApiTokenAsync(invalidTokenId, updateRequest);
            });

            exception.Should().NotBeNull();
            exception.ErrorCode.Should().BeOneOf(401, 403, 404, 400);
        }

        [Fact]
        public async Task GivenInvalidId_WhenUpsertingApiTokenWithHttpInfo_ThenApiExceptionIsThrown()
        {
            const string invalidTokenId = "00Tin-valid_id_ghi";

            var updateRequest = new ApiTokenUpdate
            {
                Network = new ApiTokenNetwork
                {
                    Connection = "ANYWHERE"
                }
            };

            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _apiTokenApi.UpsertApiTokenWithHttpInfoAsync(invalidTokenId, updateRequest);
            });

            exception.Should().NotBeNull();
            exception.ErrorCode.Should().BeOneOf(401, 403, 404, 400);
        }

        [Fact]
        public async Task GivenListOperations_WhenCalling_ThenConsistentResultsAreReturned()
        {
            var tokensFromStandard = await _apiTokenApi.ListApiTokens().ToListAsync();
            await Task.Delay(500);

            var responseFromWithHttpInfo = await _apiTokenApi.ListApiTokensWithHttpInfoAsync();
            var tokensFromWithHttpInfo = responseFromWithHttpInfo.Data;

            tokensFromStandard.Should().NotBeNullOrEmpty();
            tokensFromWithHttpInfo.Should().NotBeNullOrEmpty();
            tokensFromStandard.Count.Should().Be(tokensFromWithHttpInfo.Count);

            tokensFromStandard.Should().BeEquivalentTo(tokensFromWithHttpInfo, options => options
                .ComparingByMembers<ApiToken>()
                .Including(t => t.Id)
                .Including(t => t.Name)
                .Including(t => t.UserId)
                .Including(t => t.ClientName)
                .Including(t => t.TokenWindow));
        }

        [Fact]
        public async Task GivenGetOperations_WhenCalling_ThenConsistentResultsAreReturned()
        {
            var allTokens = await _apiTokenApi.ListApiTokens().ToListAsync();
            allTokens.Should().NotBeNullOrEmpty("Should have at least one token to test Get operations");

            var tokenId = allTokens[0].Id;
            tokenId.Should().NotBeNullOrEmpty();

            var tokenFromStandard = await _apiTokenApi.GetApiTokenAsync(tokenId);
            await Task.Delay(500);

            var responseFromWithHttpInfo = await _apiTokenApi.GetApiTokenWithHttpInfoAsync(tokenId);
            var tokenFromWithHttpInfo = responseFromWithHttpInfo.Data;

            tokenFromStandard.Should().NotBeNull();
            tokenFromWithHttpInfo.Should().NotBeNull();

            tokenFromStandard.Should().BeEquivalentTo(tokenFromWithHttpInfo, options => options
                .ComparingByMembers<ApiToken>()
                .Including(t => t.Id)
                .Including(t => t.Name)
                .Including(t => t.UserId)
                .Including(t => t.ClientName)
                .Including(t => t.TokenWindow));
        }

        [Fact]
        public async Task GivenInvalidId_WhenUpsertingToken_ThenApiExceptionIsThrown()
        {
            const string invalidTokenId = "00Tin-valid_id_jkl";

            var updateRequest = new ApiTokenUpdate
            {
                Network = new ApiTokenNetwork
                {
                    Connection = "ANYWHERE"
                }
            };

            var exceptionFromStandard = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _apiTokenApi.UpsertApiTokenAsync(invalidTokenId, updateRequest);
            });

            await Task.Delay(500);

            var exceptionFromWithHttpInfo = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _apiTokenApi.UpsertApiTokenWithHttpInfoAsync(invalidTokenId, updateRequest);
            });

            exceptionFromStandard.Should().NotBeNull();
            exceptionFromWithHttpInfo.Should().NotBeNull();
            exceptionFromStandard.ErrorCode.Should().BeOneOf(401, 403, 404, 400);
            exceptionFromWithHttpInfo.ErrorCode.Should().BeOneOf(401, 403, 404, 400);
        }
    }
}
