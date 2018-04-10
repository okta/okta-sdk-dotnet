# Okta .NET SDK

This repository contains the Okta Management SDK for .NET (C# and Visual Basic). This SDK can be used in your server code to create and update users, manage groups and roles, and more.

The SDK is compatible with:
* [.NET Standard](https://docs.microsoft.com/en-us/dotnet/standard/library) 1.4
* .NET Framework 4.6.1
* Mono

## Table of Contents

<!-- vscode-markdown-toc -->
* 1. [:warning: :construction: Alpha Preview :construction: :warning:](#warning::construction:AlphaPreview:construction::warning:)
* 2. [Installation](#Installation)
	* 2.1. [Using Nuget Package Manager](#UsingNugetPackageManager)
	* 2.2. [Using The Package Manager Console](#UsingThePackageManagerConsole)
* 3. [Getting Started](#GettingStarted)
* 4. [Client Configuration](#ClientConfiguration)
* 5. [OktaClient User Operations](#OktaClientUserOperations)
	* 5.1. [Creating a user](#Creatingauser)
	* 5.2. [Activating a User](#ActivatingaUser)
	* 5.3. [Getting a User](#GettingaUser)
	* 5.4. [Updating a User](#UpdatingaUser)
	* 5.5. [Removing a User](#RemovingaUser)
* 6. [OktaClient Group Operations](#OktaClientGroupOperations)
	* 6.1. [Creating a Group](#CreatingaGroup)
	* 6.2. [Adding a User to a Group](#AddingaUsertoaGroup)
	* 6.3. [Retrieving a User's Groups](#RetrievingaUsersGroups)
* 7. [Getting help](#Gettinghelp)


##  1. <a name='warning::construction:AlphaPreview:construction::warning:'></a>:warning: :construction: Alpha Preview :construction: :warning:

The 1.x version of this library is under active development.  Some of the API is not yet expressed in this library.  To install this library through NuGet, you will need to enable the "Include Prereleases" option when you search for the `Okta.Sdk` package.

The [`legacy` branch](https://github.com/okta/okta-sdk-dotnet/tree/legacy) contains the previous version of the SDK. It is published on NuGet as [Okta.Core.Client 0.3.3](https://www.nuget.org/packages/Okta.Core.Client/0.3.3). This older version has GA support, but only bug fixes will be applied.

Need help? Contact [developers@okta.com](mailto:developers@okta.com) or use the [Okta Developer Forum].

##  2. <a name='Installation'></a>Installation
###  2.1. <a name='UsingNugetPackageManager'></a>Using Nuget Package Manager
 1. Right-click on your project in the Solution Explorer and choose **Manage Nuget Packages...**
 2. Search for Okta. Install the `Okta.Sdk` package.

###  2.2. <a name='UsingThePackageManagerConsole'></a>Using The Package Manager Console
Simply run `install-package Okta.Sdk`. Done!

##  3. <a name='GettingStarted'></a>Getting Started
To use the SDK, you will need an `OktaClient`. The `OktaClient` needs an OrgUrl and an API Token. You can see how to create them [here](https://developer.okta.com/docs/api/getting_started/getting_a_token.html).

##  4. <a name='ClientConfiguration'></a>Client Configuration

You can configure the `OktaClient` in one of three ways:

With a `okta.yaml` file either:

* in the root of the project
* in a .okta folder in the current user's home folder (`~/.okta/okta.yml` on \*nix machines, `%userprofile%\.okta\okta.yml` on Windows)

``` yaml
okta:
  client:
    orgUrl: "https://dev-<your id>.oktapreview.com/"
    token: "<Your API Token>"
```

or with the environment variables:

```
OKTA_CLIENT_ORGURL
OKTA_CLIENT_TOKEN
```

If you use one of these first two techniques, you can instantiate an `OktaClient` class:

``` csharp
var client = new OktaClient();
```

or you can pass an `OktaClientConfiguration` class directly into the Okta client class constructor.

``` csharp
var client = new OktaClient(
    new OktaClientConfiguration
    {
        OrgUrl = "https://dev-<your id>.oktapreview.com",
        Token = "<Your API Token>"
    });
```

##  5. <a name='OktaClientUserOperations'></a>OktaClient User Operations

###  5.1. <a name='Creatingauser'></a>Creating a user

``` csharp
var vader = await client.Users.CreateUserAsync(
    // User with password
    new CreateUserWithPasswordOptions
    {
        // User profile object
        Profile = new UserProfile
        {
            FirstName = "Anakin",
            LastName = "Skywalker",
            Email = "darth.father@imperial-senate.gov",
            Login = "darth.father@imperial-senate.gov",
        },
        Password = "D1sturB1ng!",
        Activate = false,
    });
```

This will create an inactive user for the client application.

###  5.2. <a name='ActivatingaUser'></a>Activating a User

``` csharp
// having a user, just call
await vader.ActivateAsync();
```

###  5.3. <a name='GettingaUser'></a>Getting a User
``` csharp
// have some user's ID, or login
var someUserId = "<Some User ID String or Login>";

// get the user with the ID or login
var vader = await client.User.GetUserAsync(someUserId);
```

The string argument for `GetUserAsync` can be the user's ID or the user's login (email).

###  5.4. <a name='UpdatingaUser'></a>Updating a User
``` csharp
// set the nickname in the user's profile
vader.Profile["nickName"] = "Lord Vader";

// then, update the user
var newVader = await vader.UpdateAsync();
```

*Note:* You can't create the attributes via code right now, but you can get/set them. To create them you have to use the Profile Editor in the Developer Console web UI. Once you have created them, you can use the code above.

###  5.5. <a name='RemovingaUser'></a>Removing a User
``` csharp
// first, deactivate the user
await newVader.DeactivateAsync();

// then delete the user
await newVader.DeactivateOrDeleteAsync();
```

##  6. <a name='OktaClientGroupOperations'></a>OktaClient Group Operations

###  6.1. <a name='CreatingaGroup'></a>Creating a Group
``` csharp
await _oktaClient.Groups.CreateGroupAsync
(
    new CreateGroupOptions()
    {
        Name = "Stormtroopers",
        Description = "Some description here..."
    }
);
```

###  6.2. <a name='AddingaUsertoaGroup'></a>Adding a User to a Group
``` csharp
// find the desired user
var user = await _oktaClient.Users.FirstOrDefault(x => x.Profile.Email == "darth.father@imperial-senate.gov");

// find the desired group
var group = await _oktaClient.Groups.FirstOrDefault(x => x.Profile.Name == "Stormtroopers");

// add the user to the group by using their id's
if (group != null && user != null)
{
    await _oktaClient.Groups.AddUserToGroupAsync(group.Id, user.Id);
}
```

###  6.3. <a name='RetrievingaUsersGroups'></a>Retrieving a User's Groups
``` csharp
// find the desired user
var user = await _oktaClient.Users.FirstOrDefault(x => x.Profile.Email == "laura.rodriguez@okta.com");

// get the user's groups
var groups = await user.Groups.ToList();
```

##  7. <a name='Gettinghelp'></a>Getting help

This library is maintained and supported by Okta. If you run into trouble using the SDK, post an [issue](https://github.com/okta/okta-sdk-dotnet/issues) or send us an email at [developers@okta.com](mailto:developers@okta.com).

[Okta Developer Forum]: https://devforum.okta.com/
