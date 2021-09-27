// <copyright file="OrgOktaSupportSettingsObj.Generated.cs" company="Okta, Inc">
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
    public sealed partial class OrgOktaSupportSettingsObj : Resource, IOrgOktaSupportSettingsObj
    {
        /// <inheritdoc/>
        public DateTimeOffset? Expiration => GetDateTimeProperty("expiration");
        
        /// <inheritdoc/>
        public OrgOktaSupportSetting Support => GetEnumProperty<OrgOktaSupportSetting>("support");
        
        /// <inheritdoc />
        public Task<IOrgOktaSupportSettingsObj> ExtendOktaSupportAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Orgs.ExtendOktaSupportAsync(cancellationToken);
        
        /// <inheritdoc />
        public Task<IOrgOktaSupportSettingsObj> GrantOktaSupportAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Orgs.GrantOktaSupportAsync(cancellationToken);
        
        /// <inheritdoc />
        public Task<IOrgOktaSupportSettingsObj> RevokeOktaSupportAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Orgs.RevokeOktaSupportAsync(cancellationToken);
        
    }
}
