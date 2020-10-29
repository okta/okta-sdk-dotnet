// <copyright file="PasswordCredentialHash.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public partial class PasswordCredentialHash : Resource, IPasswordCredentialHash
    {
        [Obsolete("This method will deprecated in the next major version. Use WorkFactor instead.")]
        /// <summary>
        /// Gets and sets the <c>workFactor</c> property. 
        /// </summary>
        public int? WorkerFactor
        {
            get => GetIntegerProperty("workFactor");
            set => this["workFactor"] = value;
        }
    }
}
