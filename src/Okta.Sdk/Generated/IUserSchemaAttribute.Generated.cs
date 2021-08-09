// <copyright file="IUserSchemaAttribute.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a UserSchemaAttribute resource in the Okta API.</summary>
    public partial interface IUserSchemaAttribute : IResource
    {
        string Title { get; set; }

        UserSchemaAttributeType Type { get; set; }

        bool? Required { get; set; }

        string Mutability { get; set; }

        UserSchemaAttributeScope Scope { get; set; }

        IList<string> Enum { get; set; }

        IList<IUserSchemaAttributeEnum> OneOf { get; set; }

        int? MinLength { get; set; }

        int? MaxLength { get; set; }

        string Description { get; set; }

        IList<IUserSchemaAttributePermission> Permissions { get; set; }

        IUserSchemaAttributeMaster Master { get; set; }

        UserSchemaAttributeUnion Union { get; set; }

        IUserSchemaAttributeItems Items { get; set; }

        string Pattern { get; set; }

        string Unique { get; set; }

        string ExternalName { get; set; }

        string ExternalNamespace { get; set; }

    }
}
