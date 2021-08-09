// <copyright file="UserSchemaBaseProperties.Generated.cs" company="Okta, Inc">
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
    public sealed partial class UserSchemaBaseProperties : Resource, IUserSchemaBaseProperties
    {
        /// <inheritdoc/>
        public IUserSchemaAttribute Login 
        {
            get => GetResourceProperty<UserSchemaAttribute>("login");
            set => this["login"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute FirstName 
        {
            get => GetResourceProperty<UserSchemaAttribute>("firstName");
            set => this["firstName"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute LastName 
        {
            get => GetResourceProperty<UserSchemaAttribute>("lastName");
            set => this["lastName"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute MiddleName 
        {
            get => GetResourceProperty<UserSchemaAttribute>("middleName");
            set => this["middleName"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute HonorificPrefix 
        {
            get => GetResourceProperty<UserSchemaAttribute>("honorificPrefix");
            set => this["honorificPrefix"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute HonorificSuffix 
        {
            get => GetResourceProperty<UserSchemaAttribute>("honorificSuffix");
            set => this["honorificSuffix"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute Email 
        {
            get => GetResourceProperty<UserSchemaAttribute>("email");
            set => this["email"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute Title 
        {
            get => GetResourceProperty<UserSchemaAttribute>("title");
            set => this["title"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute DisplayName 
        {
            get => GetResourceProperty<UserSchemaAttribute>("displayName");
            set => this["displayName"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute NickName 
        {
            get => GetResourceProperty<UserSchemaAttribute>("nickName");
            set => this["nickName"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute ProfileUrl 
        {
            get => GetResourceProperty<UserSchemaAttribute>("profileUrl");
            set => this["profileUrl"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute SecondEmail 
        {
            get => GetResourceProperty<UserSchemaAttribute>("secondEmail");
            set => this["secondEmail"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute MobilePhone 
        {
            get => GetResourceProperty<UserSchemaAttribute>("mobilePhone");
            set => this["mobilePhone"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute PrimaryPhone 
        {
            get => GetResourceProperty<UserSchemaAttribute>("primaryPhone");
            set => this["primaryPhone"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute StreetAddress 
        {
            get => GetResourceProperty<UserSchemaAttribute>("streetAddress");
            set => this["streetAddress"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute City 
        {
            get => GetResourceProperty<UserSchemaAttribute>("city");
            set => this["city"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute State 
        {
            get => GetResourceProperty<UserSchemaAttribute>("state");
            set => this["state"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute ZipCode 
        {
            get => GetResourceProperty<UserSchemaAttribute>("zipCode");
            set => this["zipCode"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute CountryCode 
        {
            get => GetResourceProperty<UserSchemaAttribute>("countryCode");
            set => this["countryCode"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute PostalAddress 
        {
            get => GetResourceProperty<UserSchemaAttribute>("postalAddress");
            set => this["postalAddress"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute PreferredLanguage 
        {
            get => GetResourceProperty<UserSchemaAttribute>("preferredLanguage");
            set => this["preferredLanguage"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute Locale 
        {
            get => GetResourceProperty<UserSchemaAttribute>("locale");
            set => this["locale"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute Timezone 
        {
            get => GetResourceProperty<UserSchemaAttribute>("timezone");
            set => this["timezone"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute UserType 
        {
            get => GetResourceProperty<UserSchemaAttribute>("userType");
            set => this["userType"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute EmployeeNumber 
        {
            get => GetResourceProperty<UserSchemaAttribute>("employeeNumber");
            set => this["employeeNumber"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute CostCenter 
        {
            get => GetResourceProperty<UserSchemaAttribute>("costCenter");
            set => this["costCenter"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute Organization 
        {
            get => GetResourceProperty<UserSchemaAttribute>("organization");
            set => this["organization"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute Division 
        {
            get => GetResourceProperty<UserSchemaAttribute>("division");
            set => this["division"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute Department 
        {
            get => GetResourceProperty<UserSchemaAttribute>("department");
            set => this["department"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute ManagerId 
        {
            get => GetResourceProperty<UserSchemaAttribute>("managerId");
            set => this["managerId"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttribute Manager 
        {
            get => GetResourceProperty<UserSchemaAttribute>("manager");
            set => this["manager"] = value;
        }
        
    }
}
