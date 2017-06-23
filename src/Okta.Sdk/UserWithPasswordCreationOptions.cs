// <copyright file="UserWithPasswordCreationOptions.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    public sealed class UserWithPasswordCreationOptions
    {
        public UserProfile Profile { get; set; }

        public bool Activate { get; set; } = true;

        public string Password { get; set; }
    }
}
