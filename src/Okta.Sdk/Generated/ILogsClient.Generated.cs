// <copyright file="ILogsClient.Generated.cs" company="Okta, Inc">
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
    public partial interface ILogsClient
    {
        /// <summary>
        /// Fetch a list of events from your Okta organization system log. The Okta System Log API provides read access to your organization’s system log. This API provides more functionality than the Events API
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="since"> (optional)</param>
        /// <param name="until"> (optional)</param>
        /// <param name="filter"> (optional)</param>
        /// <param name="q"> (optional)</param>
        /// <param name="limit"> (optional, default to 100)</param>
        /// <param name="sortOrder"> (optional, default to ASCENDING)</param>
        /// <param name="after"> (optional)</param>
        /// A collection of <see cref="ILogsClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<ILogEvent> GetLogs(DateTime? since = null, DateTime? until = null, string filter = null, string q = null, int? limit = null, string sortOrder = null, string after = null);
    }
}

