// <copyright file="CsrMetadataSubject.Generated.cs" company="Okta, Inc">
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
    public sealed partial class CsrMetadataSubject : Resource, ICsrMetadataSubject
    {
        /// <inheritdoc/>
        public string CommonName 
        {
            get => GetStringProperty("commonName");
            set => this["commonName"] = value;
        }
        
        /// <inheritdoc/>
        public string CountryName 
        {
            get => GetStringProperty("countryName");
            set => this["countryName"] = value;
        }
        
        /// <inheritdoc/>
        public string LocalityName 
        {
            get => GetStringProperty("localityName");
            set => this["localityName"] = value;
        }
        
        /// <inheritdoc/>
        public string OrganizationName 
        {
            get => GetStringProperty("organizationName");
            set => this["organizationName"] = value;
        }
        
        /// <inheritdoc/>
        public string OrganizationalUnitName 
        {
            get => GetStringProperty("organizationalUnitName");
            set => this["organizationalUnitName"] = value;
        }
        
        /// <inheritdoc/>
        public string StateOrProvinceName 
        {
            get => GetStringProperty("stateOrProvinceName");
            set => this["stateOrProvinceName"] = value;
        }
        
    }
}
