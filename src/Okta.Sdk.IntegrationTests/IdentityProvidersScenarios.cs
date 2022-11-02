// <copyright file="IdentityProvidersScenarios.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    public class IdentityProvidersScenarios
    {
        public IdentityProvidersScenarios()
        {
            DeleteAllIdps().Wait();
        }

        private async Task DeleteAllIdps()
        {
            var client = TestClient.Create();
            var idps = await client.IdentityProviders.ListIdentityProviders().ToListAsync();

            // Deactivate idps.
            foreach (var idp in idps)
            {
                await client.IdentityProviders.DeactivateIdentityProviderAsync(idp.Id);
                await client.IdentityProviders.DeleteIdentityProviderAsync(idp.Id);
            }
        }

        [Fact]
        public async Task AddGenericOidcIdp()
        {
            var client = TestClient.Create();
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
                                Scope = "REQUEST",
                            },
                        },
                        Response = new ProtocolAlgorithmType()
                        {
                            Signature = new ProtocolAlgorithmTypeSignature()
                            {
                                Algorithm = "SHA-256",
                                Scope = "ANY",
                            },
                        },
                    },
                    Endpoints = new ProtocolEndpoints()
                    {
                        Acs = new ProtocolEndpoint()
                        {
                            Binding = "HTTP-POST",
                            Type = "INSTANCE",
                        },
                        Authorization = new ProtocolEndpoint()
                        {
                            Binding = "HTTP-REDIRECT",
                            Url = "https://idp.example.com/authorize",
                        },
                        Token = new ProtocolEndpoint()
                        {
                            Binding = "HTTP-POST",
                            Url = "https://idp.example.com/token",
                        },
                        UserInfo = new ProtocolEndpoint()
                        {
                            Binding = "HTTP-REDIRECT",
                            Url = "https://idp.example.com/userinfo",
                        },
                        Jwks = new ProtocolEndpoint()
                        {
                            Binding = "HTTP-REDIRECT",
                            Url = "https://idp.example.com/keys",
                        },
                    },
                    Scopes = new List<string>() { "openid", "profile", "email" },
                    Type = "OIDC",
                    Credentials = new IdentityProviderCredentials()
                    {
                        Client = new IdentityProviderCredentialsClient()
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
                        Action = "AUTO",
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = "AUTO",
                        Conditions = new ProvisioningConditions()
                        {
                            Deprovisioned = new ProvisioningDeprovisionedCondition()
                            {
                                Action = "NONE",
                            },
                            Suspended = new ProvisioningSuspendedCondition()
                            {
                                Action = "NONE",
                            },
                        },
                        Groups = new ProvisioningGroups()
                        {
                            Action = "NONE",
                        },
                    },
                    MaxClockSkew = 120000,
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = "USERNAME",
                    },
                },
            };

            var createdIdp = await client.IdentityProviders.CreateIdentityProviderAsync(idp);

            try
            {
                createdIdp.Should().NotBeNull();
                createdIdp.Name.Should().Be($"dotnet-sdk:AddGeneric{randomSuffix}");
                createdIdp.Type.Should().Be("OIDC");
                createdIdp.Status.Should().Be("ACTIVE");
                createdIdp.Protocol.Type.Should().Be("OIDC");
                createdIdp.Protocol.Endpoints.Authorization.Url.Should().Be("https://idp.example.com/authorize");
                createdIdp.Protocol.Endpoints.Authorization.Binding.Should().Be("HTTP-REDIRECT");
                createdIdp.Protocol.Endpoints.Token.Url.Should().Be("https://idp.example.com/token");
                createdIdp.Protocol.Endpoints.Token.Binding.Should().Be("HTTP-POST");
                createdIdp.Protocol.Endpoints.UserInfo.Url.Should().Be("https://idp.example.com/userinfo");
                createdIdp.Protocol.Endpoints.UserInfo.Binding.Should().Be("HTTP-REDIRECT");
                createdIdp.Protocol.Endpoints.Jwks.Url.Should().Be("https://idp.example.com/keys");
                createdIdp.Protocol.Endpoints.Jwks.Binding.Should().Be("HTTP-REDIRECT");
                createdIdp.Protocol.Scopes.Should().ContainInOrder("openid", "profile", "email");
                createdIdp.Protocol.Issuer.Url.Should().Be("https://idp.example.com");
                createdIdp.Protocol.Credentials.Client.ClientId.Should().Be("your-client-id");
                createdIdp.Protocol.Credentials.Client.ClientSecret.Should().Be("your-client-secret");
                createdIdp.Policy.Provisioning.Action.Should().Be("AUTO");
                createdIdp.Policy.Provisioning.ProfileMaster.Should().BeFalse();
                createdIdp.Policy.Provisioning.Groups.Action.Should().Be("NONE");
                createdIdp.Policy.Provisioning.Conditions.Deprovisioned.Action.Should().Be("NONE");
                createdIdp.Policy.Provisioning.Conditions.Suspended.Action.Should().Be("NONE");
                createdIdp.Policy.AccountLink.Action.Should().Be("AUTO");
                createdIdp.Policy.Subject.UserNameTemplate.Template.Should().Be("idpuser.email");
                createdIdp.Policy.Subject.Filter.Should().BeNull();
                createdIdp.Policy.Subject.MatchType.Value.Should().Be("USERNAME");
                createdIdp.Policy.Subject.MatchAttribute.Should().BeNull();
            }
            finally
            {
                await createdIdp.DeactivateAsync();
                await client.IdentityProviders.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task AddFacebookIdp()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = new IdentityProvider()
            {
                Type = "FACEBOOK",
                Name = $"dotnet-sdk:AddFacebook{randomSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "public_profile", "email" },
                    Type = "OAUTH2",
                    Credentials = new IdentityProviderCredentials()
                    {
                        Client = new IdentityProviderCredentialsClient()
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
                        Action = "AUTO",
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = "AUTO",
                        ProfileMaster = true,
                        Conditions = new ProvisioningConditions()
                        {
                            Deprovisioned = new ProvisioningDeprovisionedCondition()
                            {
                                Action = "NONE",
                            },
                            Suspended = new ProvisioningSuspendedCondition()
                            {
                                Action = "NONE",
                            },
                        },
                        Groups = new ProvisioningGroups()
                        {
                            Action = "NONE",
                        },
                    },
                    MaxClockSkew = 0,
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = "USERNAME",
                        Filter = null,
                    },
                },
            };

            var createdIdp = await client.IdentityProviders.CreateIdentityProviderAsync(idp);

            try
            {
                createdIdp.Should().NotBeNull();
                createdIdp.Name.Should().Be($"dotnet-sdk:AddFacebook{randomSuffix}");
                createdIdp.Type.Should().Be("FACEBOOK");
                createdIdp.Status.Should().Be("ACTIVE");
                createdIdp.Protocol.Type.Should().Be("OAUTH2");
                createdIdp.Protocol.Scopes.Should().ContainInOrder("public_profile", "email");
                createdIdp.Protocol.Credentials.Client.ClientId.Should().Be("your-client-id");
                createdIdp.Protocol.Credentials.Client.ClientSecret.Should().Be("your-client-secret");
                createdIdp.Policy.Provisioning.Action.Should().Be("AUTO");
                createdIdp.Policy.Provisioning.ProfileMaster.Should().BeTrue();
                createdIdp.Policy.Provisioning.Groups.Action.Should().Be("NONE");
                createdIdp.Policy.Provisioning.Conditions.Deprovisioned.Action.Should().Be("NONE");
                createdIdp.Policy.Provisioning.Conditions.Suspended.Action.Should().Be("NONE");
                createdIdp.Policy.AccountLink.Action.Should().Be("AUTO");
                createdIdp.Policy.Subject.UserNameTemplate.Template.Should().Be("idpuser.email");
                createdIdp.Policy.Subject.Filter.Should().BeNull();
                createdIdp.Policy.Subject.MatchType.Value.Should().Be("USERNAME");
            }
            finally
            {
                await createdIdp.DeactivateAsync();
                await client.IdentityProviders.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task AddGoogleIdp()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = new IdentityProvider()
            {
                Type = "GOOGLE",
                Name = $"dotnet-sdk:AddGoogle{randomSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "profile", "email", "openid" },
                    Type = "OIDC",
                    Credentials = new IdentityProviderCredentials()
                    {
                        Client = new IdentityProviderCredentialsClient()
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
                        Action = "AUTO",
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = "AUTO",
                        ProfileMaster = true,
                        Conditions = new ProvisioningConditions()
                        {
                            Deprovisioned = new ProvisioningDeprovisionedCondition()
                            {
                                Action = "NONE",
                            },
                            Suspended = new ProvisioningSuspendedCondition()
                            {
                                Action = "NONE",
                            },
                        },
                        Groups = new ProvisioningGroups()
                        {
                            Action = "NONE",
                        },
                    },
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = "USERNAME",
                        Filter = null,
                    },
                },
            };

            var createdIdp = await client.IdentityProviders.CreateIdentityProviderAsync(idp);

            try
            {
                createdIdp.Should().NotBeNull();
                createdIdp.Name.Should().Be($"dotnet-sdk:AddGoogle{randomSuffix}");
                createdIdp.Type.Should().Be("GOOGLE");
                createdIdp.Status.Should().Be("ACTIVE");
                createdIdp.Protocol.Type.Should().Be("OIDC");
                createdIdp.Protocol.Scopes.Should().ContainInOrder("profile", "email", "openid");
                createdIdp.Protocol.Credentials.Client.ClientId.Should().Be("your-client-id");
                createdIdp.Protocol.Credentials.Client.ClientSecret.Should().Be("your-client-secret");
                createdIdp.Policy.Provisioning.Action.Should().Be("AUTO");
                createdIdp.Policy.Provisioning.ProfileMaster.Should().BeTrue();
                createdIdp.Policy.Provisioning.Groups.Action.Should().Be("NONE");
                createdIdp.Policy.Provisioning.Conditions.Deprovisioned.Action.Should().Be("NONE");
                createdIdp.Policy.Provisioning.Conditions.Suspended.Action.Should().Be("NONE");
                createdIdp.Policy.AccountLink.Action.Should().Be("AUTO");
                createdIdp.Policy.Subject.UserNameTemplate.Template.Should().Be("idpuser.email");
                createdIdp.Policy.Subject.Filter.Should().BeNull();
                createdIdp.Policy.Subject.MatchType.Value.Should().Be("USERNAME");
            }
            finally
            {
                await createdIdp.DeactivateAsync();
                await client.IdentityProviders.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task AddLinkedInIdp()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = new IdentityProvider()
            {
                Type = "LINKEDIN",
                Name = $"dotnet-sdk:AddLinkedIn{randomSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "r_basicprofile", "r_emailaddress"},
                    Type = "OAUTH2",
                    Credentials = new IdentityProviderCredentials()
                    {
                        Client = new IdentityProviderCredentialsClient()
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
                        Action = "AUTO",
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = "AUTO",
                        ProfileMaster = true,
                        Conditions = new ProvisioningConditions()
                        {
                            Deprovisioned = new ProvisioningDeprovisionedCondition()
                            {
                                Action = "NONE",
                            },
                            Suspended = new ProvisioningSuspendedCondition()
                            {
                                Action = "NONE",
                            },
                        },
                        Groups = new ProvisioningGroups()
                        {
                            Action = "NONE",
                        },
                    },
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = "USERNAME",
                        Filter = null,
                    },
                },
            };

            var createdIdp = await client.IdentityProviders.CreateIdentityProviderAsync(idp);

            try
            {
                createdIdp.Should().NotBeNull();
                createdIdp.Name.Should().Be($"dotnet-sdk:AddLinkedIn{randomSuffix}");
                createdIdp.Type.Should().Be("LINKEDIN");
                createdIdp.Status.Should().Be("ACTIVE");
                createdIdp.Protocol.Type.Should().Be("OAUTH2");
                createdIdp.Protocol.Scopes.Should().ContainInOrder("r_basicprofile", "r_emailaddress");
                createdIdp.Protocol.Credentials.Client.ClientId.Should().Be("your-client-id");
                createdIdp.Protocol.Credentials.Client.ClientSecret.Should().Be("your-client-secret");
                createdIdp.Policy.Provisioning.Action.Should().Be("AUTO");
                createdIdp.Policy.Provisioning.ProfileMaster.Should().BeTrue();
                createdIdp.Policy.Provisioning.Groups.Action.Should().Be("NONE");
                createdIdp.Policy.Provisioning.Conditions.Deprovisioned.Action.Should().Be("NONE");
                createdIdp.Policy.Provisioning.Conditions.Suspended.Action.Should().Be("NONE");
                createdIdp.Policy.AccountLink.Action.Should().Be("AUTO");
                createdIdp.Policy.Subject.UserNameTemplate.Template.Should().Be("idpuser.email");
                createdIdp.Policy.Subject.Filter.Should().BeNull();
                createdIdp.Policy.Subject.MatchType.Value.Should().Be("USERNAME");
            }
            finally
            {
                await createdIdp.DeactivateAsync();
                await client.IdentityProviders.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task AddMicrosoftIdp()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = new IdentityProvider()
            {
                Type = "MICROSOFT",
                Name = $"dotnet-sdk:AddMicrosoft{randomSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "openid", "email", "profile", "https://graph.microsoft.com/User.Read" },
                    Type = "OIDC",
                    Credentials = new IdentityProviderCredentials()
                    {
                        Client = new IdentityProviderCredentialsClient()
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
                        Action = "AUTO",
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = "AUTO",
                        ProfileMaster = true,
                        Conditions = new ProvisioningConditions()
                        {
                            Deprovisioned = new ProvisioningDeprovisionedCondition()
                            {
                                Action = "NONE",
                            },
                            Suspended = new ProvisioningSuspendedCondition()
                            {
                                Action = "NONE",
                            },
                        },
                        Groups = new ProvisioningGroups()
                        {
                            Action = "NONE",
                        },
                    },
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.userPrincipalName",
                        },
                        MatchType = "USERNAME",
                        Filter = null,
                    },
                },
            };

            var createdIdp = await client.IdentityProviders.CreateIdentityProviderAsync(idp);

            try
            {
                createdIdp.Should().NotBeNull();
                createdIdp.Name.Should().Be($"dotnet-sdk:AddMicrosoft{randomSuffix}");
                createdIdp.Type.Should().Be("MICROSOFT");
                createdIdp.Status.Should().Be("ACTIVE");
                createdIdp.Protocol.Type.Should().Be("OIDC");
                createdIdp.Protocol.Scopes.Should().ContainInOrder("openid", "email", "profile", "https://graph.microsoft.com/User.Read");
                createdIdp.Protocol.Credentials.Client.ClientId.Should().Be("your-client-id");
                createdIdp.Protocol.Credentials.Client.ClientSecret.Should().Be("your-client-secret");
                createdIdp.Policy.Provisioning.Action.Should().Be("AUTO");
                createdIdp.Policy.Provisioning.ProfileMaster.Should().BeTrue();
                createdIdp.Policy.Provisioning.Groups.Action.Should().Be("NONE");
                createdIdp.Policy.Provisioning.Conditions.Deprovisioned.Action.Should().Be("NONE");
                createdIdp.Policy.Provisioning.Conditions.Suspended.Action.Should().Be("NONE");
                createdIdp.Policy.AccountLink.Action.Should().Be("AUTO");
                createdIdp.Policy.Subject.UserNameTemplate.Template.Should().Be("idpuser.userPrincipalName");
                createdIdp.Policy.Subject.Filter.Should().BeNull();
                createdIdp.Policy.Subject.MatchType.Value.Should().Be("USERNAME");
            }
            finally
            {
                await createdIdp.DeactivateAsync();
                await client.IdentityProviders.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task GetIdp()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = new IdentityProvider()
            {
                Type = "LINKEDIN",
                Name = $"dotnet-sdk:GetIdp{randomSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "r_basicprofile", "r_emailaddress" },
                    Type = "OAUTH2",
                    Credentials = new IdentityProviderCredentials()
                    {
                        Client = new IdentityProviderCredentialsClient()
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
                        Action = "AUTO",
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = "AUTO",
                        ProfileMaster = true,
                        Conditions = new ProvisioningConditions()
                        {
                            Deprovisioned = new ProvisioningDeprovisionedCondition()
                            {
                                Action = "NONE",
                            },
                            Suspended = new ProvisioningSuspendedCondition()
                            {
                                Action = "NONE",
                            },
                        },
                        Groups = new ProvisioningGroups()
                        {
                            Action = "NONE",
                        },
                    },
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = "USERNAME",
                        Filter = null,
                    },
                },
            };

            var createdIdp = await client.IdentityProviders.CreateIdentityProviderAsync(idp);

            try
            {
                var retrievedIdp = await client.IdentityProviders.GetIdentityProviderAsync(createdIdp.Id);

                retrievedIdp.Should().NotBeNull();
                retrievedIdp.Name.Should().Be($"dotnet-sdk:GetIdp{randomSuffix}");
                retrievedIdp.Type.Should().Be("LINKEDIN");
                retrievedIdp.Status.Should().Be("ACTIVE");
                retrievedIdp.Protocol.Type.Should().Be("OAUTH2");
                retrievedIdp.Protocol.Scopes.Should().ContainInOrder("r_basicprofile", "r_emailaddress");
                retrievedIdp.Protocol.Credentials.Client.ClientId.Should().Be("your-client-id");
                retrievedIdp.Protocol.Credentials.Client.ClientSecret.Should().Be("your-client-secret");
                retrievedIdp.Policy.Provisioning.Action.Should().Be("AUTO");
                retrievedIdp.Policy.Provisioning.ProfileMaster.Should().BeTrue();
                retrievedIdp.Policy.Provisioning.Groups.Action.Should().Be("NONE");
                retrievedIdp.Policy.Provisioning.Conditions.Deprovisioned.Action.Should().Be("NONE");
                retrievedIdp.Policy.Provisioning.Conditions.Suspended.Action.Should().Be("NONE");
                retrievedIdp.Policy.AccountLink.Action.Should().Be("AUTO");
                retrievedIdp.Policy.Subject.UserNameTemplate.Template.Should().Be("idpuser.email");
                retrievedIdp.Policy.Subject.Filter.Should().BeNull();
                retrievedIdp.Policy.Subject.MatchType.Value.Should().Be("USERNAME");
            }
            finally
            {
                await createdIdp.DeactivateAsync();
                await client.IdentityProviders.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task ListIdps()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = new IdentityProvider()
            {
                Type = "LINKEDIN",
                Name = $"dotnet-sdk:ListIdp{randomSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "r_basicprofile", "r_emailaddress" },
                    Type = "OAUTH2",
                    Credentials = new IdentityProviderCredentials()
                    {
                        Client = new IdentityProviderCredentialsClient()
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
                        Action = "AUTO",
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = "AUTO",
                        ProfileMaster = true,
                        Groups = new ProvisioningGroups()
                        {
                            Action = "NONE",
                        },
                    },
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = "USERNAME",
                        Filter = null,
                    },
                },
            };

            var createdIdp = await client.IdentityProviders.CreateIdentityProviderAsync(idp);

            try
            {
                var idps = await client.IdentityProviders.ListIdentityProviders().ToListAsync();

                idps.Should().NotBeNullOrEmpty();
                idps.FirstOrDefault(x => x.Id == createdIdp.Id).Should().NotBeNull();
            }
            finally
            {
                await createdIdp.DeactivateAsync();
                await client.IdentityProviders.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task DeactivateRoutingRulesWhenDeactivateIdp()
        {
            var client = TestClient.Create();
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

            var createdKey = await client.IdentityProviders.CreateIdentityProviderKeyAsync(new JsonWebKey()
            {
                X5C = new List<string>() { key },
            });

            var idp = new IdentityProvider()
            {
                Type = "SAML2",
                Name = $"dotnet-sdk:DeactivateRoutingRules{randomSuffix}",
                Protocol = new Protocol()
                {
                    Algorithms = new ProtocolAlgorithms()
                    {
                        Request = new ProtocolAlgorithmType()
                        {
                            Signature = new ProtocolAlgorithmTypeSignature()
                            {
                                Algorithm = "SHA-256",
                                Scope = "REQUEST",
                            },
                        },
                        Response = new ProtocolAlgorithmType()
                        {
                            Signature = new ProtocolAlgorithmTypeSignature()
                            {
                                Algorithm = "SHA-256",
                                Scope = "ANY",
                            },
                        },
                    },
                    Endpoints = new ProtocolEndpoints()
                    {
                        Acs = new ProtocolEndpoint()
                        {
                            Binding = "HTTP-POST",
                            Type = "INSTANCE",
                        },
                        Sso = new ProtocolEndpoint()
                        {
                            Url = "https://idp.example.com",
                            Binding = "HTTP-POST",
                            Destination = "https://idp.example.com",
                        },
                    },
                    Scopes = new List<string>() { "openid", "profile", "email" },
                    Type = "SAML2",
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
                        Action = "AUTO",
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = "AUTO",
                        ProfileMaster = true,
                        Conditions = new ProvisioningConditions()
                        {
                            Deprovisioned = new ProvisioningDeprovisionedCondition()
                            {
                                Action = "NONE",
                            },
                            Suspended = new ProvisioningSuspendedCondition()
                            {
                                Action = "NONE",
                            },
                        },
                        Groups = new ProvisioningGroups()
                        {
                            Action = "NONE",
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
                        MatchType = "USERNAME",
                    },
                },
            };

            var createdIdp = await client.IdentityProviders.CreateIdentityProviderAsync(idp);
            var policyId = string.Empty;
            var policyRuleId = string.Empty;

            try
            {
                createdIdp.Should().NotBeNull();

                var policies = await client.Policies.ListPolicies("IDP_DISCOVERY").ToListAsync();

                policyId = policies.FirstOrDefault().Id;
                var idpPolicyRuleActionProvider = new IdpPolicyRuleActionProvider();
                idpPolicyRuleActionProvider.SetProperty("id", createdIdp.Id);

                var policyRule = new PolicyRule
                {
                    Type = "IDP_DISCOVERY",
                    Name = $"dotnet-sdk: DeactivateRoutingRuleIDP",
                    Actions = new PolicyRuleActions
                    {
                        Idp = new IdpPolicyRuleAction
                        {
                            Providers = new List<IIdpPolicyRuleActionProvider>()
                            {
                                idpPolicyRuleActionProvider,
                            },
                        },
                    },
                    Conditions = new PolicyRuleConditions
                    {
                        Network = new PolicyNetworkCondition
                        {
                            Connection = "ANYWHERE",
                        },
                        Platform = new PlatformPolicyRuleCondition
                        {
                            Include = new List<IPlatformConditionEvaluatorPlatform>
                            {
                                new PlatformConditionEvaluatorPlatform
                                {
                                    Type = "ANY",
                                    Os = new PlatformConditionEvaluatorPlatformOperatingSystem
                                    {
                                        Type = "ANY",
                                    },
                                },
                            },
                        },
                    },
                };

                var createdPolicyRule = await client.Policies.CreatePolicyRuleAsync(policyRule, policyId);
                policyRuleId = createdPolicyRule.Id;

                createdPolicyRule.Status.Should().Be("ACTIVE");
                createdIdp.Status.Should().Be("ACTIVE");

                await client.IdentityProviders.DeactivateIdentityProviderAsync(createdIdp.Id);

                var retrievedIdp = await client.IdentityProviders.GetIdentityProviderAsync(createdIdp.Id);
                retrievedIdp.Status.Should().Be("INACTIVE");

                var retrievedPolicyRule = await client.Policies.GetPolicyRuleAsync(policyId, policyRuleId);
                retrievedPolicyRule.Status.Should().Be("INACTIVE");
            }
            finally
            {
                await createdIdp.DeactivateAsync();
                await client.IdentityProviders.DeleteIdentityProviderAsync(createdIdp.Id);
                await client.IdentityProviders.DeleteIdentityProviderKeyAsync(createdKey.Kid);
            }
        }

        [Fact]
        public async Task DeactivateIdp()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = new IdentityProvider()
            {
                Type = "LINKEDIN",
                Name = $"dotnet-sdk:DeactivateIdp{randomSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "r_basicprofile", "r_emailaddress" },
                    Type = "OAUTH2",
                    Credentials = new IdentityProviderCredentials()
                    {
                        Client = new IdentityProviderCredentialsClient()
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
                        Action = "AUTO",
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = "AUTO",
                        ProfileMaster = true,
                        Groups = new ProvisioningGroups()
                        {
                            Action = "NONE",
                        },
                    },
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = "USERNAME",
                        Filter = null,
                    },
                },
            };

            var createdIdp = await client.IdentityProviders.CreateIdentityProviderAsync(idp);

            try
            {
                createdIdp.Status.Should().Be("ACTIVE");
                await client.IdentityProviders.DeactivateIdentityProviderAsync(createdIdp.Id);
                var retrievedIdp = await client.IdentityProviders.GetIdentityProviderAsync(createdIdp.Id);
                retrievedIdp.Status.Should().Be("INACTIVE");
            }
            finally
            {
                await createdIdp.DeactivateAsync();
                await client.IdentityProviders.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task ActivateIdp()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = new IdentityProvider()
            {
                Type = "LINKEDIN",
                Name = $"dotnet-sdk:ActivateIdp{randomSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "r_basicprofile", "r_emailaddress" },
                    Type = "OAUTH2",
                    Credentials = new IdentityProviderCredentials()
                    {
                        Client = new IdentityProviderCredentialsClient()
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
                        Action = "AUTO",
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = "AUTO",
                        ProfileMaster = true,
                        Groups = new ProvisioningGroups()
                        {
                            Action = "NONE",
                        },
                    },
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = "USERNAME",
                        Filter = null,
                    },
                },
            };

            var createdIdp = await client.IdentityProviders.CreateIdentityProviderAsync(idp);

            try
            {
                createdIdp.Status.Should().Be("ACTIVE");
                await createdIdp.DeactivateAsync();
                var retrievedIdp = await client.IdentityProviders.GetIdentityProviderAsync(createdIdp.Id);
                retrievedIdp.Status.Should().Be("INACTIVE");

                await createdIdp.ActivateAsync();
                retrievedIdp = await client.IdentityProviders.GetIdentityProviderAsync(createdIdp.Id);
                retrievedIdp.Status.Should().Be("ACTIVE");
            }
            finally
            {
                await createdIdp.DeactivateAsync();
                await client.IdentityProviders.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task UpdateIdp()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = new IdentityProvider()
            {
                Type = "LINKEDIN",
                Name = $"dotnet-sdk:UpdateIdp{randomSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "r_basicprofile", "r_emailaddress" },
                    Type = "OAUTH2",
                    Credentials = new IdentityProviderCredentials()
                    {
                        Client = new IdentityProviderCredentialsClient()
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
                        Action = "AUTO",
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = "AUTO",
                        ProfileMaster = true,
                        Groups = new ProvisioningGroups()
                        {
                            Action = "NONE",
                        },
                    },
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = "USERNAME",
                        Filter = null,
                    },
                },
            };

            var createdIdp = await client.IdentityProviders.CreateIdentityProviderAsync(idp);
            createdIdp.Name = $"dotnet-sdk:UpdateIdp{randomSuffix}-upd";

            Thread.Sleep(3000); // allow for user replication prior to read attempt

            try
            {
                var updatedIdp = await client.IdentityProviders.UpdateIdentityProviderAsync(createdIdp, createdIdp.Id);
                updatedIdp.Name.Should().Be($"dotnet-sdk:UpdateIdp{randomSuffix}-upd");
            }
            finally
            {
                await createdIdp.DeactivateAsync();
                await client.IdentityProviders.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task DeleteIdp()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = new IdentityProvider()
            {
                Type = "LINKEDIN",
                Name = $"dotnet-sdk:DeleteIdp{randomSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "r_basicprofile", "r_emailaddress" },
                    Type = "OAUTH2",
                    Credentials = new IdentityProviderCredentials()
                    {
                        Client = new IdentityProviderCredentialsClient()
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
                        Action = "AUTO",
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = "AUTO",
                        ProfileMaster = true,
                        Groups = new ProvisioningGroups()
                        {
                            Action = "NONE",
                        },
                    },
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = "USERNAME",
                        Filter = null,
                    },
                },
            };

            var createdIdp = await client.IdentityProviders.CreateIdentityProviderAsync(idp);
            var idpId = createdIdp.Id;

            await createdIdp.DeactivateAsync();
            await client.IdentityProviders.DeleteIdentityProviderAsync(idpId);

            // Getting by ID should result in 404 Not found
            await Assert.ThrowsAsync<OktaApiException>(() => client.IdentityProviders.GetIdentityProviderAsync(idpId));
        }

        [Fact]
        public async Task CreateKey()
        {
            var client = TestClient.Create();
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

            var createdKey = await client.IdentityProviders.CreateIdentityProviderKeyAsync(new JsonWebKey()
            {
                X5C = new List<string>() { key },
            });

            try
            {
                createdKey.Should().NotBeNull();
                createdKey.X5C.Should().Contain(key);
            }
            finally
            {
                await client.IdentityProviders.DeleteIdentityProviderKeyAsync(createdKey.Kid);
            }
        }

        [Fact]
        public async Task GetKey()
        {
            var client = TestClient.Create();
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

            var createdKey = await client.IdentityProviders.CreateIdentityProviderKeyAsync(new JsonWebKey()
            {
                X5C = new List<string>() { key },
            });

            try
            {
                var retrievedKey = await client.IdentityProviders.GetIdentityProviderKeyAsync(createdKey.Kid);
                retrievedKey.Should().NotBeNull();
                retrievedKey.X5C.Should().Contain(key);
            }
            finally
            {
                await client.IdentityProviders.DeleteIdentityProviderKeyAsync(createdKey.Kid);
            }
        }

        [Fact]
        public async Task ListKeys()
        {
            var client = TestClient.Create();
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

            var createdKey = await client.IdentityProviders.CreateIdentityProviderKeyAsync(new JsonWebKey()
            {
                X5C = new List<string>() { key },
            });

            try
            {
                var idpKeys = await client.IdentityProviders.ListIdentityProviderKeys().ToListAsync();
                idpKeys.Should().NotBeNullOrEmpty();
                idpKeys.FirstOrDefault(x => x.Kid == createdKey.Kid).Should().NotBeNull();
            }
            finally
            {
                await client.IdentityProviders.DeleteIdentityProviderKeyAsync(createdKey.Kid);
            }
        }

        [Fact]
        public async Task DeleteKey()
        {
            var client = TestClient.Create();
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

            var createdKey = await client.IdentityProviders.CreateIdentityProviderKeyAsync(new JsonWebKey()
            {
                X5C = new List<string>() { key },
            });

            var kid = createdKey.Kid;
            await client.IdentityProviders.DeleteIdentityProviderKeyAsync(createdKey.Kid);

            // Getting by ID should result in 404 Not found
            await Assert.ThrowsAsync<OktaApiException>(() => client.IdentityProviders.GetIdentityProviderKeyAsync(kid));
        }

        [Fact]
        public async Task GenerateSigningKey()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = GetTestIdpInstance("GenerateKey", randomSuffix);
            var createdIdp = await client.IdentityProviders.CreateIdentityProviderAsync(idp);

            try
            {
                var generatedKey = await createdIdp.GenerateSigningKeyAsync(2);

                generatedKey.Should().NotBeNull();
            }
            finally
            {
                await createdIdp.DeactivateAsync();
                await client.IdentityProviders.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task ListSigningKeys()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = GetTestIdpInstance("ListSigningKeys", randomSuffix);
            var createdIdp = await client.IdentityProviders.CreateIdentityProviderAsync(idp);

            try
            {
                var generatedKey1 = await createdIdp.GenerateSigningKeyAsync(2);
                var generatedKey2 = await createdIdp.GenerateSigningKeyAsync(2);

                var keys = await createdIdp.ListSigningKeys().ToListAsync();

                keys.Should().NotBeNullOrEmpty();
                keys.FirstOrDefault(x => x.Kid == generatedKey1.Kid).Should().NotBeNull();
                keys.FirstOrDefault(x => x.Kid == generatedKey2.Kid).Should().NotBeNull();
            }
            finally
            {
                await createdIdp.DeactivateAsync();
                await client.IdentityProviders.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task GetSigningKey()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = GetTestIdpInstance("GetSigningKey", randomSuffix);
            var createdIdp = await client.IdentityProviders.CreateIdentityProviderAsync(idp);

            try
            {
                var generatedKey = await createdIdp.GenerateSigningKeyAsync(2);
                var retrievedKey = await createdIdp.GetSigningKeyAsync(generatedKey.Kid);

                retrievedKey.Should().NotBeNull();
            }
            finally
            {
                await createdIdp.DeactivateAsync();
                await client.IdentityProviders.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task CloneSigningKey()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp1 = GetTestIdpInstance("CloneSigningKey1", randomSuffix);
            var createdIdp1 = await client.IdentityProviders.CreateIdentityProviderAsync(idp1);

            var idp2 = GetTestIdpInstance("CloneSigningKey2", randomSuffix);
            var createdIdp2 = await client.IdentityProviders.CreateIdentityProviderAsync(idp2);

            try
            {
                var generatedKey1 = await createdIdp1.GenerateSigningKeyAsync(2);
                var clonedKey = await createdIdp1.CloneKeyAsync(generatedKey1.Kid, createdIdp2.Id);

                clonedKey.Should().NotBeNull();
                clonedKey.Kid.Should().Be(generatedKey1.Kid);
            }
            finally
            {
                await createdIdp1.DeactivateAsync();
                await client.IdentityProviders.DeleteIdentityProviderAsync(createdIdp1.Id);
                await createdIdp2.DeactivateAsync();
                await client.IdentityProviders.DeleteIdentityProviderAsync(createdIdp2.Id);
            }
        }

        [Fact]
        public async Task GenerateCsr()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = GetTestIdpInstance("GenerateCsr", randomSuffix);
            var createdIdp = await client.IdentityProviders.CreateIdentityProviderAsync(idp);

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

                var generatedCsr = await createdIdp.GenerateCsrAsync(csrMetadata);

                generatedCsr.Should().NotBeNull();
                generatedCsr.Kty.Should().Be("RSA");
                generatedCsr.CsrValue.Should().NotBeNullOrEmpty();
            }
            finally
            {
                await createdIdp.DeactivateAsync();
                await client.IdentityProviders.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task RevokeCsr()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = GetTestIdpInstance("RevokeCsr", randomSuffix);
            var createdIdp = await client.IdentityProviders.CreateIdentityProviderAsync(idp);

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

                var generatedCsr = await createdIdp.GenerateCsrAsync(csrMetadata);

                var retrievedCsr = await createdIdp.ListSigningCsrs().Where(x => x.Id == generatedCsr.Id).FirstOrDefaultAsync();
                retrievedCsr.Should().NotBeNull();

                await createdIdp.DeleteSigningCsrAsync(generatedCsr.Id);

                retrievedCsr = await createdIdp.ListSigningCsrs().Where(x => x.Id == generatedCsr.Id).FirstOrDefaultAsync();
                retrievedCsr.Should().BeNull();
            }
            finally
            {
                await createdIdp.DeactivateAsync();
                await client.IdentityProviders.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact]
        public async Task GetCsr()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var idp = GetTestIdpInstance("GetCsr", randomSuffix);
            var createdIdp = await client.IdentityProviders.CreateIdentityProviderAsync(idp);

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

                var generatedCsr = await createdIdp.GenerateCsrAsync(csrMetadata);
                var retrievedCsr = await createdIdp.GetSigningCsrAsync(generatedCsr.Id);

                generatedCsr.Should().NotBeNull();
                retrievedCsr.Kty.Should().Be(generatedCsr.Kty);
                retrievedCsr.CsrValue.Should().Be(generatedCsr.CsrValue);
            }
            finally
            {
                await createdIdp.DeactivateAsync();
                await client.IdentityProviders.DeleteIdentityProviderAsync(createdIdp.Id);
            }
        }

        [Fact(Skip = "Needs special permissions")]
        public async Task AddSmartCardIdp()
        {
            var client = TestClient.Create();
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

            var createdKey = await client.IdentityProviders.CreateIdentityProviderKeyAsync(new JsonWebKey()
            {
                X5C = new List<string>() { key },
            });

            var idp = new IdentityProvider()
            {
                Type = "X509",
                Name = $"dotnet-sdk:AddSmartCard{randomSuffix}",
                Status = "ACTIVE",
                Protocol = new Protocol()
                {
                    Type = "MTLS",
                    Credentials = new IdentityProviderCredentials()
                    {
                        Trust = new IdentityProviderCredentialsTrust()
                        {
                            Revocation = "CRL",
                            RevocationCacheLifetime = 2800,
                            Issuer = "your-issuer",
                            Kid = createdKey.Kid,
                        },
                    },
                },
                Policy = new IdentityProviderPolicy()
                {
                    Provisioning = new Provisioning()
                    {
                        Action = "DISABLED",
                    },
                    MaxClockSkew = 120000,
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.subjectAltNameEmail",
                        },
                        MatchType = "EMAIL",
                    },
                },
            };

            var createdIdp = await client.IdentityProviders.CreateIdentityProviderAsync(idp);

            try
            {
                createdIdp.Should().NotBeNull();
                createdIdp.Name.Should().Be($"dotnet-sdk:AddSmartCard{randomSuffix}");
                createdIdp.Type.Should().Be("X509");
                createdIdp.Status.Should().Be("ACTIVE");
                createdIdp.Protocol.Type.Should().Be("MTLS");
                createdIdp.Protocol.Credentials.Trust.Revocation.Should().Be("CRL");
                createdIdp.Protocol.Credentials.Trust.RevocationCacheLifetime.Should().Be(2800);
                createdIdp.Policy.Provisioning.Action.Should().Be("DISABLED");
                createdIdp.Policy.Provisioning.ProfileMaster.Should().BeFalse();
                createdIdp.Policy.Subject.UserNameTemplate.Template.Should().Be("idpuser.subjectAltNameEmail");
                createdIdp.Policy.Subject.Filter.Should().BeNull();
                createdIdp.Policy.Subject.MatchType.Value.Should().Be("EMAIL");
            }
            finally
            {
                await createdIdp.DeactivateAsync();
                await client.IdentityProviders.DeleteIdentityProviderAsync(createdIdp.Id);
                await client.IdentityProviders.DeleteIdentityProviderKeyAsync(createdKey.Kid);
            }
        }

        [Fact]
        public async Task AddSamlIdp()
        {
            var client = TestClient.Create();
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

            var createdKey = await client.IdentityProviders.CreateIdentityProviderKeyAsync(new JsonWebKey()
            {
                X5C = new List<string>() { key },
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
                                Scope = "REQUEST",
                            },
                        },
                        Response = new ProtocolAlgorithmType()
                        {
                            Signature = new ProtocolAlgorithmTypeSignature()
                            {
                                Algorithm = "SHA-256",
                                Scope = "ANY",
                            },
                        },
                    },
                    Endpoints = new ProtocolEndpoints()
                    {
                        Acs = new ProtocolEndpoint()
                        {
                            Binding = "HTTP-POST",
                            Type = "INSTANCE",
                        },
                        Sso = new ProtocolEndpoint()
                        {
                            Url = "https://idp.example.com",
                            Binding = "HTTP-POST",
                            Destination = "https://idp.example.com",
                        },
                    },
                    Scopes = new List<string>() { "openid", "profile", "email" },
                    Type = "SAML2",
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
                        Action = "AUTO",
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = "AUTO",
                        ProfileMaster = true,
                        Conditions = new ProvisioningConditions()
                        {
                            Deprovisioned = new ProvisioningDeprovisionedCondition()
                            {
                                Action = "NONE",
                            },
                            Suspended = new ProvisioningSuspendedCondition()
                            {
                                Action = "NONE",
                            },
                        },
                        Groups = new ProvisioningGroups()
                        {
                            Action = "NONE",
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
                        MatchType = "USERNAME",
                    },
                },
            };

            var createdIdp = await client.IdentityProviders.CreateIdentityProviderAsync(idp);

            try
            {
                createdIdp.Should().NotBeNull();
                createdIdp.Name.Should().Be($"dotnet-sdk:AddSAML{randomSuffix}");
                createdIdp.Type.Should().Be("SAML2");
                createdIdp.Status.Should().Be("ACTIVE");
                createdIdp.Protocol.Type.Should().Be("SAML2");
                createdIdp.Protocol.Endpoints.Sso.Url.Should().Be("https://idp.example.com");
                createdIdp.Protocol.Endpoints.Sso.Binding.Should().Be("HTTP-POST");
                createdIdp.Protocol.Endpoints.Sso.Destination.Should().Be("https://idp.example.com");
                createdIdp.Protocol.Endpoints.Acs.Type.Should().Be("INSTANCE");
                createdIdp.Protocol.Endpoints.Acs.Binding.Should().Be("HTTP-POST");
                createdIdp.Protocol.Settings.NameFormat.Should().Be("urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified");
                createdIdp.Protocol.Credentials.Trust.Issuer.Should().Be("https://idp.example.com");
                createdIdp.Protocol.Credentials.Trust.Audience.Should().Be("http://www.okta.com/123");
                createdIdp.Policy.Provisioning.Action.Should().Be("AUTO");
                createdIdp.Policy.Provisioning.ProfileMaster.Should().BeTrue();
                createdIdp.Policy.Provisioning.Groups.Action.Should().Be("NONE");
                createdIdp.Policy.Provisioning.Conditions.Deprovisioned.Action.Should().Be("NONE");
                createdIdp.Policy.Provisioning.Conditions.Suspended.Action.Should().Be("NONE");

                createdIdp.Policy.Provisioning.Conditions.Suspended.Action.Should().Be("NONE");
                createdIdp.Policy.AccountLink.Action.Should().Be("AUTO");
                createdIdp.Policy.Subject.UserNameTemplate.Template.Should().Be("idpuser.subjectNameId");
                createdIdp.Policy.Subject.MatchType.Value.Should().Be("USERNAME");
                createdIdp.Policy.Subject.MatchAttribute.Should().BeNull();
            }
            finally
            {
                await createdIdp.DeactivateAsync();
                await client.IdentityProviders.DeleteIdentityProviderAsync(createdIdp.Id);
                await client.IdentityProviders.DeleteIdentityProviderKeyAsync(createdKey.Kid);
            }
        }

        private IIdentityProvider GetTestIdpInstance(string idpNameKeyword, string randomSuffix)
        {
            return new IdentityProvider()
            {
                Type = "LINKEDIN",
                Name = $"dotnet-sdk:{idpNameKeyword}{randomSuffix}",
                Protocol = new Protocol()
                {
                    Scopes = new List<string>() { "r_basicprofile", "r_emailaddress" },
                    Type = "OAUTH2",
                    Credentials = new IdentityProviderCredentials()
                    {
                        Client = new IdentityProviderCredentialsClient()
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
                        Action = "AUTO",
                        Filter = null,
                    },
                    Provisioning = new Provisioning()
                    {
                        Action = "AUTO",
                        ProfileMaster = true,
                        Groups = new ProvisioningGroups()
                        {
                            Action = "NONE",
                        },
                    },
                    Subject = new PolicySubject()
                    {
                        UserNameTemplate = new PolicyUserNameTemplate()
                        {
                            Template = "idpuser.email",
                        },
                        MatchType = "USERNAME",
                        Filter = null,
                    },
                },
            };
        }
    }
}
