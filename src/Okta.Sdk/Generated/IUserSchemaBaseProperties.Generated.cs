// <copyright file="IUserSchemaBaseProperties.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a UserSchemaBaseProperties resource in the Okta API.</summary>
    public partial interface IUserSchemaBaseProperties : IResource
    {
        IUserSchemaAttribute Login { get; set; }

        IUserSchemaAttribute FirstName { get; set; }

        IUserSchemaAttribute LastName { get; set; }

        IUserSchemaAttribute MiddleName { get; set; }

        IUserSchemaAttribute HonorificPrefix { get; set; }

        IUserSchemaAttribute HonorificSuffix { get; set; }

        IUserSchemaAttribute Email { get; set; }

        IUserSchemaAttribute Title { get; set; }

        IUserSchemaAttribute DisplayName { get; set; }

        IUserSchemaAttribute NickName { get; set; }

        IUserSchemaAttribute ProfileUrl { get; set; }

        IUserSchemaAttribute SecondEmail { get; set; }

        IUserSchemaAttribute MobilePhone { get; set; }

        IUserSchemaAttribute PrimaryPhone { get; set; }

        IUserSchemaAttribute StreetAddress { get; set; }

        IUserSchemaAttribute City { get; set; }

        IUserSchemaAttribute State { get; set; }

        IUserSchemaAttribute ZipCode { get; set; }

        IUserSchemaAttribute CountryCode { get; set; }

        IUserSchemaAttribute PostalAddress { get; set; }

        IUserSchemaAttribute PreferredLanguage { get; set; }

        IUserSchemaAttribute Locale { get; set; }

        IUserSchemaAttribute Timezone { get; set; }

        IUserSchemaAttribute UserType { get; set; }

        IUserSchemaAttribute EmployeeNumber { get; set; }

        IUserSchemaAttribute CostCenter { get; set; }

        IUserSchemaAttribute Organization { get; set; }

        IUserSchemaAttribute Division { get; set; }

        IUserSchemaAttribute Department { get; set; }

        IUserSchemaAttribute ManagerId { get; set; }

        IUserSchemaAttribute Manager { get; set; }

    }
}
