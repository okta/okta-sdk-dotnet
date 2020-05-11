// <copyright file="IonForm.Generated.cs" company="Okta, Inc">
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
    public sealed partial class IonForm : Resource, IIonForm
    {
        /// <inheritdoc/>
        public string Accepts 
        {
            get => GetStringProperty("accepts");
            set => this["accepts"] = value;
        }
        
        /// <inheritdoc/>
        public string Href 
        {
            get => GetStringProperty("href");
            set => this["href"] = value;
        }
        
        /// <inheritdoc/>
        public string Method 
        {
            get => GetStringProperty("method");
            set => this["method"] = value;
        }
        
        /// <inheritdoc/>
        public string Name 
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
        /// <inheritdoc/>
        public string Produces 
        {
            get => GetStringProperty("produces");
            set => this["produces"] = value;
        }
        
        /// <inheritdoc/>
        public int? Refresh 
        {
            get => GetIntegerProperty("refresh");
            set => this["refresh"] = value;
        }
        
        /// <inheritdoc/>
        public IList<string> Rel 
        {
            get => GetArrayProperty<string>("rel");
            set => this["rel"] = value;
        }
        
        /// <inheritdoc/>
        public IList<string> RelatesTo 
        {
            get => GetArrayProperty<string>("relatesTo");
            set => this["relatesTo"] = value;
        }
        
        /// <inheritdoc/>
        public IList<IIonField> Value => GetArrayProperty<IIonField>("value");
        
    }
}
