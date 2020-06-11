﻿// <copyright file="FeaturesScenarios.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    public class FeaturesScenarios
    {
        [Fact]
        public async Task ListFeatures()
        {
            var client = TestClient.Create();
            var features = await client.Features.ListFeatures().ToListAsync();
            features.Should().NotBeNull();
            features.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task GetFeatureById()
        {
            var client = TestClient.Create();
            var feature = await client.Features.ListFeatures().FirstOrDefaultAsync();
            feature.Should().NotBeNull();

            var retrievedFeature = await client.Features.GetFeatureAsync(feature.Id);
            retrievedFeature.Should().NotBeNull();
            retrievedFeature.Id.Should().Be(feature.Id);
            retrievedFeature.Name.Should().Be(feature.Name);
            retrievedFeature.Description.Should().Be(feature.Description);
        }
    }
}
