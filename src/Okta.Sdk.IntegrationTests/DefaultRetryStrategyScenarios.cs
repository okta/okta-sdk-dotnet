// <copyright file="DefaultRetryStrategyScenarios.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Okta.Sdk.Configuration;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    public class DefaultRetryStrategyScenarios
    {
        [Fact]
        public void RetryShouldNotThrowInvalidOperationException()
        {
            List<string> guidList = new List<string>();

            for (int i = 0; i < 150; i++)
            {
                guidList.Add(Guid.NewGuid().ToString());
            }

            var oktaClient = new OktaClient(
                null,
                new HttpClient(),
                null,
                new DefaultRetryStrategy(
                    OktaClientConfiguration.DefaultMaxRetries,
                    OktaClientConfiguration.DefaultRequestTimeout));

            // Forcing several parallel requests to trigger rate limiting
            guidList
                .AsParallel()
                .ForAll(t =>
                {
                    var log = oktaClient.Logs
                        .GetLogs(
                            q: $"eventType eq \"user.lifecycle.create\" and target.id eq \"{t.Trim()}\"",
                            since: DateTime.Now.Add(TimeSpan.FromDays(-180d)))
                        .Select(ev => ev.Actor.AlternateId)
                        .FirstOrDefaultAsync();
                    try
                    {
                        Assert.True(log.Result == null, "not found");
                    }
                    catch (AggregateException e)
                    {
                        foreach (var ex in e.Flatten().InnerExceptions)
                        {
                            Assert.False(ex.GetType() == typeof(InvalidOperationException) && ex.Message.Contains("The request message was already sent"), "The request shouldn't be reused.");
                        }
                    }
                });
        }
    }
}
