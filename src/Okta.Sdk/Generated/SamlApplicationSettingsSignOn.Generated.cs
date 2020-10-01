// <copyright file="SamlApplicationSettingsSignOn.Generated.cs" company="Okta, Inc">
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
    public sealed partial class SamlApplicationSettingsSignOn : Resource, ISamlApplicationSettingsSignOn
    {
        /// <inheritdoc/>
        public bool? AssertionSigned 
        {
            get => GetBooleanProperty("assertionSigned");
            set => this["assertionSigned"] = value;
        }
        
        /// <inheritdoc/>
        public IList<ISamlAttributeStatement> AttributeStatements 
        {
            get => GetArrayProperty<ISamlAttributeStatement>("attributeStatements");
            set => this["attributeStatements"] = value;
        }
        
        /// <inheritdoc/>
        public string Audience 
        {
            get => GetStringProperty("audience");
            set => this["audience"] = value;
        }
        
        /// <inheritdoc/>
        public string AudienceOverride 
        {
            get => GetStringProperty("audienceOverride");
            set => this["audienceOverride"] = value;
        }
        
        /// <inheritdoc/>
        public string AuthenticationContextClassName 
        {
            get => GetStringProperty("authnContextClassRef");
            set => this["authnContextClassRef"] = value;
        }
        
        /// <inheritdoc/>
        public string DefaultRelayState 
        {
            get => GetStringProperty("defaultRelayState");
            set => this["defaultRelayState"] = value;
        }
        
        /// <inheritdoc/>
        public string Destination 
        {
            get => GetStringProperty("destination");
            set => this["destination"] = value;
        }
        
        /// <inheritdoc/>
        public string DestinationOverride 
        {
            get => GetStringProperty("destinationOverride");
            set => this["destinationOverride"] = value;
        }
        
        /// <inheritdoc/>
        public string DigestAlgorithm 
        {
            get => GetStringProperty("digestAlgorithm");
            set => this["digestAlgorithm"] = value;
        }
        
        /// <inheritdoc/>
        public bool? HonorForceAuthentication 
        {
            get => GetBooleanProperty("honorForceAuthn");
            set => this["honorForceAuthn"] = value;
        }
        
        /// <inheritdoc/>
        public string IdpIssuer 
        {
            get => GetStringProperty("idpIssuer");
            set => this["idpIssuer"] = value;
        }
        
        /// <inheritdoc/>
        public string Recipient 
        {
            get => GetStringProperty("recipient");
            set => this["recipient"] = value;
        }
        
        /// <inheritdoc/>
        public string RecipientOverride 
        {
            get => GetStringProperty("recipientOverride");
            set => this["recipientOverride"] = value;
        }
        
        /// <inheritdoc/>
        public bool? RequestCompressed 
        {
            get => GetBooleanProperty("requestCompressed");
            set => this["requestCompressed"] = value;
        }
        
        /// <inheritdoc/>
        public bool? ResponseSigned 
        {
            get => GetBooleanProperty("responseSigned");
            set => this["responseSigned"] = value;
        }
        
        /// <inheritdoc/>
        public string SignatureAlgorithm 
        {
            get => GetStringProperty("signatureAlgorithm");
            set => this["signatureAlgorithm"] = value;
        }
        
        /// <inheritdoc/>
        public string SpIssuer 
        {
            get => GetStringProperty("spIssuer");
            set => this["spIssuer"] = value;
        }
        
        /// <inheritdoc/>
        public string SsoAcsUrl 
        {
            get => GetStringProperty("ssoAcsUrl");
            set => this["ssoAcsUrl"] = value;
        }
        
        /// <inheritdoc/>
        public string SsoAcsUrlOverride 
        {
            get => GetStringProperty("ssoAcsUrlOverride");
            set => this["ssoAcsUrlOverride"] = value;
        }
        
        /// <inheritdoc/>
        public string SubjectNameIdFormat 
        {
            get => GetStringProperty("subjectNameIdFormat");
            set => this["subjectNameIdFormat"] = value;
        }
        
        /// <inheritdoc/>
        public string SubjectNameIdTemplate 
        {
            get => GetStringProperty("subjectNameIdTemplate");
            set => this["subjectNameIdTemplate"] = value;
        }
        
    }
}
