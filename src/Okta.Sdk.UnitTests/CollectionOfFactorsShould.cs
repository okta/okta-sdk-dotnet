// <copyright file="CollectionOfFactorsShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Okta.Sdk.Internal;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class CollectionOfFactorsShould
    {
        private static readonly List<IFactor> AllFactors = new List<IFactor>()
        {
            TestResourceCreator.NewFactor(
                factorType: FactorType.Question,
                provider: "OTKA",
                profile: new SecurityQuestionFactorProfile { Question = "disliked_food" }),

            TestResourceCreator.NewFactor(
                factorType: FactorType.Sms,
                provider: "OTKA",
                profile: new SmsFactorProfile() { PhoneNumber = "+15556667899" }),
        };

        [Fact]
        public async Task RetrieveQuestionFactor()
        {
            var mockRequestExecutor = new MockedCollectionRequestExecutor<IFactor>(pageSize: 2, items: AllFactors);
            var dataStore = new DefaultDataStore(
                mockRequestExecutor,
                new DefaultSerializer(),
                new ResourceFactory(null, null),
                NullLogger.Instance);

            var collection = new CollectionClient<Factor>(
                dataStore,
                new HttpRequest { Uri = "http://mock-collection.dev" },
                new RequestContext());

            var retrievedItems = await collection.ToArray();
            var securityQuestionFactor = retrievedItems.OfType<SecurityQuestionFactor>().FirstOrDefault();
            securityQuestionFactor.Should().NotBeNull();
        }

        [Fact]
        public async Task RetrieveQuestionFactorAsInterface()
        {
            var mockRequestExecutor = new MockedCollectionRequestExecutor<IFactor>(pageSize: 2, items: AllFactors);
            var dataStore = new DefaultDataStore(
                mockRequestExecutor,
                new DefaultSerializer(),
                new ResourceFactory(null, null),
                NullLogger.Instance);

            var collection = new CollectionClient<Factor>(
                dataStore,
                new HttpRequest { Uri = "http://mock-collection.dev" },
                new RequestContext());

            var retrievedItems = await collection.ToArray();
            var securityQuestionFactor = retrievedItems.OfType<ISecurityQuestionFactor>().FirstOrDefault();
            securityQuestionFactor.Should().NotBeNull();
        }
    }
}
