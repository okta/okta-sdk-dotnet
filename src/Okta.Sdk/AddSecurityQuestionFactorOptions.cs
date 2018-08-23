// <copyright file="AddSecurityQuestionFactorOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    /// <summary>
    /// Helper class for security question factor settings
    /// </summary>
    public sealed class AddSecurityQuestionFactorOptions
    {
        /// <summary>
        /// Gets or sets the question
        /// </summary>
        public string Question { get; set; }

        /// <summary>
        /// Gets or sets the answer
        /// </summary>
        public string Answer { get; set; }
    }
}
