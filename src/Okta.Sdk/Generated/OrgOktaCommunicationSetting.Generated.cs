// <copyright file="OrgOktaCommunicationSetting.Generated.cs" company="Okta, Inc">
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
    public sealed partial class OrgOktaCommunicationSetting : Resource, IOrgOktaCommunicationSetting
    {
        /// <inheritdoc/>
        public bool? OptOutEmailUsers => GetBooleanProperty("optOutEmailUsers");
        
        /// <inheritdoc />
        public Task<IOrgOktaCommunicationSetting> OptInUsersToOktaCommunicationEmailsAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Orgs.OptInUsersToOktaCommunicationEmailsAsync(cancellationToken);
        
        /// <inheritdoc />
        public Task<IOrgOktaCommunicationSetting> OptOutUsersFromOktaCommunicationEmailsAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Orgs.OptOutUsersFromOktaCommunicationEmailsAsync(cancellationToken);
        
    }
}
