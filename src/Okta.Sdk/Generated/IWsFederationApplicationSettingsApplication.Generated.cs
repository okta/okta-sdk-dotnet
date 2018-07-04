// <copyright file="IWsFederationApplicationSettingsApplication.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a WsFederationApplicationSettingsApplication resource in the Okta API.</summary>
    public partial interface IWsFederationApplicationSettingsApplication : IApplicationSettingsApplication
    {
        string AttributeStatements { get; set; }

        string AudienceRestriction { get; set; }

        string AuthenticationContextClassName { get; set; }

        string GroupFilter { get; set; }

        string GroupName { get; set; }

        string GroupValueFormat { get; set; }

        string NameIdFormat { get; set; }

        string Realm { get; set; }

        string SiteUrl { get; set; }

        string UsernameAttribute { get; set; }

        bool? WReplyOverride { get; set; }

        string WReplyUrl { get; set; }

    }
}
