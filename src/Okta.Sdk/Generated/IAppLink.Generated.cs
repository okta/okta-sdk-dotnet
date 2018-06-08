// <copyright file="IAppLink.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>Represents a AppLink resource in the Okta API.</summary>
    public partial interface IAppLink : IResource
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
