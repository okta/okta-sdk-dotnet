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
        string AppAssignmentId { get; }

        string AppInstanceId { get; }

        string AppName { get; }

        bool? CredentialsSetup { get; }

        bool? Hidden { get; }

        string Id { get; }

        string Label { get; }

        string LinkUrl { get; }

        string LogoUrl { get; }

        int? SortOrder { get; }

    }
}
