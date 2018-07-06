// <copyright file="CreateSwaApplicationOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    public sealed class CreateSwaApplicationOptions
    {
        public string Label { get; set; }

        public string ButtonField { get; set; }

        public string PasswordField { get; set; }

        public string UsernameField { get; set; }

        public string Url { get; set; }

        public string LoginUrlRegex { get; set; }

        public bool Activate { get; set; } = true;
    }
}