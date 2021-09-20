// <copyright file="UserSchemasClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class UserSchemasClient : OktaClient, IUserSchemasClient
    {
        // Remove parameterless constructor
        private UserSchemasClient()
        {
        }

        internal UserSchemasClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public async Task<IUserSchema> GetApplicationUserSchemaAsync(string appInstanceId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<UserSchema>(new HttpRequest
            {
                Uri = "/api/v1/meta/schemas/apps/{appInstanceId}/default",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["appInstanceId"] = appInstanceId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IUserSchema> UpdateApplicationUserProfileAsync(IUserSchema body, string appInstanceId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<UserSchema>(new HttpRequest
            {
                Uri = "/api/v1/meta/schemas/apps/{appInstanceId}/default",
                Verb = HttpVerb.Post,
                Payload = body,
                PathParameters = new Dictionary<string, object>()
                {
                    ["appInstanceId"] = appInstanceId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IUserSchema> GetUserSchemaAsync(string schemaId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<UserSchema>(new HttpRequest
            {
                Uri = "/api/v1/meta/schemas/user/{schemaId}",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["schemaId"] = schemaId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IUserSchema> UpdateUserProfileAsync(IUserSchema userSchema, string schemaId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<UserSchema>(new HttpRequest
            {
                Uri = "/api/v1/meta/schemas/user/{schemaId}",
                Verb = HttpVerb.Post,
                Payload = userSchema,
                PathParameters = new Dictionary<string, object>()
                {
                    ["schemaId"] = schemaId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
