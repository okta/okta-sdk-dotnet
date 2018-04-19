# Okta .NET SDK

This repository contains the Okta Management SDK for .NET (C# and Visual Basic). This SDK can be used in your server code to create and update users, manage groups and roles, and more.

The SDK is compatible with:
* [.NET Standard](https://docs.microsoft.com/en-us/dotnet/standard/library) 1.4
* .NET Framework 4.6.1
* Mono

## :warning: :construction: Alpha Preview :construction: :warning:

The 1.x version of this library is under active development.  Some of the API is not yet expressed in this library.  To install this library through NuGet, you will need to enable the "Include Prereleases" option when you search for the `Okta.Sdk` package.

The [`legacy` branch](https://github.com/okta/okta-sdk-dotnet/tree/legacy) contains the previous version of the SDK. It is published on NuGet as [Okta.Core.Client 0.3.3](https://www.nuget.org/packages/Okta.Core.Client/0.3.3). This older version has GA support, but only bug fixes will be applied.

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

### Creating a User

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

### Activating a User

``` csharp
// having a user, just call
await vader.ActivateAsync();
```

### Getting a User
``` csharp
// have some user's ID, or login
var someUserId = "<Some User ID String or Login>";

// get the user with the ID or login
var vader = await client.Users.GetUserAsync(someUserId);
```

The string argument for `GetUserAsync` can be the user's ID or the user's login (email).

### Updating a User
``` csharp
// set the nickname in the user's profile
vader.Profile["nickName"] = "Lord Vader";

// then, update the user
await vader.UpdateAsync();
```

### Get and Set Custom Attributes

You can't create attributes via code right now, but you can get/set them. To create them you have to use the Profile Editor in the Developer Console web UI. Once you have created them, you can use the code below:

```csharp
vader.Profile["homeworld"] = "Tattooine";

await vader.UpdateAsync();
```

### Removing a User
``` csharp
// first, deactivate the user
await newVader.DeactivateAsync();

// then delete the user
await newVader.DeactivateOrDeleteAsync();
```

### Creating a Group
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

### Adding a User to a Group
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

### Retrieving a User's Groups
``` csharp
// find the desired user
var user = await _oktaClient.Users.FirstOrDefault(x => x.Profile.Email == "laura.rodriguez@okta.com");

// get the user's groups
var groups = await user.Groups.ToList();
```

## Using raw HTTP methods

The SDK client object can be used to make calls to any Okta API (not just the endpoints officially supported by the SDK) via the `GetAsync`, `PostAsync`, `PutAsync` and `DeleteAsync` methods. You can take a look at [GitHub](https://github.com/okta/okta-sdk-dotnet/blob/master/src/Okta.Sdk/OktaClient.cs) to see the different overloadings.

### Activating a User via `PostAsync`

```csharp
var userId = "<Some User ID String or Login>";

await _oktaClient.PostAsync(
    new Okta.Sdk.Internal.HttpRequest
    {
        Uri = "/api/v1/users/{userId}/lifecycle/activate",
            
        PathParameters = new Dictionary<string, object>()
        {
            ["userId"] = userId,
        },
        QueryParameters = new Dictionary<string, object>()
        {
            ["sendEmail"] = true,
        }
    });
```

### Deleting a User via `DeleteAsync`

```csharp
var userId = "<Some User ID String or Login>";

await _oktaClient.DeleteAsync(new Okta.Sdk.Internal.HttpRequest
{
    Uri = "/api/v1/users/{userId}",
    
    PathParameters = new Dictionary<string, object>()
    {
        ["userId"] = userId,
    },
}
```

## Getting help

This library is maintained and supported by Okta. If you run into trouble using the SDK, post an [issue](https://github.com/okta/okta-sdk-dotnet/issues) or send us an email at [developers@okta.com](mailto:developers@okta.com).

[Okta Developer Forum]: https://devforum.okta.com/
