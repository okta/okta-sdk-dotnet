// <copyright file="AuthorizationMode.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk.Configuration
{
    /// <summary>
    /// Authorization mode enum.
    /// </summary>
    public enum AuthorizationMode
    {
        /// <summary>
        /// Indicates that the SDK will send a SSWS token in the authorozation header when making calls. 
        /// </summary>
        SSWS,

        /// <summary>
        /// Indicates that the SDK will request and send an access token in the authorization header when making calls.
        /// </summary>
        PrivateKey,
    }
}
