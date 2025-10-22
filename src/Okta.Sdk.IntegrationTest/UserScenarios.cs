using System.Collections.Generic;
using System.Threading.Tasks;
using Okta.Sdk.Api;
using Xunit;
using Xunit.Abstractions;

namespace Okta.Sdk.IntegrationTest
{

    [Collection(name: nameof(UserScenarios))]
    public class UserScenarios
    {
        private readonly UserApi _userApi;
        private readonly UserAuthenticatorEnrollmentsApi _userAuthenticatorEnrollmentsApi;
        private readonly UserClassificationApi _userClassificationApi;
        private readonly UserCredApi _userCredApi;
        private readonly UserFactorApi _userFactorsApi;
        private readonly UserGrantApi _userGrantsApi;
        private readonly UserLifecycleApi _userLifecycleApi;
        private readonly UserLinkedObjectApi _userLinkedObjectApi;
        private readonly UserOAuthApi _userOAuthApi;
        private readonly UserResourcesApi _userResourcesApi;
        private readonly UserRiskApi _userRiskApi;
        private readonly UserSessionsApi _userSessionsApi;
        private readonly UserTypeApi _userTypeApi;
        private readonly ProfileMappingApi _profileMappingApi;
        private readonly List<string> _createdUserIds;
        private readonly ITestOutputHelper _output;

        public UserScenarios(ITestOutputHelper output)
        {
            _output = output;
            _createdUserIds = new List<string>();

            _userApi = new UserApi();
            _userAuthenticatorEnrollmentsApi = new UserAuthenticatorEnrollmentsApi();
            _userClassificationApi = new UserClassificationApi();
            _userCredApi = new UserCredApi();
            _userFactorsApi = new UserFactorApi();
            _userGrantsApi = new UserGrantApi();
            _userLifecycleApi = new UserLifecycleApi();
            _userLinkedObjectApi = new UserLinkedObjectApi();
            _userOAuthApi = new UserOAuthApi();
            _userResourcesApi = new UserResourcesApi();
            _userRiskApi = new UserRiskApi();
            _userSessionsApi = new UserSessionsApi();
            _userTypeApi = new UserTypeApi();
            _profileMappingApi = new ProfileMappingApi();
        }
    }
}