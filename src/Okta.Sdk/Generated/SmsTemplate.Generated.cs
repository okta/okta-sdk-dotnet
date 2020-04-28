// <copyright file="SmsTemplate.Generated.cs" company="Okta, Inc">
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
    public sealed partial class SmsTemplate : Resource, ISmsTemplate
    {
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");
        
        /// <inheritdoc/>
        public string Name 
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
        /// <inheritdoc/>
        public string Template 
        {
            get => GetStringProperty("template");
            set => this["template"] = value;
        }
        
        /// <inheritdoc/>
        public ISmsTemplateTranslations Translations 
        {
            get => GetResourceProperty<SmsTemplateTranslations>("translations");
            set => this["translations"] = value;
        }
        
        /// <inheritdoc/>
        public SmsTemplateType Type 
        {
            get => GetEnumProperty<SmsTemplateType>("type");
            set => this["type"] = value;
        }
        
        /// <inheritdoc />
        public Task<ISmsTemplate> PartialUpdateAsync(SmsTemplate smsTemplate, 
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Templates.PartialUpdateSmsTemplateAsync(smsTemplate, Id, cancellationToken);
        
    }
}
