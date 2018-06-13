// <copyright file="ISwaThreeFieldApplicationSettingsApplication.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a SwaThreeFieldApplicationSettingsApplication resource in the Okta API.</summary>
    public partial interface ISwaThreeFieldApplicationSettingsApplication : IApplicationSettingsApplication
    {
        string ButtonSelector { get; set; }

        string ExtraFieldSelector { get; set; }

        string ExtraFieldValue { get; set; }

        string LoginUrlRegex { get; set; }

        string PasswordSelector { get; set; }

        string TargetUrl { get; set; }

        string UserNameSelector { get; set; }

    }
}
