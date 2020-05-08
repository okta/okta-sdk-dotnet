// <copyright file="LinkedObjectsClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class LinkedObjectsClient : OktaClient, ILinkedObjectsClient
    {
        // Remove parameterless constructor
        private LinkedObjectsClient()
        {
        }

        internal LinkedObjectsClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public ICollectionClient<ILinkedObject> ListLinkedObjectDefinitions()
            => GetCollectionClient<ILinkedObject>(new HttpRequest
            {
                Uri = "/api/v1/meta/schemas/user/linkedObjects",
                
            });
                    
        /// <inheritdoc />
        public async Task<ILinkedObject> AddLinkedObjectDefinitionAsync(ILinkedObject linkedObject, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<LinkedObject>(new HttpRequest
            {
                Uri = "/api/v1/meta/schemas/user/linkedObjects",
                Payload = linkedObject,
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteLinkedObjectDefinitionAsync(string linkedObjectName, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/meta/schemas/user/linkedObjects/{linkedObjectName}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["linkedObjectName"] = linkedObjectName,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<ILinkedObject> GetLinkedObjectDefinitionAsync(string linkedObjectName, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<LinkedObject>(new HttpRequest
            {
                Uri = "/api/v1/meta/schemas/user/linkedObjects/{linkedObjectName}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["linkedObjectName"] = linkedObjectName,
                },
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
