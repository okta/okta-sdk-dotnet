// <copyright file="PoliciesScenarios.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    [Collection(nameof(PoliciesScenarios))]
    public class PoliciesScenarios
    {
        [Fact]
        public async Task CreatePolicy()
        {
            var client = TestClient.Create();

            IPolicy policy = new Policy()
            {
                // Name has a maximum of 50 chars
                Name = $"Default policy {Guid.NewGuid()}".Substring(0, 50),
                Type = PolicyType.OktaSignOn,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await client.Policies.CreatePolicyAsync(policy);

            try
            {
                createdPolicy.Should().NotBeNull();
                createdPolicy.Name.Should().Be(policy.Name);
                createdPolicy.Type.Should().Be(PolicyType.OktaSignOn);
                createdPolicy.Status.Should().Be("ACTIVE");
                createdPolicy.Description.Should().Be(policy.Description);
            }
            finally
            {
                await client.Policies.DeactivatePolicyAsync(createdPolicy.Id);
                await client.Policies.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact]
        public async Task GetAPolicy()
        {
            var client = TestClient.Create();

            IPolicy policy = new Policy()
            {
                // Name has a maximum of 50 chars
                Name = $"Default policy {Guid.NewGuid()}".Substring(0, 50),
                Type = PolicyType.OktaSignOn,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await client.Policies.CreatePolicyAsync(policy);

            try
            {
                var retrievedPolicy = await client.Policies.GetPolicyAsync(createdPolicy.Id);

                retrievedPolicy.Should().NotBeNull();
                retrievedPolicy.Name.Should().Be(policy.Name);
                retrievedPolicy.Type.Should().Be(PolicyType.OktaSignOn);
                retrievedPolicy.Status.Should().Be("ACTIVE");
                retrievedPolicy.Description.Should().Be(policy.Description);
            }
            finally
            {
                await client.Policies.DeactivatePolicyAsync(createdPolicy.Id);
                await client.Policies.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact]
        public async Task GetAPolicyOfType()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var createdGroup = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"Group Policy People {guid}",
            });

            var policy = new OktaSignOnPolicy()
            {
                // Name has a maximum of 50 chars
                Name = $"Default policy {guid}".Substring(0, 50),
                Type = PolicyType.OktaSignOn,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            IOktaSignOnPolicyConditions policyConditions = new OktaSignOnPolicyConditions()
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

            var createdPolicy = await client.Policies.CreatePolicyAsync(policy);

            try
            {
                var retrievedPolicy = await client.Policies.GetPolicyAsync<IOktaSignOnPolicy>(createdPolicy.Id);

                retrievedPolicy.Should().NotBeNull();
                retrievedPolicy.Name.Should().Be(policy.Name);
                retrievedPolicy.Type.Should().Be(PolicyType.OktaSignOn);
                retrievedPolicy.Status.Should().Be("ACTIVE");
                retrievedPolicy.Description.Should().Be(policy.Description);
                retrievedPolicy.Conditions.Should().NotBeNull();
                retrievedPolicy.Conditions.People.Groups.Should().NotBeNull();
                retrievedPolicy.Conditions.People.Groups.Include.Should().HaveCount(1);
                retrievedPolicy.Conditions.People.Groups.Include.First().Should().Be(createdGroup.Id);
            }
            finally
            {
                await createdGroup.DeleteAsync();
                await client.Policies.DeactivatePolicyAsync(createdPolicy.Id);
                await client.Policies.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact]
        public async Task CreateSignOnPolicyWithGroupConditions()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var createdGroup = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"Group Policy People {guid}",
            });

            var policy = new OktaSignOnPolicy()
            {
                // Name has a maximum of 50 chars
                Name = $"Default policy {guid}".Substring(0, 50),
                Type = PolicyType.OktaSignOn,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            IOktaSignOnPolicyConditions policyConditions = new OktaSignOnPolicyConditions()
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

            var createdPolicy = await client.Policies.CreatePolicyAsync(policy);

            try
            {
                createdPolicy.Should().NotBeNull();
                createdPolicy.Name.Should().Be(policy.Name);
                createdPolicy.Type.Should().Be(PolicyType.OktaSignOn);
                createdPolicy.Status.Should().Be("ACTIVE");
                createdPolicy.Description.Should().Be(policy.Description);
                ((IOktaSignOnPolicy)createdPolicy).Conditions.Should().NotBeNull();
                ((IOktaSignOnPolicy)createdPolicy).Conditions.People.Groups.Should().NotBeNull();
                ((IOktaSignOnPolicy)createdPolicy).Conditions.People.Groups.Include.Should().HaveCount(1);
                ((IOktaSignOnPolicy)createdPolicy).Conditions.People.Groups.Include.First().Should().Be(createdGroup.Id);
            }
            finally
            {
                await createdGroup.DeleteAsync();
                await client.Policies.DeactivatePolicyAsync(createdPolicy.Id);
                await client.Policies.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact]
        public async Task GetAllPoliciesByType()
        {
            var client = TestClient.Create();

            var policy1 = new OktaSignOnPolicy()
            {
                // Name has a maximum of 50 chars
                Name = $"Sign On policy {Guid.NewGuid()}".Substring(0, 50),
                Type = PolicyType.OktaSignOn,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var policy2 = new PasswordPolicy()
            {
                Name = $"Password policy {Guid.NewGuid()}".Substring(0, 50),
                Type = PolicyType.Password,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy1 = await client.Policies.CreatePolicyAsync(policy1);
            var createdPolicy2 = await client.Policies.CreatePolicyAsync(policy2);

            try
            {
                var signOnPolicies = await client.Policies.ListPolicies(PolicyType.OktaSignOn).ToList();
                signOnPolicies.Should().NotBeNullOrEmpty();
                signOnPolicies.First(x => x.Id == createdPolicy1.Id).Should().NotBeNull();
                signOnPolicies.FirstOrDefault(x => x.Id == createdPolicy2.Id).Should().BeNull();

                var passwordPolicies = await client.Policies.ListPolicies(PolicyType.Password).ToList();
                passwordPolicies.Should().NotBeNullOrEmpty();
                passwordPolicies.First(x => x.Id == createdPolicy2.Id).Should().NotBeNull();
                passwordPolicies.FirstOrDefault(x => x.Id == createdPolicy1.Id).Should().BeNull();
            }
            finally
            {
                await client.Policies.DeactivatePolicyAsync(createdPolicy1.Id);
                await client.Policies.DeletePolicyAsync(createdPolicy1.Id);
                await client.Policies.DeactivatePolicyAsync(createdPolicy2.Id);
                await client.Policies.DeletePolicyAsync(createdPolicy2.Id);
            }
        }

        [Fact]
        public async Task DeletePolicy()
        {
            var client = TestClient.Create();

            var policy = new OktaSignOnPolicy()
            {
                // Name has a maximum of 50 chars
                Name = $"Sign On policy {Guid.NewGuid()}".Substring(0, 50),
                Type = PolicyType.OktaSignOn,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await client.Policies.CreatePolicyAsync(policy);
            var retrievedPolicy = await client.Policies.GetPolicyAsync(createdPolicy.Id);
            retrievedPolicy.Should().NotBeNull();

            await client.Policies.DeactivatePolicyAsync(createdPolicy.Id);
            await client.Policies.DeletePolicyAsync(createdPolicy.Id);

            Func<Task> act = async () => await client.Policies.GetPolicyAsync(createdPolicy.Id);
            act.Should().Throw<OktaApiException>();
        }

        [Fact]
        public async Task UpdatePolicy()
        {
            var client = TestClient.Create();

            var policy = new OktaSignOnPolicy()
            {
                // Name has a maximum of 50 chars
                Name = $"Sign On policy {Guid.NewGuid()}".Substring(0, 50),
                Type = PolicyType.OktaSignOn,
                Status = "ACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await client.Policies.CreatePolicyAsync(policy);

            createdPolicy.Name = $"Updated Sign On policy {Guid.NewGuid()}".Substring(0, 50);
            createdPolicy.Description = "This description was updated";
            // TODO: Create Helper
            await client.Policies.UpdatePolicyAsync(createdPolicy, createdPolicy.Id);

            var updatedPolicy = await client.Policies.GetPolicyAsync(createdPolicy.Id);

            try
            {
                updatedPolicy.Id.Should().Be(createdPolicy.Id);
                updatedPolicy.Type.Should().Be(createdPolicy.Type);
                updatedPolicy.Name.Should().StartWith("Updated");
                updatedPolicy.Description.Should().Be("This description was updated");
            }
            finally
            {
                await client.Policies.DeactivatePolicyAsync(createdPolicy.Id);
                await client.Policies.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        [Fact(Skip = "Possible error in the API")]
        public async Task ActivatePolicy()
        {
            var client = TestClient.Create();

            var policy = new OktaSignOnPolicy()
            {
                // Name has a maximum of 50 chars
                Name = $"Sign On policy {Guid.NewGuid()}".Substring(0, 50),
                Type = PolicyType.OktaSignOn,
                Status = "INACTIVE",
                Description = "The default policy applies in all situations if no other policy applies.",
            };

            var createdPolicy = await client.Policies.CreatePolicyAsync(policy);

            try
            {
                createdPolicy.Status.Should().Be("INACTIVE");
                await createdPolicy.ActivateAsync();

                var retrievedPolicy = await client.Policies.GetPolicyAsync(createdPolicy.Id);
                retrievedPolicy.Status.Should().Be("ACTIVE");
            }
            finally
            {
                await client.Policies.DeactivatePolicyAsync(createdPolicy.Id);
                await client.Policies.DeletePolicyAsync(createdPolicy.Id);
            }
        }

        // TODO
        //public async Task GetPolicyWithRules() { }
    }
}
