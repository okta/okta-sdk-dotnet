using FluentAssertions;
using Microsoft.Extensions.Options;
using Okta.Sdk.Abstractions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Policy = Okta.Sdk.Model.Policy;

namespace Okta.Sdk.IntegrationTest
{
    public class PolicyScenarios
    {
        private PolicyApi _policyApi;
        private GroupApi _groupApi;
        private ApplicationApi _applicationApi;
        public PolicyScenarios()
        {
            _policyApi = new PolicyApi();
            _groupApi = new GroupApi();
            _applicationApi = new ApplicationApi();
        }

        [Fact]
        public async Task CreateSignOnPolicy()
        {
            
            var policy = new Policy()
            {
                // Name has a maximum of 50 chars
                Name = $"dotnet-sdk: CreateSignOnPolicy {Guid.NewGuid()}".Substring(0, 50),
                Type = PolicyType.OKTASIGNON,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await _policyApi.CreatePolicyAsync(policy);

            try
            {
                createdPolicy.Should().NotBeNull();
                createdPolicy.Name.Should().Be(policy.Name);
                createdPolicy.Type.Should().Be(PolicyType.OKTASIGNON);
                createdPolicy.Status.Should().Be(LifecycleStatus.ACTIVE);
                createdPolicy.Description.Should().Be(policy.Description);
            }
            finally
            {
                await _policyApi.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact]
        public async Task CreateProfileEnrollmentPolicy()
        {
            var policy = new Policy()
            {
                // Name has a maximum of 50 chars
                Name = $"dotnet-sdk: ProfileEnrollmentPolicy {Guid.NewGuid()}".Substring(0, 50),
                Type = PolicyType.PROFILEENROLLMENT,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await _policyApi.CreatePolicyAsync(policy);

            try
            {
                createdPolicy.Should().NotBeNull();
                createdPolicy.Name.Should().Be(policy.Name);
                createdPolicy.Type.Should().Be(PolicyType.PROFILEENROLLMENT);
                createdPolicy.Status.Should().Be(LifecycleStatus.ACTIVE);
                createdPolicy.Description.Should().Be(policy.Description);
            }
            finally
            {
                await _policyApi.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact]
        public async Task GetPolicy()
        {
            var policy = new Policy()
            {
                // Name has a maximum of 50 chars
                Name = $"dotnet-sdk: GetPolicy {Guid.NewGuid()}".Substring(0, 50),
                Type = PolicyType.OKTASIGNON,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await _policyApi.CreatePolicyAsync(policy);

            try
            {
                var retrievedPolicy = await _policyApi.GetPolicyAsync(createdPolicy.Id);

                retrievedPolicy.Should().NotBeNull();
                retrievedPolicy.Name.Should().Be(policy.Name);
                retrievedPolicy.Type.Should().Be(PolicyType.OKTASIGNON);
                retrievedPolicy.Status.Should().Be(LifecycleStatus.ACTIVE);
                retrievedPolicy.Description.Should().Be(policy.Description);
            }
            finally
            {
                await _policyApi.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact]
        public async Task GetPolicyOfType()
        {
            var guid = Guid.NewGuid();

            var policy = new OktaSignOnPolicy()
            {
                // Name has a maximum of 50 chars
                Name = $"dotnet-sdk: GetPolicyOfType {guid}".Substring(0, 50),
                Type = PolicyType.OKTASIGNON,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await _policyApi.CreatePolicyAsync(policy);

            try
            {
                var retrievedPolicy = await _policyApi.GetPolicyAsync(createdPolicy.Id) as OktaSignOnPolicy;

                retrievedPolicy.Should().NotBeNull();
                retrievedPolicy.Should().BeAssignableTo<OktaSignOnPolicy>();
                retrievedPolicy.Name.Should().Be(policy.Name);
                retrievedPolicy.Type.Should().Be(PolicyType.OKTASIGNON);
                retrievedPolicy.Status.Should().Be(LifecycleStatus.ACTIVE);
                retrievedPolicy.Description.Should().Be(policy.Description);
            }
            finally
            {
                await _policyApi.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact]
        public async Task CreateSignOnPolicyWithGroupConditions()
        {
            var guid = Guid.NewGuid();

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: CreateSignOnPolicyWithGroupConditions {guid}",
                }
            };

            var createdGroup = await _groupApi.CreateGroupAsync(group);

            var policy = new OktaSignOnPolicy()
            {
                // Name has a maximum of 50 chars
                Name = $"dotnet-sdk: CreateSignOnPolicyWithGroupConditions {guid}".Substring(0, 50),
                Type = PolicyType.OKTASIGNON,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var policyConditions = new OktaSignOnPolicyConditions()
            {
                People = new PolicyPeopleCondition()
                {
                    Groups = new GroupCondition()
                    {
                        Include = new List<string>() { createdGroup.Id },
                    },
                },
            };

            policy.Conditions = policyConditions;

            var createdPolicy = await _policyApi.CreatePolicyAsync(policy) as OktaSignOnPolicy;

            try
            {
                createdPolicy.Should().NotBeNull();
                createdPolicy.Name.Should().Be(policy.Name);
                createdPolicy.Type.Should().Be(PolicyType.OKTASIGNON);
                createdPolicy.Status.Should().Be(LifecycleStatus.ACTIVE);
                createdPolicy.Description.Should().Be(policy.Description);
                createdPolicy.Conditions.Should().NotBeNull();
                createdPolicy.Conditions.People.Groups.Should().NotBeNull();
                createdPolicy.Conditions.People.Groups.Include.Should().HaveCount(1);
                createdPolicy.Conditions.People.Groups.Include.First().Should().Be(createdGroup.Id);
            }
            finally
            {
                await _groupApi.DeleteGroupAsync(createdGroup.Id);
                await _policyApi.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact]
        public async Task DeletePolicy()
        {
            var policy = new OktaSignOnPolicy()
            {
                // Name has a maximum of 50 chars
                Name = $"dotnet-sdk: DeletePolicy {Guid.NewGuid()}".Substring(0, 50),
                Type = PolicyType.OKTASIGNON,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await _policyApi.CreatePolicyAsync(policy);
            var retrievedPolicy = await _policyApi.GetPolicyAsync(createdPolicy.Id);
            retrievedPolicy.Should().NotBeNull();

            await _policyApi.DeactivatePolicyAsync(createdPolicy.Id);
            await _policyApi.DeletePolicyAsync(createdPolicy.Id);
            
            // Getting by ID should result in 404 Not found
            await Assert.ThrowsAsync<ApiException>(async () => await _policyApi.GetPolicyAsync(createdPolicy.Id));
        }

        [Fact]
        public async Task UpdatePolicy()
        {
            var policy = new OktaSignOnPolicy()
            {
                // Name has a maximum of 50 chars
                Name = $"dotnet-sdk: UpdatePolicy {Guid.NewGuid()}".Substring(0, 50),
                Type = PolicyType.OKTASIGNON,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await _policyApi.CreatePolicyAsync(policy);

            createdPolicy.Name = $"dotnet-sdk: Updated UpdatePolicy {Guid.NewGuid()}".Substring(0, 50);
            createdPolicy.Description = "This description was updated";

            await _policyApi.UpdatePolicyAsync(createdPolicy.Id, createdPolicy);

            var updatedPolicy = await _policyApi.GetPolicyAsync(createdPolicy.Id);

            try
            {
                updatedPolicy.Id.Should().Be(createdPolicy.Id);
                updatedPolicy.Type.Should().Be(createdPolicy.Type);
                updatedPolicy.Name.Should().StartWith("dotnet-sdk: Updated");
                updatedPolicy.Description.Should().Be("This description was updated");
            }
            finally
            {
                await _policyApi.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact]
        public async Task ActivateAnInactivePolicy()
        {
            var policy = new OktaSignOnPolicy()
            {
                // Name has a maximum of 50 chars
                Name = $"dotnet-sdk: ActivatePolicy {Guid.NewGuid()}".Substring(0, 50),
                Type = PolicyType.OKTASIGNON,
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await _policyApi.CreatePolicyAsync(policy);

            try
            {
                await _policyApi.DeactivatePolicyAsync(createdPolicy.Id);
                var retrievedPolicy = await _policyApi.GetPolicyAsync(createdPolicy.Id);

                retrievedPolicy.Status.Should().Be(LifecycleStatus.INACTIVE);
                await _policyApi.ActivatePolicyAsync(createdPolicy.Id);
                
                retrievedPolicy = await _policyApi.GetPolicyAsync(createdPolicy.Id);
                retrievedPolicy.Status.Should().Be(LifecycleStatus.ACTIVE);
            }
            finally
            {
                await _policyApi.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact]
        public async Task CreatePasswordPolicy()
        {
            var guid = Guid.NewGuid();

            var policy = new PasswordPolicy()
            {
                // Name has a maximum of 50 chars
                Name = $"dotnet-sdk: CreatePasswordPolicy {guid}".Substring(0, 50),
                Type = PolicyType.PASSWORD,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await _policyApi.CreatePolicyAsync(policy);

            try
            {
                createdPolicy.Should().NotBeNull();
                createdPolicy.Type.Should().Be(PolicyType.PASSWORD);
                createdPolicy.Status.Should().Be(LifecycleStatus.ACTIVE);
                createdPolicy.Description.Should().Be(policy.Description);
            }
            finally
            {
                await _policyApi.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact(Skip = "Depends on OKTA-542930")]
        public async Task CreateAccessPolicyPolicyRule()
        {

            var guid = Guid.NewGuid();
            Application createdApp = null;

            var app = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                SignOnMode = "OPENID_CONNECT",
                Label = $"dotnet-sdk: CreateAccessPolicyPolicyRule {guid}",
                Credentials = new OAuthApplicationCredentials()
                {
                    OauthClient = new ApplicationCredentialsOAuthClient()
                    {
                        ClientId = $"{nameof(CreateAccessPolicyPolicyRule)}{guid}_TestClientId",
                        TokenEndpointAuthMethod = "client_secret_post",
                        AutoKeyRotation = true,
                    },
                },
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient()
                    {
                        ClientUri = "https://example.com/client",
                        LogoUri = "https://example.com/assets/images/logo-new.png",
                        ResponseTypes = new List<OAuthResponseType>
                        {
                            "token",
                            "id_token",
                            "code",
                        },
                        RedirectUris = new List<string>
                        {
                            "https://example.com/oauth2/callback",
                            "myapp://callback",
                        },
                        PostLogoutRedirectUris = new List<string>
                        {
                            "https://example.com/postlogout",
                            "myapp://postlogoutcallback",
                        },
                        GrantTypes = new List<OAuthGrantType>
                        {
                            "implicit",
                            "authorization_code",
                        },
                        ApplicationType = "web",

                        TosUri = "https://example.com/client/tos",
                        PolicyUri = "https://example.com/client/policy",
                    },
                }
            };

            try
            {
                createdApp = await _applicationApi.CreateApplicationAsync(app);

                var accessPolicyId = createdApp.Links.AccessPolicy.Href.Split('/')?.LastOrDefault();

                var accessPolicyRuleOptions = new AccessPolicyRule
                {
                    Name = $"dotnet-sdk: CreateAccessPolicyRule {guid}".Substring(0, 50),
                    Type = PolicyRuleType.ACCESSPOLICY.Value,
                    Actions = new AccessPolicyRuleActions
                    {
                        AppSignOn = new AccessPolicyRuleApplicationSignOn
                        {
                            Access = "DENY",
                            VerificationMethod = new VerificationMethod
                            {
                                Type = "ASSURANCE",
                                FactorMode = "1FA",
                                ReauthenticateIn = "PT43800H",
                            },
                        },
                    },
                };

                var createdPolicyRule = await  _policyApi.CreatePolicyRuleAsync(accessPolicyId, accessPolicyRuleOptions) as AccessPolicyRule;
                    
             
                    createdPolicyRule.Should().NotBeNull();
                    createdPolicyRule.Name.Should().Be(accessPolicyRuleOptions.Name);
                    createdPolicyRule.Actions.Should().NotBeNull();
                    createdPolicyRule.Actions.AppSignOn.Access.Should().Be("DENY");
                    createdPolicyRule.Actions.AppSignOn.VerificationMethod.Type.Should().Be("ASSURANCE");
                    createdPolicyRule.Actions.AppSignOn.VerificationMethod.FactorMode.Should().Be("1FA");
                    createdPolicyRule.Actions.AppSignOn.VerificationMethod.ReauthenticateIn.Should().Be("PT43800H");
                    createdPolicyRule.Type.Should().Be(PolicyType.ACCESSPOLICY);
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp?.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp?.Id);
            }
        }

        [Fact]
        public async Task CreateProfileEnrollmentPolicyRule()
        {
            var policy = new Policy()
            {
                // Name has a maximum of 50 chars
                Name = $"dotnet-sdk: ProfileEnrollmentPolicy {Guid.NewGuid()}".Substring(0, 50),
                Type = PolicyType.PROFILEENROLLMENT,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await _policyApi.CreatePolicyAsync(policy);
            var defaultPolicyRule = await _policyApi.ListPolicyRules(createdPolicy.Id).FirstOrDefaultAsync() as ProfileEnrollmentPolicyRule;
            var profileAttributes = new List<ProfileEnrollmentPolicyRuleProfileAttribute>();
            profileAttributes.Add(new ProfileEnrollmentPolicyRuleProfileAttribute
            {
                Name = "email",
                Label = "Email",
                Required = true,
            });

            defaultPolicyRule.Actions = new ProfileEnrollmentPolicyRuleActions
            {
                ProfileEnrollment = new ProfileEnrollmentPolicyRuleAction
                {
                    Access = "ALLOW",
                    PreRegistrationInlineHooks = null,
                    ProfileAttributes = profileAttributes,
                    UnknownUserAction = "DENY",
                    TargetGroupIds = null,
                    ActivationRequirements = new ProfileEnrollmentPolicyRuleActivationRequirement
                    {
                        EmailVerification = true,
                    },
                },
            };

            try
            {
                var createdPolicyRule = await _policyApi.UpdatePolicyRuleAsync( createdPolicy.Id, defaultPolicyRule.Id, defaultPolicyRule) as ProfileEnrollmentPolicyRule;
                createdPolicyRule.Should().NotBeNull();
                createdPolicyRule.Name.Should().Be(defaultPolicyRule.Name);
                createdPolicyRule.Type.Should().Be(PolicyRuleType.PROFILEENROLLMENT);
                createdPolicyRule.Actions.Should().NotBeNull();
                createdPolicyRule.Actions.ProfileEnrollment.Should().NotBeNull();
                createdPolicyRule.Actions.ProfileEnrollment.Access.Should().Be("ALLOW");
                createdPolicyRule.Actions.ProfileEnrollment.PreRegistrationInlineHooks.Should().BeNullOrEmpty();
                createdPolicyRule.Actions.ProfileEnrollment.UnknownUserAction.Should().Be("DENY");
                createdPolicyRule.Actions.ProfileEnrollment.TargetGroupIds.Should().BeNullOrEmpty();
                createdPolicyRule.Actions.ProfileEnrollment.ActivationRequirements.EmailVerification.Should().BeTrue();
                createdPolicyRule.Actions.ProfileEnrollment.ProfileAttributes.Should().HaveCount(1);
                createdPolicyRule.Actions.ProfileEnrollment.ProfileAttributes.First().Name.Should().Be("email");
                createdPolicyRule.Actions.ProfileEnrollment.ProfileAttributes.First().Label.Should().Be("Email");
                createdPolicyRule.Actions.ProfileEnrollment.ProfileAttributes.First().Required.Should().BeTrue();
            }
            finally
            {
                await _policyApi.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact]
        public async Task CreateOktaSignOnOnPremPolicyRule()
        {   
            var guid = Guid.NewGuid();

            var policy = new OktaSignOnPolicy()
            {
                // Name has a maximum of 50 chars
                Name = $"dotnet-sdk: CreateOktaSignOnOnPremPolicyRule {guid}".Substring(0, 50),
                Type = PolicyType.OKTASIGNON,
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await _policyApi.CreatePolicyAsync(policy) as OktaSignOnPolicy;


            var policyRule = new OktaSignOnPolicyRule
            {
                Type = PolicyRuleType.SIGNON,
                Name = $"dotnet-sdk: CreateOktaSignOnOnPremPolicyRule {guid}".Substring(0, 50),
                Actions = new OktaSignOnPolicyRuleActions
                {
                    Signon = new OktaSignOnPolicyRuleSignonActions
                    {
                        Access = "ALLOW",
                        FactorLifetime = 10,
                        RememberDeviceByDefault = false,
                        Session = new OktaSignOnPolicyRuleSignonSessionActions
                        {
                            UsePersistentCookie = false,
                            MaxSessionIdleMinutes = 720,
                            MaxSessionLifetimeMinutes = 800,
                        },
                    },
                },
                Conditions = new OktaSignOnPolicyRuleConditions
                {
                    AuthContext = new PolicyRuleAuthContextCondition
                    {
                        AuthType = "ANY",
                    },
                },
            };


            var createdPolicyRule = await _policyApi.CreatePolicyRuleAsync(createdPolicy.Id, policyRule) as OktaSignOnPolicyRule;

            try
            {
                createdPolicyRule.Should().NotBeNull();
                createdPolicyRule.Name.Should().Be(policyRule.Name);
                createdPolicyRule.Type.Value.Should().Be("SIGN_ON");
                createdPolicyRule.Actions.Signon.Access.Value.Should().Be("ALLOW");
                createdPolicyRule.Actions.Signon.RequireFactor.Should().Be(false);
                createdPolicyRule.Actions.Signon.RememberDeviceByDefault.Should().Be(false);
                createdPolicyRule.Actions.Signon.Session.UsePersistentCookie.Should().Be(false);
                createdPolicyRule.Actions.Signon.Session.MaxSessionIdleMinutes.Should().Be(720);
                createdPolicyRule.Actions.Signon.Session.MaxSessionLifetimeMinutes.Should().Be(800);
                createdPolicyRule.Conditions.AuthContext.AuthType.Value.Should().Be("ANY");
            }
            finally
            {
                await _policyApi.DeletePolicyRuleAsync(createdPolicy.Id, createdPolicyRule.Id);
                await _policyApi.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact]
        public async Task CreateOktaSignOnCloudPolicyRule()
        {
            var guid = Guid.NewGuid();

            var policy = new OktaSignOnPolicy()
            {
                // Name has a maximum of 50 chars
                Name = $"dotnet-sdk: CreateOktaSignOnCloudPolicyRule {guid}".Substring(0, 50),
                Type = PolicyType.OKTASIGNON,
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await _policyApi.CreatePolicyAsync(policy);

            var policyRule = new OktaSignOnPolicyRule
            {
                Type = PolicyRuleType.SIGNON,
                Name = $"dotnet-sdk: CreateOktaSignOnCloudPolicyRule {guid}".Substring(0, 50),
                Actions = new OktaSignOnPolicyRuleActions
                {
                    Signon = new OktaSignOnPolicyRuleSignonActions
                    {
                        Access = "ALLOW",
                        FactorLifetime = 10,
                        RememberDeviceByDefault = false,
                        RequireFactor = true,
                        FactorPromptMode = "ALWAYS",
                        Session = new OktaSignOnPolicyRuleSignonSessionActions
                        {
                            UsePersistentCookie = false,
                            MaxSessionIdleMinutes = 720,
                            MaxSessionLifetimeMinutes = 800,
                        },
                    },
                },
                Conditions = new OktaSignOnPolicyRuleConditions
                {
                    Network = new PolicyNetworkCondition
                    {
                        Connection = "ANYWHERE",
                    },
                    AuthContext = new PolicyRuleAuthContextCondition
                    {
                        AuthType = "ANY",
                    },
                },
            };

            var createdPolicyRule = await _policyApi.CreatePolicyRuleAsync(createdPolicy.Id, policyRule) as OktaSignOnPolicyRule;
            try
            {
                createdPolicyRule.Should().NotBeNull();
                createdPolicyRule.Name.Should().Be(policyRule.Name);
                createdPolicyRule.Type.Value.Should().Be("SIGN_ON");
                createdPolicyRule.Actions.Signon.Access.Value.Should().Be("ALLOW");
                createdPolicyRule.Actions.Signon.RequireFactor.Should().Be(true);
                createdPolicyRule.Actions.Signon.FactorPromptMode.Value.Should().Be("ALWAYS");
                createdPolicyRule.Actions.Signon.RememberDeviceByDefault.Should().Be(false);
                createdPolicyRule.Actions.Signon.Session.UsePersistentCookie.Should().Be(false);
                createdPolicyRule.Actions.Signon.Session.MaxSessionIdleMinutes.Should().Be(720);
                createdPolicyRule.Actions.Signon.Session.MaxSessionLifetimeMinutes.Should().Be(800);
                createdPolicyRule.Conditions.AuthContext.AuthType.Value.Should().Be("ANY");
                createdPolicyRule.Conditions.Network.Connection.Value.Should().Be("ANYWHERE");
            }
            finally
            {
                await _policyApi.DeletePolicyRuleAsync(createdPolicy.Id, createdPolicyRule.Id);
                await _policyApi.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact]
        public async Task CreateOktaSignOnDenyPolicyRule()
        {
            var guid = Guid.NewGuid();

            var policy = new OktaSignOnPolicy()
            {
                // Name has a maximum of 50 chars
                Name = $"dotnet-sdk: CreateOktaSignOnDenyPolicyRule {guid}".Substring(0, 50),
                Type = PolicyType.OKTASIGNON,
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await _policyApi.CreatePolicyAsync(policy);

          
            var policyRule = new OktaSignOnPolicyRule
            {
                Type = PolicyRuleType.SIGNON,
                Name = $"dotnet-sdk: CreateOktaSignOnDenyPolicyRule {guid}".Substring(0, 50),
                Actions = new OktaSignOnPolicyRuleActions
                {
                    Signon = new OktaSignOnPolicyRuleSignonActions
                    {
                        Access = "DENY",
                        RequireFactor = false,
                    },
                },
                Conditions = new OktaSignOnPolicyRuleConditions
                {
                    Network = new PolicyNetworkCondition
                    {
                        Connection = "ANYWHERE",
                    },
                    AuthContext = new PolicyRuleAuthContextCondition
                    {
                        AuthType = "ANY",
                    },
                },
            };

            var createdPolicyRule = await _policyApi.CreatePolicyRuleAsync(createdPolicy.Id, policyRule) as OktaSignOnPolicyRule;

            try
            {
                createdPolicyRule.Should().NotBeNull();
                createdPolicyRule.Name.Should().Be(policyRule.Name);
                createdPolicyRule.Type.Value.Should().Be("SIGN_ON");
                createdPolicyRule.Actions.Signon.Access.Value.Should().Be("DENY");
                createdPolicyRule.Actions.Signon.RequireFactor.Should().Be(false);
                createdPolicyRule.Conditions.AuthContext.AuthType.Value.Should().Be("ANY");
                createdPolicyRule.Conditions.Network.Connection.Value.Should().Be("ANYWHERE");
            }
            finally
            {
                await _policyApi.DeletePolicyRuleAsync(createdPolicy.Id, createdPolicyRule.Id);
                await _policyApi.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact]
        public async Task UpdateOktaSignOnPolicyRule()
        {
            var guid = Guid.NewGuid();

            var policy = new OktaSignOnPolicy()
            {
                // Name has a maximum of 50 chars
                Name = $"dotnet-sdk: UpdateOktaSignOnPolicyRule  {guid}".Substring(0, 50),
                Type = PolicyType.OKTASIGNON,
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await _policyApi.CreatePolicyAsync(policy);

            var policyRule = new OktaSignOnPolicyRule
            {
                Type = PolicyRuleType.SIGNON,
                Name = $"dotnet-sdk: UpdateOktaSignOnPolicyRule  {guid}".Substring(0, 50),
                Actions = new OktaSignOnPolicyRuleActions
                {
                    Signon = new OktaSignOnPolicyRuleSignonActions
                    {
                        Access = "ALLOW",
                        FactorLifetime = 10,
                        RememberDeviceByDefault = false,
                        RequireFactor = true,
                        FactorPromptMode = "ALWAYS",
                        Session = new OktaSignOnPolicyRuleSignonSessionActions
                        {
                            UsePersistentCookie = false,
                            MaxSessionIdleMinutes = 720,
                            MaxSessionLifetimeMinutes = 800,
                        },
                    },
                },
                Conditions = new OktaSignOnPolicyRuleConditions
                {
                    Network = new PolicyNetworkCondition
                    {
                        Connection = "ANYWHERE",
                    },
                    AuthContext = new PolicyRuleAuthContextCondition
                    {
                        AuthType = "ANY",
                    },
                },
            };

            var createdPolicyRule = await _policyApi.CreatePolicyRuleAsync(createdPolicy.Id, policyRule) as OktaSignOnPolicyRule;
            try
            {
                createdPolicyRule.Should().NotBeNull();
                createdPolicyRule.Name.Should().Be(policyRule.Name);
                createdPolicyRule.Type.Value.Should().Be("SIGN_ON");
                createdPolicyRule.Actions.Signon.Access.Value.Should().Be("ALLOW");
                createdPolicyRule.Actions.Signon.RequireFactor.Should().Be(true);
                createdPolicyRule.Actions.Signon.FactorPromptMode.Value.Should().Be("ALWAYS");
                createdPolicyRule.Actions.Signon.RememberDeviceByDefault.Should().Be(false);
                createdPolicyRule.Actions.Signon.Session.UsePersistentCookie.Should().Be(false);
                createdPolicyRule.Actions.Signon.Session.MaxSessionIdleMinutes.Should().Be(720);
                createdPolicyRule.Actions.Signon.Session.MaxSessionLifetimeMinutes.Should().Be(800);
                createdPolicyRule.Conditions.AuthContext.AuthType.Value.Should().Be("ANY");
                createdPolicyRule.Conditions.Network.Connection.Value.Should().Be("ANYWHERE");

                createdPolicyRule.Name = $"dotnet-sdk: Updated {createdPolicyRule.Name}".Substring(0, 50);
                createdPolicyRule.Conditions.Network = new PolicyNetworkCondition() { Connection = "ANYWHERE" };

                var updatedPolicyRule = await _policyApi.UpdatePolicyRuleAsync(createdPolicy.Id, createdPolicyRule.Id, createdPolicyRule) as OktaSignOnPolicyRule;

                updatedPolicyRule.Name.Should().StartWith("dotnet-sdk: Updated");
                updatedPolicyRule.Type.Value.Should().Be("SIGN_ON");
                updatedPolicyRule.Actions.Signon.Access.Value.Should().Be("ALLOW");
                updatedPolicyRule.Actions.Signon.RequireFactor.Should().Be(true);
                updatedPolicyRule.Actions.Signon.FactorPromptMode.Value.Should().Be("ALWAYS");
                updatedPolicyRule.Actions.Signon.RememberDeviceByDefault.Should().Be(false);
                updatedPolicyRule.Actions.Signon.Session.UsePersistentCookie.Should().Be(false);
                updatedPolicyRule.Actions.Signon.Session.MaxSessionIdleMinutes.Should().Be(720);
                updatedPolicyRule.Actions.Signon.Session.MaxSessionLifetimeMinutes.Should().Be(800);
                updatedPolicyRule.Conditions.AuthContext.AuthType.Value.Should().Be("ANY");
                updatedPolicyRule.Conditions.Network.Connection.Value.Should().Be("ANYWHERE");
            }
            finally
            {
                await _policyApi.DeletePolicyRuleAsync(createdPolicy.Id, createdPolicyRule.Id);
                await _policyApi.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact]
        public async Task ListPolicyRules()
        {
            var guid = Guid.NewGuid();

            var policy = new OktaSignOnPolicy()
            {
                // Name has a maximum of 50 chars
                Name = $"dotnet-sdk: ListPolicyRules {guid}".Substring(0, 50),
                Type = PolicyType.OKTASIGNON,
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await _policyApi.CreatePolicyAsync(policy);

            var policyRule = new OktaSignOnPolicyRule
            {
                Type = PolicyRuleType.SIGNON,
                Name = $"dotnet-sdk: UpdateOktaSignOnPolicyRule  {guid}".Substring(0, 50),
                Actions = new OktaSignOnPolicyRuleActions
                {
                    Signon = new OktaSignOnPolicyRuleSignonActions
                    {
                        Access = "ALLOW",
                        FactorLifetime = 10,
                        RememberDeviceByDefault = false,
                        RequireFactor = true,
                        FactorPromptMode = "ALWAYS",
                        Session = new OktaSignOnPolicyRuleSignonSessionActions
                        {
                            UsePersistentCookie = false,
                            MaxSessionIdleMinutes = 720,
                            MaxSessionLifetimeMinutes = 800,
                        },
                    },
                },
                Conditions = new OktaSignOnPolicyRuleConditions
                {
                    Network = new PolicyNetworkCondition
                    {
                        Connection = "ANYWHERE",
                    },
                    AuthContext = new PolicyRuleAuthContextCondition
                    {
                        AuthType = "ANY",
                    },
                },
            };

            var createdPolicyRule = await _policyApi.CreatePolicyRuleAsync(createdPolicy.Id, policyRule) as OktaSignOnPolicyRule;
            try
            {
                var policyRules = await _policyApi.ListPolicyRules(createdPolicy.Id).ToListAsync();
                policyRules.Should().NotBeNullOrEmpty();
                policyRules.Any(x => x.Id == createdPolicyRule.Id).Should().BeTrue();
            }
            finally
            {
                await _policyApi.DeletePolicyRuleAsync(createdPolicy.Id, createdPolicyRule.Id);
                await _policyApi.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact]
        public async Task GetPolicyRule()
        {
            var guid = Guid.NewGuid();

            var policy = new PasswordPolicy()
            {
                // Name has a maximum of 50 chars
                Name = $"dotnet-sdk: GetPolicyRule {guid}".Substring(0, 50),
                Type = PolicyType.PASSWORD,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await _policyApi.CreatePolicyAsync(policy);

            var policyRule = new PasswordPolicyRule()
            {
                Name = $"dotnet-sdk: GetPolicyRule {guid}".Substring(0, 50),
                Type = PolicyRuleType.PASSWORD,
                Conditions = new PasswordPolicyRuleConditions()
                {
                    People = new PolicyPeopleCondition()
                    {
                        Users = new UserCondition()
                        {
                            Exclude = new List<string>(),
                        },
                    },
                },
                Actions = new PasswordPolicyRuleActions()
                {
                    PasswordChange = new PasswordPolicyRuleAction()
                    {
                        Access = "ALLOW",
                    },
                },
            };

            var createdPolicyRule = await _policyApi.CreatePolicyRuleAsync(createdPolicy.Id, policyRule) as PasswordPolicyRule;
            try
            {
                var retrievedPolicyRule = await _policyApi.GetPolicyRuleAsync(createdPolicy.Id, createdPolicyRule.Id) as PasswordPolicyRule;
                retrievedPolicyRule.Should().NotBeNull();
                retrievedPolicyRule.Id.Should().Be(createdPolicyRule.Id);
                retrievedPolicyRule.Name.Should().Be(policyRule.Name);
                retrievedPolicyRule.Type.Should().Be(PolicyRuleType.PASSWORD);
                retrievedPolicyRule.Conditions.People.Users.Exclude.Should().BeNullOrEmpty();
                retrievedPolicyRule.Actions.PasswordChange.Access.Value.Should().Be("ALLOW");
            }
            finally
            {
                await _policyApi.DeletePolicyRuleAsync(createdPolicy.Id, createdPolicyRule.Id);
                await _policyApi.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact]
        public async Task UpdatePasswordPolicyRule()
        {
            var guid = Guid.NewGuid();

            var policy = new PasswordPolicy()
            {
                // Name has a maximum of 50 chars
                Name = $"dotnet-sdk: UpdatePasswordPolicyRule {guid}".Substring(0, 50),
                Type = PolicyType.PASSWORD,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await _policyApi.CreatePolicyAsync(policy);

            var policyRule = new PasswordPolicyRule()
            {
                Name = $"dotnet-sdk: UpdatePasswordPolicyRule {guid}".Substring(0, 50),
                Type = PolicyRuleType.PASSWORD,
                Conditions = new PasswordPolicyRuleConditions()
                {
                    People = new PolicyPeopleCondition()
                    {
                        Users = new UserCondition()
                        {
                            Exclude = new List<string>(),
                        },
                    },
                },
                Actions = new PasswordPolicyRuleActions()
                {
                    PasswordChange = new PasswordPolicyRuleAction()
                    {
                        Access = "ALLOW",
                    },
                },
            };

            var createdPolicyRule = await _policyApi.CreatePolicyRuleAsync(createdPolicy.Id, policyRule) as PasswordPolicyRule;
            try
            {
                var retrievedPolicyRule = await _policyApi.GetPolicyRuleAsync(createdPolicy.Id, createdPolicyRule.Id) as PasswordPolicyRule;
                retrievedPolicyRule.Should().NotBeNull();
                retrievedPolicyRule.Id.Should().Be(createdPolicyRule.Id);
                retrievedPolicyRule.Name.Should().Be(policyRule.Name);
                retrievedPolicyRule.Type.Should().Be(PolicyRuleType.PASSWORD);
                retrievedPolicyRule.Conditions.People.Users.Exclude.Should().BeNullOrEmpty();
                retrievedPolicyRule.Actions.PasswordChange.Access.Value.Should().Be("ALLOW");

                // Update values
                retrievedPolicyRule.Actions.PasswordChange.Access = "DENY";
                retrievedPolicyRule.Actions.SelfServicePasswordReset.Access = "DENY";
                retrievedPolicyRule.Name = $"dotnet-sdk: Updated {policyRule.Name}".Substring(0, 50);

                var updatedPolicyRule = await _policyApi.UpdatePolicyRuleAsync(createdPolicy.Id, createdPolicyRule.Id, retrievedPolicyRule) as PasswordPolicyRule;

                updatedPolicyRule.Actions.PasswordChange.Access.Value.Should().Be("DENY");
                updatedPolicyRule.Actions.SelfServicePasswordReset.Access.Value.Should().Be("DENY");
                updatedPolicyRule.Name.Should().StartWith("dotnet-sdk: Updated");
                updatedPolicyRule.Type.Should().Be(PolicyRuleType.PASSWORD);
                updatedPolicyRule.Conditions.People.Users.Exclude.Should().BeNullOrEmpty();
            }
            finally
            {
                await _policyApi.DeletePolicyRuleAsync(createdPolicy.Id, createdPolicyRule.Id);
                await _policyApi.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact]
        public async Task DeactivatePolicyRule()
        {
            var guid = Guid.NewGuid();

            var policy = new PasswordPolicy()
            {
                // Name has a maximum of 50 chars
                Name = $"dotnet-sdk: DeactivatePolicyRule {guid}".Substring(0, 50),
                Type = PolicyType.PASSWORD,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await _policyApi.CreatePolicyAsync(policy);

            var policyRule = new PasswordPolicyRule()
            {
                Name = $"dotnet-sdk: DeactivatePolicyRule {guid}".Substring(0, 50),
                Type = PolicyRuleType.PASSWORD,
                Conditions = new PasswordPolicyRuleConditions()
                {
                    People = new PolicyPeopleCondition()
                    {
                        Users = new UserCondition()
                        {
                            Exclude = new List<string>(),
                        },
                    },
                },
                Actions = new PasswordPolicyRuleActions()
                {
                    PasswordChange = new PasswordPolicyRuleAction()
                    {
                        Access = "ALLOW",
                    },
                },
            };

            var createdPolicyRule = await _policyApi.CreatePolicyRuleAsync(createdPolicy.Id, policyRule) as PasswordPolicyRule;
            try
            {
                var retrievedPolicyRule = await _policyApi.GetPolicyRuleAsync(createdPolicy.Id, createdPolicyRule.Id) as PasswordPolicyRule;
                retrievedPolicyRule.Should().NotBeNull();
                // Default status
                retrievedPolicyRule.Status.Value.Should().Be("ACTIVE");

                await _policyApi.DeactivatePolicyRuleAsync(createdPolicy.Id, createdPolicyRule.Id);
                retrievedPolicyRule = await _policyApi.GetPolicyRuleAsync(createdPolicy.Id, createdPolicyRule.Id) as PasswordPolicyRule;
                retrievedPolicyRule.Status.Value.Should().Be("INACTIVE");

            }
            finally
            {
                await _policyApi.DeletePolicyRuleAsync(createdPolicy.Id, createdPolicyRule.Id);
                await _policyApi.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact]
        public async Task ActivateAnInactivePolicyRule()
        {
            var guid = Guid.NewGuid();

            var policy = new PasswordPolicy()
            {
                // Name has a maximum of 50 chars
                Name = $"dotnet-sdk: ActivateAnInactivePolicyRule {guid}".Substring(0, 50),
                Type = PolicyType.PASSWORD,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await _policyApi.CreatePolicyAsync(policy);

            var policyRule = new PasswordPolicyRule()
            {
                Name = $"dotnet-sdk: ActivateAnInactivePolicyRule {guid}".Substring(0, 50),
                Type = PolicyRuleType.PASSWORD,
                Conditions = new PasswordPolicyRuleConditions()
                {
                    People = new PolicyPeopleCondition()
                    {
                        Users = new UserCondition()
                        {
                            Exclude = new List<string>(),
                        },
                    },
                },
                Actions = new PasswordPolicyRuleActions()
                {
                    PasswordChange = new PasswordPolicyRuleAction()
                    {
                        Access = "ALLOW",
                    },
                },
            };

            var createdPolicyRule = await _policyApi.CreatePolicyRuleAsync(createdPolicy.Id, policyRule);
            Assert.NotNull(createdPolicyRule);
            Thread.Sleep(3000);

            try
            {
                var retrievedPolicyRule = await _policyApi.GetPolicyRuleAsync(createdPolicy.Id, createdPolicyRule.Id) as PasswordPolicyRule;
                retrievedPolicyRule.Should().NotBeNull();
                // Default status
                retrievedPolicyRule.Status.Value.Should().Be("ACTIVE");

                await _policyApi.DeactivatePolicyRuleAsync(createdPolicy.Id, createdPolicyRule.Id);
                retrievedPolicyRule = await _policyApi.GetPolicyRuleAsync(createdPolicy.Id, createdPolicyRule.Id) as PasswordPolicyRule;
                retrievedPolicyRule.Status.Value.Should().Be("INACTIVE");

                await _policyApi.ActivatePolicyRuleAsync(createdPolicy.Id, createdPolicyRule.Id);
                retrievedPolicyRule = await _policyApi.GetPolicyRuleAsync(createdPolicy.Id, createdPolicyRule.Id) as PasswordPolicyRule;
                retrievedPolicyRule.Status.Value.Should().Be("ACTIVE");

            }
            finally
            {
                await _policyApi.DeletePolicyRuleAsync(createdPolicy.Id, createdPolicyRule.Id);
                await _policyApi.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact(Skip = "API not supported")]
        public async Task AssignApplicationToPolicy()
        {
            var guid = Guid.NewGuid();

            var app = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                SignOnMode = "OPENID_CONNECT",
                Label = $"dotnet-sdk: AssignApplicationToPolicy {guid}",
                Credentials = new OAuthApplicationCredentials()
                {
                    OauthClient = new ApplicationCredentialsOAuthClient()
                    {
                        ClientId = $"{nameof(AssignApplicationToPolicy)}_TestClientId",
                        TokenEndpointAuthMethod = "client_secret_post",
                        AutoKeyRotation = true,
                    },
                },
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient()
                    {
                        ClientUri = "https://example.com/client",
                        LogoUri = "https://example.com/assets/images/logo-new.png",
                        ResponseTypes = new List<OAuthResponseType>
                        {
                            "token",
                            "id_token",
                            "code",
                        },
                        RedirectUris = new List<string>
                        {
                            "https://example.com/oauth2/callback",
                            "myapp://callback",
                        },
                        PostLogoutRedirectUris = new List<string>
                        {
                            "https://example.com/postlogout",
                            "myapp://postlogoutcallback",
                        },
                        GrantTypes = new List<OAuthGrantType>
                        {
                            "implicit",
                            "authorization_code",
                        },
                        ApplicationType = "native",

                        TosUri = "https://example.com/client/tos",
                        PolicyUri = "https://example.com/client/policy",
                    },
                }
            };
            var createdApp = await _applicationApi.CreateApplicationAsync(app);


            var policy1 = new Policy()
            {
                // Name has a maximum of 50 chars
                Name = $"dotnet-sdk: AccessPolicy {Guid.NewGuid()}".Substring(0, 50),
                Type = PolicyType.ACCESSPOLICY,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy1 = await _policyApi.CreatePolicyAsync(policy1);

            var policy2 = new Policy()
            {
                // Name has a maximum of 50 chars
                Name = $"dotnet-sdk: AccessPolicy {Guid.NewGuid()}".Substring(0, 50),
                Type = PolicyType.ACCESSPOLICY,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy2 = await _policyApi.CreatePolicyAsync(policy2);

            try
            {
                //await createdApp.UpdateApplicationPolicyAsync(createdPolicy1.Id);
                //var updatedApp = await _applicationApi.GetApplicationAsync(createdApp.Id);
                //updatedApp.GetAccessPolicyId().Should().Be(createdPolicy1.Id);

                //await createdApp.UpdateApplicationPolicyAsync(createdPolicy2.Id);
                //updatedApp = await _applicationApi.GetApplicationAsync(createdApp.Id);
                //updatedApp.GetAccessPolicyId().Should().Be(createdPolicy2.Id);
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
                await _policyApi.DeletePolicyAsync(createdPolicy1.Id);
                await _policyApi.DeletePolicyAsync(createdPolicy2.Id);
            }
        }

    }
}
