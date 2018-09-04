// <copyright file="Application.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public partial class Application : Resource, IApplication
    {
        /// <inheritdoc/>
        public IApplicationAccessibility Accessibility 
        {
            get => GetResourceProperty<ApplicationAccessibility>("accessibility");
            set => this["accessibility"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public IApplicationCredentials Credentials 
        {
            get => GetResourceProperty<ApplicationCredentials>("credentials");
            set => this["credentials"] = value;
        }
        
        /// <inheritdoc/>
        public IList<string> Features 
        {
            get => GetArrayProperty<string>("features");
            set => this["features"] = value;
        }
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public string Label 
        {
            get => GetStringProperty("label");
            set => this["label"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");
        
        /// <inheritdoc/>
        public IApplicationLicensing Licensing 
        {
            get => GetResourceProperty<ApplicationLicensing>("licensing");
            set => this["licensing"] = value;
        }
        
        /// <inheritdoc/>
        public string Name => GetStringProperty("name");
        
        /// <inheritdoc/>
        public Resource Profile 
        {
            get => GetResourceProperty<Resource>("profile");
            set => this["profile"] = value;
        }
        
        /// <inheritdoc/>
        public IApplicationSettings Settings 
        {
            get => GetResourceProperty<ApplicationSettings>("settings");
            set => this["settings"] = value;
        }
        
        /// <inheritdoc/>
        public ApplicationSignOnMode SignOnMode 
        {
            get => GetEnumProperty<ApplicationSignOnMode>("signOnMode");
            set => this["signOnMode"] = value;
        }
        
        /// <inheritdoc/>
        public string Status => GetStringProperty("status");
        
        /// <inheritdoc/>
        public IApplicationVisibility Visibility 
        {
            get => GetResourceProperty<ApplicationVisibility>("visibility");
            set => this["visibility"] = value;
        }
        
        /// <inheritdoc />
        public Task ActivateAsync(CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.ActivateApplicationAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task DeactivateAsync(CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.DeactivateApplicationAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IAppUser> ListApplicationUsers(string q = null, string query_scope = null, string after = null, int? limit = -1, string filter = null, string expand = null)
            => GetClient().Applications.ListApplicationUsers(Id, q, query_scope, after, limit, filter, expand);
        
        /// <inheritdoc />
        public Task<IAppUser> AssignUserToApplicationAsync(AppUser appUser, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.AssignUserToApplicationAsync(appUser, Id, cancellationToken);
        
        /// <inheritdoc />
        public Task<IAppUser> GetApplicationUserAsync(string userId, string expand = null, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.GetApplicationUserAsync(Id, userId, expand, cancellationToken);
        
        /// <inheritdoc />
        public Task<IApplicationGroupAssignment> CreateApplicationGroupAssignmentAsync(ApplicationGroupAssignment applicationGroupAssignment, string groupId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.CreateApplicationGroupAssignmentAsync(applicationGroupAssignment, Id, groupId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IApplicationGroupAssignment> GetApplicationGroupAssignmentAsync(string groupId, string expand = null, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.GetApplicationGroupAssignmentAsync(Id, groupId, expand, cancellationToken);
        
        /// <inheritdoc />
        public Task<IJsonWebKey> CloneApplicationKeyAsync(string keyId, string targetAid, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.CloneApplicationKeyAsync(Id, keyId, targetAid, cancellationToken);
        
        /// <inheritdoc />
        public Task<IJsonWebKey> GetApplicationKeyAsync(string keyId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.GetApplicationKeyAsync(Id, keyId, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IApplicationGroupAssignment> ListGroupAssignments(string q = null, string after = null, int? limit = -1, string expand = null)
            => GetClient().Applications.ListApplicationGroupAssignments(Id, q, after, limit, expand);
        
        /// <inheritdoc />
        public ICollectionClient<IJsonWebKey> ListKeys()
            => GetClient().Applications.ListApplicationKeys(Id);
        
    }
}
