// <copyright file="ILogsClient.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>A client that works with Okta Log resources.</summary>
    public partial interface ILogsClient
    {
        /// <summary>
        /// The Okta System Log API provides read access to your organization’s system log. This API provides more functionality than the Events API
        /// </summary>
        /// <param name="until"></param>
        /// <param name="since"></param>
        /// <param name="filter"></param>
        /// <param name="q"></param>
        /// <param name="limit"></param>
        /// <param name="sortOrder"></param>
        /// <param name="after"></param>
        /// <returns>A collection of <see cref="ILogEvent"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<ILogEvent> GetLogs(string until = null, string since = null, string filter = null, string q = null, int? limit = 100, string sortOrder = "ASCENDING", string after = null);

    }
}
