// <copyright file="CsrMetadata.Generated.cs" company="Okta, Inc">
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
    public sealed partial class CsrMetadata : Resource, ICsrMetadata
    {
        /// <inheritdoc/>
        public ICsrMetadataSubject Subject 
        {
            get => GetResourceProperty<CsrMetadataSubject>("subject");
            set => this["subject"] = value;
        }
        
        /// <inheritdoc/>
        public ICsrMetadataSubjectAltNames SubjectAltNames 
        {
            get => GetResourceProperty<CsrMetadataSubjectAltNames>("subjectAltNames");
            set => this["subjectAltNames"] = value;
        }
        
    }
}
