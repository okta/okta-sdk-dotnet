// <copyright file="ApplicationsClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class ApplicationsClient : OktaClient, IApplicationsClient
    {
        // Remove parameterless constructor
        private ApplicationsClient()
        {
        }

        internal ApplicationsClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public ICollectionClient<IApplication> ListApplications(string q = null, string after = null, int? limit = -1, string filter = null, string expand = null, bool? includeNonDeleted = false)
            => GetCollectionClient<IApplication>(new HttpRequest
            {
                Uri = "/api/v1/apps",
                
                QueryParameters = new Dictionary<string, object>()
                {
                    ["q"] = q,
                    ["after"] = after,
                    ["limit"] = limit,
                    ["filter"] = filter,
                    ["expand"] = expand,
                    ["includeNonDeleted"] = includeNonDeleted,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IApplication> CreateApplicationAsync(IApplication application, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<Application>(new HttpRequest
            {
                Uri = "/api/v1/apps",
                Payload = application,
                QueryParameters = new Dictionary<string, object>()
                {
                    ["activate"] = activate,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteApplicationAsync(string appId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/apps/{appId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["appId"] = appId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IApplication> GetApplicationAsync(string appId, string expand = null, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<Application>(new HttpRequest
            {
                Uri = "/api/v1/apps/{appId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["appId"] = appId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["expand"] = expand,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IApplication> UpdateApplicationAsync(IApplication application, string appId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<Application>(new HttpRequest
            {
                Uri = "/api/v1/apps/{appId}",
                Payload = application,
                PathParameters = new Dictionary<string, object>()
                {
                    ["appId"] = appId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IJsonWebKey> ListApplicationKeys(string appId)
            => GetCollectionClient<IJsonWebKey>(new HttpRequest
            {
                Uri = "/api/v1/apps/{appId}/credentials/keys",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["appId"] = appId,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IJsonWebKey> GetApplicationKeyAsync(string appId, string keyId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<JsonWebKey>(new HttpRequest
            {
                Uri = "/api/v1/apps/{appId}/credentials/keys/{keyId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["appId"] = appId,
                    ["keyId"] = keyId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IJsonWebKey> CloneApplicationKeyAsync(string appId, string keyId, string targetAid, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<JsonWebKey>(new HttpRequest
            {
                Uri = "/api/v1/apps/{appId}/credentials/keys/{keyId}/clone",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["appId"] = appId,
                    ["keyId"] = keyId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["targetAid"] = targetAid,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IApplicationGroupAssignment> ListApplicationGroupAssignments(string appId, string q = null, string after = null, int? limit = -1, string expand = null)
            => GetCollectionClient<IApplicationGroupAssignment>(new HttpRequest
            {
                Uri = "/api/v1/apps/{appId}/groups",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["appId"] = appId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["q"] = q,
                    ["after"] = after,
                    ["limit"] = limit,
                    ["expand"] = expand,
                },
            });
                    
        /// <inheritdoc />
        public async Task DeleteApplicationGroupAssignmentAsync(string appId, string groupId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/apps/{appId}/groups/{groupId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["appId"] = appId,
                    ["groupId"] = groupId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IApplicationGroupAssignment> GetApplicationGroupAssignmentAsync(string appId, string groupId, string expand = null, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<ApplicationGroupAssignment>(new HttpRequest
            {
                Uri = "/api/v1/apps/{appId}/groups/{groupId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["appId"] = appId,
                    ["groupId"] = groupId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["expand"] = expand,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IApplicationGroupAssignment> CreateApplicationGroupAssignmentAsync(IApplicationGroupAssignment applicationGroupAssignment, string appId, string groupId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<ApplicationGroupAssignment>(new HttpRequest
            {
                Uri = "/api/v1/apps/{appId}/groups/{groupId}",
                Payload = applicationGroupAssignment,
                PathParameters = new Dictionary<string, object>()
                {
                    ["appId"] = appId,
                    ["groupId"] = groupId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task ActivateApplicationAsync(string appId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/apps/{appId}/lifecycle/activate",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["appId"] = appId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeactivateApplicationAsync(string appId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/apps/{appId}/lifecycle/deactivate",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["appId"] = appId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IAppUser> ListApplicationUsers(string appId, string q = null, string query_scope = null, string after = null, int? limit = -1, string filter = null, string expand = null)
            => GetCollectionClient<IAppUser>(new HttpRequest
            {
                Uri = "/api/v1/apps/{appId}/users",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["appId"] = appId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["q"] = q,
                    ["query_scope"] = query_scope,
                    ["after"] = after,
                    ["limit"] = limit,
                    ["filter"] = filter,
                    ["expand"] = expand,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IAppUser> AssignUserToApplicationAsync(IAppUser appUser, string appId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<AppUser>(new HttpRequest
            {
                Uri = "/api/v1/apps/{appId}/users",
                Payload = appUser,
                PathParameters = new Dictionary<string, object>()
                {
                    ["appId"] = appId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteApplicationUserAsync(string appId, string userId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/apps/{appId}/users/{userId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["appId"] = appId,
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IAppUser> GetApplicationUserAsync(string appId, string userId, string expand = null, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<AppUser>(new HttpRequest
            {
                Uri = "/api/v1/apps/{appId}/users/{userId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["appId"] = appId,
                    ["userId"] = userId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["expand"] = expand,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IAppUser> UpdateApplicationUserAsync(IAppUser appUser, string appId, string userId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<AppUser>(new HttpRequest
            {
                Uri = "/api/v1/apps/{appId}/users/{userId}",
                Payload = appUser,
                PathParameters = new Dictionary<string, object>()
                {
                    ["appId"] = appId,
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
