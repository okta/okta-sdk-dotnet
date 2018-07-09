// <copyright file="CreateBookmarkApplicationOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    public sealed class CreateBookmarkApplicationOptions
    {
        public string Label { get; set; }

        public bool RequestIntegration { get; set; } = false;

        public string Url { get; set; }

        public bool Activate { get; set; } = true;
    }
}
