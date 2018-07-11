// <copyright file="CreateSwaCustomApplicationOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    public sealed class CreateSwaCustomApplicationOptions
    {
        public string Label { get; set; }

        public bool AutoSubmitToolbar { get; set; } = false;

        public bool HideIOs { get; set; } = false;

        public bool HideWeb { get; set; } = false;

        public string RedirectUrl { get; set; }

        public string LoginUrl { get; set; }

        public IList<string> Features { get; set; }

        public bool Activate { get; set; } = true;
    }
}
