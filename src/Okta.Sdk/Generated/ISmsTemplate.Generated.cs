// <copyright file="ISmsTemplate.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a SmsTemplate resource in the Okta API.</summary>
    public partial interface ISmsTemplate : IResource
    {
        DateTimeOffset? Created { get; }

        string Id { get; }

        DateTimeOffset? LastUpdated { get; }

        string Name { get; set; }

        string Template { get; set; }

        ISmsTemplateTranslations Translations { get; set; }

        SmsTemplateType Type { get; set; }

        Task<ISmsTemplate> PartialUpdateAsync(SmsTemplate smsTemplate, 
            CancellationToken cancellationToken = default(CancellationToken));

    }
}
