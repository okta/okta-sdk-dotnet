// <copyright file="LogsClient.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Okta.Sdk.Configuration;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public sealed partial class LogsClient : OktaClient, ILogsClient
    {
        // Remove parameterless constructor
        private LogsClient()
        {
        }

        internal LogsClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public ICollectionClient<ILogEvent> GetLogs(string until = null, string since = null, string filter = null, string q = null, int? limit = 100, string sortOrder = "ASCENDING", string after = null)
            => GetCollectionClient<ILogEvent>(new HttpRequest
            {
                Uri = "/api/v1/logs",
                
                QueryParameters = new Dictionary<string, object>()
                {
                    ["until"] = until,
                    ["since"] = since,
                    ["filter"] = filter,
                    ["q"] = q,
                    ["limit"] = limit,
                    ["sortOrder"] = sortOrder,
                    ["after"] = after,
                },
            });
                    
    }
}
