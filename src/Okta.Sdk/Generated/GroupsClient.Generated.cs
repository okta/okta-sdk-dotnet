// <copyright file="GroupsClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class GroupsClient : OktaClient, IGroupsClient
    {
        // Remove parameterless constructor
        private GroupsClient()
        {
        }

        internal GroupsClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public ICollectionClient<IGroup> ListGroups(string q = null, string filter = null, string after = null, int? limit = -1, string expand = null)
            => GetCollectionClient<IGroup>(new HttpRequest
            {
                Uri = "/api/v1/groups",
                
                QueryParameters = new Dictionary<string, object>()
                {
                    ["q"] = q,
                    ["filter"] = filter,
                    ["after"] = after,
                    ["limit"] = limit,
                    ["expand"] = expand,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IGroup> CreateGroupAsync(IGroup group, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<Group>(new HttpRequest
            {
                Uri = "/api/v1/groups",
                Payload = group,
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IGroupRule> ListRules(int? limit = -1, string after = null, string expand = "")
            => GetCollectionClient<IGroupRule>(new HttpRequest
            {
                Uri = "/api/v1/groups/rules",
                
                QueryParameters = new Dictionary<string, object>()
                {
                    ["limit"] = limit,
                    ["after"] = after,
                    ["expand"] = expand,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IGroupRule> CreateRuleAsync(IGroupRule groupRule, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<GroupRule>(new HttpRequest
            {
                Uri = "/api/v1/groups/rules",
                Payload = groupRule,
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteRuleAsync(string ruleId, bool? removeUsers = false, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/groups/rules/{ruleId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["ruleId"] = ruleId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["removeUsers"] = removeUsers,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IGroupRule> GetRuleAsync(string ruleId, string expand = "", CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<GroupRule>(new HttpRequest
            {
                Uri = "/api/v1/groups/rules/{ruleId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["ruleId"] = ruleId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["expand"] = expand,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IGroupRule> UpdateRuleAsync(IGroupRule groupRule, string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<GroupRule>(new HttpRequest
            {
                Uri = "/api/v1/groups/rules/{ruleId}",
                Payload = groupRule,
                PathParameters = new Dictionary<string, object>()
                {
                    ["ruleId"] = ruleId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task ActivateRuleAsync(string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/groups/rules/{ruleId}/lifecycle/activate",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["ruleId"] = ruleId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeactivateRuleAsync(string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/groups/rules/{ruleId}/lifecycle/deactivate",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["ruleId"] = ruleId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteGroupAsync(string groupId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/groups/{groupId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["groupId"] = groupId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IGroup> GetGroupAsync(string groupId, string expand = null, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<Group>(new HttpRequest
            {
                Uri = "/api/v1/groups/{groupId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["groupId"] = groupId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["expand"] = expand,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IGroup> UpdateGroupAsync(IGroup group, string groupId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<Group>(new HttpRequest
            {
                Uri = "/api/v1/groups/{groupId}",
                Payload = group,
                PathParameters = new Dictionary<string, object>()
                {
                    ["groupId"] = groupId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IUser> ListGroupUsers(string groupId, string after = null, int? limit = -1, string managedBy = "all")
            => GetCollectionClient<IUser>(new HttpRequest
            {
                Uri = "/api/v1/groups/{groupId}/users",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["groupId"] = groupId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["after"] = after,
                    ["limit"] = limit,
                    ["managedBy"] = managedBy,
                },
            });
                    
        /// <inheritdoc />
        public async Task RemoveGroupUserAsync(string groupId, string userId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/groups/{groupId}/users/{userId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["groupId"] = groupId,
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task AddUserToGroupAsync(string groupId, string userId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync(new HttpRequest
            {
                Uri = "/api/v1/groups/{groupId}/users/{userId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["groupId"] = groupId,
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
