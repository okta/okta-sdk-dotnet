using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    public class IdentityProvidersScenarios
    {
        private IdentityProviderApi _idpApi;

        public IdentityProvidersScenarios()
        {
            _idpApi = new IdentityProviderApi();

            DeleteAllIdps().Wait();
        }

        private async Task DeleteAllIdps()
        {
            var idps = await _idpApi.ListIdentityProvidersAsync().ToListAsync();

            // Deactivate idps.
            foreach (var idp in idps)
            {
                await _idpApi.DeactivateIdentityProviderAsync(idp.Id);
                await _idpApi.DeleteIdentityProviderAsync(idp.Id);
            }
        }

        [Fact]
        public async Task AddGenericOidcIdp()
        {
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = new IdentityProvider()
            {
                Type = "OIDC",
                Name = $"dotnet-sdk:AddGeneric{randomSuffix}",
                Protocol = new Protocol()
                {
                    Algorithms = new ProtocolAlgorithms()
                    {
                        Request = new ProtocolAlgorithmType()
                        {
                            Signature = new ProtocolAlgorithmTypeSignature()
                            {
                                Algorithm = "SHA-256",
                                Scope = ProtocolAlgorithmTypeSignatureScope.REQUEST,
                            },
                        },
                        Response = new ProtocolAlgorithmType()
                        {
                            Signature = new ProtocolAlgorithmTypeSignature()
                            {
                                Algorithm = "SHA-256",
                                Scope = ProtocolAlgorithmTypeSignatureScope.ANY,
                            },
                        },
                    },
                    Endpoints = new ProtocolEndpoints()
                    {
                        Acs = new ProtocolEndpoint()
                        {
                            Binding = ProtocolEndpointBinding.POST,
                            Type = ProtocolEndpointType.INSTANCE,
                        },
                        Authorization = new ProtocolEndpoint()
                        {
                            Binding = ProtocolEndpointBinding.REDIRECT,
                            Url = "https://idp.example.com/authorize",
                        },
                        Token = new ProtocolEndpoint()
                        {
                            Binding = ProtocolEndpointBinding.POST,
                            Url = "https://idp.example.com/token",
                        },
                        UserInfo = new ProtocolEndpoint()
                        {
                            Binding = ProtocolEndpointBinding.REDIRECT,
                            Url = "https://idp.example.com/userinfo",
                        },
                        Jwks = new ProtocolEndpoint()
                        {
                            Binding = ProtocolEndpointBinding.REDIRECT,
                            Url = "https://idp.example.com/keys",
                        },
                    },
                    Scopes = new List<string>() { "openid", "profile", "email" },
                    Type = ProtocolType.OAUTH2,
                    Credentials = new IdentityProviderCredentials()
                    {
                        _Client = new IdentityProviderCredentialsClient()
                        {
                            ClientId = "your-client-id",
                            ClientSecret = "your-client-secret",
                        },
                    },
                    Issuer = new ProtocolEndpoint()
                    {
                        Url = "https://idp.example.com",
                    },
                },
                Policy = new IdentityProviderPolicy()
                {
                    AccountLink = new PolicyAccountLink()
                    {
                        Action = PolicyAccountLinkAction.AUTO,
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = ProvisioningAction.AUTO,
                        Conditions = new ProvisioningConditions()
                        {
                            Deprovisioned = new ProvisioningDeprovisionedCondition()
                            {
                                Action = ProvisioningDeprovisionedAction.NONE,
                            },
                            Suspended = new ProvisioningSuspendedCondition()
                            {
                                Action = ProvisioningSuspendedAction.NONE,
                            },
                        },
                        Groups = new ProvisioningGroups()
                        {
                            Action = ProvisioningGroupsAction.NONE,
                        },
                    },
                    MaxClockSkew = 120000,
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = PolicySubjectMatchType.USERNAME,
                    },
                },
            };

            var createdIdp = await _idpApi.CreateIdentityProviderAsync(idp);

            try
            {
                createdIdp.Should().NotBeNull();
                createdIdp.Name.Should().Be($"dotnet-sdk:AddGeneric{randomSuffix}");
                createdIdp.Type.Should().Be("OIDC");
                createdIdp.Status.Should().Be(LifecycleStatus.ACTIVE);
                createdIdp.Protocol.Type.Should().Be(ProtocolType.OIDC);
                createdIdp.Protocol.Endpoints.Authorization.Url.Should().Be("https://idp.example.com/authorize");
                createdIdp.Protocol.Endpoints.Authorization.Binding.Should().Be(ProtocolEndpointBinding.REDIRECT);
                createdIdp.Protocol.Endpoints.Token.Url.Should().Be("https://idp.example.com/token");
                createdIdp.Protocol.Endpoints.Token.Binding.Should().Be(ProtocolEndpointBinding.POST);
                createdIdp.Protocol.Endpoints.UserInfo.Url.Should().Be("https://idp.example.com/userinfo");
                createdIdp.Protocol.Endpoints.UserInfo.Binding.Should().Be(ProtocolEndpointBinding.REDIRECT);
                createdIdp.Protocol.Endpoints.Jwks.Url.Should().Be("https://idp.example.com/keys");
                createdIdp.Protocol.Endpoints.Jwks.Binding.Should().Be(ProtocolEndpointBinding.REDIRECT);
                createdIdp.Protocol.Scopes.Should().ContainInOrder("openid", "profile", "email");
                createdIdp.Protocol.Issuer.Url.Should().Be("https://idp.example.com");
                createdIdp.Protocol.Credentials._Client.ClientId.Should().Be("your-client-id");
                createdIdp.Protocol.Credentials._Client.ClientSecret.Should().Be("your-client-secret");
                createdIdp.Policy.Provisioning.Action.Should().Be(ProvisioningAction.AUTO);
                createdIdp.Policy.Provisioning.ProfileMaster.Should().BeFalse();
                createdIdp.Policy.Provisioning.Groups.Action.Should().Be(ProvisioningGroupsAction.NONE);
                createdIdp.Policy.Provisioning.Conditions.Deprovisioned.Action.Should().Be(ProvisioningDeprovisionedAction.NONE);
                createdIdp.Policy.Provisioning.Conditions.Suspended.Action.Should().Be(ProvisioningSuspendedAction.NONE);
                createdIdp.Policy.AccountLink.Action.Should().Be(PolicyAccountLinkAction.AUTO);
                createdIdp.Policy.Subject.UserNameTemplate.Template.Should().Be("idpuser.email");
                createdIdp.Policy.Subject.Filter.Should().BeNull();
                createdIdp.Policy.Subject.MatchType.Value.Should().Be(PolicySubjectMatchType.USERNAME);
                createdIdp.Policy.Subject.MatchAttribute.Should().BeNull();
            }
            finally
            {
                await _idpApi.DeactivateIdentityProviderAsync(createdIdp.Id);
                await _idpApi.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task AddFacebookIdp()
        {
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = new IdentityProvider()
            {
                Type = "FACEBOOK",
                Name = $"dotnet-sdk:AddFacebook{randomSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "public_profile", "email" },
                    Type = ProtocolType.OAUTH2,
                    Credentials = new IdentityProviderCredentials()
                    {
                        _Client = new IdentityProviderCredentialsClient()
                        {
                            ClientId = "your-client-id",
                            ClientSecret = "your-client-secret",
                        },
                    },
                },
                Policy = new IdentityProviderPolicy()
                {
                    AccountLink = new PolicyAccountLink()
                    {
                        Action = PolicyAccountLinkAction.AUTO,
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = ProvisioningAction.AUTO,
                        ProfileMaster = true,
                        Conditions = new ProvisioningConditions()
                        {
                            Deprovisioned = new ProvisioningDeprovisionedCondition()
                            {
                                Action = ProvisioningDeprovisionedAction.NONE,
                            },
                            Suspended = new ProvisioningSuspendedCondition()
                            {
                                Action = ProvisioningSuspendedAction.NONE,
                            },
                        },
                        Groups = new ProvisioningGroups()
                        {
                            Action = ProvisioningGroupsAction.NONE,
                        },
                    },
                    MaxClockSkew = 0,
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = PolicySubjectMatchType.USERNAME,
                        Filter = null,
                    },
                },
            };

            var createdIdp = await _idpApi.CreateIdentityProviderAsync(idp);

            try
            {
                createdIdp.Should().NotBeNull();
                createdIdp.Name.Should().Be($"dotnet-sdk:AddFacebook{randomSuffix}");
                createdIdp.Type.Should().Be("FACEBOOK");
                createdIdp.Status.Should().Be(LifecycleStatus.ACTIVE);
                createdIdp.Protocol.Type.Should().Be(ProtocolType.OAUTH2);
                createdIdp.Protocol.Scopes.Should().ContainInOrder("public_profile", "email");
                createdIdp.Protocol.Credentials._Client.ClientId.Should().Be("your-client-id");
                createdIdp.Protocol.Credentials._Client.ClientSecret.Should().Be("your-client-secret");
                createdIdp.Policy.Provisioning.Action.Should().Be(ProvisioningAction.AUTO);
                createdIdp.Policy.Provisioning.ProfileMaster.Should().BeTrue();
                createdIdp.Policy.Provisioning.Groups.Action.Should().Be(ProvisioningGroupsAction.NONE);
                createdIdp.Policy.Provisioning.Conditions.Deprovisioned.Action.Should().Be(ProvisioningDeprovisionedAction.NONE);
                createdIdp.Policy.Provisioning.Conditions.Suspended.Action.Should().Be(ProvisioningSuspendedAction.NONE);
                createdIdp.Policy.AccountLink.Action.Should().Be(PolicyAccountLinkAction.AUTO);
                createdIdp.Policy.Subject.UserNameTemplate.Template.Should().Be("idpuser.email");
                createdIdp.Policy.Subject.Filter.Should().BeNull();
                createdIdp.Policy.Subject.MatchType.Value.Should().Be(PolicySubjectMatchType.USERNAME);
            }
            finally
            {
                await _idpApi.DeactivateIdentityProviderAsync(createdIdp.Id);
                await _idpApi.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task AddGoogleIdp()
        {
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = new IdentityProvider()
            {
                Type = "GOOGLE",
                Name = $"dotnet-sdk:AddGoogleIdp{randomSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "public_profile", "email", "openid" },
                    Type = ProtocolType.OIDC,
                    Credentials = new IdentityProviderCredentials()
                    {
                        _Client = new IdentityProviderCredentialsClient()
                        {
                            ClientId = "your-client-id",
                            ClientSecret = "your-client-secret",
                        },
                    },
                },
                Policy = new IdentityProviderPolicy()
                {
                    AccountLink = new PolicyAccountLink()
                    {
                        Action = PolicyAccountLinkAction.AUTO,
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = ProvisioningAction.AUTO,
                        ProfileMaster = true,
                        Conditions = new ProvisioningConditions()
                        {
                            Deprovisioned = new ProvisioningDeprovisionedCondition()
                            {
                                Action = ProvisioningDeprovisionedAction.NONE,
                            },
                            Suspended = new ProvisioningSuspendedCondition()
                            {
                                Action = ProvisioningSuspendedAction.NONE,
                            },
                        },
                        Groups = new ProvisioningGroups()
                        {
                            Action = ProvisioningGroupsAction.NONE,
                        },
                    },
                    MaxClockSkew = 0,
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = PolicySubjectMatchType.USERNAME,
                        Filter = null,
                    },
                },
            };

            var createdIdp = await _idpApi.CreateIdentityProviderAsync(idp);

            try
            {
                createdIdp.Should().NotBeNull();
                createdIdp.Name.Should().Be($"dotnet-sdk:AddGoogleIdp{randomSuffix}");
                createdIdp.Type.Should().Be("GOOGLE");
                createdIdp.Status.Should().Be(LifecycleStatus.ACTIVE);
                createdIdp.Protocol.Type.Should().Be(ProtocolType.OIDC);
                createdIdp.Protocol.Scopes.Should().ContainInOrder("public_profile", "email", "openid");
                createdIdp.Protocol.Credentials._Client.ClientId.Should().Be("your-client-id");
                createdIdp.Protocol.Credentials._Client.ClientSecret.Should().Be("your-client-secret");
                createdIdp.Policy.Provisioning.Action.Should().Be(ProvisioningAction.AUTO);
                createdIdp.Policy.Provisioning.ProfileMaster.Should().BeTrue();
                createdIdp.Policy.Provisioning.Groups.Action.Should().Be(ProvisioningGroupsAction.NONE);
                createdIdp.Policy.Provisioning.Conditions.Deprovisioned.Action.Should().Be(ProvisioningDeprovisionedAction.NONE);
                createdIdp.Policy.Provisioning.Conditions.Suspended.Action.Should().Be(ProvisioningSuspendedAction.NONE);
                createdIdp.Policy.AccountLink.Action.Should().Be(PolicyAccountLinkAction.AUTO);
                createdIdp.Policy.Subject.UserNameTemplate.Template.Should().Be("idpuser.email");
                createdIdp.Policy.Subject.Filter.Should().BeNull();
                createdIdp.Policy.Subject.MatchType.Value.Should().Be(PolicySubjectMatchType.USERNAME);
            }
            finally
            {
                await _idpApi.DeactivateIdentityProviderAsync(createdIdp.Id);
                await _idpApi.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task AddLinkedInIdp()
        {
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = new IdentityProvider()
            {
                Type = "LINKEDIN",
                Name = $"dotnet-sdk:AddLinkedInIdp{randomSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "r_basicprofile", "r_emailaddress" },
                    Type = ProtocolType.OAUTH2,
                    Credentials = new IdentityProviderCredentials()
                    {
                        _Client = new IdentityProviderCredentialsClient()
                        {
                            ClientId = "your-client-id",
                            ClientSecret = "your-client-secret",
                        },
                    },
                },
                Policy = new IdentityProviderPolicy()
                {
                    AccountLink = new PolicyAccountLink()
                    {
                        Action = PolicyAccountLinkAction.AUTO,
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = ProvisioningAction.AUTO,
                        ProfileMaster = true,
                        Conditions = new ProvisioningConditions()
                        {
                            Deprovisioned = new ProvisioningDeprovisionedCondition()
                            {
                                Action = ProvisioningDeprovisionedAction.NONE,
                            },
                            Suspended = new ProvisioningSuspendedCondition()
                            {
                                Action = ProvisioningSuspendedAction.NONE,
                            },
                        },
                        Groups = new ProvisioningGroups()
                        {
                            Action = ProvisioningGroupsAction.NONE,
                        },
                    },
                    MaxClockSkew = 0,
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = PolicySubjectMatchType.USERNAME,
                        Filter = null,
                    },
                },
            };

            var createdIdp = await _idpApi.CreateIdentityProviderAsync(idp);

            try
            {
                createdIdp.Should().NotBeNull();
                createdIdp.Name.Should().Be($"dotnet-sdk:AddLinkedInIdp{randomSuffix}");
                createdIdp.Type.Should().Be("LINKEDIN");
                createdIdp.Status.Should().Be(LifecycleStatus.ACTIVE);
                createdIdp.Protocol.Type.Should().Be(ProtocolType.OAUTH2);
                createdIdp.Protocol.Scopes.Should().ContainInOrder("r_basicprofile", "r_emailaddress");
                createdIdp.Protocol.Credentials._Client.ClientId.Should().Be("your-client-id");
                createdIdp.Protocol.Credentials._Client.ClientSecret.Should().Be("your-client-secret");
                createdIdp.Policy.Provisioning.Action.Should().Be(ProvisioningAction.AUTO);
                createdIdp.Policy.Provisioning.ProfileMaster.Should().BeTrue();
                createdIdp.Policy.Provisioning.Groups.Action.Should().Be(ProvisioningGroupsAction.NONE);
                createdIdp.Policy.Provisioning.Conditions.Deprovisioned.Action.Should().Be(ProvisioningDeprovisionedAction.NONE);
                createdIdp.Policy.Provisioning.Conditions.Suspended.Action.Should().Be(ProvisioningSuspendedAction.NONE);
                createdIdp.Policy.AccountLink.Action.Should().Be(PolicyAccountLinkAction.AUTO);
                createdIdp.Policy.Subject.UserNameTemplate.Template.Should().Be("idpuser.email");
                createdIdp.Policy.Subject.Filter.Should().BeNull();
                createdIdp.Policy.Subject.MatchType.Value.Should().Be(PolicySubjectMatchType.USERNAME);
            }
            finally
            {
                await _idpApi.DeactivateIdentityProviderAsync(createdIdp.Id);
                await _idpApi.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task AddMicrosoftIdp()
        {
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = new IdentityProvider()
            {
                Type = "MICROSOFT",
                Name = $"dotnet-sdk:AddMicrosoftIdp{randomSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "openid", "email", "profile", "https://graph.microsoft.com/User.Read" },
                    Type = ProtocolType.OIDC,
                    Credentials = new IdentityProviderCredentials()
                    {
                        _Client = new IdentityProviderCredentialsClient()
                        {
                            ClientId = "your-client-id",
                            ClientSecret = "your-client-secret",
                        },
                    },
                },
                Policy = new IdentityProviderPolicy()
                {
                    AccountLink = new PolicyAccountLink()
                    {
                        Action = PolicyAccountLinkAction.AUTO,
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = ProvisioningAction.AUTO,
                        ProfileMaster = true,
                        Conditions = new ProvisioningConditions()
                        {
                            Deprovisioned = new ProvisioningDeprovisionedCondition()
                            {
                                Action = ProvisioningDeprovisionedAction.NONE,
                            },
                            Suspended = new ProvisioningSuspendedCondition()
                            {
                                Action = ProvisioningSuspendedAction.NONE,
                            },
                        },
                        Groups = new ProvisioningGroups()
                        {
                            Action = ProvisioningGroupsAction.NONE,
                        },
                    },
                    MaxClockSkew = 0,
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.userPrincipalName",
                        },
                        MatchType = PolicySubjectMatchType.USERNAME,
                        Filter = null,
                    },
                },
            };

            var createdIdp = await _idpApi.CreateIdentityProviderAsync(idp);

            try
            {
                createdIdp.Should().NotBeNull();
                createdIdp.Name.Should().Be($"dotnet-sdk:AddMicrosoftIdp{randomSuffix}");
                createdIdp.Type.Should().Be("MICROSOFT");
                createdIdp.Status.Should().Be(LifecycleStatus.ACTIVE);
                createdIdp.Protocol.Type.Should().Be(ProtocolType.OIDC);
                createdIdp.Protocol.Scopes.Should().ContainInOrder("openid", "email", "profile", "https://graph.microsoft.com/User.Read");
                createdIdp.Protocol.Credentials._Client.ClientId.Should().Be("your-client-id");
                createdIdp.Protocol.Credentials._Client.ClientSecret.Should().Be("your-client-secret");
                createdIdp.Policy.Provisioning.Action.Should().Be(ProvisioningAction.AUTO);
                createdIdp.Policy.Provisioning.ProfileMaster.Should().BeTrue();
                createdIdp.Policy.Provisioning.Groups.Action.Should().Be(ProvisioningGroupsAction.NONE);
                createdIdp.Policy.Provisioning.Conditions.Deprovisioned.Action.Should().Be(ProvisioningDeprovisionedAction.NONE);
                createdIdp.Policy.Provisioning.Conditions.Suspended.Action.Should().Be(ProvisioningSuspendedAction.NONE);
                createdIdp.Policy.AccountLink.Action.Should().Be(PolicyAccountLinkAction.AUTO);
                createdIdp.Policy.Subject.UserNameTemplate.Template.Should().Be("idpuser.userPrincipalName");
                createdIdp.Policy.Subject.Filter.Should().BeNull();
                createdIdp.Policy.Subject.MatchType.Value.Should().Be(PolicySubjectMatchType.USERNAME);
            }
            finally
            {
                await _idpApi.DeactivateIdentityProviderAsync(createdIdp.Id);
                await _idpApi.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task GetIdp()
        {
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = new IdentityProvider()
            {
                Type = "LINKEDIN",
                Name = $"dotnet-sdk:GetIdp{randomSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "r_basicprofile", "r_emailaddress" },
                    Type = ProtocolType.OAUTH2,
                    Credentials = new IdentityProviderCredentials()
                    {
                        _Client = new IdentityProviderCredentialsClient()
                        {
                            ClientId = "your-client-id",
                            ClientSecret = "your-client-secret",
                        },
                    },
                },
                Policy = new IdentityProviderPolicy()
                {
                    AccountLink = new PolicyAccountLink()
                    {
                        Action = PolicyAccountLinkAction.AUTO,
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = ProvisioningAction.AUTO,
                        ProfileMaster = true,
                        Conditions = new ProvisioningConditions()
                        {
                            Deprovisioned = new ProvisioningDeprovisionedCondition()
                            {
                                Action = ProvisioningDeprovisionedAction.NONE,
                            },
                            Suspended = new ProvisioningSuspendedCondition()
                            {
                                Action = ProvisioningSuspendedAction.NONE,
                            },
                        },
                        Groups = new ProvisioningGroups()
                        {
                            Action = ProvisioningGroupsAction.NONE,
                        },
                    },
                    MaxClockSkew = 0,
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = PolicySubjectMatchType.USERNAME,
                        Filter = null,
                    },
                },
            };

            var createdIdp = await _idpApi.CreateIdentityProviderAsync(idp);

            try
            {
                var retrievedIdp = await _idpApi.GetIdentityProviderAsync(createdIdp.Id);
                retrievedIdp.Should().NotBeNull();
                retrievedIdp.Name.Should().Be($"dotnet-sdk:GetIdp{randomSuffix}");
                retrievedIdp.Type.Should().Be("LINKEDIN");
                retrievedIdp.Status.Should().Be(LifecycleStatus.ACTIVE);
                retrievedIdp.Protocol.Type.Should().Be(ProtocolType.OAUTH2);
                retrievedIdp.Protocol.Scopes.Should().ContainInOrder("r_basicprofile", "r_emailaddress");
                retrievedIdp.Protocol.Credentials._Client.ClientId.Should().Be("your-client-id");
                retrievedIdp.Protocol.Credentials._Client.ClientSecret.Should().Be("your-client-secret");
                retrievedIdp.Policy.Provisioning.Action.Should().Be(ProvisioningAction.AUTO);
                retrievedIdp.Policy.Provisioning.ProfileMaster.Should().BeTrue();
                retrievedIdp.Policy.Provisioning.Groups.Action.Should().Be(ProvisioningGroupsAction.NONE);
                retrievedIdp.Policy.Provisioning.Conditions.Deprovisioned.Action.Should().Be(ProvisioningDeprovisionedAction.NONE);
                retrievedIdp.Policy.Provisioning.Conditions.Suspended.Action.Should().Be(ProvisioningSuspendedAction.NONE);
                retrievedIdp.Policy.AccountLink.Action.Should().Be(PolicyAccountLinkAction.AUTO);
                retrievedIdp.Policy.Subject.UserNameTemplate.Template.Should().Be("idpuser.email");
                retrievedIdp.Policy.Subject.Filter.Should().BeNull();
                retrievedIdp.Policy.Subject.MatchType.Value.Should().Be(PolicySubjectMatchType.USERNAME);
            }
            finally
            {
                await _idpApi.DeactivateIdentityProviderAsync(createdIdp.Id);
                await _idpApi.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task GetListIdps()
        {
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = new IdentityProvider()
            {
                Type = "LINKEDIN",
                Name = $"dotnet-sdk:ListIdp{randomSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "r_basicprofile", "r_emailaddress" },
                    Type = ProtocolType.OAUTH2,
                    Credentials = new IdentityProviderCredentials()
                    {
                        _Client = new IdentityProviderCredentialsClient()
                        {
                            ClientId = "your-client-id",
                            ClientSecret = "your-client-secret",
                        },
                    },
                },
                Policy = new IdentityProviderPolicy()
                {
                    AccountLink = new PolicyAccountLink()
                    {
                        Action = PolicyAccountLinkAction.AUTO,
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = ProvisioningAction.AUTO,
                        ProfileMaster = true,
                        Conditions = new ProvisioningConditions()
                        {
                            Deprovisioned = new ProvisioningDeprovisionedCondition()
                            {
                                Action = ProvisioningDeprovisionedAction.NONE,
                            },
                            Suspended = new ProvisioningSuspendedCondition()
                            {
                                Action = ProvisioningSuspendedAction.NONE,
                            },
                        },
                        Groups = new ProvisioningGroups()
                        {
                            Action = ProvisioningGroupsAction.NONE,
                        },
                    },
                    MaxClockSkew = 0,
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = PolicySubjectMatchType.USERNAME,
                        Filter = null,
                    },
                },
            };

            var createdIdp = await _idpApi.CreateIdentityProviderAsync(idp);

            try
            {
                var idps = await _idpApi.ListIdentityProvidersAsync().ToListAsync();
                idps.Should().NotBeNullOrEmpty();
                idps.FirstOrDefault(x => x.Id == createdIdp.Id).Should().NotBeNull();
            }
            finally
            {
                await _idpApi.DeactivateIdentityProviderAsync(createdIdp.Id);
                await _idpApi.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task DeactivateIdp()
        {
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = new IdentityProvider()
            {
                Type = "LINKEDIN",
                Name = $"dotnet-sdk:DeactivateIdp{randomSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "r_basicprofile", "r_emailaddress" },
                    Type = ProtocolType.OAUTH2,
                    Credentials = new IdentityProviderCredentials()
                    {
                        _Client = new IdentityProviderCredentialsClient()
                        {
                            ClientId = "your-client-id",
                            ClientSecret = "your-client-secret",
                        },
                    },
                },
                Policy = new IdentityProviderPolicy()
                {
                    AccountLink = new PolicyAccountLink()
                    {
                        Action = PolicyAccountLinkAction.AUTO,
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = ProvisioningAction.AUTO,
                        ProfileMaster = true,
                        Conditions = new ProvisioningConditions()
                        {
                            Deprovisioned = new ProvisioningDeprovisionedCondition()
                            {
                                Action = ProvisioningDeprovisionedAction.NONE,
                            },
                            Suspended = new ProvisioningSuspendedCondition()
                            {
                                Action = ProvisioningSuspendedAction.NONE,
                            },
                        },
                        Groups = new ProvisioningGroups()
                        {
                            Action = ProvisioningGroupsAction.NONE,
                        },
                    },
                    MaxClockSkew = 0,
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = PolicySubjectMatchType.USERNAME,
                        Filter = null,
                    },
                },
            };

            var createdIdp = await _idpApi.CreateIdentityProviderAsync(idp);

            try
            {
                createdIdp.Status.Should().Be(LifecycleStatus.ACTIVE);
                await _idpApi.DeactivateIdentityProviderAsync(createdIdp.Id);
                var retrievedIdp = await _idpApi.GetIdentityProviderAsync(createdIdp.Id);
                retrievedIdp.Status.Should().Be(LifecycleStatus.INACTIVE);
            }
            finally
            {
                await _idpApi.DeactivateIdentityProviderAsync(createdIdp.Id);
                await _idpApi.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task ActivateIdp()
        {
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = new IdentityProvider()
            {
                Type = "LINKEDIN",
                Name = $"dotnet-sdk:ActivateIdp{randomSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "r_basicprofile", "r_emailaddress" },
                    Type = ProtocolType.OAUTH2,
                    Credentials = new IdentityProviderCredentials()
                    {
                        _Client = new IdentityProviderCredentialsClient()
                        {
                            ClientId = "your-client-id",
                            ClientSecret = "your-client-secret",
                        },
                    },
                },
                Policy = new IdentityProviderPolicy()
                {
                    AccountLink = new PolicyAccountLink()
                    {
                        Action = PolicyAccountLinkAction.AUTO,
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = ProvisioningAction.AUTO,
                        ProfileMaster = true,
                        Conditions = new ProvisioningConditions()
                        {
                            Deprovisioned = new ProvisioningDeprovisionedCondition()
                            {
                                Action = ProvisioningDeprovisionedAction.NONE,
                            },
                            Suspended = new ProvisioningSuspendedCondition()
                            {
                                Action = ProvisioningSuspendedAction.NONE,
                            },
                        },
                        Groups = new ProvisioningGroups()
                        {
                            Action = ProvisioningGroupsAction.NONE,
                        },
                    },
                    MaxClockSkew = 0,
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = PolicySubjectMatchType.USERNAME,
                        Filter = null,
                    },
                },
            };

            var createdIdp = await _idpApi.CreateIdentityProviderAsync(idp);

            try
            {
                createdIdp.Status.Should().Be(LifecycleStatus.ACTIVE);
                await _idpApi.DeactivateIdentityProviderAsync(createdIdp.Id);
                var retrievedIdp = await _idpApi.GetIdentityProviderAsync(createdIdp.Id);
                retrievedIdp.Status.Should().Be(LifecycleStatus.INACTIVE);

                await _idpApi.ActivateIdentityProviderAsync(createdIdp.Id);
                retrievedIdp = await _idpApi.GetIdentityProviderAsync(createdIdp.Id);
                retrievedIdp.Status.Should().Be(LifecycleStatus.ACTIVE);
            }
            finally
            {
                await _idpApi.DeactivateIdentityProviderAsync(createdIdp.Id);
                await _idpApi.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task UpdateIdp()
        {
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = new IdentityProvider()
            {
                Type = "LINKEDIN",
                Name = $"dotnet-sdk:UpdateIdp{randomSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "r_basicprofile", "r_emailaddress" },
                    Type = ProtocolType.OAUTH2,
                    Credentials = new IdentityProviderCredentials()
                    {
                        _Client = new IdentityProviderCredentialsClient()
                        {
                            ClientId = "your-client-id",
                            ClientSecret = "your-client-secret",
                        },
                    },
                },
                Policy = new IdentityProviderPolicy()
                {
                    AccountLink = new PolicyAccountLink()
                    {
                        Action = PolicyAccountLinkAction.AUTO,
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = ProvisioningAction.AUTO,
                        ProfileMaster = true,
                        Conditions = new ProvisioningConditions()
                        {
                            Deprovisioned = new ProvisioningDeprovisionedCondition()
                            {
                                Action = ProvisioningDeprovisionedAction.NONE,
                            },
                            Suspended = new ProvisioningSuspendedCondition()
                            {
                                Action = ProvisioningSuspendedAction.NONE,
                            },
                        },
                        Groups = new ProvisioningGroups()
                        {
                            Action = ProvisioningGroupsAction.NONE,
                        },
                    },
                    MaxClockSkew = 0,
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = PolicySubjectMatchType.USERNAME,
                        Filter = null,
                    },
                },
            };

            var createdIdp = await _idpApi.CreateIdentityProviderAsync(idp);

            try
            {
               createdIdp.Name = $"dotnet-sdk:UpdateIdp{randomSuffix}-upd";
               Thread.Sleep(3000); // allow for user replication prior to read attempt

               var updatedIdp = await _idpApi.UpdateIdentityProviderAsync(createdIdp.Id, createdIdp);
               updatedIdp.Name.Should().Be($"dotnet-sdk:UpdateIdp{randomSuffix}-upd");

            }
            finally
            {
                await _idpApi.DeactivateIdentityProviderAsync(createdIdp.Id);
                await _idpApi.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task DeleteIdp()
        {
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = new IdentityProvider()
            {
                Type = "LINKEDIN",
                Name = $"dotnet-sdk:DeleteIdp{randomSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "r_basicprofile", "r_emailaddress" },
                    Type = ProtocolType.OAUTH2,
                    Credentials = new IdentityProviderCredentials()
                    {
                        _Client = new IdentityProviderCredentialsClient()
                        {
                            ClientId = "your-client-id",
                            ClientSecret = "your-client-secret",
                        },
                    },
                },
                Policy = new IdentityProviderPolicy()
                {
                    AccountLink = new PolicyAccountLink()
                    {
                        Action = PolicyAccountLinkAction.AUTO,
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = ProvisioningAction.AUTO,
                        ProfileMaster = true,
                        Conditions = new ProvisioningConditions()
                        {
                            Deprovisioned = new ProvisioningDeprovisionedCondition()
                            {
                                Action = ProvisioningDeprovisionedAction.NONE,
                            },
                            Suspended = new ProvisioningSuspendedCondition()
                            {
                                Action = ProvisioningSuspendedAction.NONE,
                            },
                        },
                        Groups = new ProvisioningGroups()
                        {
                            Action = ProvisioningGroupsAction.NONE,
                        },
                    },
                    MaxClockSkew = 0,
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = PolicySubjectMatchType.USERNAME,
                        Filter = null,
                    },
                },
            };

            var createdIdp = await _idpApi.CreateIdentityProviderAsync(idp);
            var idpId = createdIdp.Id;

            await _idpApi.DeactivateIdentityProviderAsync(createdIdp.Id);
            await _idpApi.DeleteIdentityProviderAsync(createdIdp.Id);

            // Deleting by ID should result in 403 Forbidden
            await Assert.ThrowsAsync<ApiException>(async () =>
                await _idpApi.GetIdentityProviderAsync(idpId));
        }

        [Fact]
        public async Task CreateKey()
        {
            var key = @"MIIDnjCCAoagAwIBAgIGAVG3MN+PMA0GCSqGSIb3DQEBBQUAMIGPMQswCQYDVQQGEwJVUzETMBEGA1UECAwKQ2FsaWZvcm5p
                    YTEWMBQGA1UEBwwNU2FuIEZyYW5jaXNjbzENMAsGA1UECgwET2t0YTEUMBIGA1UECwwLU1NPUHJvdmlkZXIxEDAOBgNVBAMM
                    B2V4YW1wbGUxHDAaBgkqhkiG9w0BCQEWDWluZm9Ab2t0YS5jb20wHhcNMTUxMjE4MjIyMjMyWhcNMjUxMjE4MjIyMzMyWjCB
                    jzELMAkGA1UEBhMCVVMxEzARBgNVBAgMCkNhbGlmb3JuaWExFjAUBgNVBAcMDVNhbiBGcmFuY2lzY28xDTALBgNVBAoMBE9r
                    dGExFDASBgNVBAsMC1NTT1Byb3ZpZGVyMRAwDgYDVQQDDAdleGFtcGxlMRwwGgYJKoZIhvcNAQkBFg1pbmZvQG9rdGEuY29t
                    MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAtcnyvuVCrsFEKCwHDenS3Ocjed8eWDv3zLtD2K/iZfE8BMj2wpTf
                    n6Ry8zCYey3mWlKdxIybnV9amrujGRnE0ab6Q16v9D6RlFQLOG6dwqoRKuZy33Uyg8PGdEudZjGbWuKCqqXEp+UKALJHV+k4
                    wWeVH8g5d1n3KyR2TVajVJpCrPhLFmq1Il4G/IUnPe4MvjXqB6CpKkog1+ThWsItPRJPAM+RweFHXq7KfChXsYE7Mmfuly8s
                    DQlvBmQyxZnFHVuiPfCvGHJjpvHy11YlHdOjfgqHRvZbmo30+y0X/oY/yV4YEJ00LL6eJWU4wi7ViY3HP6/VCdRjHoRdr5L/
                    DwIDAQABMA0GCSqGSIb3DQEBBQUAA4IBAQCzzhOFkvyYLNFj2WDcq1YqD4sBy1iCia9QpRH3rjQvMKDwQDYWbi6EdOX0TQ/I
                    YR7UWGj+2pXd6v0t33lYtoKocp/4lUvT3tfBnWZ5KnObi+J2uY2teUqoYkASN7F+GRPVOuMVoVgm05ss8tuMb2dLc9vsx93s
                    Dt+XlMTv/2qi5VPwaDtqduKkzwW9lUfn4xIMkTiVvCpe0X2HneD2Bpuao3/U8Rk0uiPfq6TooWaoW3kjsmErhEAs9bA7xuqo
                    1KKY9CdHcFhkSsMhoeaZylZHtzbnoipUlQKSLMdJQiiYZQ0bYL83/Ta9fulr1EERICMFt3GUmtYaZZKHpWSfdJp9";

            var createdKey = await _idpApi.CreateIdentityProviderKeyAsync(new JsonWebKey()
            {
                X5c = new List<string>() { key },
            });

            try
            {
                createdKey.Should().NotBeNull();
                createdKey.X5c.Should().Contain(key);
            }
            finally
            {
                await _idpApi.DeleteIdentityProviderKeyAsync(createdKey.Kid);
            }
        }

        [Fact]
        public async Task GetKey()
        {
            var key = @"MIIDnjCCAoagAwIBAgIGAVG3MN+PMA0GCSqGSIb3DQEBBQUAMIGPMQswCQYDVQQGEwJVUzETMBEGA1UECAwKQ2FsaWZvcm5p
                    YTEWMBQGA1UEBwwNU2FuIEZyYW5jaXNjbzENMAsGA1UECgwET2t0YTEUMBIGA1UECwwLU1NPUHJvdmlkZXIxEDAOBgNVBAMM
                    B2V4YW1wbGUxHDAaBgkqhkiG9w0BCQEWDWluZm9Ab2t0YS5jb20wHhcNMTUxMjE4MjIyMjMyWhcNMjUxMjE4MjIyMzMyWjCB
                    jzELMAkGA1UEBhMCVVMxEzARBgNVBAgMCkNhbGlmb3JuaWExFjAUBgNVBAcMDVNhbiBGcmFuY2lzY28xDTALBgNVBAoMBE9r
                    dGExFDASBgNVBAsMC1NTT1Byb3ZpZGVyMRAwDgYDVQQDDAdleGFtcGxlMRwwGgYJKoZIhvcNAQkBFg1pbmZvQG9rdGEuY29t
                    MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAtcnyvuVCrsFEKCwHDenS3Ocjed8eWDv3zLtD2K/iZfE8BMj2wpTf
                    n6Ry8zCYey3mWlKdxIybnV9amrujGRnE0ab6Q16v9D6RlFQLOG6dwqoRKuZy33Uyg8PGdEudZjGbWuKCqqXEp+UKALJHV+k4
                    wWeVH8g5d1n3KyR2TVajVJpCrPhLFmq1Il4G/IUnPe4MvjXqB6CpKkog1+ThWsItPRJPAM+RweFHXq7KfChXsYE7Mmfuly8s
                    DQlvBmQyxZnFHVuiPfCvGHJjpvHy11YlHdOjfgqHRvZbmo30+y0X/oY/yV4YEJ00LL6eJWU4wi7ViY3HP6/VCdRjHoRdr5L/
                    DwIDAQABMA0GCSqGSIb3DQEBBQUAA4IBAQCzzhOFkvyYLNFj2WDcq1YqD4sBy1iCia9QpRH3rjQvMKDwQDYWbi6EdOX0TQ/I
                    YR7UWGj+2pXd6v0t33lYtoKocp/4lUvT3tfBnWZ5KnObi+J2uY2teUqoYkASN7F+GRPVOuMVoVgm05ss8tuMb2dLc9vsx93s
                    Dt+XlMTv/2qi5VPwaDtqduKkzwW9lUfn4xIMkTiVvCpe0X2HneD2Bpuao3/U8Rk0uiPfq6TooWaoW3kjsmErhEAs9bA7xuqo
                    1KKY9CdHcFhkSsMhoeaZylZHtzbnoipUlQKSLMdJQiiYZQ0bYL83/Ta9fulr1EERICMFt3GUmtYaZZKHpWSfdJp9";

            var createdKey = await _idpApi.CreateIdentityProviderKeyAsync(new JsonWebKey()
            {
                X5c = new List<string>() { key },
            });

            try
            {
                var retrievedKey = await _idpApi.GetIdentityProviderKeyAsync(createdKey.Kid);
                retrievedKey.Should().NotBeNull();
                retrievedKey.X5c.Should().Contain(key);
            }
            finally
            {
                await _idpApi.DeleteIdentityProviderKeyAsync(createdKey.Kid);
            }
        }

        [Fact]
        public async Task ListKeys()
        {
            var key = @"MIIDnjCCAoagAwIBAgIGAVG3MN+PMA0GCSqGSIb3DQEBBQUAMIGPMQswCQYDVQQGEwJVUzETMBEGA1UECAwKQ2FsaWZvcm5p
                    YTEWMBQGA1UEBwwNU2FuIEZyYW5jaXNjbzENMAsGA1UECgwET2t0YTEUMBIGA1UECwwLU1NPUHJvdmlkZXIxEDAOBgNVBAMM
                    B2V4YW1wbGUxHDAaBgkqhkiG9w0BCQEWDWluZm9Ab2t0YS5jb20wHhcNMTUxMjE4MjIyMjMyWhcNMjUxMjE4MjIyMzMyWjCB
                    jzELMAkGA1UEBhMCVVMxEzARBgNVBAgMCkNhbGlmb3JuaWExFjAUBgNVBAcMDVNhbiBGcmFuY2lzY28xDTALBgNVBAoMBE9r
                    dGExFDASBgNVBAsMC1NTT1Byb3ZpZGVyMRAwDgYDVQQDDAdleGFtcGxlMRwwGgYJKoZIhvcNAQkBFg1pbmZvQG9rdGEuY29t
                    MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAtcnyvuVCrsFEKCwHDenS3Ocjed8eWDv3zLtD2K/iZfE8BMj2wpTf
                    n6Ry8zCYey3mWlKdxIybnV9amrujGRnE0ab6Q16v9D6RlFQLOG6dwqoRKuZy33Uyg8PGdEudZjGbWuKCqqXEp+UKALJHV+k4
                    wWeVH8g5d1n3KyR2TVajVJpCrPhLFmq1Il4G/IUnPe4MvjXqB6CpKkog1+ThWsItPRJPAM+RweFHXq7KfChXsYE7Mmfuly8s
                    DQlvBmQyxZnFHVuiPfCvGHJjpvHy11YlHdOjfgqHRvZbmo30+y0X/oY/yV4YEJ00LL6eJWU4wi7ViY3HP6/VCdRjHoRdr5L/
                    DwIDAQABMA0GCSqGSIb3DQEBBQUAA4IBAQCzzhOFkvyYLNFj2WDcq1YqD4sBy1iCia9QpRH3rjQvMKDwQDYWbi6EdOX0TQ/I
                    YR7UWGj+2pXd6v0t33lYtoKocp/4lUvT3tfBnWZ5KnObi+J2uY2teUqoYkASN7F+GRPVOuMVoVgm05ss8tuMb2dLc9vsx93s
                    Dt+XlMTv/2qi5VPwaDtqduKkzwW9lUfn4xIMkTiVvCpe0X2HneD2Bpuao3/U8Rk0uiPfq6TooWaoW3kjsmErhEAs9bA7xuqo
                    1KKY9CdHcFhkSsMhoeaZylZHtzbnoipUlQKSLMdJQiiYZQ0bYL83/Ta9fulr1EERICMFt3GUmtYaZZKHpWSfdJp9";

            var createdKey = await _idpApi.CreateIdentityProviderKeyAsync(new JsonWebKey()
            {
                X5c = new List<string>() { key },
            });

            try
            {
                var idpKeys = await _idpApi.ListIdentityProviderKeysAsync().ToListAsync();
                idpKeys.Should().NotBeNullOrEmpty();
                idpKeys.FirstOrDefault(x => x.Kid == createdKey.Kid).Should().NotBeNull();
            }
            finally
            {
                await _idpApi.DeleteIdentityProviderKeyAsync(createdKey.Kid);
            }
        }

        [Fact]
        public async Task DeleteKey()
        {
            var key = @"MIIDnjCCAoagAwIBAgIGAVG3MN+PMA0GCSqGSIb3DQEBBQUAMIGPMQswCQYDVQQGEwJVUzETMBEGA1UECAwKQ2FsaWZvcm5p
                    YTEWMBQGA1UEBwwNU2FuIEZyYW5jaXNjbzENMAsGA1UECgwET2t0YTEUMBIGA1UECwwLU1NPUHJvdmlkZXIxEDAOBgNVBAMM
                    B2V4YW1wbGUxHDAaBgkqhkiG9w0BCQEWDWluZm9Ab2t0YS5jb20wHhcNMTUxMjE4MjIyMjMyWhcNMjUxMjE4MjIyMzMyWjCB
                    jzELMAkGA1UEBhMCVVMxEzARBgNVBAgMCkNhbGlmb3JuaWExFjAUBgNVBAcMDVNhbiBGcmFuY2lzY28xDTALBgNVBAoMBE9r
                    dGExFDASBgNVBAsMC1NTT1Byb3ZpZGVyMRAwDgYDVQQDDAdleGFtcGxlMRwwGgYJKoZIhvcNAQkBFg1pbmZvQG9rdGEuY29t
                    MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAtcnyvuVCrsFEKCwHDenS3Ocjed8eWDv3zLtD2K/iZfE8BMj2wpTf
                    n6Ry8zCYey3mWlKdxIybnV9amrujGRnE0ab6Q16v9D6RlFQLOG6dwqoRKuZy33Uyg8PGdEudZjGbWuKCqqXEp+UKALJHV+k4
                    wWeVH8g5d1n3KyR2TVajVJpCrPhLFmq1Il4G/IUnPe4MvjXqB6CpKkog1+ThWsItPRJPAM+RweFHXq7KfChXsYE7Mmfuly8s
                    DQlvBmQyxZnFHVuiPfCvGHJjpvHy11YlHdOjfgqHRvZbmo30+y0X/oY/yV4YEJ00LL6eJWU4wi7ViY3HP6/VCdRjHoRdr5L/
                    DwIDAQABMA0GCSqGSIb3DQEBBQUAA4IBAQCzzhOFkvyYLNFj2WDcq1YqD4sBy1iCia9QpRH3rjQvMKDwQDYWbi6EdOX0TQ/I
                    YR7UWGj+2pXd6v0t33lYtoKocp/4lUvT3tfBnWZ5KnObi+J2uY2teUqoYkASN7F+GRPVOuMVoVgm05ss8tuMb2dLc9vsx93s
                    Dt+XlMTv/2qi5VPwaDtqduKkzwW9lUfn4xIMkTiVvCpe0X2HneD2Bpuao3/U8Rk0uiPfq6TooWaoW3kjsmErhEAs9bA7xuqo
                    1KKY9CdHcFhkSsMhoeaZylZHtzbnoipUlQKSLMdJQiiYZQ0bYL83/Ta9fulr1EERICMFt3GUmtYaZZKHpWSfdJp9";

            var createdKey = await _idpApi.CreateIdentityProviderKeyAsync(new JsonWebKey()
            {
                X5c = new List<string>() { key },
            });

            var kid = createdKey.Kid;
            await _idpApi.DeleteIdentityProviderKeyAsync(createdKey.Kid);

            // Deleting by ID should result in 403 Forbidden
            await Assert.ThrowsAsync<ApiException>(async () =>
                await _idpApi.GetIdentityProviderKeyAsync(kid));
        }

        [Fact]
        public async Task GenerateSigningKey()
        {
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = GetTestIdentityProvider("GenerateSigningKey", randomSuffix);
            var createdIdp = await _idpApi.CreateIdentityProviderAsync(idp);

            try
            {
                var generatedKey = await _idpApi.GenerateIdentityProviderSigningKeyAsync(createdIdp.Id, 2);

                generatedKey.Should().NotBeNull();
            }
            finally
            {
                await _idpApi.DeactivateIdentityProviderAsync(createdIdp.Id);
                await _idpApi.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task ListSigningKeys()
        {
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = GetTestIdentityProvider("ListSigningKeys", randomSuffix);
            var createdIdp = await _idpApi.CreateIdentityProviderAsync(idp);

            try
            {
                var generatedKey1 = await _idpApi.GenerateIdentityProviderSigningKeyAsync(createdIdp.Id, 2);
                var generatedKey2 = await _idpApi.GenerateIdentityProviderSigningKeyAsync(createdIdp.Id, 2);

                var keys = await _idpApi.ListIdentityProviderSigningKeysAsync(createdIdp.Id).ToListAsync();
                
                keys.Should().NotBeNullOrEmpty();
                keys.FirstOrDefault(x => x.Kid == generatedKey1.Kid).Should().NotBeNull();
                keys.FirstOrDefault(x => x.Kid == generatedKey2.Kid).Should().NotBeNull();
            }
            finally
            {
                await _idpApi.DeactivateIdentityProviderAsync(createdIdp.Id);
                await _idpApi.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task GetSigningKey()
        {
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = GetTestIdentityProvider("GetSigningKey", randomSuffix);
            var createdIdp = await _idpApi.CreateIdentityProviderAsync(idp);

            try
            {
                var generatedKey = await _idpApi.GenerateIdentityProviderSigningKeyAsync(createdIdp.Id, 2);
                var retrievedKey = await _idpApi.GetIdentityProviderSigningKeyAsync(createdIdp.Id, generatedKey.Kid);

                retrievedKey.Should().NotBeNull();

            }
            finally
            {
                await _idpApi.DeactivateIdentityProviderAsync(createdIdp.Id);
                await _idpApi.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task CloneKey()
        {
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp1 = GetTestIdentityProvider("CloneSigningKey1", randomSuffix);
            var createdIdp1 = await _idpApi.CreateIdentityProviderAsync(idp1);

            var idp2 = GetTestIdentityProvider("CloneSigningKey2", randomSuffix);
            var createdIdp2 = await _idpApi.CreateIdentityProviderAsync(idp2);

            try
            {
                var generatedKey1 = await _idpApi.GenerateIdentityProviderSigningKeyAsync(createdIdp1.Id, 2);
                var clonedKey =
                    await _idpApi.CloneIdentityProviderKeyAsync(createdIdp1.Id, generatedKey1.Kid, createdIdp2.Id);
                
                clonedKey.Should().NotBeNull();
                clonedKey.Kid.Should().Be(generatedKey1.Kid);

            }
            finally
            {
                await _idpApi.DeactivateIdentityProviderAsync(createdIdp1.Id);
                await _idpApi.DeleteIdentityProviderAsync(createdIdp1.Id);

                await _idpApi.DeactivateIdentityProviderAsync(createdIdp2.Id);
                await _idpApi.DeleteIdentityProviderAsync(createdIdp2.Id);
            }
        }

        [Fact]
        public async Task GenerateCsr()
        {
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = GetTestIdentityProvider("GenerateCsr", randomSuffix);
            var createdIdp = await _idpApi.CreateIdentityProviderAsync(idp);

            try
            {
                var csrMetadata = new CsrMetadata()
                {
                    Subject = new CsrMetadataSubject()
                    {
                        CountryName = "US",
                        StateOrProvinceName = "California",
                        LocalityName = "San Francisco",
                        OrganizationName = "Okta, Inc.",
                        OrganizationalUnitName = "Dev",
                        CommonName = "SP Issuer",
                    },
                    SubjectAltNames = new CsrMetadataSubjectAltNames()
                    {
                        DnsNames = new List<string>() { "dev.okta.com" },
                    },
                };

                var generatedCsr = await _idpApi.GenerateCsrForIdentityProviderAsync(createdIdp.Id, csrMetadata);

                generatedCsr.Should().NotBeNull();
                generatedCsr.Kty.Should().Be("RSA");
                generatedCsr._Csr.Should().NotBeNullOrEmpty();
            }
            finally
            {
                await _idpApi.DeactivateIdentityProviderAsync(createdIdp.Id);
                await _idpApi.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task RevokeCsr()
        {
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = GetTestIdentityProvider("RevokeCsr", randomSuffix);
            var createdIdp = await _idpApi.CreateIdentityProviderAsync(idp);

            try
            {
                var csrMetadata = new CsrMetadata()
                {
                    Subject = new CsrMetadataSubject()
                    {
                        CountryName = "US",
                        StateOrProvinceName = "California",
                        LocalityName = "San Francisco",
                        OrganizationName = "Okta, Inc.",
                        OrganizationalUnitName = "Dev",
                        CommonName = "SP Issuer",
                    },
                    SubjectAltNames = new CsrMetadataSubjectAltNames()
                    {
                        DnsNames = new List<string>() { "dev.okta.com" },
                    },
                };

                var generatedCsr = await _idpApi.GenerateCsrForIdentityProviderAsync(createdIdp.Id, csrMetadata);

                var retrievedCsrs = await _idpApi.ListCsrsForIdentityProviderAsync(createdIdp.Id).ToListAsync();
                retrievedCsrs.Any(x => x.Id == generatedCsr.Id).Should().BeTrue();

                await _idpApi.RevokeCsrForIdentityProviderAsync(createdIdp.Id, generatedCsr.Id);

                retrievedCsrs = await _idpApi.ListCsrsForIdentityProviderAsync(createdIdp.Id).ToListAsync();
                retrievedCsrs.Any(x => x.Id == generatedCsr.Id).Should().BeFalse();
            }
            finally
            {
                await _idpApi.DeactivateIdentityProviderAsync(createdIdp.Id);
                await _idpApi.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task GetCsr()
        {
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = GetTestIdentityProvider("GetCsr", randomSuffix);
            var createdIdp = await _idpApi.CreateIdentityProviderAsync(idp);

            try
            {
                var csrMetadata = new CsrMetadata()
                {
                    Subject = new CsrMetadataSubject()
                    {
                        CountryName = "US",
                        StateOrProvinceName = "California",
                        LocalityName = "San Francisco",
                        OrganizationName = "Okta, Inc.",
                        OrganizationalUnitName = "Dev",
                        CommonName = "SP Issuer",
                    },
                    SubjectAltNames = new CsrMetadataSubjectAltNames()
                    {
                        DnsNames = new List<string>() { "dev.okta.com" },
                    },
                };

                var generatedCsr = await _idpApi.GenerateCsrForIdentityProviderAsync(createdIdp.Id, csrMetadata);

                var retrievedCsr = await _idpApi.GetCsrForIdentityProviderAsync(createdIdp.Id, generatedCsr.Id);
                retrievedCsr.Kty.Should().Be(generatedCsr.Kty);
                retrievedCsr._Csr.Should().Be(generatedCsr._Csr);

            }
            finally
            {
                await _idpApi.DeactivateIdentityProviderAsync(createdIdp.Id);
                await _idpApi.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task AddSamlIdp()
        {
            var randomSuffix = DateTime.UtcNow.ToString();

            var key = @"MIIDnjCCAoagAwIBAgIGAVG3MN+PMA0GCSqGSIb3DQEBBQUAMIGPMQswCQYDVQQGEwJVUzETMBEGA1UECAwKQ2FsaWZvcm5p
                    YTEWMBQGA1UEBwwNU2FuIEZyYW5jaXNjbzENMAsGA1UECgwET2t0YTEUMBIGA1UECwwLU1NPUHJvdmlkZXIxEDAOBgNVBAMM
                    B2V4YW1wbGUxHDAaBgkqhkiG9w0BCQEWDWluZm9Ab2t0YS5jb20wHhcNMTUxMjE4MjIyMjMyWhcNMjUxMjE4MjIyMzMyWjCB
                    jzELMAkGA1UEBhMCVVMxEzARBgNVBAgMCkNhbGlmb3JuaWExFjAUBgNVBAcMDVNhbiBGcmFuY2lzY28xDTALBgNVBAoMBE9r
                    dGExFDASBgNVBAsMC1NTT1Byb3ZpZGVyMRAwDgYDVQQDDAdleGFtcGxlMRwwGgYJKoZIhvcNAQkBFg1pbmZvQG9rdGEuY29t
                    MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAtcnyvuVCrsFEKCwHDenS3Ocjed8eWDv3zLtD2K/iZfE8BMj2wpTf
                    n6Ry8zCYey3mWlKdxIybnV9amrujGRnE0ab6Q16v9D6RlFQLOG6dwqoRKuZy33Uyg8PGdEudZjGbWuKCqqXEp+UKALJHV+k4
                    wWeVH8g5d1n3KyR2TVajVJpCrPhLFmq1Il4G/IUnPe4MvjXqB6CpKkog1+ThWsItPRJPAM+RweFHXq7KfChXsYE7Mmfuly8s
                    DQlvBmQyxZnFHVuiPfCvGHJjpvHy11YlHdOjfgqHRvZbmo30+y0X/oY/yV4YEJ00LL6eJWU4wi7ViY3HP6/VCdRjHoRdr5L/
                    DwIDAQABMA0GCSqGSIb3DQEBBQUAA4IBAQCzzhOFkvyYLNFj2WDcq1YqD4sBy1iCia9QpRH3rjQvMKDwQDYWbi6EdOX0TQ/I
                    YR7UWGj+2pXd6v0t33lYtoKocp/4lUvT3tfBnWZ5KnObi+J2uY2teUqoYkASN7F+GRPVOuMVoVgm05ss8tuMb2dLc9vsx93s
                    Dt+XlMTv/2qi5VPwaDtqduKkzwW9lUfn4xIMkTiVvCpe0X2HneD2Bpuao3/U8Rk0uiPfq6TooWaoW3kjsmErhEAs9bA7xuqo
                    1KKY9CdHcFhkSsMhoeaZylZHtzbnoipUlQKSLMdJQiiYZQ0bYL83/Ta9fulr1EERICMFt3GUmtYaZZKHpWSfdJp9";

            var createdKey = await _idpApi.CreateIdentityProviderKeyAsync(new JsonWebKey()
            {
                X5c = new List<string>() { key },
            });

            var idp = new IdentityProvider()
            {
                Type = "SAML2",
                Name = $"dotnet-sdk:AddSAML{randomSuffix}",
                Protocol = new Protocol()
                {
                    Algorithms = new ProtocolAlgorithms()
                    {
                        Request = new ProtocolAlgorithmType()
                        {
                            Signature = new ProtocolAlgorithmTypeSignature()
                            {
                                Algorithm = "SHA-256",
                                Scope = ProtocolAlgorithmTypeSignatureScope.REQUEST,
                            },
                        },
                        Response = new ProtocolAlgorithmType()
                        {
                            Signature = new ProtocolAlgorithmTypeSignature()
                            {
                                Algorithm = "SHA-256",
                                Scope = ProtocolAlgorithmTypeSignatureScope.ANY,
                            },
                        },
                    },
                    Endpoints = new ProtocolEndpoints()
                    {
                        Acs = new ProtocolEndpoint()
                        {
                            Binding = ProtocolEndpointBinding.POST,
                            Type = ProtocolEndpointType.INSTANCE,
                        },
                        Sso = new ProtocolEndpoint()
                        {
                            Url = "https://idp.example.com",
                            Binding = ProtocolEndpointBinding.POST,
                            Destination = "https://idp.example.com",
                        },
                    },
                    Scopes = new List<string>() { "openid", "profile", "email" },
                    Type = ProtocolType.SAML2,
                    Credentials = new IdentityProviderCredentials()
                    {
                        Trust = new IdentityProviderCredentialsTrust()
                        {
                            Issuer = "https://idp.example.com",
                            Audience = "http://www.okta.com/123",
                            Kid = createdKey.Kid,
                        },
                    },
                    Issuer = new ProtocolEndpoint()
                    {
                        Url = "https://idp.example.com",
                    },
                },
                Policy = new IdentityProviderPolicy()
                {
                    AccountLink = new PolicyAccountLink()
                    {
                        Action = PolicyAccountLinkAction.AUTO,
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = ProvisioningAction.AUTO,
                        ProfileMaster = true,
                        Conditions = new ProvisioningConditions()
                        {
                            Deprovisioned = new ProvisioningDeprovisionedCondition()
                            {
                                Action = ProvisioningDeprovisionedAction.NONE,
                            },
                            Suspended = new ProvisioningSuspendedCondition()
                            {
                                Action = ProvisioningSuspendedAction.NONE,
                            },
                        },
                        Groups = new ProvisioningGroups()
                        {
                            Action = ProvisioningGroupsAction.NONE,
                        },
                    },
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.subjectNameId",
                        },
                        Format = new List<string>() { "urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified" },
                        Filter = "(\\S+@example\\.com)",
                        MatchType = PolicySubjectMatchType.USERNAME,
                    },
                },
            };

            var createdIdp = await _idpApi.CreateIdentityProviderAsync(idp);

            try
            {
                createdIdp.Should().NotBeNull();
                createdIdp.Name.Should().Be($"dotnet-sdk:AddSAML{randomSuffix}");
                createdIdp.Type.Should().Be("SAML2");
                createdIdp.Status.Should().Be(LifecycleStatus.ACTIVE);
                createdIdp.Protocol.Type.Should().Be(ProtocolType.SAML2);
                createdIdp.Protocol.Endpoints.Sso.Url.Should().Be("https://idp.example.com");
                createdIdp.Protocol.Endpoints.Sso.Binding.Should().Be(ProtocolEndpointBinding.POST);
                createdIdp.Protocol.Endpoints.Sso.Destination.Should().Be("https://idp.example.com");
                createdIdp.Protocol.Endpoints.Acs.Type.Should().Be(ProtocolEndpointType.INSTANCE);
                createdIdp.Protocol.Endpoints.Acs.Binding.Should().Be(ProtocolEndpointBinding.POST);
                createdIdp.Protocol.Settings.NameFormat.Should().Be("urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified");
                createdIdp.Protocol.Credentials.Trust.Issuer.Should().Be("https://idp.example.com");
                createdIdp.Protocol.Credentials.Trust.Audience.Should().Be("http://www.okta.com/123");
                createdIdp.Policy.Provisioning.Action.Should().Be(ProvisioningAction.AUTO);
                createdIdp.Policy.Provisioning.ProfileMaster.Should().BeTrue();
                createdIdp.Policy.Provisioning.Groups.Action.Should().Be(ProvisioningGroupsAction.NONE);
                createdIdp.Policy.Provisioning.Conditions.Deprovisioned.Action.Should().Be(ProvisioningDeprovisionedAction.NONE);
                createdIdp.Policy.Provisioning.Conditions.Suspended.Action.Should().Be(ProvisioningSuspendedAction.NONE);

                createdIdp.Policy.Provisioning.Conditions.Suspended.Action.Should().Be(ProvisioningSuspendedAction.NONE);
                createdIdp.Policy.AccountLink.Action.Should().Be(PolicyAccountLinkAction.AUTO);
                createdIdp.Policy.Subject.UserNameTemplate.Template.Should().Be("idpuser.subjectNameId");
                createdIdp.Policy.Subject.MatchType.Value.Should().Be(PolicySubjectMatchType.USERNAME);
                createdIdp.Policy.Subject.MatchAttribute.Should().BeNull();
            }
            finally
            {
                await _idpApi.DeactivateIdentityProviderAsync(createdIdp.Id);
                await _idpApi.DeleteIdentityProviderAsync(createdIdp.Id);
                await _idpApi.DeleteIdentityProviderKeyAsync(createdKey.Kid);
            }
        }

        [Fact(Skip = "TODO")]
        public async Task PublishCsr()
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes("foo")))
            {
                var key = await _idpApi.PublishCsrForIdentityProviderAsync("foo", "bar", stream);
                key.Should().NotBeNull();
            }
            
        }

        private static IdentityProvider GetTestIdentityProvider(string idpName, string idpSuffix)
        {
            var idp = new IdentityProvider()
            {
                Type = "LINKEDIN",
                Name = $"dotnet-sdk:{idpName}{idpSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "r_basicprofile", "r_emailaddress" },
                    Type = ProtocolType.OAUTH2,
                    Credentials = new IdentityProviderCredentials()
                    {
                        _Client = new IdentityProviderCredentialsClient()
                        {
                            ClientId = "your-client-id",
                            ClientSecret = "your-client-secret",
                        },
                    },
                },
                Policy = new IdentityProviderPolicy()
                {
                    AccountLink = new PolicyAccountLink()
                    {
                        Action = PolicyAccountLinkAction.AUTO,
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = ProvisioningAction.AUTO,
                        ProfileMaster = true,
                        Conditions = new ProvisioningConditions()
                        {
                            Deprovisioned = new ProvisioningDeprovisionedCondition()
                            {
                                Action = ProvisioningDeprovisionedAction.NONE,
                            },
                            Suspended = new ProvisioningSuspendedCondition()
                            {
                                Action = ProvisioningSuspendedAction.NONE,
                            },
                        },
                        Groups = new ProvisioningGroups()
                        {
                            Action = ProvisioningGroupsAction.NONE,
                        },
                    },
                    MaxClockSkew = 0,
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = PolicySubjectMatchType.USERNAME,
                        Filter = null,
                    },
                },
            };
            return idp;
        }
    }
}
