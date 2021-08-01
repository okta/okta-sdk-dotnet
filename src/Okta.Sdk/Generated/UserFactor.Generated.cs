// <copyright file="UserFactor.Generated.cs" company="Okta, Inc">
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
    public sealed partial class UserFactor : Resource, IUserFactor
    {
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public FactorType FactorType 
        {
            get => GetEnumProperty<FactorType>("factorType");
            set => this["factorType"] = value;
        }
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");
        
        /// <inheritdoc/>
        public FactorProvider Provider 
        {
            get => GetEnumProperty<FactorProvider>("provider");
            set => this["provider"] = value;
        }
        
        /// <inheritdoc/>
        public FactorStatus Status 
        {
            get => GetEnumProperty<FactorStatus>("status");
            set => this["status"] = value;
        }
        
        /// <inheritdoc/>
        public IVerifyFactorRequest Verify 
        {
            get => GetResourceProperty<VerifyFactorRequest>("verify");
            set => this["verify"] = value;
        }
        
        /// <inheritdoc />
        public Task<IUserFactor> ActivateAsync(IActivateFactorRequest activateFactorRequest, 
            string userId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().UserFactors.ActivateFactorAsync(activateFactorRequest, userId, Id, cancellationToken);
        
        /// <inheritdoc />
        public Task<IVerifyUserFactorResponse> VerifyAsync(IVerifyFactorRequest verifyFactorRequest, 
            string userId, string templateId = null, int? tokenLifetimeSeconds = 300, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().UserFactors.VerifyFactorAsync(verifyFactorRequest, userId, Id, templateId, tokenLifetimeSeconds, cancellationToken);
        
    }
}
