// <copyright file="IMfaEnrollmentPolicyFactors.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>Represents a MfaEnrollmentPolicyFactors resource in the Okta API.</summary>
    public partial interface IMfaEnrollmentPolicyFactors : IResource
    {
        IMfaEnrollmentPolicyFactor Duo { get; set; }

        IMfaEnrollmentPolicyFactor FidoU2F { get; set; }

        IMfaEnrollmentPolicyFactor FidoWebauthn { get; set; }

        IMfaEnrollmentPolicyFactor GoogleOtp { get; set; }

        IMfaEnrollmentPolicyFactor OktaCall { get; set; }

        IMfaEnrollmentPolicyFactor OktaEmail { get; set; }

        IMfaEnrollmentPolicyFactor OktaOtp { get; set; }

        IMfaEnrollmentPolicyFactor OktaPush { get; set; }

        IMfaEnrollmentPolicyFactor OktaQuestion { get; set; }

        IMfaEnrollmentPolicyFactor OktaSms { get; set; }

        IMfaEnrollmentPolicyFactor RsaToken { get; set; }

        IMfaEnrollmentPolicyFactor SymantecVip { get; set; }

        IMfaEnrollmentPolicyFactor YubikeyToken { get; set; }

    }
}
