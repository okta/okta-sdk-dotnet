// <copyright file="AddTokenFactorOptions.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    public sealed class AddTokenFactorOptions
    {
        public string CredentialId { get; set; }
        public string PassCode { get; set; }
        public string NextPassCode { get; set; }
        public string Provider { get; set; }
    }
}
