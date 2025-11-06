// <copyright file="AgentPoolsApiTest.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.UnitTest.Api
{
    public class AgentPoolsApiTests
    {
        private Mock<IAsynchronousClient> CreateMockAsyncClient()
        {
            return new Mock<IAsynchronousClient>();
        }

        private Configuration CreateTestConfiguration()
        {
            return new Configuration
            {
                OktaDomain = "https://test.okta.com"
            };
        }

        private AgentPoolsApi CreateAgentPoolsApi(Mock<IAsynchronousClient> mockClient = null)
        {
            var client = mockClient ?? CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            return new AgentPoolsApi(client.Object, config);
        }

        #region Constructor Tests

        [Fact]
        public void Constructor_WithNullClient_ThrowsArgumentNullException()
        {
            // Arrange
            var config = CreateTestConfiguration();

            // Act
            Action act = () => new AgentPoolsApi(null, config);

            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithParameterName("asyncClient");
        }

        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();

            // Act
            Action act = () => new AgentPoolsApi(mockClient.Object, null);

            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithParameterName("configuration");
        }

        [Fact]
        public void Constructor_WithValidParameters_CreatesInstance()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();

            // Act
            var api = new AgentPoolsApi(mockClient.Object, config);

            // Assert
            api.Should().NotBeNull();
            api.Should().BeAssignableTo<IAgentPoolsApiAsync>();
        }

        #endregion

        #region ActivateAgentPoolsUpdateAsync Tests

        [Fact]
        public async Task ActivateAgentPoolsUpdateAsync_WithValidParameters_ReturnsAgentPoolUpdate()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var expected = new AgentPoolUpdate();
            
            mockClient.Setup(c => c.PostAsync<AgentPoolUpdate>(
                    It.IsAny<string>(), 
                    It.IsAny<RequestOptions>(), 
                    It.IsAny<IReadableConfiguration>(), 
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<AgentPoolUpdate>(HttpStatusCode.OK, null, expected));

            var api = CreateAgentPoolsApi(mockClient);

            // Act
            var result = await api.ActivateAgentPoolsUpdateAsync("pool123", "update123");

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(expected);
            mockClient.Verify(c => c.PostAsync<AgentPoolUpdate>(
                It.Is<string>(s => s.Contains("/agentPools/") && s.Contains("/updates/")),
                It.IsAny<RequestOptions>(), 
                It.IsAny<IReadableConfiguration>(), 
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task ActivateAgentPoolsUpdateAsync_WithNullPoolId_ThrowsApiException()
        {
            // Arrange
            var api = CreateAgentPoolsApi();

            // Act
            Func<Task> act = async () => await api.ActivateAgentPoolsUpdateAsync(null, "update123");

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*Missing required parameter*poolId*");
        }

        [Fact]
        public async Task ActivateAgentPoolsUpdateAsync_WithNullUpdateId_ThrowsApiException()
        {
            // Arrange
            var api = CreateAgentPoolsApi();

            // Act
            Func<Task> act = async () => await api.ActivateAgentPoolsUpdateAsync("pool123", null);

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*Missing required parameter*updateId*");
        }

        #endregion

        #region CreateAgentPoolsUpdateAsync Tests

        [Fact]
        public async Task CreateAgentPoolsUpdateAsync_WithValidParameters_ReturnsAgentPoolUpdate()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var inputUpdate = new AgentPoolUpdate();
            var expectedUpdate = new AgentPoolUpdate();
            
            mockClient.Setup(c => c.PostAsync<AgentPoolUpdate>(
                    It.IsAny<string>(), 
                    It.IsAny<RequestOptions>(), 
                    It.IsAny<IReadableConfiguration>(), 
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<AgentPoolUpdate>(HttpStatusCode.OK, null, expectedUpdate));

            var api = CreateAgentPoolsApi(mockClient);

            // Act
            var result = await api.CreateAgentPoolsUpdateAsync("pool123", inputUpdate);

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(expectedUpdate);
        }

        [Fact]
        public async Task CreateAgentPoolsUpdateAsync_WithNullPoolId_ThrowsApiException()
        {
            // Arrange
            var api = CreateAgentPoolsApi();

            // Act
            Func<Task> act = async () => await api.CreateAgentPoolsUpdateAsync(null, new AgentPoolUpdate());

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*Missing required parameter*poolId*");
        }

        #endregion

        #region DeactivateAgentPoolsUpdateAsync Tests

        [Fact]
        public async Task DeactivateAgentPoolsUpdateAsync_WithValidParameters_ReturnsAgentPoolUpdate()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var expected = new AgentPoolUpdate();
            
            mockClient.Setup(c => c.PostAsync<AgentPoolUpdate>(
                    It.IsAny<string>(), 
                    It.IsAny<RequestOptions>(), 
                    It.IsAny<IReadableConfiguration>(), 
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<AgentPoolUpdate>(HttpStatusCode.OK, null, expected));

            var api = CreateAgentPoolsApi(mockClient);

            // Act
            var result = await api.DeactivateAgentPoolsUpdateAsync("pool123", "update123");

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(expected);
        }

        [Fact]
        public async Task DeactivateAgentPoolsUpdateAsync_WithNullPoolId_ThrowsApiException()
        {
            // Arrange
            var api = CreateAgentPoolsApi();

            // Act
            Func<Task> act = async () => await api.DeactivateAgentPoolsUpdateAsync(null, "update123");

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*Missing required parameter*poolId*");
        }

        #endregion

        #region DeleteAgentPoolsUpdateAsync Tests

        [Fact]
        public async Task DeleteAgentPoolsUpdateAsync_WithValidParameters_Succeeds()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            
            mockClient.Setup(c => c.DeleteAsync<Object>(
                    It.IsAny<string>(), 
                    It.IsAny<RequestOptions>(), 
                    It.IsAny<IReadableConfiguration>(), 
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<Object>(HttpStatusCode.NoContent, null, null, null));

            var api = CreateAgentPoolsApi(mockClient);

            // Act
            await api.DeleteAgentPoolsUpdateAsync("pool123", "update123");

            // Assert
            mockClient.Verify(c => c.DeleteAsync<Object>(
                It.Is<string>(s => s.Contains("/agentPools/") && s.Contains("/updates/")),
                It.IsAny<RequestOptions>(), 
                It.IsAny<IReadableConfiguration>(), 
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAgentPoolsUpdateAsync_WithNullPoolId_ThrowsApiException()
        {
            // Arrange
            var api = CreateAgentPoolsApi();

            // Act
            Func<Task> act = async () => await api.DeleteAgentPoolsUpdateAsync(null, "update123");

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*Missing required parameter*poolId*");
        }

        #endregion

        #region GetAgentPoolsUpdateInstanceAsync Tests

        [Fact]
        public async Task GetAgentPoolsUpdateInstanceAsync_WithValidParameters_ReturnsAgentPoolUpdate()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var expected = new AgentPoolUpdate();
            
            mockClient.Setup(c => c.GetAsync<AgentPoolUpdate>(
                    It.IsAny<string>(), 
                    It.IsAny<RequestOptions>(), 
                    It.IsAny<IReadableConfiguration>(), 
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<AgentPoolUpdate>(HttpStatusCode.OK, null, expected));

            var api = CreateAgentPoolsApi(mockClient);

            // Act
            var result = await api.GetAgentPoolsUpdateInstanceAsync("pool123", "update123");

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(expected);
        }

        [Fact]
        public async Task GetAgentPoolsUpdateInstanceAsync_WithNullPoolId_ThrowsApiException()
        {
            // Arrange
            var api = CreateAgentPoolsApi();

            // Act
            Func<Task> act = async () => await api.GetAgentPoolsUpdateInstanceAsync(null, "update123");

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*Missing required parameter*poolId*");
        }

        #endregion

        #region GetAgentPoolsUpdateSettingsAsync Tests

        [Fact]
        public async Task GetAgentPoolsUpdateSettingsAsync_WithValidPoolId_ReturnsSettings()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var expected = new AgentPoolUpdateSetting();
            
            mockClient.Setup(c => c.GetAsync<AgentPoolUpdateSetting>(
                    It.IsAny<string>(), 
                    It.IsAny<RequestOptions>(), 
                    It.IsAny<IReadableConfiguration>(), 
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<AgentPoolUpdateSetting>(HttpStatusCode.OK, null, expected));

            var api = CreateAgentPoolsApi(mockClient);

            // Act
            var result = await api.GetAgentPoolsUpdateSettingsAsync("pool123");

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(expected);
        }

        [Fact]
        public async Task GetAgentPoolsUpdateSettingsAsync_WithNullPoolId_ThrowsApiException()
        {
            // Arrange
            var api = CreateAgentPoolsApi();

            // Act
            Func<Task> act = async () => await api.GetAgentPoolsUpdateSettingsAsync(null);

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*Missing required parameter*poolId*");
        }

        #endregion

        #region ListAgentPools Tests

        [Fact]
        public void ListAgentPools_ReturnsCollectionClient()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var api = CreateAgentPoolsApi(mockClient);

            // Act
            var result = api.ListAgentPools();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IOktaCollectionClient<AgentPool>>();
        }

        #endregion

        #region ListAgentPoolsUpdates Tests

        [Fact]
        public void ListAgentPoolsUpdates_WithValidPoolId_ReturnsCollectionClient()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var api = CreateAgentPoolsApi(mockClient);

            // Act
            var result = api.ListAgentPoolsUpdates("pool123");

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IOktaCollectionClient<AgentPoolUpdate>>();
        }

        #endregion

        #region PauseAgentPoolsUpdateAsync Tests

        [Fact]
        public async Task PauseAgentPoolsUpdateAsync_WithValidParameters_ReturnsAgentPoolUpdate()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var expected = new AgentPoolUpdate();
            
            mockClient.Setup(c => c.PostAsync<AgentPoolUpdate>(
                    It.IsAny<string>(), 
                    It.IsAny<RequestOptions>(), 
                    It.IsAny<IReadableConfiguration>(), 
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<AgentPoolUpdate>(HttpStatusCode.OK, null, expected));

            var api = CreateAgentPoolsApi(mockClient);

            // Act
            var result = await api.PauseAgentPoolsUpdateAsync("pool123", "update123");

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(expected);
        }

        #endregion

        #region ResumeAgentPoolsUpdateAsync Tests

        [Fact]
        public async Task ResumeAgentPoolsUpdateAsync_WithValidParameters_ReturnsAgentPoolUpdate()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var expected = new AgentPoolUpdate();
            
            mockClient.Setup(c => c.PostAsync<AgentPoolUpdate>(
                    It.IsAny<string>(), 
                    It.IsAny<RequestOptions>(), 
                    It.IsAny<IReadableConfiguration>(), 
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<AgentPoolUpdate>(HttpStatusCode.OK, null, expected));

            var api = CreateAgentPoolsApi(mockClient);

            // Act
            var result = await api.ResumeAgentPoolsUpdateAsync("pool123", "update123");

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(expected);
        }

        #endregion

        #region RetryAgentPoolsUpdateAsync Tests

        [Fact]
        public async Task RetryAgentPoolsUpdateAsync_WithValidParameters_ReturnsAgentPoolUpdate()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var expected = new AgentPoolUpdate();
            
            mockClient.Setup(c => c.PostAsync<AgentPoolUpdate>(
                    It.IsAny<string>(), 
                    It.IsAny<RequestOptions>(), 
                    It.IsAny<IReadableConfiguration>(), 
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<AgentPoolUpdate>(HttpStatusCode.OK, null, expected));

            var api = CreateAgentPoolsApi(mockClient);

            // Act
            var result = await api.RetryAgentPoolsUpdateAsync("pool123", "update123");

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(expected);
        }

        #endregion

        #region StopAgentPoolsUpdateAsync Tests

        [Fact]
        public async Task StopAgentPoolsUpdateAsync_WithValidParameters_ReturnsAgentPoolUpdate()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var expected = new AgentPoolUpdate();
            
            mockClient.Setup(c => c.PostAsync<AgentPoolUpdate>(
                    It.IsAny<string>(), 
                    It.IsAny<RequestOptions>(), 
                    It.IsAny<IReadableConfiguration>(), 
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<AgentPoolUpdate>(HttpStatusCode.OK, null, expected));

            var api = CreateAgentPoolsApi(mockClient);

            // Act
            var result = await api.StopAgentPoolsUpdateAsync("pool123", "update123");

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(expected);
        }

        #endregion

        #region UpdateAgentPoolsUpdateAsync Tests

        [Fact]
        public async Task UpdateAgentPoolsUpdateAsync_WithValidParameters_ReturnsAgentPoolUpdate()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var inputUpdate = new AgentPoolUpdate();
            var expectedUpdate = new AgentPoolUpdate();
            
            mockClient.Setup(c => c.PostAsync<AgentPoolUpdate>(
                    It.IsAny<string>(), 
                    It.IsAny<RequestOptions>(), 
                    It.IsAny<IReadableConfiguration>(), 
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<AgentPoolUpdate>(HttpStatusCode.OK, null, expectedUpdate));

            var api = CreateAgentPoolsApi(mockClient);

            // Act
            var result = await api.UpdateAgentPoolsUpdateAsync("pool123", "update123", inputUpdate);

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(expectedUpdate);
        }

        [Fact]
        public async Task UpdateAgentPoolsUpdateAsync_WithNullPoolId_ThrowsApiException()
        {
            // Arrange
            var api = CreateAgentPoolsApi();

            // Act
            Func<Task> act = async () => await api.UpdateAgentPoolsUpdateAsync(null, "update123", new AgentPoolUpdate());

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*Missing required parameter*poolId*");
        }

        #endregion

        #region UpdateAgentPoolsUpdateSettingsAsync Tests

        [Fact]
        public async Task UpdateAgentPoolsUpdateSettingsAsync_WithValidParameters_ReturnsSettings()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var inputSettings = new AgentPoolUpdateSetting();
            var expectedSettings = new AgentPoolUpdateSetting();
            
            mockClient.Setup(c => c.PostAsync<AgentPoolUpdateSetting>(
                    It.IsAny<string>(), 
                    It.IsAny<RequestOptions>(), 
                    It.IsAny<IReadableConfiguration>(), 
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<AgentPoolUpdateSetting>(HttpStatusCode.OK, null, expectedSettings));

            var api = CreateAgentPoolsApi(mockClient);

            // Act
            var result = await api.UpdateAgentPoolsUpdateSettingsAsync("pool123", inputSettings);

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(expectedSettings);
        }

        [Fact]
        public async Task UpdateAgentPoolsUpdateSettingsAsync_WithNullPoolId_ThrowsApiException()
        {
            // Arrange
            var api = CreateAgentPoolsApi();

            // Act
            Func<Task> act = async () => await api.UpdateAgentPoolsUpdateSettingsAsync(null, new AgentPoolUpdateSetting());

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*Missing required parameter*poolId*");
        }

        #endregion

        #region Error Handling Tests

        [Fact]
        public async Task GetAgentPoolsUpdateInstanceAsync_WhenApiReturns404_ThrowsApiException()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            mockClient.Setup(c => c.GetAsync<AgentPoolUpdate>(
                    It.IsAny<string>(), 
                    It.IsAny<RequestOptions>(), 
                    It.IsAny<IReadableConfiguration>(), 
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new ApiException(404, "Not Found"));

            var api = CreateAgentPoolsApi(mockClient);

            // Act
            Func<Task> act = async () => await api.GetAgentPoolsUpdateInstanceAsync("pool123", "invalid");

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404);
        }

        #endregion

        #region Cancellation Tests

        [Fact]
        public async Task GetAgentPoolsUpdateInstanceAsync_WhenCancellationRequested_ThrowsOperationCanceledException()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var cancellationToken = new CancellationToken(true);
            
            mockClient.Setup(c => c.GetAsync<AgentPoolUpdate>(
                    It.IsAny<string>(), 
                    It.IsAny<RequestOptions>(), 
                    It.IsAny<IReadableConfiguration>(), 
                    It.Is<CancellationToken>(ct => ct.IsCancellationRequested)))
                .ThrowsAsync(new OperationCanceledException());

            var api = CreateAgentPoolsApi(mockClient);

            // Act
            Func<Task> act = async () => await api.GetAgentPoolsUpdateInstanceAsync("pool123", "update123", cancellationToken);

            // Assert
            await act.Should().ThrowAsync<OperationCanceledException>();
        }

        #endregion
    }
}