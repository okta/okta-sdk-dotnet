// <copyright file="GroupSchemasClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class GroupSchemasClient : OktaClient, IGroupSchemasClient
    {
        // Remove parameterless constructor
        private GroupSchemasClient()
        {
        }

        internal GroupSchemasClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public async Task<IGroupSchema> GetGroupSchemaAsync(CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<GroupSchema>(new HttpRequest
            {
                Uri = "/api/v1/meta/schemas/group/default",
                Verb = HttpVerb.GET,
                
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IGroupSchema> UpdateGroupSchemaAsync(IGroupSchema body, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<GroupSchema>(new HttpRequest
            {
                Uri = "/api/v1/meta/schemas/group/default",
                Verb = HttpVerb.POST,
                Payload = body,
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
