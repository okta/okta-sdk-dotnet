// <copyright file="SmsTemplateType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of SmsTemplateType values in the Okta API.
    /// </summary>
    public sealed class SmsTemplateType : StringEnum
    {
        /// <summary>The SMS_VERIFY_CODE SmsTemplateType.</summary>
        public static SmsTemplateType SmsVerifyCode = new SmsTemplateType("SMS_VERIFY_CODE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="SmsTemplateType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator SmsTemplateType(string value) => new SmsTemplateType(value);

        /// <summary>
        /// Creates a new <see cref="SmsTemplateType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public SmsTemplateType(string value)
            : base(value)
        {
        }

    }
}
