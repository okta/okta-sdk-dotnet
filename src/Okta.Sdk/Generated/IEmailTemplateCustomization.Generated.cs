// <copyright file="IEmailTemplateCustomization.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a EmailTemplateCustomization resource in the Okta API.</summary>
    public partial interface IEmailTemplateCustomization : IResource
    {
        string Body { get; set; }

        DateTimeOffset? Created { get; }

        string Id { get; }

        bool? IsDefault { get; set; }

        string Language { get; set; }

        DateTimeOffset? LastUpdated { get; }

        string Subject { get; set; }

    }
}
