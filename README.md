# Okta .NET SDK

This repository contains the Okta Management SDK for .NET (C# and Visual Basic). This SDK can be used in your server code to create and update users, manage groups and roles, and more.

The SDK is compatible with:
* [.NET Standard](https://docs.microsoft.com/en-us/dotnet/standard/library) 1.4
* .NET Framework 4.6.1
* Mono

## :warning: :construction: Alpha Preview :construction: :warning:

This library is under development and is currently a 1.0.0-alpha series.  Some of the API is not yet expressed in this library.  To install this library through NuGet, you will need to enable the "Include Prereleases" option when you search for this package.

The latest SDK is where all the new and exciting development will happen. Our [`legacy` branch](https://github.com/okta/okta-sdk-dotnet/tree/legacy) contains the previous version of the SDK. It is published on NuGet as [Okta.Core.Client 0.3.3](https://www.nuget.org/packages/Okta.Core.Client/0.3.3) and lower. This older version has GA support, but only bug fixes will be applied.

Need help? Contact [developers@okta.com](mailto:developers@okta.com) or use the [Okta Developer Forum].

## Installation
### Using Nuget Package Manager
 1. Right-click on your project in the Solution Explorer and choose **Manage Nuget Packages...**
 2. Search for Okta. Install the `Okta.Sdk` package.

### Using The Package Manager Console
Simply run `install-package Okta.Sdk`. Done!

## Getting Started
To use the SDK, you will need an `OktaClient`. The `OktaClient` needs an OrgUrl and an API Token. You can see how to create them [here](https://developer.okta.com/docs/api/getting_started/getting_a_token.html).

## Client Configuration

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

## OktaClient User Operations

### Creating a user

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

### Activating A User

``` csharp
// having a user, just call
await vader.ActivateAsync();
```

### Getting A User
``` csharp
// have some user's ID, or login
var someUserId = "<Some User ID String or Login>";

// get the user with the ID or login
var vader = await client.User.GetUserAsync(someUserId);
```

The string argument for `GetUserAsync` can be the user's ID or the user's login (email).

### Updating A User
``` csharp
// set the nickname in the user's profile
vader.Profile["nickName"] = "Lord Vader";

// then, update the user
var newVader = await vader.UpdateAsync();
```

### Removing A User
``` csharp
// first, deactivate the user
await newVader.DeactivateAsync();

// then delete the user
await newVader.DeactivateOrDeleteAsync();
```

## Getting help

This library is maintained and supported by Okta. If you run into trouble using the SDK, post an [issue](https://github.com/okta/okta-sdk-dotnet/issues) or send us an email at [developers@okta.com](mailto:developers@okta.com).

[Okta Developer Forum]: https://devforum.okta.com/
