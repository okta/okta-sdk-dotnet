// <copyright file="Client.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// Do not modify this file directly. This file was automatically generated with:
// spec.json - 0.3.0

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Okta.Sdk.Configuration;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    public sealed partial class GroupClient : OktaClient, IGroupClient
    {
        // Remove parameterless constructor
        private GroupClient()
        {
        }

        internal GroupClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public IAsyncEnumerable<Group> ListGroups(string q = null, string filter = null, string after = null, int? limit = -1, string expand = null)
            => GetCollectionClient<Group>(new HttpRequest
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
        public Task<Group> CreateGroupAsync(Group group, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync<Group>(new HttpRequest
        {
            Uri = "/api/v1/groups",
            Payload = group,
        }, cancellationToken);

        /// <inheritdoc />
        public IAsyncEnumerable<GroupRule> ListRules(int? limit = -1, string after = null)
            => GetCollectionClient<GroupRule>(new HttpRequest
        {
            Uri = "/api/v1/groups/rules",
            
            QueryParameters = new Dictionary<string, object>()
            {
                ["limit"] = limit,
                ["after"] = after,
            },
        });

        /// <inheritdoc />
        public Task<GroupRule> CreateRuleAsync(GroupRule groupRule, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync<GroupRule>(new HttpRequest
        {
            Uri = "/api/v1/groups/rules",
            Payload = groupRule,
        }, cancellationToken);

        /// <inheritdoc />
        public Task DeleteRuleAsync(string ruleId, bool? removeUsers = null, CancellationToken cancellationToken = default(CancellationToken))
            => DeleteAsync(new HttpRequest
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
        }, cancellationToken);

        /// <inheritdoc />
        public Task<GroupRule> GetRuleAsync(string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            => GetAsync<GroupRule>(new HttpRequest
        {
            Uri = "/api/v1/groups/rules/{ruleId}",
            
            PathParameters = new Dictionary<string, object>()
            {
                ["ruleId"] = ruleId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task<GroupRule> UpdateRuleAsync(GroupRule groupRule, string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            => PutAsync<GroupRule>(new HttpRequest
        {
            Uri = "/api/v1/groups/rules/{ruleId}",
            Payload = groupRule,
            PathParameters = new Dictionary<string, object>()
            {
                ["ruleId"] = ruleId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task ActivateRuleAsync(string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync(new HttpRequest
        {
            Uri = "/api/v1/groups/rules/{ruleId}/lifecycle/activate",
            
            PathParameters = new Dictionary<string, object>()
            {
                ["ruleId"] = ruleId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task DeactivateRuleAsync(string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync(new HttpRequest
        {
            Uri = "/api/v1/groups/rules/{ruleId}/lifecycle/deactivate",
            
            PathParameters = new Dictionary<string, object>()
            {
                ["ruleId"] = ruleId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task DeleteGroupAsync(string groupId, CancellationToken cancellationToken = default(CancellationToken))
            => DeleteAsync(new HttpRequest
        {
            Uri = "/api/v1/groups/{groupId}",
            
            PathParameters = new Dictionary<string, object>()
            {
                ["groupId"] = groupId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task<Group> GetGroupAsync(string groupId, string expand = null, CancellationToken cancellationToken = default(CancellationToken))
            => GetAsync<Group>(new HttpRequest
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
        }, cancellationToken);

        /// <inheritdoc />
        public Task<Group> UpdateGroupAsync(Group group, string groupId, CancellationToken cancellationToken = default(CancellationToken))
            => PutAsync<Group>(new HttpRequest
        {
            Uri = "/api/v1/groups/{groupId}",
            Payload = group,
            PathParameters = new Dictionary<string, object>()
            {
                ["groupId"] = groupId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public IAsyncEnumerable<User> ListGroupUsers(string groupId, string after = null, int? limit = -1)
            => GetCollectionClient<User>(new HttpRequest
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
            },
        });

        /// <inheritdoc />
        public Task RemoveGroupUserAsync(string groupId, string userId, CancellationToken cancellationToken = default(CancellationToken))
            => DeleteAsync(new HttpRequest
        {
            Uri = "/api/v1/groups/{groupId}/users/{userId}",
            
            PathParameters = new Dictionary<string, object>()
            {
                ["groupId"] = groupId,
                ["userId"] = userId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task AddUserToGroupAsync(string groupId, string userId, CancellationToken cancellationToken = default(CancellationToken))
            => PutAsync(new HttpRequest
        {
            Uri = "/api/v1/groups/{groupId}/users/{userId}",
            
            PathParameters = new Dictionary<string, object>()
            {
                ["groupId"] = groupId,
                ["userId"] = userId,
            },
        }, cancellationToken);
    }
}
