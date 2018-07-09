// <copyright file="CreateSwaThreeFieldApplicationOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    public sealed class CreateSwaThreeFieldApplicationOptions
    {
        public string Label { get; set; }

        public string ButtonSelector { get; set; }

        public string PasswordSelector { get; set; }

        public string UserNameSelector { get; set; }

        public string TargetUrl { get; set; }

        public string ExtraFieldSelector { get; set; }

        public string ExtraFieldValue { get; set; }

        public string LoginUrlRegex { get; set; }

        public bool? Activate { get; set; } = true;
    }
}
