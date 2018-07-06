// <copyright file="ApplicationCredentialsSigning.Generated.cs" company="Okta, Inc">
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
    public sealed partial class ApplicationCredentialsSigning : Resource, IApplicationCredentialsSigning
    {
        /// <inheritdoc/>
        public string Kid 
        {
            get => GetStringProperty("kid");
            set => this["kid"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? LastRotated => GetDateTimeProperty("lastRotated");
        
        /// <inheritdoc/>
        public DateTimeOffset? NextRotation => GetDateTimeProperty("nextRotation");
        
        /// <inheritdoc/>
        public string RotationMode 
        {
            get => GetStringProperty("rotationMode");
            set => this["rotationMode"] = value;
        }
        
    }
}
