// <copyright file="CreateSamlApplicationOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    /// <summary>
    /// Helper class for SAML application settings
    /// </summary>
    public sealed class CreateSamlApplicationOptions
    {
        /// <summary>
        /// Gets or sets a label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets an auto submit toolbar flag value
        /// </summary>
        public bool AutoSubmitToolbar { get; set; } = false;

        /// <summary>
        /// Gets or sets a hide IOs flag value
        /// </summary>
        public bool HideIOs { get; set; } = false;

        /// <summary>
        /// Gets or sets a hide web flag value
        /// </summary>
        public bool HideWeb { get; set; } = false;

        /// <summary>
        /// Gets or sets a features list
        /// </summary>
        public IList<string> Features { get; set; }

        /// <summary>
        /// Gets or sets the default relay state
        /// </summary>
        public string DefaultRelayState { get; set; }

        /// <summary>
        /// Gets or sets an SSO url
        /// </summary>
        public string SsoAcsUrl { get; set; }

        /// <summary>
        /// Gets or sets an IDP issuer
        /// </summary>
        public string IdpIssuer { get; set; }

        /// <summary>
        /// Gets or sets an audience
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Gets or sets a recipient
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// Gets or sets a destination
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Gets or sets a subject name id template
        /// </summary>
        public string SubjectNameIdTemplate { get; set; }

        /// <summary>
        /// Gets or sets a subject name id format
        /// </summary>
        public string SubjectNameIdFormat { get; set; }

        /// <summary>
        /// Gets or sets a response singned flag value
        /// </summary>
        public bool ResponseSigned { get; set; }

        /// <summary>
        /// Gets or sets an assetion signed flag value
        /// </summary>
        public bool AssertionSigned { get; set; }

        /// <summary>
        /// Gets or sets a signature algorithm
        /// </summary>
        public string SignatureAlgorithm { get; set; }

        /// <summary>
        /// Gets or sets a digest algorithm
        /// </summary>
        public string DigestAlgorithm { get; set; }

        /// <summary>
        /// Gets or sets a honor force authentication flag value
        /// </summary>
        public bool HonorForceAuthentication { get; set; }

        /// <summary>
        /// Gets or sets an authentication context class name
        /// </summary>
        public string AuthenticationContextClassName { get; set; }

        /// <summary>
        /// Gets or set a SP issuer
        /// </summary>
        public string SpIssuer { get; set; }

        /// <summary>
        /// Gets or sets a request compressed flag value
        /// </summary>
        public bool RequestCompressed { get; set; }

        /// <summary>
        /// Gets or sets an attribute statement list
        /// </summary>
        public IList<ISamlAttributeStatement> AttributeStatements { get; set; }

        /// <summary>
        /// Gets or sets an activate flag value
        /// </summary>
        public bool Activate { get; set; } = true;
    }
}
