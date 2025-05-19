using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.UnitTest.Api
{
    public class AgentPoolsApiTest
    {
        private readonly Mock<IAsynchronousClient> _mockClient;
        private readonly AgentPoolsApi _api;

        public AgentPoolsApiTest()
        {
            _mockClient = new Mock<IAsynchronousClient>();
            var mockConfig = new Mock<IReadableConfiguration>();
            _api = new AgentPoolsApi(_mockClient.Object, mockConfig.Object);
        }

        [Fact]
        public async Task ActivateAgentPoolsUpdateAsync_ReturnsData()
        {
            var expected = new AgentPoolUpdate();
            var response = new ApiResponse<AgentPoolUpdate>(HttpStatusCode.OK, null, expected, null);
            _mockClient.Setup(c => c.PostAsync<AgentPoolUpdate>(
                It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await _api.ActivateAgentPoolsUpdateAsync("pool", "update");

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task ActivateAgentPoolsUpdateAsync_ThrowsOnNullPoolId()
        {
            await Assert.ThrowsAsync<ApiException>(() => _api.ActivateAgentPoolsUpdateAsync(null, "update"));
        }

        [Fact]
        public async Task ActivateAgentPoolsUpdateAsync_ThrowsOnNullUpdateId()
        {
            await Assert.ThrowsAsync<ApiException>(() => _api.ActivateAgentPoolsUpdateAsync("pool", null));
        }

        [Fact]
        public async Task CreateAgentPoolsUpdateAsync_ReturnsData()
        {
            var expected = new AgentPoolUpdate();
            var response = new ApiResponse<AgentPoolUpdate>(HttpStatusCode.OK, null, expected, null);
            _mockClient.Setup(c => c.PostAsync<AgentPoolUpdate>(
                It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await _api.CreateAgentPoolsUpdateAsync("pool", expected);

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task CreateAgentPoolsUpdateAsync_ThrowsOnNullPoolId()
        {
            await Assert.ThrowsAsync<ApiException>(() => _api.CreateAgentPoolsUpdateAsync(null, new AgentPoolUpdate()));
        }

        [Fact]
        public async Task CreateAgentPoolsUpdateAsync_ThrowsOnNullAgentPoolUpdate()
        {
            await Assert.ThrowsAsync<ApiException>(() => _api.CreateAgentPoolsUpdateAsync("pool", null));
        }

        [Fact]
        public async Task DeactivateAgentPoolsUpdateAsync_ReturnsData()
        {
            var expected = new AgentPoolUpdate();
            var response = new ApiResponse<AgentPoolUpdate>(HttpStatusCode.OK, null, expected, null);
            _mockClient.Setup(c => c.PostAsync<AgentPoolUpdate>(
                It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await _api.DeactivateAgentPoolsUpdateAsync("pool", "update");

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task DeactivateAgentPoolsUpdateAsync_ThrowsOnNullPoolId()
        {
            await Assert.ThrowsAsync<ApiException>(() => _api.DeactivateAgentPoolsUpdateAsync(null, "update"));
        }

        [Fact]
        public async Task DeactivateAgentPoolsUpdateAsync_ThrowsOnNullUpdateId()
        {
            await Assert.ThrowsAsync<ApiException>(() => _api.DeactivateAgentPoolsUpdateAsync("pool", null));
        }

        [Fact]
        public async Task DeleteAgentPoolsUpdateAsync_ThrowsOnNullPoolId()
        {
            await Assert.ThrowsAsync<ApiException>(() => _api.DeleteAgentPoolsUpdateAsync(null, "update"));
        }

        [Fact]
        public async Task DeleteAgentPoolsUpdateAsync_ThrowsOnNullUpdateId()
        {
            await Assert.ThrowsAsync<ApiException>(() => _api.DeleteAgentPoolsUpdateAsync("pool", null));
        }

        [Fact]
        public async Task GetAgentPoolsUpdateInstanceAsync_ReturnsData()
        {
            var expected = new AgentPoolUpdate();
            var response = new ApiResponse<AgentPoolUpdate>(HttpStatusCode.OK, null, expected, null);
            _mockClient.Setup(c => c.GetAsync<AgentPoolUpdate>(
                It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await _api.GetAgentPoolsUpdateInstanceAsync("pool", "update");

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task GetAgentPoolsUpdateInstanceAsync_ThrowsOnNullPoolId()
        {
            await Assert.ThrowsAsync<ApiException>(() => _api.GetAgentPoolsUpdateInstanceAsync(null, "update"));
        }

        [Fact]
        public async Task GetAgentPoolsUpdateInstanceAsync_ThrowsOnNullUpdateId()
        {
            await Assert.ThrowsAsync<ApiException>(() => _api.GetAgentPoolsUpdateInstanceAsync("pool", null));
        }

        [Fact]
        public async Task GetAgentPoolsUpdateSettingsAsync_ReturnsData()
        {
            var expected = new AgentPoolUpdateSetting();
            var response = new ApiResponse<AgentPoolUpdateSetting>(HttpStatusCode.OK, null, expected, null);
            _mockClient.Setup(c => c.GetAsync<AgentPoolUpdateSetting>(
                It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await _api.GetAgentPoolsUpdateSettingsAsync("pool");

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task GetAgentPoolsUpdateSettingsAsync_ThrowsOnNullPoolId()
        {
            await Assert.ThrowsAsync<ApiException>(() => _api.GetAgentPoolsUpdateSettingsAsync(null));
        }

        [Fact]
        public void ListAgentPools_ReturnsCollection()
        {
            var result = _api.ListAgentPools();
            Assert.NotNull(result);
        }

        [Fact]
        public void ListAgentPoolsUpdates_ReturnsCollection()
        {
            var result = _api.ListAgentPoolsUpdates("pool");
            Assert.NotNull(result);
        }

        [Fact]
        public async Task PauseAgentPoolsUpdateAsync_ReturnsData()
        {
            var expected = new AgentPoolUpdate();
            var response = new ApiResponse<AgentPoolUpdate>(HttpStatusCode.OK, null, expected, null);
            _mockClient.Setup(c => c.PostAsync<AgentPoolUpdate>(
                It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await _api.PauseAgentPoolsUpdateAsync("pool", "update");

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task ResumeAgentPoolsUpdateAsync_ReturnsData()
        {
            var expected = new AgentPoolUpdate();
            var response = new ApiResponse<AgentPoolUpdate>(HttpStatusCode.OK, null, expected, null);
            _mockClient.Setup(c => c.PostAsync<AgentPoolUpdate>(
                It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await _api.ResumeAgentPoolsUpdateAsync("pool", "update");

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task RetryAgentPoolsUpdateAsync_ReturnsData()
        {
            var expected = new AgentPoolUpdate();
            var response = new ApiResponse<AgentPoolUpdate>(HttpStatusCode.OK, null, expected, null);
            _mockClient.Setup(c => c.PostAsync<AgentPoolUpdate>(
                It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await _api.RetryAgentPoolsUpdateAsync("pool", "update");

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task StopAgentPoolsUpdateAsync_ReturnsData()
        {
            var expected = new AgentPoolUpdate();
            var response = new ApiResponse<AgentPoolUpdate>(HttpStatusCode.OK, null, expected, null);
            _mockClient.Setup(c => c.PostAsync<AgentPoolUpdate>(
                It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await _api.StopAgentPoolsUpdateAsync("pool", "update");

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task UpdateAgentPoolsUpdateAsync_ReturnsData()
        {
            var expected = new AgentPoolUpdate();
            var response = new ApiResponse<AgentPoolUpdate>(HttpStatusCode.OK, null, expected, null);
            _mockClient.Setup(c => c.PostAsync<AgentPoolUpdate>(
                It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await _api.UpdateAgentPoolsUpdateAsync("pool", "update", expected);

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task UpdateAgentPoolsUpdateAsync_ThrowsOnNullPoolId()
        {
            await Assert.ThrowsAsync<ApiException>(() => _api.UpdateAgentPoolsUpdateAsync(null, "update", new AgentPoolUpdate()));
        }

        [Fact]
        public async Task UpdateAgentPoolsUpdateAsync_ThrowsOnNullUpdateId()
        {
            await Assert.ThrowsAsync<ApiException>(() => _api.UpdateAgentPoolsUpdateAsync("pool", null, new AgentPoolUpdate()));
        }

        [Fact]
        public async Task UpdateAgentPoolsUpdateAsync_ThrowsOnNullAgentPoolUpdate()
        {
            await Assert.ThrowsAsync<ApiException>(() => _api.UpdateAgentPoolsUpdateAsync("pool", "update", null));
        }

        [Fact]
        public async Task UpdateAgentPoolsUpdateSettingsAsync_ReturnsData()
        {
            var expected = new AgentPoolUpdateSetting();
            var response = new ApiResponse<AgentPoolUpdateSetting>(HttpStatusCode.OK, null, expected, null);
            _mockClient.Setup(c => c.PostAsync<AgentPoolUpdateSetting>(
                It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await _api.UpdateAgentPoolsUpdateSettingsAsync("pool", expected);

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task UpdateAgentPoolsUpdateSettingsAsync_ThrowsOnNullPoolId()
        {
            await Assert.ThrowsAsync<ApiException>(() => _api.UpdateAgentPoolsUpdateSettingsAsync(null, new AgentPoolUpdateSetting()));
        }

        [Fact]
        public async Task UpdateAgentPoolsUpdateSettingsAsync_ThrowsOnNullAgentPoolUpdateSetting()
        {
            await Assert.ThrowsAsync<ApiException>(() => _api.UpdateAgentPoolsUpdateSettingsAsync("pool", null));
        }
    }
}