// <copyright file="LinkedObjectClientScenarios.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    public class LinkedObjectClientScenarios
    {
        private const string SdkPrefix = "dotnet_sdk";

        [Fact]
        public async Task AddLinkedObjectDefinition()
        {
            var testClient = TestClient.Create();
            var randomString = TestClient.RandomString(6);
            var testPrimaryName = $"{SdkPrefix}_{nameof(AddLinkedObjectDefinition)}_primary_{randomString}";
            var testAssociatedName = $"{SdkPrefix}_{nameof(AddLinkedObjectDefinition)}_associated_{randomString}";

            var createdLinkedObjectDefinition = await testClient.LinkedObjects.AddLinkedObjectDefinitionAsync(
                new LinkedObject
                {
                    Primary = new LinkedObjectDetails
                    {
                        Name = testPrimaryName,
                        Title = "Primary",
                        Description = "Primary link property",
                        Type = "USER",
                    },
                    Associated = new LinkedObjectDetails
                    {
                        Name = testAssociatedName,
                        Title = "Associated",
                        Description = "Associated link property",
                        Type = "USER",
                    },
                });

            try
            {
                createdLinkedObjectDefinition.Primary.Should().NotBeNull();
                createdLinkedObjectDefinition.Primary.Name.Should().Be(testPrimaryName);
                createdLinkedObjectDefinition.Primary.Title.Should().Be("Primary");
                createdLinkedObjectDefinition.Primary.Description.Should().Be("Primary link property");
                createdLinkedObjectDefinition.Primary.Type.Value.Should().Be("USER");
                createdLinkedObjectDefinition.Associated.Should().NotBeNull();
                createdLinkedObjectDefinition.Associated.Name.Should().Be(testAssociatedName);
                createdLinkedObjectDefinition.Associated.Title.Should().Be("Associated");
                createdLinkedObjectDefinition.Associated.Description.Should().Be("Associated link property");
                createdLinkedObjectDefinition.Associated.Type.Value.Should().Be("USER");
            }
            finally
            {
                await testClient.LinkedObjects.DeleteLinkedObjectDefinitionAsync(testPrimaryName);
            }
        }

        [Fact]
        public async Task GetLinkedObjectDefinitionByPrimaryName()
        {
            var testClient = TestClient.Create();
            var randomString = TestClient.RandomString(6);
            var testPrimaryName = $"{SdkPrefix}_{nameof(GetLinkedObjectDefinitionByPrimaryName)}_primary_{randomString}";
            var testAssociatedName = $"{SdkPrefix}_{nameof(GetLinkedObjectDefinitionByPrimaryName)}_associated_{randomString}";

            var createdLinkedObjectDefinition = await testClient.LinkedObjects.AddLinkedObjectDefinitionAsync(
                new LinkedObject
                {
                    Primary = new LinkedObjectDetails
                    {
                        Name = testPrimaryName,
                        Title = "Primary",
                        Description = "Primary link property",
                        Type = "USER",
                    },
                    Associated = new LinkedObjectDetails
                    {
                        Name = testAssociatedName,
                        Title = "Associated",
                        Description = "Associated link property",
                        Type = "USER",
                    },
                });

            var retrievedLinkedObjectDefinition = await testClient.LinkedObjects.GetLinkedObjectDefinitionAsync(testPrimaryName);

            try
            {
                retrievedLinkedObjectDefinition.Should().NotBeNull();
                retrievedLinkedObjectDefinition.Primary.Should().NotBeNull();
                retrievedLinkedObjectDefinition.Primary.Name.Should().Be(testPrimaryName);
                retrievedLinkedObjectDefinition.Primary.Title.Should().Be("Primary");
                retrievedLinkedObjectDefinition.Primary.Type.Value.Should().Be("USER");
                retrievedLinkedObjectDefinition.Associated.Should().NotBeNull();
                retrievedLinkedObjectDefinition.Associated.Name.Should().Be(testAssociatedName);
                retrievedLinkedObjectDefinition.Associated.Title.Should().Be("Associated");
                retrievedLinkedObjectDefinition.Associated.Type.Value.Should().Be("USER");
            }
            finally
            {
                await testClient.LinkedObjects.DeleteLinkedObjectDefinitionAsync(testPrimaryName);
            }
        }

        [Fact]
        public async Task GetLinkedObjectDefinitionByAssociatedName()
        {
            var testClient = TestClient.Create();
            var randomString = TestClient.RandomString(6);
            var testPrimaryName = $"{SdkPrefix}_{nameof(GetLinkedObjectDefinitionByAssociatedName)}_primary_{randomString}";
            var testAssociatedName = $"{SdkPrefix}_{nameof(GetLinkedObjectDefinitionByAssociatedName)}_associated_{randomString}";

            var createdLinkedObjectDefinition = await testClient.LinkedObjects.AddLinkedObjectDefinitionAsync(
                new LinkedObject
                {
                    Primary = new LinkedObjectDetails
                    {
                        Name = testPrimaryName,
                        Title = "Primary",
                        Description = "Primary link property",
                        Type = "USER",
                    },
                    Associated = new LinkedObjectDetails
                    {
                        Name = testAssociatedName,
                        Title = "Associated",
                        Description = "Associated link property",
                        Type = "USER",
                    },
                });

            var retrievedLinkedObjectDefinition = await testClient.LinkedObjects.GetLinkedObjectDefinitionAsync(testAssociatedName);

            try
            {
                retrievedLinkedObjectDefinition.Should().NotBeNull();
                retrievedLinkedObjectDefinition.Primary.Should().NotBeNull();
                retrievedLinkedObjectDefinition.Primary.Name.Should().Be(testPrimaryName);
                retrievedLinkedObjectDefinition.Primary.Title.Should().Be("Primary");
                retrievedLinkedObjectDefinition.Primary.Type.Value.Should().Be("USER");
                retrievedLinkedObjectDefinition.Associated.Should().NotBeNull();
                retrievedLinkedObjectDefinition.Associated.Name.Should().Be(testAssociatedName);
                retrievedLinkedObjectDefinition.Associated.Title.Should().Be("Associated");
                retrievedLinkedObjectDefinition.Associated.Type.Value.Should().Be("USER");
            }
            finally
            {
                await testClient.LinkedObjects.DeleteLinkedObjectDefinitionAsync(testAssociatedName);
            }
        }

        [Fact]
        public async Task GetAllLinkedObjectDefinitions()
        {
            var testClient = TestClient.Create();
            var randomString = TestClient.RandomString(6);
            var testPrimaryName = $"{SdkPrefix}_{nameof(GetAllLinkedObjectDefinitions)}_primary_{randomString}";
            var testAssociatedName = $"{SdkPrefix}_{nameof(GetAllLinkedObjectDefinitions)}_associated_{randomString}";

            var createdLinkedObjectDefinition1 = await testClient.LinkedObjects.AddLinkedObjectDefinitionAsync(
                new LinkedObject
                {
                    Primary = new LinkedObjectDetails
                    {
                        Name = $"{testPrimaryName}_1",
                        Title = "Primary",
                        Description = "Primary link property",
                        Type = "USER",
                    },
                    Associated = new LinkedObjectDetails
                    {
                        Name = $"{testAssociatedName}_1",
                        Title = "Associated",
                        Description = "Associated link property",
                        Type = "USER",
                    },
                });
            var createdLinkedObjectDefinition2 = await testClient.LinkedObjects.AddLinkedObjectDefinitionAsync(
                new LinkedObject
                {
                    Primary = new LinkedObjectDetails
                    {
                        Name = $"{testPrimaryName}_2",
                        Title = "Primary",
                        Description = "Primary link property",
                        Type = "USER",
                    },
                    Associated = new LinkedObjectDetails
                    {
                        Name = $"{testAssociatedName}_2",
                        Title = "Associated",
                        Description = "Associated link property",
                        Type = "USER",
                    },
                });

            var allLinkedObjectDefinitions = testClient.LinkedObjects.ListLinkedObjectDefinitions();
            var allLinkedObjectPrimaryNames =
                await allLinkedObjectDefinitions.Select(lod => lod.Primary.Name).ToHashSetAsync();
            var allLinkedObjectAssociatedNames =
                await allLinkedObjectDefinitions.Select(lod => lod.Associated.Name).ToHashSetAsync();

            Assert.Contains(createdLinkedObjectDefinition1.Primary.Name, allLinkedObjectPrimaryNames);
            Assert.Contains(createdLinkedObjectDefinition2.Primary.Name, allLinkedObjectPrimaryNames);
            Assert.Contains(createdLinkedObjectDefinition1.Associated.Name, allLinkedObjectAssociatedNames);
            Assert.Contains(createdLinkedObjectDefinition2.Associated.Name, allLinkedObjectAssociatedNames);

            await testClient.LinkedObjects.DeleteLinkedObjectDefinitionAsync(
                createdLinkedObjectDefinition1.Primary.Name);
            await testClient.LinkedObjects.DeleteLinkedObjectDefinitionAsync(
                createdLinkedObjectDefinition2.Primary.Name);
        }
    }
}
