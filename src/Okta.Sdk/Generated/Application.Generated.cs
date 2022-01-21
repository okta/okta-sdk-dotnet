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
        public Task ActivateAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.ActivateApplicationAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task DeactivateAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.DeactivateApplicationAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IAppUser> ListApplicationUsers(
            string q = null, string query_scope = null, string after = null, int? limit = -1, string filter = null, string expand = null)
            => GetClient().Applications.ListApplicationUsers(Id, q, query_scope, after, limit, filter, expand);
        
        /// <inheritdoc />
        public Task<IAppUser> AssignUserToApplicationAsync(IAppUser appUser, 
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.AssignUserToApplicationAsync(appUser, Id, cancellationToken);
        
        /// <inheritdoc />
        public Task<IAppUser> GetApplicationUserAsync(
            string userId, string expand = null, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.GetApplicationUserAsync(Id, userId, expand, cancellationToken);
        
        /// <inheritdoc />
        public Task<IApplicationGroupAssignment> CreateApplicationGroupAssignmentAsync(IApplicationGroupAssignment applicationGroupAssignment, 
            string groupId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.CreateApplicationGroupAssignmentAsync(applicationGroupAssignment, Id, groupId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IApplicationGroupAssignment> GetApplicationGroupAssignmentAsync(
            string groupId, string expand = null, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.GetApplicationGroupAssignmentAsync(Id, groupId, expand, cancellationToken);
        
        /// <inheritdoc />
        public Task<IJsonWebKey> CloneApplicationKeyAsync(
            string keyId, string targetAid, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.CloneApplicationKeyAsync(Id, keyId, targetAid, cancellationToken);
        
        /// <inheritdoc />
        public Task<IJsonWebKey> GetApplicationKeyAsync(
            string keyId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.GetApplicationKeyAsync(Id, keyId, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IApplicationGroupAssignment> ListGroupAssignments(
            string q = null, string after = null, int? limit = -1, string expand = null)
            => GetClient().Applications.ListApplicationGroupAssignments(Id, q, after, limit, expand);
        
        /// <inheritdoc />
        public ICollectionClient<IJsonWebKey> ListKeys(
            )
            => GetClient().Applications.ListApplicationKeys(Id);
        
        /// <inheritdoc />
        public Task<IJsonWebKey> GenerateKeyAsync(
            int? validityYears = null, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.GenerateApplicationKeyAsync(Id, validityYears, cancellationToken);
        
        /// <inheritdoc />
        public Task<ICsr> GenerateCsrAsync(ICsrMetadata metadata, 
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.GenerateCsrForApplicationAsync(metadata, Id, cancellationToken);
        
        /// <inheritdoc />
        public Task<ICsr> GetCsrAsync(
            string csrId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.GetCsrForApplicationAsync(Id, csrId, cancellationToken);
        
        /// <inheritdoc />
        public Task RevokeCsrAsync(
            string csrId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.RevokeCsrFromApplicationAsync(Id, csrId, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<ICsr> ListCsrs(
            )
            => GetClient().Applications.ListCsrsForApplication(Id);
        
        /// <inheritdoc />
        public Task<IJsonWebKey> PublishCerCertAsync(string certificate, 
            string csrId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.PublishCerCertAsync(certificate, Id, csrId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IJsonWebKey> PublishBinaryCerCertAsync(byte[] certificate, 
            string csrId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.PublishBinaryCerCertAsync(certificate, Id, csrId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IJsonWebKey> PublishDerCertAsync(string certificate, 
            string csrId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.PublishDerCertAsync(certificate, Id, csrId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IJsonWebKey> PublishBinaryDerCertAsync(byte[] certificate, 
            string csrId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.PublishBinaryDerCertAsync(certificate, Id, csrId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IJsonWebKey> PublishBinaryPemCertAsync(byte[] certificate, 
            string csrId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.PublishBinaryPemCertAsync(certificate, Id, csrId, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IOAuth2Token> ListOAuth2Tokens(
            string expand = null, string after = null, int? limit = 20)
            => GetClient().Applications.ListOAuth2TokensForApplication(Id, expand, after, limit);
        
        /// <inheritdoc />
        public Task RevokeOAuth2TokenForApplicationAsync(
            string tokenId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.RevokeOAuth2TokenForApplicationAsync(Id, tokenId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IOAuth2Token> GetOAuth2TokenAsync(
            string tokenId, string expand = null, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.GetOAuth2TokenForApplicationAsync(Id, tokenId, expand, cancellationToken);
        
        /// <inheritdoc />
        public Task RevokeOAuth2TokensAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.RevokeOAuth2TokensForApplicationAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IOAuth2ScopeConsentGrant> ListScopeConsentGrants(
            string expand = null)
            => GetClient().Applications.ListScopeConsentGrants(Id, expand);
        
        /// <inheritdoc />
        public Task<IOAuth2ScopeConsentGrant> GrantConsentToScopeAsync(IOAuth2ScopeConsentGrant oAuth2ScopeConsentGrant, 
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.GrantConsentToScopeAsync(oAuth2ScopeConsentGrant, Id, cancellationToken);
        
        /// <inheritdoc />
        public Task RevokeScopeConsentGrantAsync(
            string grantId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.RevokeScopeConsentGrantAsync(Id, grantId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IOAuth2ScopeConsentGrant> GetScopeConsentGrantAsync(
            string grantId, string expand = null, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.GetScopeConsentGrantAsync(Id, grantId, expand, cancellationToken);
        
        /// <inheritdoc />
        public Task UploadApplicationLogoAsync(
            string appId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.UploadApplicationLogoAsync(appId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IApplicationFeature> GetFeatureForApplicationAsync(
            string name, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.GetFeatureForApplicationAsync(Id, name, cancellationToken);
        
        /// <inheritdoc />
        public Task<IApplicationFeature> UpdateFeatureForApplicationAsync(ICapabilitiesObject capabilities, 
            string name, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Applications.UpdateFeatureForApplicationAsync(capabilities, Id, name, cancellationToken);
        
    }
}
