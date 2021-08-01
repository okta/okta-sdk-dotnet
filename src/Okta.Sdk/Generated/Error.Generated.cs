// <copyright file="Error.Generated.cs" company="Okta, Inc">
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
    public sealed partial class Error : Resource, IError
    {
        /// <inheritdoc/>
        public IList<object> ErrorCauses 
        {
            get => GetArrayProperty<object>("errorCauses");
            set => this["errorCauses"] = value;
        }
        
        /// <inheritdoc/>
        public string ErrorCode 
        {
            get => GetStringProperty("errorCode");
            set => this["errorCode"] = value;
        }
        
        /// <inheritdoc/>
        public string ErrorId 
        {
            get => GetStringProperty("errorId");
            set => this["errorId"] = value;
        }
        
        /// <inheritdoc/>
        public string ErrorLink 
        {
            get => GetStringProperty("errorLink");
            set => this["errorLink"] = value;
        }
        
        /// <inheritdoc/>
        public string ErrorSummary 
        {
            get => GetStringProperty("errorSummary");
            set => this["errorSummary"] = value;
        }
        
    }
}
