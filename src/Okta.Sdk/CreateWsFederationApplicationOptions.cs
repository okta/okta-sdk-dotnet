// <copyright file="CreateWsFederationApplicationOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    public sealed class CreateWsFederationApplicationOptions
    {
        public string Label { get; set; }

        public bool Activate { get; set; } = true;

        public string AudienceRestriction { get; set; }

        public string GroupName { get; set; }

        public string GroupValueFormat { get; set; }

        public string Realm { get; set; }

        public string WReplyUrl { get; set; }

        public string AttributeStatements { get; set; }

        public string NameIdFormat { get; set; }

        public string AuthenticationContextClassName { get; set; }

        public string SiteUrl { get; set; }

        public bool WReplyOverride { get; set; }

        public string GroupFilter { get; set; }

        public string UsernameAttribute { get; set; }

    }
}
