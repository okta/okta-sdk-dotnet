// <copyright file="UserTypesClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class UserTypesClient : OktaClient, IUserTypesClient
    {
        // Remove parameterless constructor
        private UserTypesClient()
        {
        }

        internal UserTypesClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public ICollectionClient<IUserType> ListUserTypes()
            => GetCollectionClient<IUserType>(new HttpRequest
            {
                Uri = "/api/v1/meta/types/user",
                
            });
                    
        /// <inheritdoc />
        public async Task<IUserType> CreateUserTypeAsync(IUserType userType, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<UserType>(new HttpRequest
            {
                Uri = "/api/v1/meta/types/user",
                Payload = userType,
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteUserTypeAsync(string typeId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/meta/types/user/{typeId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["typeId"] = typeId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IUserType> GetUserTypeAsync(string typeId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<UserType>(new HttpRequest
            {
                Uri = "/api/v1/meta/types/user/{typeId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["typeId"] = typeId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IUserType> UpdateUserTypeAsync(IUserType userType, string typeId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<UserType>(new HttpRequest
            {
                Uri = "/api/v1/meta/types/user/{typeId}",
                Payload = userType,
                PathParameters = new Dictionary<string, object>()
                {
                    ["typeId"] = typeId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IUserType> ReplaceUserTypeAsync(IUserType userType, string typeId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<UserType>(new HttpRequest
            {
                Uri = "/api/v1/meta/types/user/{typeId}",
                Payload = userType,
                PathParameters = new Dictionary<string, object>()
                {
                    ["typeId"] = typeId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
