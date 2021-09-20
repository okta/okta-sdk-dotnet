// <copyright file="IThreatInsightsClient.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>A client that works with Okta ThreatInsight resources.</summary>
    public partial interface IThreatInsightsClient
    {
        /// <summary>
        /// Gets current ThreatInsight configuration
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IThreatInsightConfiguration"/> response.</returns>
        Task<IThreatInsightConfiguration> GetCurrentConfigurationAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates ThreatInsight configuration
        /// </summary>
        /// <param name="threatInsightConfiguration">The <see cref="IThreatInsightConfiguration"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IThreatInsightConfiguration"/> response.</returns>
        Task<IThreatInsightConfiguration> UpdateConfigurationAsync(IThreatInsightConfiguration threatInsightConfiguration, CancellationToken cancellationToken = default(CancellationToken));

    }
}
