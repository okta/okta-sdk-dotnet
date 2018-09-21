// <copyright file="MfaEnrollmentPolicyFactors.Generated.cs" company="Okta, Inc">
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
    public sealed partial class MfaEnrollmentPolicyFactors : Resource, IMfaEnrollmentPolicyFactors
    {
        /// <inheritdoc/>
        public IMfaEnrollmentPolicyFactor Duo 
        {
            get => GetResourceProperty<MfaEnrollmentPolicyFactor>("duo");
            set => this["duo"] = value;
        }
        
        /// <inheritdoc/>
        public IMfaEnrollmentPolicyFactor FidoU2F 
        {
            get => GetResourceProperty<MfaEnrollmentPolicyFactor>("fido_u2f");
            set => this["fido_u2f"] = value;
        }
        
        /// <inheritdoc/>
        public IMfaEnrollmentPolicyFactor FidoWebauthn 
        {
            get => GetResourceProperty<MfaEnrollmentPolicyFactor>("fido_webauthn");
            set => this["fido_webauthn"] = value;
        }
        
        /// <inheritdoc/>
        public IMfaEnrollmentPolicyFactor GoogleOtp 
        {
            get => GetResourceProperty<MfaEnrollmentPolicyFactor>("google_otp");
            set => this["google_otp"] = value;
        }
        
        /// <inheritdoc/>
        public IMfaEnrollmentPolicyFactor OktaCall 
        {
            get => GetResourceProperty<MfaEnrollmentPolicyFactor>("okta_call");
            set => this["okta_call"] = value;
        }
        
        /// <inheritdoc/>
        public IMfaEnrollmentPolicyFactor OktaEmail 
        {
            get => GetResourceProperty<MfaEnrollmentPolicyFactor>("okta_email");
            set => this["okta_email"] = value;
        }
        
        /// <inheritdoc/>
        public IMfaEnrollmentPolicyFactor OktaOtp 
        {
            get => GetResourceProperty<MfaEnrollmentPolicyFactor>("okta_otp");
            set => this["okta_otp"] = value;
        }
        
        /// <inheritdoc/>
        public IMfaEnrollmentPolicyFactor OktaPush 
        {
            get => GetResourceProperty<MfaEnrollmentPolicyFactor>("okta_push");
            set => this["okta_push"] = value;
        }
        
        /// <inheritdoc/>
        public IMfaEnrollmentPolicyFactor OktaQuestion 
        {
            get => GetResourceProperty<MfaEnrollmentPolicyFactor>("okta_question");
            set => this["okta_question"] = value;
        }
        
        /// <inheritdoc/>
        public IMfaEnrollmentPolicyFactor OktaSms 
        {
            get => GetResourceProperty<MfaEnrollmentPolicyFactor>("okta_sms");
            set => this["okta_sms"] = value;
        }
        
        /// <inheritdoc/>
        public IMfaEnrollmentPolicyFactor RsaToken 
        {
            get => GetResourceProperty<MfaEnrollmentPolicyFactor>("rsa_token");
            set => this["rsa_token"] = value;
        }
        
        /// <inheritdoc/>
        public IMfaEnrollmentPolicyFactor SymantecVip 
        {
            get => GetResourceProperty<MfaEnrollmentPolicyFactor>("symantec_vip");
            set => this["symantec_vip"] = value;
        }
        
        /// <inheritdoc/>
        public IMfaEnrollmentPolicyFactor YubikeyToken 
        {
            get => GetResourceProperty<MfaEnrollmentPolicyFactor>("yubikey_token");
            set => this["yubikey_token"] = value;
        }
        
    }
}
