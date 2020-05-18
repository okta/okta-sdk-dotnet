using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Xunit.Sdk;

namespace Okta.Sdk.IntegrationTests
{
    public class EventHooksClientShould
    {
        private const string SdkPrefix = "dotnet_sdk";
        private const string EventType = "EVENT_TYPE";

        private static readonly string[] TestEventItems = new string[]
        {
            "user.lifecycle.create",
            "user.lifecycle.activate",
        };

        private static readonly string[] UpdatedTestEventItems = new string[]
        {
            "user.lifecycle.create",
            "user.lifecycle.activate",
            "user.lifecycle.deactivate",
        };

        private static readonly EventHookChannel TestEventHookChannel = new EventHookChannel
        {
            Type = "HTTP",
            Version = "1.0.0",
            Config = new EventHookChannelConfig
            {
                Uri = "https://www.example.com/eventHooks",
                Headers = new List<IEventHookChannelConfigHeader>
                {
                    new EventHookChannelConfigHeader
                    {
                        Key = "X-Test-Header",
                        Value = "Test header value",
                    },
                },
                AuthScheme = new EventHookChannelConfigAuthScheme
                {
                    Type = "HEADER",
                    Key = "Authorization",
                    Value = "Test-Api-Key",
                },
            },
        };

        private static readonly EventHookChannel UpdatedTestEventHookChannel = new EventHookChannel
        {
            Type = "HTTP",
            Version = "1.0.0",
            Config = new EventHookChannelConfig
            {
                Uri = "https://www.example.com/eventHooksUpdated",
                Headers = new List<IEventHookChannelConfigHeader>
                {
                    new EventHookChannelConfigHeader
                    {
                        Key = "X-Test-Header",
                        Value = "Test header value updated",
                    },
                },
                AuthScheme = new EventHookChannelConfigAuthScheme
                {
                    Type = "HEADER",
                    Key = "Authorization",
                    Value = "Test-Api-Key-Updated",
                },
            },
        };

        public EventHooksClientShould()
        {
            DeleteAllEventHooks().Wait();
        }

        [Fact]
        public async Task CreateEventHook()
        {
            var testClient = TestClient.Create();
            var testEventHookName = $"{SdkPrefix}:{nameof(CreateEventHook)} Test Event Hook Name";

            var createdEventHook = await testClient.EventHooks.CreateEventHookAsync(new EventHook
            {
                Name = testEventHookName,
                Events = new EventSubscriptions
                {
                    Type = EventType,
                    Items = TestEventItems,
                },
                Channel = TestEventHookChannel,
            });

            try
            {
                createdEventHook.Id.Should().NotBeNullOrEmpty();
                createdEventHook.Name.Should().Be(testEventHookName);
                createdEventHook.Events.Should().NotBeNull();
                createdEventHook.Events.Items.Should().NotBeNull();
                createdEventHook.Events.Items.Count.Should().Be(TestEventItems.Length);
                createdEventHook.Channel.Should().NotBeNull();
                createdEventHook.Channel.Config.Should().NotBeNull();
                createdEventHook.Channel.Config.Uri.Should().Be(TestEventHookChannel.Config.Uri);
            }
            finally
            {
                await DeleteAllEventHooks();
            }
        }

        [Fact]
        public async Task RetrieveEventHook()
        {
            var testClient = TestClient.Create();
            var testEventHookName = $"{SdkPrefix}:{nameof(RetrieveEventHook)} Test Event Hook Name";

            var createdEventHook = await testClient.EventHooks.CreateEventHookAsync(new EventHook
            {
                Name = testEventHookName,
                Events = new EventSubscriptions
                {
                    Type = EventType,
                    Items = TestEventItems
                },
                Channel = TestEventHookChannel
            });

            try
            {
                createdEventHook.Id.Should().NotBeNullOrEmpty();

                var retrievedEventHook = await testClient.EventHooks.GetEventHookAsync(createdEventHook.Id);
                retrievedEventHook.Id.Should().NotBeNullOrEmpty();
                retrievedEventHook.Name.Should().Be(testEventHookName);
                retrievedEventHook.Events.Should().NotBeNull();
                retrievedEventHook.Events.Items.Should().NotBeNull();
                retrievedEventHook.Events.Items.Count.Should().Be(TestEventItems.Length);
                retrievedEventHook.Channel.Should().NotBeNull();
                retrievedEventHook.Channel.Config.Should().NotBeNull();
                retrievedEventHook.Channel.Config.Uri.Should().Be(TestEventHookChannel.Config.Uri);
            }
            finally
            {
                await DeleteAllEventHooks();
            }
        }

        [Fact]
        public async Task UpdateEventHook()
        {
            var testClient = TestClient.Create();
            var testEventHookName = $"{SdkPrefix}:{nameof(UpdateEventHook)} Test Event Hook Name";
            var updatedTestEventHookName = $"{SdkPrefix}:{nameof(RetrieveEventHook)} Test Event Hook Name Updated";

            var createdEventHook = await testClient.EventHooks.CreateEventHookAsync(new EventHook
            {
                Name = testEventHookName,
                Events = new EventSubscriptions
                {
                    Type = EventType,
                    Items = TestEventItems
                },
                Channel = TestEventHookChannel
            });

            try
            {
                createdEventHook.Id.Should().NotBeNullOrEmpty();

                var updatedEventHook = await testClient.EventHooks.UpdateEventHookAsync(
                    new EventHook
                    {
                        Name = updatedTestEventHookName,
                        Events = new EventSubscriptions
                        {
                            Type = EventType,
                            Items = UpdatedTestEventItems
                        },
                        Channel = UpdatedTestEventHookChannel
                    }, createdEventHook.Id);

                updatedEventHook.Id.Should().NotBeNullOrEmpty();
                updatedEventHook.Id.Should().Be(createdEventHook.Id);
                updatedEventHook.Name.Should().Be(updatedTestEventHookName);
                updatedEventHook.Events.Should().NotBeNull();
                updatedEventHook.Events.Items.Should().NotBeNull();
                updatedEventHook.Events.Items.Count.Should().Be(UpdatedTestEventItems.Length);
                updatedEventHook.Channel.Should().NotBeNull();
                updatedEventHook.Channel.Config.Should().NotBeNull();
                updatedEventHook.Channel.Config.Uri.Should().Be(UpdatedTestEventHookChannel.Config.Uri);

                var retrievedEventHookForValidation = await testClient.EventHooks.GetEventHookAsync(createdEventHook.Id);
                retrievedEventHookForValidation.Id.Should().NotBeNullOrEmpty();
                retrievedEventHookForValidation.Id.Should().Be(createdEventHook.Id);
                retrievedEventHookForValidation.Name.Should().Be(updatedTestEventHookName);
                retrievedEventHookForValidation.Events.Should().NotBeNull();
                retrievedEventHookForValidation.Events.Items.Should().NotBeNull();
                retrievedEventHookForValidation.Events.Items.Count.Should().Be(UpdatedTestEventItems.Length);
                retrievedEventHookForValidation.Channel.Should().NotBeNull();
                retrievedEventHookForValidation.Channel.Config.Should().NotBeNull();
                retrievedEventHookForValidation.Channel.Config.Uri.Should().Be(UpdatedTestEventHookChannel.Config.Uri);
            }
            finally
            {
                await DeleteAllEventHooks();
            }
        }

        [Fact]
        public async Task DeleteEventHook()
        {
            var testClient = TestClient.Create();
            var testEventHookName = $"{SdkPrefix}:{nameof(DeleteEventHook)} Test Event Hook Name";

            var createdEventHook = await testClient.EventHooks.CreateEventHookAsync(new EventHook
            {
                Name = testEventHookName,
                Events = new EventSubscriptions
                {
                    Type = EventType,
                    Items = TestEventItems
                },
                Channel = TestEventHookChannel
            });

            try
            {
                createdEventHook.Id.Should().NotBeNullOrEmpty();

                var retrievedEventHook = await testClient.EventHooks.GetEventHookAsync(createdEventHook.Id);
                retrievedEventHook.Id.Should().Be(createdEventHook.Id);

                await testClient.EventHooks.DeactivateEventHookAsync(createdEventHook.Id);
                await testClient.EventHooks.DeleteEventHookAsync(createdEventHook.Id);

                var ex = await Assert.ThrowsAsync<OktaApiException>(() =>
                    testClient.EventHooks.GetEventHookAsync(createdEventHook.Id));
                ex.StatusCode.Should().Be(404);
            }
            finally
            {
                await DeleteAllEventHooks();
            }
        }

        [Fact]
        public async Task ListAllEventHooks()
        {
            var testClient = TestClient.Create();
            var testEventHookName = $"{SdkPrefix}:{nameof(ListAllEventHooks)} Test Event Hook Name";

            var existingEventHookIds = new HashSet<string>();
            await foreach (IEventHook existingEventHook in testClient.EventHooks.ListEventHooks())
            {
                existingEventHookIds.Add(existingEventHook.Id);
            }

            var testEventHookIds = new HashSet<string>();
            for (int i = 0; i < 5; i++)
            {
                var createdEventHook = await testClient.EventHooks.CreateEventHookAsync(new EventHook
                {
                    Name = $"{testEventHookName} {i}",
                    Events = new EventSubscriptions
                    {
                        Type = EventType,
                        Items = TestEventItems,
                    },
                    Channel = TestEventHookChannel,
                });
                testEventHookIds.Add(createdEventHook.Id);
            }

            try
            {
                var allEventHookIds = new HashSet<string>();
                var allEventHooks = testClient.EventHooks.ListEventHooks();
                int allEventHooksCount = await allEventHooks.CountAsync();
                allEventHooksCount.Should().BeGreaterThan(0);
                allEventHooksCount.Should().Be(existingEventHookIds.Count + testEventHookIds.Count);

                await foreach (IEventHook eventHook in allEventHooks)
                {
                    allEventHookIds.Add(eventHook.Id);
                }

                foreach (string testEventHookId in testEventHookIds)
                {
                    Assert.Contains(testEventHookId, allEventHookIds);
                }
            }
            finally
            {
                await DeleteAllEventHooks();
            }
        }

        [Fact]
        public async Task DeactivateEventHook()
        {
            var testClient = TestClient.Create();
            var testEventHookName = $"{SdkPrefix}:{nameof(DeactivateEventHook)} Test Event Hook Name";

            var createdEventHook = await testClient.EventHooks.CreateEventHookAsync(new EventHook
            {
                Name = testEventHookName,
                Events = new EventSubscriptions
                {
                    Type = EventType,
                    Items = TestEventItems
                },
                Channel = TestEventHookChannel
            });

            try
            {
                createdEventHook.Id.Should().NotBeNullOrEmpty();
                createdEventHook.Status.Should().Be("ACTIVE");

                testClient.EventHooks.DeactivateEventHookAsync(createdEventHook.Id);

                var retrievedEventHook = await testClient.EventHooks.GetEventHookAsync(createdEventHook.Id);
                retrievedEventHook.Status.Should().Be("INACTIVE");
            }
            finally
            {
                await DeleteAllEventHooks();
            }
        }
        
        [Fact]
        public async Task ActivateEventHook()
        {
            var testClient = TestClient.Create();
            var testEventHookName = $"{SdkPrefix}:{nameof(ActivateEventHook)} Test Event Hook Name";

            var createdEventHook = await testClient.EventHooks.CreateEventHookAsync(new EventHook
            {
                Name = testEventHookName,
                Events = new EventSubscriptions
                {
                    Type = EventType,
                    Items = TestEventItems
                },
                Channel = TestEventHookChannel
            });

            try
            {
                createdEventHook.Id.Should().NotBeNullOrEmpty();
                createdEventHook.Status.Should().Be("ACTIVE");

                testClient.EventHooks.DeactivateEventHookAsync(createdEventHook.Id);

                var retrievedEventHook = await testClient.EventHooks.GetEventHookAsync(createdEventHook.Id);
                retrievedEventHook.Status.Should().Be("INACTIVE");

                testClient.EventHooks.ActivateEventHookAsync(createdEventHook.Id);
                var reactivatedEventHook = await testClient.EventHooks.GetEventHookAsync(createdEventHook.Id);
                reactivatedEventHook.Status.Should().Be("ACTIVE");
            }
            finally
            {
                await DeleteAllEventHooks();
            }
        }
        
        private async Task DeleteAllEventHooks()
        {
            var testClient = TestClient.Create();
            await foreach (IEventHook eventHook in testClient.EventHooks.ListEventHooks())
            {
                await testClient.EventHooks.DeactivateEventHookAsync(eventHook.Id);
                await testClient.EventHooks.DeleteEventHookAsync(eventHook.Id);
            }
        }
    }
}
