// <copyright file="UserProfile.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    public class UserProfile : Resource
    {
        public UserProfile()
            : base(ResourceDictionaryType.ChangeTracking)
        {
        }

        public string LastName
        {
            get => GetStringProperty(nameof(LastName));
            set => SetProperty(nameof(LastName), value);
        }

        public string Email
        {
            get => GetStringProperty(nameof(Email));
            set => SetProperty(nameof(Email), value);
        }

        public string Login
        {
            get => GetStringProperty(nameof(Login));
            set => SetProperty(nameof(Login), value);
        }

        public string FirstName
        {
            get => GetStringProperty(nameof(FirstName));
            set => SetProperty(nameof(FirstName), value);
        }

        public string DisplayName
        {
            get => GetStringProperty(nameof(DisplayName));
            set => SetProperty(nameof(DisplayName), value);
        }
    }
}
