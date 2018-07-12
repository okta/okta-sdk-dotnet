// <copyright file="ISamlApplicationSettingsSignOn.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>Represents a SamlApplicationSettingsSignOn resource in the Okta API.</summary>
    public partial interface ISamlApplicationSettingsSignOn : IResource
    {
        bool? AssertionSigned { get; set; }

        IList<ISamlAttributeStatement> AttributeStatements { get; set; }

        string Audience { get; set; }

        string AudienceOverride { get; set; }

        string AuthenticationContextClassName { get; set; }

        string DefaultRelayState { get; set; }

        string Destination { get; set; }

        string DestinationOverride { get; set; }

        string DigestAlgorithm { get; set; }

        bool? HonorForceAuthentication { get; set; }

        string IdpIssuer { get; set; }

        string Recipient { get; set; }

        string RecipientOverride { get; set; }

        bool? RequestCompressed { get; set; }

        bool? ResponseSigned { get; set; }

        string SignatureAlgorithm { get; set; }

        string SpIssuer { get; set; }

        string SsoAcsUrl { get; set; }

        string SsoAcsUrlOverride { get; set; }

        string SubjectNameIdFormat { get; set; }

        string SubjectNameIdTemplate { get; set; }

    }
}
