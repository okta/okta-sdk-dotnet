// <copyright file="CreateSwaNoPluginApplicationOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    public sealed class CreateSwaNoPluginApplicationOptions
    {
        public string Label { get; set; }

        public string Url { get; set; }

        public string PasswordField { get; set; }

        public string UsernameField { get; set; }

        public string OptionalField1 { get; set; }

        public string OptionalField1Value { get; set; }

        public string OptionalField2 { get; set; }

        public string OptionalField2Value { get; set; }

        public string OptionalField3 { get; set; }

        public string OptionalField3Value { get; set; }

        public bool Activate { get; set; } = true;

    }
}
