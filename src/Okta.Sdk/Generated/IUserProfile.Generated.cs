// <copyright file="IUserProfile.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a UserProfile resource in the Okta API.</summary>
    public partial interface IUserProfile : IResource
    {
        string City { get; set; }

        string CostCenter { get; set; }

        string CountryCode { get; set; }

        string Department { get; set; }

        string DisplayName { get; set; }

        string Division { get; set; }

        string Email { get; set; }

        string EmployeeNumber { get; set; }

        string FirstName { get; set; }

        string HonorificPrefix { get; set; }

        string HonorificSuffix { get; set; }

        string LastName { get; set; }

        string Locale { get; set; }

        string Login { get; set; }

        string Manager { get; set; }

        string ManagerId { get; set; }

        string MiddleName { get; set; }

        string MobilePhone { get; set; }

        string NickName { get; set; }

        string Organization { get; set; }

        string PostalAddress { get; set; }

        string PreferredLanguage { get; set; }

        string PrimaryPhone { get; set; }

        string ProfileUrl { get; set; }

        string SecondEmail { get; set; }

        string State { get; set; }

        string StreetAddress { get; set; }

        string Timezone { get; set; }

        string Title { get; set; }

        string UserType { get; set; }

        string ZipCode { get; set; }

    }
}
