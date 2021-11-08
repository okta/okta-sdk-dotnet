// <copyright file="TrustedOriginScenarios.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    public class TrustedOriginScenarios
    {
        private static string dotnetSdkPrefix = "dotnetSdk";

        [Fact]
        public async Task ListOrigins()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();
            var testTrustedOriginName = $"{dotnetSdkPrefix}_{nameof(ListOrigins)}_{guid}_Test";
            var createdTrustedOrigin = await client.TrustedOrigins.CreateOriginAsync(
                new TrustedOrigin
                {
                    Name = testTrustedOriginName,
                    Origin = "http://example.com",
                    Scopes = new List<IScope>()
                    {
                        new Scope()
                        {
                            Type = ScopeType.Cors,
                        },
                        new Scope()
                        {
                            Type = ScopeType.Redirect,
                        },
                    },
                });

            try
            {
                var trustedOrigins = await client.TrustedOrigins.ListOrigins().ToListAsync();
                trustedOrigins.Should().NotBeNull();
                trustedOrigins.Count.Should().BeGreaterThan(0);
                trustedOrigins.FirstOrDefault(to => to.Name.Equals(testTrustedOriginName)).Should().NotBeNull();
            }
            finally
            {
                await client.TrustedOrigins.DeleteOriginAsync(createdTrustedOrigin.Id);
            }
        }

        [Fact]
        public async Task CreateOrigin()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();
            var testTrustedOriginName = $"{dotnetSdkPrefix}_{nameof(CreateOrigin)}_{guid}_Test";
            var createdTrustedOrigin = await client.TrustedOrigins.CreateOriginAsync(
                new TrustedOrigin
                {
                    Name = testTrustedOriginName,
                    Origin = "http://example.com",
                    Scopes = new List<IScope>()
                    {
                        new Scope()
                        {
                            Type = ScopeType.Cors,
                        },
                        new Scope()
                        {
                            Type = ScopeType.Redirect,
                        },
                    },
                });

            try
            {
                createdTrustedOrigin.Should().NotBeNull();
                createdTrustedOrigin.Name.Should().Be(testTrustedOriginName);
                createdTrustedOrigin.Scopes.Count.Should().Be(2);
                createdTrustedOrigin.Scopes.FirstOrDefault(scope => scope.Type == ScopeType.Cors).Should().NotBeNull();
                createdTrustedOrigin.Scopes.FirstOrDefault(scope => scope.Type == ScopeType.Redirect).Should().NotBeNull();
            }
            finally
            {
                await client.TrustedOrigins.DeleteOriginAsync(createdTrustedOrigin.Id);
            }
        }

        [Fact]
        public async Task DeleteOrigin()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();
            var testTrustedOriginName = $"{dotnetSdkPrefix}_{nameof(DeleteOrigin)}_{guid}_Test";
            var createdTrustedOrigin = await client.TrustedOrigins.CreateOriginAsync(
                new TrustedOrigin
                {
                    Name = testTrustedOriginName,
                    Origin = "http://example.com",
                    Scopes = new List<IScope>()
                    {
                        new Scope()
                        {
                            Type = ScopeType.Cors,
                        },
                        new Scope()
                        {
                            Type = ScopeType.Redirect,
                        },
                    },
                });

            var retrievedTrustedOrigin = await client.TrustedOrigins.GetOriginAsync(createdTrustedOrigin.Id);
            retrievedTrustedOrigin.Should().NotBeNull();
            await client.TrustedOrigins.DeleteOriginAsync(createdTrustedOrigin.Id);

            var ex = await Assert.ThrowsAsync<OktaApiException>(() => client.TrustedOrigins.GetOriginAsync(createdTrustedOrigin.Id));
            ex.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task GetOrigin()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();
            var testTrustedOriginName = $"{dotnetSdkPrefix}_{nameof(GetOrigin)}_{guid}_Test";
            var createdTrustedOrigin = await client.TrustedOrigins.CreateOriginAsync(
                new TrustedOrigin
                {
                    Name = testTrustedOriginName,
                    Origin = "http://example.com",
                    Scopes = new List<IScope>()
                    {
                        new Scope()
                        {
                            Type = ScopeType.Cors,
                        },
                        new Scope()
                        {
                            Type = ScopeType.Redirect,
                        },
                    },
                });
            try
            {
                var retrievedTrustedOrigin = await client.TrustedOrigins.GetOriginAsync(createdTrustedOrigin.Id);
                retrievedTrustedOrigin.Should().NotBeNull();
                retrievedTrustedOrigin.Id.Should().Be(createdTrustedOrigin.Id);
                retrievedTrustedOrigin.Name.Should().Be(createdTrustedOrigin.Name);
                retrievedTrustedOrigin.Origin.Should().Be(createdTrustedOrigin.Origin);
            }
            finally
            {
                await client.TrustedOrigins.DeleteOriginAsync(createdTrustedOrigin.Id);
            }
        }

        [Fact]
        public async Task UpdateOrigin()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();
            var testTrustedOriginName = $"{dotnetSdkPrefix}_{nameof(UpdateOrigin)}_{guid}_Test";
            var testUpdatedTrustedOriginName = $"{dotnetSdkPrefix}_{nameof(UpdateOrigin)}_{guid}_Test_Updated";
            var createdTrustedOrigin = await client.TrustedOrigins.CreateOriginAsync(
                new TrustedOrigin
                {
                    Name = testTrustedOriginName,
                    Origin = "http://example.com",
                    Scopes = new List<IScope>()
                    {
                        new Scope()
                        {
                            Type = ScopeType.Cors,
                        },
                        new Scope()
                        {
                            Type = ScopeType.Redirect,
                        },
                    },
                });

            try
            {
                createdTrustedOrigin.Name.Should().Be(testTrustedOriginName);
                var updatedTrustedOrigin = new TrustedOrigin
                {
                    Name = testUpdatedTrustedOriginName,
                    Origin = "http://example.com",
                    Scopes = new List<IScope>()
                    {
                        new Scope()
                        {
                            Type = ScopeType.Cors,
                        },
                        new Scope()
                        {
                            Type = ScopeType.Redirect,
                        },
                    },
                };
                var updatedTrustedOriginResponse = await client.TrustedOrigins.UpdateOriginAsync(updatedTrustedOrigin, createdTrustedOrigin.Id);
                updatedTrustedOriginResponse.Id.Should().Be(createdTrustedOrigin.Id);
                updatedTrustedOriginResponse.Name.Should().Be(testUpdatedTrustedOriginName);

                var retrievedTrustedOriginResponse = await client.TrustedOrigins.GetOriginAsync(updatedTrustedOriginResponse.Id);
                retrievedTrustedOriginResponse.Id.Should().Be(createdTrustedOrigin.Id);
                retrievedTrustedOriginResponse.Name.Should().Be(testUpdatedTrustedOriginName);
            }
            finally
            {
                await client.TrustedOrigins.DeleteOriginAsync(createdTrustedOrigin.Id);
            }
        }

        [Fact]
        public async Task ActivateOrigin()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();
            var testTrustedOriginName = $"{dotnetSdkPrefix}_{nameof(ActivateOrigin)}_{guid}_Test";
            var createdTrustedOrigin = await client.TrustedOrigins.CreateOriginAsync(
                new TrustedOrigin
                {
                    Name = testTrustedOriginName,
                    Origin = "http://example.com",
                    Scopes = new List<IScope>()
                    {
                        new Scope()
                        {
                            Type = ScopeType.Cors,
                        },
                        new Scope()
                        {
                            Type = ScopeType.Redirect,
                        },
                    },
                });

            try
            {
                createdTrustedOrigin.Status.Should().Be("ACTIVE");
                var deactivatedTrustedOrigin = await client.TrustedOrigins.DeactivateOriginAsync(createdTrustedOrigin.Id);
                deactivatedTrustedOrigin.Status.Should().Be("INACTIVE");
                var reactivatedTrustedOrigin = await client.TrustedOrigins.ActivateOriginAsync(createdTrustedOrigin.Id);
                reactivatedTrustedOrigin.Status.Should().Be("ACTIVE");
            }
            finally
            {
                await client.TrustedOrigins.DeleteOriginAsync(createdTrustedOrigin.Id);
            }
        }

        [Fact]
        public async Task DeactivateOrigin()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();
            var testTrustedOriginName = $"{dotnetSdkPrefix}_{nameof(ActivateOrigin)}_{guid}_Test";
            var createdTrustedOrigin = await client.TrustedOrigins.CreateOriginAsync(
                new TrustedOrigin
                {
                    Name = testTrustedOriginName,
                    Origin = "http://example.com",
                    Scopes = new List<IScope>()
                    {
                        new Scope()
                        {
                            Type = ScopeType.Cors,
                        },
                        new Scope()
                        {
                            Type = ScopeType.Redirect,
                        },
                    },
                });

            try
            {
                createdTrustedOrigin.Status.Should().Be("ACTIVE");
                var deactivatedTrustedOrigin = await client.TrustedOrigins.DeactivateOriginAsync(createdTrustedOrigin.Id);
                deactivatedTrustedOrigin.Status.Should().Be("INACTIVE");
            }
            finally
            {
                await client.TrustedOrigins.DeleteOriginAsync(createdTrustedOrigin.Id);
            }
        }
    }
}
