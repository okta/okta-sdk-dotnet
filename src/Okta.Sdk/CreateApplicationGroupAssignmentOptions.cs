// <copyright file="CreateApplicationGroupAssignmentOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    public sealed class CreateApplicationGroupAssignmentOptions
    {
        public int Priority { get; set; }

        public string ApplicationId { get; set; }

        public string GroupId { get; set; }
    }
}
