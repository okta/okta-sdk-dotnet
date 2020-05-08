// <copyright file="IPolicyRuleConditions.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a PolicyRuleConditions resource in the Okta API.</summary>
    public partial interface IPolicyRuleConditions : IResource
    {
        IAppAndInstancePolicyRuleCondition App { get; set; }

        IAppInstancePolicyRuleCondition Apps { get; set; }

        IPolicyRuleAuthContextCondition AuthContext { get; set; }

        IPasswordPolicyAuthenticationProviderCondition AuthProvider { get; set; }

        IBeforeScheduledActionPolicyRuleCondition BeforeScheduledAction { get; set; }

        IClientPolicyCondition Clients { get; set; }

        IContextPolicyRuleCondition Context { get; set; }

        IDevicePolicyRuleCondition Device { get; set; }

        IGrantTypePolicyRuleCondition GrantTypes { get; set; }

        IGroupPolicyRuleCondition Groups { get; set; }

        IIdentityProviderPolicyRuleCondition IdentityProvider { get; set; }

        IMDMEnrollmentPolicyRuleCondition MdmEnrollment { get; set; }

        IPolicyNetworkCondition Network { get; set; }

        IPolicyPeopleCondition People { get; set; }

        IPlatformPolicyRuleCondition Platform { get; set; }

        IRiskPolicyRuleCondition Risk { get; set; }

        IRiskScorePolicyRuleCondition RiskScore { get; set; }

        IOAuth2ScopesMediationPolicyRuleCondition Scopes { get; set; }

        IUserIdentifierPolicyRuleCondition UserIdentifier { get; set; }

        IUserStatusPolicyRuleCondition UserStatus { get; set; }

        IUserPolicyRuleCondition Users { get; set; }

    }
}
