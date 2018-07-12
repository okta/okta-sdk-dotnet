// <copyright file="CreateSamlApplicationOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    public sealed class CreateSamlApplicationOptions
    {
        public string Label { get; set; }

        public bool AutoSubmitToolbar { get; set; } = false;

        public bool HideIOs { get; set; } = false;

        public bool HideWeb { get; set; } = false;

        public IList<string> Features { get; set; }

        public string DefaultRelayState { get; set; }

        public string SsoAcsUrl { get; set; }

        public string IdpIssuer { get; set; }

        public string Audience { get; set; }

        public string Recipient { get; set; }

        public string Destination { get; set; }

        public string SubjectNameIdTemplate { get; set; }

        public string SubjectNameIdFormat { get; set; }

        public bool ResponseSigned { get; set; }

        public bool AssertionSigned { get; set; }

        public string SignatureAlgorithm { get; set; }

        public string DigestAlgorithm { get; set; }

        public bool HonorForceAuthentication { get; set; }

        public string AuthenticationContextClassName { get; set; }

        public string SpIssuer { get; set; }

        public bool RequestCompressed { get; set; }

        public IList<ISamlAttributeStatement> AttributeStatements { get; set; }

        public bool Activate { get; set; } = true;
    }
}
