// <copyright file="InlineHooksClientShould.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    public class InlineHooksClientShould
    {
        private const string SdkPrefix = "dotnet_sdk";

        [Fact]
        public async Task CreateInlineHook()
        {
            var testClient = TestClient.Create();
            var testInlineHookName = $"{SdkPrefix}:{nameof(CreateInlineHook)} Test Inline Hook Name ({TestClient.RandomString(6)})";

            var createdInlineHook = await testClient.InlineHooks.CreateInlineHookAsync(
                new InlineHook
                {
                    Name = testInlineHookName,
                    Version = "1.0.0",
                    Type = "com.okta.oauth2.tokens.transform",
                    Channel = new InlineHookChannel
                    {
                        Type = "HTTP",
                        Version = "1.0.0",
                        Config = new InlineHookChannelConfig
                        {
                            Uri = "https://www.example.com/inlineHook",
                            Headers = new List<IInlineHookChannelConfigHeaders>
                            {
                                new InlineHookChannelConfigHeaders
                                {
                                    Key = "X-Test-Header",
                                    Value = "Test header value",
                                },
                            },
                            AuthScheme = new InlineHookChannelConfigAuthScheme
                            {
                                Type = "HEADER",
                                Key = "Authorization",
                                Value = "Test-Api-Key",
                            },
                        },
                    },
                });

            try
            {
                createdInlineHook.Id.Should().NotBeNullOrEmpty();
                createdInlineHook.Name.Should().Be(testInlineHookName);
                createdInlineHook.Channel.Should().NotBeNull();
                createdInlineHook.Channel.Config.Should().NotBeNull();
                createdInlineHook.Channel.Config.Uri.Should().Be("https://www.example.com/inlineHook");
            }
            finally
            {
                await testClient.InlineHooks.DeactivateInlineHookAsync(createdInlineHook.Id);
                await testClient.InlineHooks.DeleteInlineHookAsync(createdInlineHook.Id);
            }
        }

        [Fact]
        public async Task RetrieveInlineHook()
        {
            var testClient = TestClient.Create();
            var testInlineHookName = $"{SdkPrefix}:{nameof(RetrieveInlineHook)} Test Inline Hook Name ({TestClient.RandomString(6)})";

            var createdInlineHook = await testClient.InlineHooks.CreateInlineHookAsync(
                new InlineHook
                {
                    Name = testInlineHookName,
                    Version = "1.0.0",
                    Type = "com.okta.oauth2.tokens.transform",
                    Channel = new InlineHookChannel
                    {
                        Type = "HTTP",
                        Version = "1.0.0",
                        Config = new InlineHookChannelConfig
                        {
                            Uri = "https://www.example.com/inlineHook",
                            Headers = new List<IInlineHookChannelConfigHeaders>
                            {
                                new InlineHookChannelConfigHeaders
                                {
                                    Key = "X-Test-Header",
                                    Value = "Test header value",
                                },
                            },
                            AuthScheme = new InlineHookChannelConfigAuthScheme
                            {
                                Type = "HEADER",
                                Key = "Authorization",
                                Value = "Test-Api-Key",
                            },
                        },
                    },
                });

            try
            {
                createdInlineHook.Id.Should().NotBeNullOrEmpty();

                var retrievedInlineHook = await testClient.InlineHooks.GetInlineHookAsync(createdInlineHook.Id);
                retrievedInlineHook.Id.Should().NotBeNullOrEmpty();
                retrievedInlineHook.Id.Should().Be(createdInlineHook.Id);
                retrievedInlineHook.Name.Should().Be(testInlineHookName);
                retrievedInlineHook.Version.Should().Be("1.0.0");
                retrievedInlineHook.Type.Should().Be("com.okta.oauth2.tokens.transform");
                retrievedInlineHook.Channel.Should().NotBeNull();
                retrievedInlineHook.Channel.Config.Should().NotBeNull();
                retrievedInlineHook.Channel.Config.Uri.Should().Be("https://www.example.com/inlineHook");
            }
            finally
            {
                await testClient.InlineHooks.DeactivateInlineHookAsync(createdInlineHook.Id);
                await testClient.InlineHooks.DeleteInlineHookAsync(createdInlineHook.Id);
            }
        }

        [Fact]
        public async Task UpdateInlineHook()
        {
            var testClient = TestClient.Create();
            var testInlineHookName = $"{SdkPrefix}:{nameof(UpdateInlineHook)} Test Inline Hook Name ({TestClient.RandomString(6)})";
            var updatedTestInlineHookName = $"{testInlineHookName} Updated";

            var createdInlineHook = await testClient.InlineHooks.CreateInlineHookAsync(
                new InlineHook
                {
                    Name = testInlineHookName,
                    Version = "1.0.0",
                    Type = "com.okta.oauth2.tokens.transform",
                    Channel = new InlineHookChannel
                    {
                        Type = "HTTP",
                        Version = "1.0.0",
                        Config = new InlineHookChannelConfig
                        {
                            Uri = "https://www.example.com/inlineHook",
                            Headers = new List<IInlineHookChannelConfigHeaders>
                            {
                                new InlineHookChannelConfigHeaders
                                {
                                    Key = "X-Test-Header",
                                    Value = "Test header value",
                                },
                            },
                            AuthScheme = new InlineHookChannelConfigAuthScheme
                            {
                                Type = "HEADER",
                                Key = "Authorization",
                                Value = "Test-Api-Key",
                            },
                        },
                    },
                });

            try
            {
                createdInlineHook.Id.Should().NotBeNullOrEmpty();

                var updatedInlineHook = await testClient.InlineHooks.UpdateInlineHookAsync(
                    new InlineHook
                    {
                        Name = updatedTestInlineHookName,
                        Version = "1.0.0",
                        Type = "com.okta.oauth2.tokens.transform",
                        Channel = new InlineHookChannel
                        {
                            Type = "HTTP",
                            Version = "1.0.0",
                            Config = new InlineHookChannelConfig
                            {
                                Uri = "https://www.example.com/inlineHookUpdated",
                                Headers = new List<IInlineHookChannelConfigHeaders>
                                {
                                    new InlineHookChannelConfigHeaders
                                    {
                                        Key = "X-Test-Header",
                                        Value = "Test header value updated",
                                    },
                                },
                                AuthScheme = new InlineHookChannelConfigAuthScheme
                                {
                                    Type = "HEADER",
                                    Key = "Authorization",
                                    Value = "Test-Api-Key-Updated",
                                },
                            },
                        },
                    }, createdInlineHook.Id);

                updatedInlineHook.Id.Should().NotBeNullOrEmpty();
                updatedInlineHook.Id.Should().Be(createdInlineHook.Id);
                updatedInlineHook.Name.Should().Be(updatedTestInlineHookName);
                updatedInlineHook.Version.Should().Be("1.0.0");
                updatedInlineHook.Type.Should().Be("com.okta.oauth2.tokens.transform");
                updatedInlineHook.Channel.Should().NotBeNull();
                updatedInlineHook.Channel.Config.Should().NotBeNull();
                updatedInlineHook.Channel.Config.Uri.Should().Be("https://www.example.com/inlineHookUpdated");

                var retrievedInlineHookForValidation = await testClient.InlineHooks.GetInlineHookAsync(createdInlineHook.Id);
                retrievedInlineHookForValidation.Id.Should().NotBeNullOrEmpty();
                retrievedInlineHookForValidation.Id.Should().Be(createdInlineHook.Id);
                retrievedInlineHookForValidation.Name.Should().Be(updatedTestInlineHookName);
                retrievedInlineHookForValidation.Version.Should().Be("1.0.0");
                retrievedInlineHookForValidation.Type.Should().Be("com.okta.oauth2.tokens.transform");
                retrievedInlineHookForValidation.Channel.Should().NotBeNull();
                retrievedInlineHookForValidation.Channel.Config.Should().NotBeNull();
                retrievedInlineHookForValidation.Channel.Config.Uri.Should().Be("https://www.example.com/inlineHookUpdated");
            }
            finally
            {
                await testClient.InlineHooks.DeactivateInlineHookAsync(createdInlineHook.Id);
                await testClient.InlineHooks.DeleteInlineHookAsync(createdInlineHook.Id);
            }
        }

        [Fact]
        public async Task DeleteInlineHook()
        {
            var testClient = TestClient.Create();
            var testInlineHookName = $"{SdkPrefix}:{nameof(DeleteInlineHook)} Test Inline Hook Name ({TestClient.RandomString(6)})";

            var createdInlineHook = await testClient.InlineHooks.CreateInlineHookAsync(new InlineHook
            {
                Name = testInlineHookName,
                Version = "1.0.0",
                Type = "com.okta.oauth2.tokens.transform",
                Channel = new InlineHookChannel
                {
                    Type = "HTTP",
                    Version = "1.0.0",
                    Config = new InlineHookChannelConfig
                    {
                        Uri = "https://www.example.com/inlineHook",
                        Headers = new List<IInlineHookChannelConfigHeaders>
                        {
                            new InlineHookChannelConfigHeaders
                            {
                                Key = "X-Test-Header",
                                Value = "Test header value",
                            },
                        },
                        AuthScheme = new InlineHookChannelConfigAuthScheme
                        {
                            Type = "HEADER",
                            Key = "Authorization",
                            Value = "Test-Api-Key",
                        },
                    },
                },
            });

            createdInlineHook.Id.Should().NotBeNullOrEmpty();

            var retrievedEventHook = await testClient.InlineHooks.GetInlineHookAsync(createdInlineHook.Id);
            retrievedEventHook.Id.Should().Be(createdInlineHook.Id);

            await testClient.InlineHooks.DeactivateInlineHookAsync(createdInlineHook.Id);
            await testClient.InlineHooks.DeleteInlineHookAsync(createdInlineHook.Id);

            var ex = await Assert.ThrowsAsync<OktaApiException>(() =>
                testClient.EventHooks.GetEventHookAsync(createdInlineHook.Id));
            ex.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task ListAllInlineHooks()
        {
            var testClient = TestClient.Create();
            var testInlineHookName = $"{SdkPrefix}:{nameof(ListAllInlineHooks)} Test Inline Hook Name ({TestClient.RandomString(6)})";

            var existingInlineHookIds = new HashSet<string>();
            await foreach (IInlineHook existingInlineHook in testClient.InlineHooks.ListInlineHooks())
            {
                existingInlineHookIds.Add(existingInlineHook.Id);
            }

            var testInlineHookIds = new HashSet<string>();
            for (int i = 0; i < 5; i++)
            {
                var createdInlineHook = await testClient.InlineHooks.CreateInlineHookAsync(new InlineHook
                {
                    Name = $"{testInlineHookName} {i}",
                    Version = "1.0.0",
                    Type = "com.okta.oauth2.tokens.transform",
                    Channel = new InlineHookChannel
                    {
                        Type = "HTTP",
                        Version = "1.0.0",
                        Config = new InlineHookChannelConfig
                        {
                            Uri = "https://www.example.com/inlineHook",
                            Headers = new List<IInlineHookChannelConfigHeaders>
                            {
                                new InlineHookChannelConfigHeaders
                                {
                                    Key = "X-Test-Header",
                                    Value = "Test header value",
                                },
                            },
                            AuthScheme = new InlineHookChannelConfigAuthScheme
                            {
                                Type = "HEADER",
                                Key = "Authorization",
                                Value = "Test-Api-Key",
                            },
                        },
                    },
                });
                testInlineHookIds.Add(createdInlineHook.Id);
            }

            try
            {
                var allInlineHookIds = new HashSet<string>();
                var allInlineHooks = testClient.InlineHooks.ListInlineHooks();
                int allInlineHooksCount = await allInlineHooks.CountAsync();
                allInlineHooksCount.Should().BeGreaterThan(0);
                allInlineHooksCount.Should().Be(existingInlineHookIds.Count + testInlineHookIds.Count);

                await foreach (var inlineHook in allInlineHooks)
                {
                    allInlineHookIds.Add(inlineHook.Id);
                }

                foreach (var testInlineHookId in testInlineHookIds)
                {
                    Assert.Contains(testInlineHookId, allInlineHookIds);
                }
            }
            finally
            {
                foreach (var testInlineHookId in testInlineHookIds)
                {
                    await testClient.InlineHooks.DeactivateInlineHookAsync(testInlineHookId);
                    await testClient.InlineHooks.DeleteInlineHookAsync(testInlineHookId);
                }
            }
        }

        [Fact]
        public async Task DeactivateInlineHook()
        {
            var testClient = TestClient.Create();
            var testInlineHookName = $"{SdkPrefix}:{nameof(DeactivateInlineHook)} Test Inline Hook Name ({TestClient.RandomString(6)})";

            var createdInlineHook = await testClient.InlineHooks.CreateInlineHookAsync(new InlineHook
            {
                Name = testInlineHookName,
                Version = "1.0.0",
                Type = "com.okta.oauth2.tokens.transform",
                Channel = new InlineHookChannel
                {
                    Type = "HTTP",
                    Version = "1.0.0",
                    Config = new InlineHookChannelConfig
                    {
                        Uri = "https://www.example.com/inlineHook",
                        Headers = new List<IInlineHookChannelConfigHeaders>
                        {
                            new InlineHookChannelConfigHeaders
                            {
                                Key = "X-Test-Header",
                                Value = "Test header value",
                            },
                        },
                        AuthScheme = new InlineHookChannelConfigAuthScheme
                        {
                            Type = "HEADER",
                            Key = "Authorization",
                            Value = "Test-Api-Key",
                        },
                    },
                },
            });

            try
            {
                createdInlineHook.Id.Should().NotBeNullOrEmpty();
                createdInlineHook.Status.Should().Be("ACTIVE");

                await testClient.InlineHooks.DeactivateInlineHookAsync(createdInlineHook.Id);

                var retrievedInlineHook = await testClient.InlineHooks.GetInlineHookAsync(createdInlineHook.Id);
                retrievedInlineHook.Status.Should().Be("INACTIVE");
            }
            finally
            {
                await testClient.InlineHooks.DeactivateInlineHookAsync(createdInlineHook.Id);
                await testClient.InlineHooks.DeleteInlineHookAsync(createdInlineHook.Id);
            }
        }

        [Fact]
        public async Task ActivateInlineHook()
        {
            var testClient = TestClient.Create();
            var testInlineHookName = $"{SdkPrefix}:{nameof(ActivateInlineHook)} Test Inline Hook Name ({TestClient.RandomString(6)})";

            var createdInlineHook = await testClient.InlineHooks.CreateInlineHookAsync(new InlineHook
            {
                Name = testInlineHookName,
                Version = "1.0.0",
                Type = "com.okta.oauth2.tokens.transform",
                Channel = new InlineHookChannel
                {
                    Type = "HTTP",
                    Version = "1.0.0",
                    Config = new InlineHookChannelConfig
                    {
                        Uri = "https://www.example.com/inlineHook",
                        Headers = new List<IInlineHookChannelConfigHeaders>
                        {
                            new InlineHookChannelConfigHeaders
                            {
                                Key = "X-Test-Header",
                                Value = "Test header value",
                            },
                        },
                        AuthScheme = new InlineHookChannelConfigAuthScheme
                        {
                            Type = "HEADER",
                            Key = "Authorization",
                            Value = "Test-Api-Key",
                        },
                    },
                },
            });

            try
            {
                createdInlineHook.Id.Should().NotBeNullOrEmpty();
                createdInlineHook.Status.Should().Be("ACTIVE");

                await testClient.InlineHooks.DeactivateInlineHookAsync(createdInlineHook.Id);

                var retrievedInlineHook = await testClient.InlineHooks.GetInlineHookAsync(createdInlineHook.Id);
                retrievedInlineHook.Status.Should().Be("INACTIVE");

                await testClient.InlineHooks.ActivateInlineHookAsync(createdInlineHook.Id);
                var reactivatedInlineHook = await testClient.InlineHooks.GetInlineHookAsync(createdInlineHook.Id);
                reactivatedInlineHook.Status.Should().Be("ACTIVE");
            }
            finally
            {
                await testClient.InlineHooks.DeactivateInlineHookAsync(createdInlineHook.Id);
                await testClient.InlineHooks.DeleteInlineHookAsync(createdInlineHook.Id);
            }
        }
    }
}