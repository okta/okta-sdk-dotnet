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
    
    public class mappingScenarios
    {
        private UserTypeApi _userTypeApi;
        private ProfileMappingApi _profileMappingApi;
        private IdentityProviderApi _idpApi;

        public mappingScenarios()
        {
            _profileMappingApi = new ProfileMappingApi();
            _userTypeApi = new UserTypeApi();
            _idpApi = new IdentityProviderApi();

        }

        [Fact]
        public async Task ListProfileMappings()
        {
            var randomSuffix = GetRandomSuffix();

            UserType userType = null;

            try
            {
                userType = await _userTypeApi.CreateUserTypeAsync(
                    new UserType
                    {
                        DisplayName = $"dotnet-sdk{nameof(ListProfileMappings)}{randomSuffix}",
                        Name = $"list_profile_mapping_{randomSuffix}",
                    });

                Thread.Sleep(6000);
                var mappings = await _profileMappingApi.ListProfileMappings(sourceId: userType.Id)
                    .ToListAsync();

                mappings.Should().NotBeNullOrEmpty();
            }
            finally
            {
                if (userType != null)
                {
                    await _userTypeApi.DeleteUserTypeAsync(userType.Id);
                }
            }
        }

        [Fact]
        public async Task GetProfileMapping()
        {
            var randomSuffix = GetRandomSuffix();

            UserType userType = null;

            try
            {
                userType = await _userTypeApi.CreateUserTypeAsync(
                    new UserType
                    {
                        DisplayName = $"dotnet-sdk{nameof(GetProfileMapping)}{randomSuffix}",
                        Name = $"get_profile_mapping_{randomSuffix}",
                    });

                Thread.Sleep(6000);

                var mappings = await _profileMappingApi.ListProfileMappings(sourceId: userType.Id)
                    .ToListAsync();

                mappings.Should().NotBeNullOrEmpty();

                var mappingId = mappings.FirstOrDefault().Id;

                var retrievedMapping = await _profileMappingApi.GetProfileMappingAsync(mappingId);

                retrievedMapping.Should().NotBeNull();
            }
            finally
            {
                if (userType != null)
                {
                    await _userTypeApi.DeleteUserTypeAsync(userType.Id);
                }
            }
        }

        [Fact]
        public async Task UpdateProfileMapping()
        {
            var randomSuffix = GetRandomSuffix();

            IdentityProvider createdIdp = null;

            JsonWebKey createdKey = null;

            try
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

                createdKey = await _idpApi.CreateIdentityProviderKeyAsync(new JsonWebKey()
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

                createdIdp = await _idpApi.CreateIdentityProviderAsync(idp);
                
                Thread.Sleep(6000);

                var mappings = await _profileMappingApi
                                                        .ListProfileMappings(sourceId: createdIdp.Id)
                                                        .ToListAsync();

                mappings.Should().NotBeNullOrEmpty();

                var mapping = await _profileMappingApi.GetProfileMappingAsync(mappings.FirstOrDefault().Id);
                mapping.Properties?.Keys?.Should().NotContain("userType");
                mapping.Properties?.Keys?.Should().NotContain("nickName");

                var profileMappingRequest = new ProfileMappingRequest();
                profileMappingRequest.Properties = new Dictionary<string, ProfileMappingProperty>();
                profileMappingRequest.Properties.Add("userType", new ProfileMappingProperty
                {
                    Expression = "appuser.firstName",
                    PushStatus = ProfileMappingPropertyPushStatus.PUSH,
                });

                profileMappingRequest.Properties.Add("nickName", new ProfileMappingProperty
                {
                    Expression = "appuser.firstName + appuser.lastName",
                    PushStatus = ProfileMappingPropertyPushStatus.PUSH,
                });


                var updatedMapping = await _profileMappingApi.UpdateProfileMappingAsync(mapping.Id, profileMappingRequest);
                updatedMapping.Properties.Keys.Should().Contain("userType");
                updatedMapping.Properties.Keys.Should().Contain("nickName");
                updatedMapping.Properties["nickName"].Expression.Should().Be("appuser.firstName + appuser.lastName");
                updatedMapping.Properties["nickName"].PushStatus.Should().Be(ProfileMappingPropertyPushStatus.PUSH);



                // Update property
                profileMappingRequest.Properties["nickName"] = 
                    new ProfileMappingProperty
                    {
                        Expression = "source.userName",
                        PushStatus = ProfileMappingPropertyPushStatus.PUSH,
                    };

                updatedMapping = await _profileMappingApi.UpdateProfileMappingAsync(mapping.Id, profileMappingRequest);
                updatedMapping.Properties.Keys.Should().Contain("nickName");
                updatedMapping.Properties["nickName"].Expression.Should().Be("source.userName");
                updatedMapping.Properties["nickName"].PushStatus.Should().Be(ProfileMappingPropertyPushStatus.PUSH);

                // Remove property
                profileMappingRequest.Properties["nickName"] =  null;
                updatedMapping = await _profileMappingApi.UpdateProfileMappingAsync(mapping.Id, profileMappingRequest);
                updatedMapping.Properties.Keys.Should().NotContain("nickName");
            }
            finally
            {
                if (createdIdp != null)
                {
                    await _idpApi.DeactivateIdentityProviderAsync(createdIdp.Id);
                    await _idpApi.DeleteIdentityProviderAsync(createdIdp.Id);
                    await _idpApi.DeleteIdentityProviderKeyAsync(createdKey.Kid);
                }
            }
        }

        /// <summary>
        /// Creates a random string using UTCNow and replaces special chars by "_" to successfully create User Types.  
        /// </summary>
        /// <returns></returns>
        private static string GetRandomSuffix()
        {
            return DateTime.UtcNow.ToString()
                .Replace("/", "_")
                .Replace(" ", "_")
                .Replace(":", "_")
                .Replace("-", "_");
        }
    }
}
