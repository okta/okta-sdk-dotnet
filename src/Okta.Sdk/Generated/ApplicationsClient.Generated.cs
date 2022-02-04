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
        public async Task ActivateApplicationAsync(string appId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/lifecycle/activate",
            Verb = HttpVerb.POST,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<IAppUser> AssignUserToApplicationAsync(IAppUser body, string appId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<AppUser>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/users",
            Verb = HttpVerb.POST,
            Payload = body,
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<IJsonWebKey> CloneApplicationKeyAsync(string appId, string keyId, string targetAid,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<JsonWebKey>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/credentials/keys/{keyId}/clone",
            Verb = HttpVerb.POST,
            
            
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
        public async Task<IApplication> CreateApplicationAsync(IApplication body, string oktaAccessGatewayAgent = null, bool? activate = null,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<Application>(new HttpRequest
        {
            Uri = "/api/v1/apps",
            Verb = HttpVerb.POST,
            Payload = body,
            
            PathParameters = new Dictionary<string, object>()
            {
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
                ["activate"] = activate,
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<IApplicationGroupAssignment> CreateApplicationGroupAssignmentAsync(string appId, string groupId, IApplicationGroupAssignment body = null,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PutAsync<ApplicationGroupAssignment>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/groups/{groupId}",
            Verb = HttpVerb.PUT,
            Payload = body,
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
                ["groupId"] = groupId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task DeactivateApplicationAsync(string appId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/lifecycle/deactivate",
            Verb = HttpVerb.POST,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task DeleteApplicationAsync(string appId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await DeleteAsync(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}",
            Verb = HttpVerb.DELETE,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task DeleteApplicationGroupAssignmentAsync(string appId, string groupId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await DeleteAsync(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/groups/{groupId}",
            Verb = HttpVerb.DELETE,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
                ["groupId"] = groupId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task DeleteApplicationUserAsync(string appId, string userId, bool? sendEmail = null,CancellationToken cancellationToken = default(CancellationToken))
        
        => await DeleteAsync(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/users/{userId}",
            Verb = HttpVerb.DELETE,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
                ["userId"] = userId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
                ["sendEmail"] = sendEmail,
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<IJsonWebKey> GenerateApplicationKeyAsync(string appId, int? validityYears = null,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<JsonWebKey>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/credentials/keys/generate",
            Verb = HttpVerb.POST,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
                ["validityYears"] = validityYears,
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<ICsr> GenerateCsrForApplicationAsync(ICsrMetadata body, string appId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<Csr>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/credentials/csrs",
            Verb = HttpVerb.POST,
            Payload = body,
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<IApplication> GetApplicationAsync(string appId, string expand = null,CancellationToken cancellationToken = default(CancellationToken))
        
        => await GetAsync<Application>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}",
            Verb = HttpVerb.GET,
            
            
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
        public async Task<IApplicationGroupAssignment> GetApplicationGroupAssignmentAsync(string appId, string groupId, string expand = null,CancellationToken cancellationToken = default(CancellationToken))
        
        => await GetAsync<ApplicationGroupAssignment>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/groups/{groupId}",
            Verb = HttpVerb.GET,
            
            
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
        public async Task<IJsonWebKey> GetApplicationKeyAsync(string appId, string keyId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await GetAsync<JsonWebKey>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/credentials/keys/{keyId}",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
                ["keyId"] = keyId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<IAppUser> GetApplicationUserAsync(string appId, string userId, string expand = null,CancellationToken cancellationToken = default(CancellationToken))
        
        => await GetAsync<AppUser>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/users/{userId}",
            Verb = HttpVerb.GET,
            
            
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
        public async Task<ICsr> GetCsrForApplicationAsync(string appId, string csrId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await GetAsync<Csr>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/credentials/csrs/{csrId}",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
                ["csrId"] = csrId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<IOAuth2Token> GetOAuth2TokenForApplicationAsync(string appId, string tokenId, string expand = null,CancellationToken cancellationToken = default(CancellationToken))
        
        => await GetAsync<OAuth2Token>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/tokens/{tokenId}",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
                ["tokenId"] = tokenId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
                ["expand"] = expand,
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<IOAuth2ScopeConsentGrant> GetScopeConsentGrantAsync(string appId, string grantId, string expand = null,CancellationToken cancellationToken = default(CancellationToken))
        
        => await GetAsync<OAuth2ScopeConsentGrant>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/grants/{grantId}",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
                ["grantId"] = grantId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
                ["expand"] = expand,
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<IOAuth2ScopeConsentGrant> GrantConsentToScopeAsync(IOAuth2ScopeConsentGrant body, string appId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<OAuth2ScopeConsentGrant>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/grants",
            Verb = HttpVerb.POST,
            Payload = body,
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public ICollectionClient<IApplicationGroupAssignment>ListApplicationGroupAssignments(string appId, string q = null, string after = null, int? limit = null, string expand = null)
        
        => GetCollectionClient<IApplicationGroupAssignment>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/groups",
            Verb = HttpVerb.GET,
            
            
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
        public ICollectionClient<IJsonWebKey>ListApplicationKeys(string appId)
        
        => GetCollectionClient<IJsonWebKey>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/credentials/keys",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        });
            
        
        /// <inheritdoc />
        public ICollectionClient<IAppUser>ListApplicationUsers(string appId, string q = null, string queryScope = null, string after = null, int? limit = null, string filter = null, string expand = null)
        
        => GetCollectionClient<IAppUser>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/users",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
                ["q"] = q,
                ["query_scope"] = queryScope,
                ["after"] = after,
                ["limit"] = limit,
                ["filter"] = filter,
                ["expand"] = expand,
            },
        });
            
        
        /// <inheritdoc />
        public ICollectionClient<IApplication>ListApplications(string q = null, string after = null, int? limit = null, string filter = null, string expand = null, bool? includeNonDeleted = null)
        
        => GetCollectionClient<IApplication>(new HttpRequest
        {
            Uri = "/api/v1/apps",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
            },
            
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
        public ICollectionClient<ICsr>ListCsrsForApplication(string appId)
        
        => GetCollectionClient<ICsr>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/credentials/csrs",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        });
            
        
        /// <inheritdoc />
        public ICollectionClient<IOAuth2Token>ListOAuth2TokensForApplication(string appId, string expand = null, string after = null, int? limit = null)
        
        => GetCollectionClient<IOAuth2Token>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/tokens",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
                ["expand"] = expand,
                ["after"] = after,
                ["limit"] = limit,
            },
        });
            
        
        /// <inheritdoc />
        public ICollectionClient<IOAuth2ScopeConsentGrant>ListScopeConsentGrants(string appId, string expand = null)
        
        => GetCollectionClient<IOAuth2ScopeConsentGrant>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/grants",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
                ["expand"] = expand,
            },
        });
            
        
        /// <inheritdoc />
        public async Task<IJsonWebKey> PublishCsrFromApplicationAsync(string appId, string csrId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<JsonWebKey>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/credentials/csrs/{csrId}/lifecycle/publish",
            Verb = HttpVerb.POST,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
                ["csrId"] = csrId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task RevokeCsrFromApplicationAsync(string appId, string csrId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await DeleteAsync(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/credentials/csrs/{csrId}",
            Verb = HttpVerb.DELETE,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
                ["csrId"] = csrId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task RevokeOAuth2TokenForApplicationAsync(string appId, string tokenId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await DeleteAsync(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/tokens/{tokenId}",
            Verb = HttpVerb.DELETE,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
                ["tokenId"] = tokenId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task RevokeOAuth2TokensForApplicationAsync(string appId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await DeleteAsync(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/tokens",
            Verb = HttpVerb.DELETE,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task RevokeScopeConsentGrantAsync(string appId, string grantId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await DeleteAsync(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/grants/{grantId}",
            Verb = HttpVerb.DELETE,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
                ["grantId"] = grantId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<IApplication> UpdateApplicationAsync(IApplication body, string appId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PutAsync<Application>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}",
            Verb = HttpVerb.PUT,
            Payload = body,
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<IAppUser> UpdateApplicationUserAsync(IAppUser body, string appId, string userId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<AppUser>(new HttpRequest
        {
            Uri = "/api/v1/apps/{appId}/users/{userId}",
            Verb = HttpVerb.POST,
            Payload = body,
            
            PathParameters = new Dictionary<string, object>()
            {
                ["appId"] = appId,
                ["userId"] = userId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
    }
}
