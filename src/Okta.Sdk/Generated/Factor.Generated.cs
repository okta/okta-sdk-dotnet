// <copyright file="Factor.Generated.cs" company="Okta, Inc">
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
    public partial class Factor : Resource, IFactor
    {
        /// <inheritdoc/>
        public string Device 
        {
            get => GetStringProperty("device");
            set => this["device"] = value;
        }
        
        /// <inheritdoc/>
        public string DeviceType => GetStringProperty("deviceType");
        
        /// <inheritdoc/>
        public FactorType FactorType 
        {
            get => GetEnumProperty<FactorType>("factorType");
            set => this["factorType"] = value;
        }
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public string MfaStateTokenId 
        {
            get => GetStringProperty("mfaStateTokenId");
            set => this["mfaStateTokenId"] = value;
        }
        
        /// <inheritdoc/>
        public IFactorProfile Profile 
        {
            get => GetResourceProperty<FactorProfile>("profile");
            set => this["profile"] = value;
        }
        
        /// <inheritdoc/>
        public FactorProvider Provider 
        {
            get => GetEnumProperty<FactorProvider>("provider");
            set => this["provider"] = value;
        }
        
        /// <inheritdoc/>
        public bool? RechallengeExistingFactor 
        {
            get => GetBooleanProperty("rechallengeExistingFactor");
            set => this["rechallengeExistingFactor"] = value;
        }
        
        /// <inheritdoc/>
        public string SessionId 
        {
            get => GetStringProperty("sessionId");
            set => this["sessionId"] = value;
        }
        
        /// <inheritdoc/>
        public FactorStatus Status => GetEnumProperty<FactorStatus>("status");
        
        /// <inheritdoc/>
        public int? TokenLifetimeSeconds 
        {
            get => GetIntegerProperty("tokenLifetimeSeconds");
            set => this["tokenLifetimeSeconds"] = value;
        }
        
        /// <inheritdoc/>
        public string UserId 
        {
            get => GetStringProperty("userId");
            set => this["userId"] = value;
        }
        
        /// <inheritdoc/>
        public IVerifyFactorRequest Verify 
        {
            get => GetResourceProperty<VerifyFactorRequest>("verify");
            set => this["verify"] = value;
        }
        
        /// <inheritdoc />
        public Task<IFactor> ActivateAsync(VerifyFactorRequest verifyFactorRequest, string userId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().UserFactors.ActivateFactorAsync(verifyFactorRequest, userId, Id, cancellationToken);
        
        /// <inheritdoc />
        public Task<IVerifyFactorResponse> VerifyAsync(VerifyFactorRequest verifyFactorRequest, string userId, string templateId = null, int? tokenLifetimeSeconds = 300, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().UserFactors.VerifyFactorAsync(verifyFactorRequest, userId, Id, templateId, tokenLifetimeSeconds, cancellationToken);
        
    }
}
