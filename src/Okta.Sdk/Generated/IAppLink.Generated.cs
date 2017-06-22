// <copyright file="IAppLink.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// Do not modify this file directly. This file was automatically generated with:
// spec.json - 0.3.0

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public partial interface IAppLink
    {
        string AppAssignmentId { get; set; }

        string AppInstanceId { get; set; }

        string AppName { get; set; }

        bool? CredentialsSetup { get; set; }

        bool? Hidden { get; set; }

        string Id { get; set; }

        string Label { get; set; }

        string LinkUrl { get; set; }

        string LogoUrl { get; set; }

        int? SortOrder { get; set; }

    }
}
