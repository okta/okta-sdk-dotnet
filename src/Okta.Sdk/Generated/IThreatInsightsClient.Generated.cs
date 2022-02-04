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
    /// <summary>A client that works with Okta resources.</summary>
    public partial interface IThreatInsightsClient
    {
        /// <summary>
        ///  Gets current ThreatInsight configuration
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        ///  <returns>Task of IThreatInsightConfiguration</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IThreatInsightConfiguration> GetCurrentConfigurationAsync( CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Updates ThreatInsight configuration
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        ///  <returns>Task of IThreatInsightConfiguration</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IThreatInsightConfiguration> UpdateConfigurationAsync(IThreatInsightConfiguration body, CancellationToken cancellationToken = default(CancellationToken));
    }
}

