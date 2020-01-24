﻿// <copyright file="LogsClient.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Threading;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public sealed partial class LogsClient : OktaClient, ILogsClient, IAsyncEnumerable<ILogEvent>
    {
        /// <summary>
        /// Gets the LogsClient enumerator.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A collection of <see cref="ILogEvent"/> that can be enumerated asynchronously.</returns>
        public IAsyncEnumerator<ILogEvent> GetAsyncEnumerator(CancellationToken cancellationToken = default) => GetLogs().GetAsyncEnumerator(cancellationToken);
    }
}
