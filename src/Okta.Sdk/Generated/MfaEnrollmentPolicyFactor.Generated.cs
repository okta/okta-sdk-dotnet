// <copyright file="MfaEnrollmentPolicyFactor.Generated.cs" company="Okta, Inc">
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
    public sealed partial class MfaEnrollmentPolicyFactor : Resource, IMfaEnrollmentPolicyFactor
    {
        /// <inheritdoc/>
        public IMfaEnrollmentPolicyFactorConsent Consent 
        {
            get => GetResourceProperty<MfaEnrollmentPolicyFactorConsent>("consent");
            set => this["consent"] = value;
        }
        
        /// <inheritdoc/>
        public IMfaEnrollmentPolicyFactorRequirements Enroll 
        {
            get => GetResourceProperty<MfaEnrollmentPolicyFactorRequirements>("enroll");
            set => this["enroll"] = value;
        }
        
    }
}
