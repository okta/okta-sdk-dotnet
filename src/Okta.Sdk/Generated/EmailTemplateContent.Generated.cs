// <copyright file="EmailTemplateContent.Generated.cs" company="Okta, Inc">
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
    public sealed partial class EmailTemplateContent : Resource, IEmailTemplateContent
    {
        /// <inheritdoc/>
        public string Body 
        {
            get => GetStringProperty("body");
            set => this["body"] = value;
        }
        
        /// <inheritdoc/>
        public string FromAddress 
        {
            get => GetStringProperty("fromAddress");
            set => this["fromAddress"] = value;
        }
        
        /// <inheritdoc/>
        public string FromName 
        {
            get => GetStringProperty("fromName");
            set => this["fromName"] = value;
        }
        
        /// <inheritdoc/>
        public string Subject 
        {
            get => GetStringProperty("subject");
            set => this["subject"] = value;
        }
        
    }
}
