// <copyright file="AssignUserToApplicationOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    public sealed class AssignUserToApplicationOptions
    {
        public string UserId { get; set; }

        public string Scope { get; set; } = "USER";

        public string Password { get; set; }

        public string UserName { get; set; }

        public string ApplicationId { get; set; }

        public AppUserProfile Profile { get; set; }
    }
}
