// <copyright file="UserProfile.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public sealed partial class UserProfile : Resource, IUserProfile
    {
        /// <inheritdoc/>
        public string City 
        {
            get => GetStringProperty("city");
            set => this["city"] = value;
        }
        
        /// <inheritdoc/>
        public string CostCenter 
        {
            get => GetStringProperty("costCenter");
            set => this["costCenter"] = value;
        }
        
        /// <inheritdoc/>
        public string CountryCode 
        {
            get => GetStringProperty("countryCode");
            set => this["countryCode"] = value;
        }
        
        /// <inheritdoc/>
        public string Department 
        {
            get => GetStringProperty("department");
            set => this["department"] = value;
        }
        
        /// <inheritdoc/>
        public string DisplayName 
        {
            get => GetStringProperty("displayName");
            set => this["displayName"] = value;
        }
        
        /// <inheritdoc/>
        public string Division 
        {
            get => GetStringProperty("division");
            set => this["division"] = value;
        }
        
        /// <inheritdoc/>
        public string Email 
        {
            get => GetStringProperty("email");
            set => this["email"] = value;
        }
        
        /// <inheritdoc/>
        public string EmployeeNumber 
        {
            get => GetStringProperty("employeeNumber");
            set => this["employeeNumber"] = value;
        }
        
        /// <inheritdoc/>
        public string FirstName 
        {
            get => GetStringProperty("firstName");
            set => this["firstName"] = value;
        }
        
        /// <inheritdoc/>
        public string HonorificPrefix 
        {
            get => GetStringProperty("honorificPrefix");
            set => this["honorificPrefix"] = value;
        }
        
        /// <inheritdoc/>
        public string HonorificSuffix 
        {
            get => GetStringProperty("honorificSuffix");
            set => this["honorificSuffix"] = value;
        }
        
        /// <inheritdoc/>
        public string LastName 
        {
            get => GetStringProperty("lastName");
            set => this["lastName"] = value;
        }
        
        /// <inheritdoc/>
        public string Locale 
        {
            get => GetStringProperty("locale");
            set => this["locale"] = value;
        }
        
        /// <inheritdoc/>
        public string Login 
        {
            get => GetStringProperty("login");
            set => this["login"] = value;
        }
        
        /// <inheritdoc/>
        public string Manager 
        {
            get => GetStringProperty("manager");
            set => this["manager"] = value;
        }
        
        /// <inheritdoc/>
        public string ManagerId 
        {
            get => GetStringProperty("managerId");
            set => this["managerId"] = value;
        }
        
        /// <inheritdoc/>
        public string MiddleName 
        {
            get => GetStringProperty("middleName");
            set => this["middleName"] = value;
        }
        
        /// <inheritdoc/>
        public string MobilePhone 
        {
            get => GetStringProperty("mobilePhone");
            set => this["mobilePhone"] = value;
        }
        
        /// <inheritdoc/>
        public string NickName 
        {
            get => GetStringProperty("nickName");
            set => this["nickName"] = value;
        }
        
        /// <inheritdoc/>
        public string Organization 
        {
            get => GetStringProperty("organization");
            set => this["organization"] = value;
        }
        
        /// <inheritdoc/>
        public string PostalAddress 
        {
            get => GetStringProperty("postalAddress");
            set => this["postalAddress"] = value;
        }
        
        /// <inheritdoc/>
        public string PreferredLanguage 
        {
            get => GetStringProperty("preferredLanguage");
            set => this["preferredLanguage"] = value;
        }
        
        /// <inheritdoc/>
        public string PrimaryPhone 
        {
            get => GetStringProperty("primaryPhone");
            set => this["primaryPhone"] = value;
        }
        
        /// <inheritdoc/>
        public string ProfileUrl 
        {
            get => GetStringProperty("profileUrl");
            set => this["profileUrl"] = value;
        }
        
        /// <inheritdoc/>
        public string SecondEmail 
        {
            get => GetStringProperty("secondEmail");
            set => this["secondEmail"] = value;
        }
        
        /// <inheritdoc/>
        public string State 
        {
            get => GetStringProperty("state");
            set => this["state"] = value;
        }
        
        /// <inheritdoc/>
        public string StreetAddress 
        {
            get => GetStringProperty("streetAddress");
            set => this["streetAddress"] = value;
        }
        
        /// <inheritdoc/>
        public string Timezone 
        {
            get => GetStringProperty("timezone");
            set => this["timezone"] = value;
        }
        
        /// <inheritdoc/>
        public string Title 
        {
            get => GetStringProperty("title");
            set => this["title"] = value;
        }
        
        /// <inheritdoc/>
        public string UserType 
        {
            get => GetStringProperty("userType");
            set => this["userType"] = value;
        }
        
        /// <inheritdoc/>
        public string ZipCode 
        {
            get => GetStringProperty("zipCode");
            set => this["zipCode"] = value;
        }
        
    }
}
