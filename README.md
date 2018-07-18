[<img src="https://devforum.okta.com/uploads/oktadev/original/1X/bf54a16b5fda189e4ad2706fb57cbb7a1e5b8deb.png" align="right" width="256px"/>](https://devforum.okta.com/)

[![Support](https://img.shields.io/badge/support-Developer%20Forum-blue.svg)][devforum]
[![API Reference](https://img.shields.io/badge/docs-reference-lightgrey.svg)][dotnetdocs]

# Okta .NET Management SDK

> :warning: Beta alert! This library is in beta. See [release status](#release-status) for more information.

* [Release status](#release-status)
* [Need help?](#need-help)
* [Getting started](#getting-started)
* [Usage guide](#usage-guide)
* [Configuration reference](#configuration-reference)
* [Building the SDK](#building-the-sdk)
* [Contributing](#contributing)

This repository contains the Okta management SDK for .NET. This SDK can be used in your server-side code to interact with the Okta management API and:
 
* Create and update users with the [Users API](https://developer.okta.com/docs/api/resources/users)
* Add security factors to users with the [Factors API](https://developer.okta.com/docs/api/resources/factors)
* Manage groups with the [Groups API](https://developer.okta.com/docs/api/resources/groups)
* Manage applications with the [Apps API](https://developer.okta.com/docs/api/resources/apps)
* Manage logs with the [Logs API](https://developer.okta.com/docs/api/resources/system_log)
* Manage sessions with the [Sessions API](https://developer.okta.com/docs/api/resources/sessions)
* Much more!
 
We also publish these libraries for .NET:
 
* [Okta ASP.NET middleware](https://github.com/okta/okta-aspnet)
 
You can learn more on the [Okta + .NET][lang-landing] page in our documentation.

## Release status

This library uses semantic versioning and follows Okta's [library version policy](https://developer.okta.com/code/library-versions/).

:heavy_check_mark: The current stable major version series is: 0.x

| Version | Status                    |
| ------- | ------------------------- |
| 1.x | :warning: Beta/Under active development |
| 0.x   | :heavy_check_mark: Stable |
 
The latest release can always be found on the [releases page][github-releases].

## Need help?
 
If you run into problems using the SDK, you can
 
* Ask questions on the [Okta Developer Forums][devforum]
* Post [issues][github-issues] here on GitHub (for code errors)


## Getting Started

The SDK is compatible with:
* [.NET Standard](https://docs.microsoft.com/en-us/dotnet/standard/library) 1.4
* .NET Framework 4.6.1
* Mono

### Install using Nuget Package Manager
 1. Right-click on your project in the Solution Explorer and choose **Manage Nuget Packages...**
 2. Search for Okta. Install the `Okta.Sdk` package.

### Install using The Package Manager Console
Simply run `install-package Okta.Sdk`. Done!

To install 1.x version through NuGet, you will need to enable the "Include Prereleases" option when you search for the `Okta.Sdk` package.

The [`legacy` branch](https://github.com/okta/okta-sdk-dotnet/tree/legacy) is published on NuGet as [Okta.Core.Client 0.3.3](https://www.nuget.org/packages/Okta.Core.Client/0.3.3).

You'll also need:

* An Okta account, called an _organization_ (sign up for a free [developer organization](https://developer.okta.com/signup) if you need one)
* An [API token](https://developer.okta.com/docs/api/getting_started/getting_a_token)
 
Construct a client instance by passing it your Okta domain name and API token:
 
``` csharp
var client = new OktaClient(
    new OktaClientConfiguration
    {
        OrgUrl = "https://dev-<your id>.oktapreview.com",
        Token = "<Your API Token>"
    });
```
 
Hard-coding the Okta domain and API token works for quick tests, but for real projects you should use a more secure way of storing these values (such as environment variables). This library supports a few different configuration sources, covered in the [configuration reference](#configuration-reference) section.
 
## Usage guide

These examples will help you understand how to use this library. You can also browse the full [API reference documentation][dotnetdocs].

Once you initialize a `Client`, you can call methods to make requests to the Okta API.

### Authenticate a User

This library should be used with the Okta management API. For authentication, we recommend using an OAuth 2.0 or OpenID Connect library such as [Okta ASP.NET middleware](https://github.com/okta/okta-aspnet). For [Okta Authentcation API] refers to (https://developer.okta.com/docs/api/resources/authn).

### Create a User

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

### Activate a User

``` csharp
// having a user, just call
await vader.ActivateAsync();
```

### Get a User
``` csharp
// have some user's ID, or login
var someUserId = "<Some User ID String or Login>";

// get the user with the ID or login
var vader = await client.Users.GetUserAsync(someUserId);
```

The string argument for `GetUserAsync` can be the user's ID or the user's login (email).

### Update a User
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

### Remove a User
``` csharp
// first, deactivate the user
await newVader.DeactivateAsync();

// then delete the user
await newVader.DeactivateOrDeleteAsync();
```

### Create a Group
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

### Add a User to a Group
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

### Retrieve a User's Groups
``` csharp
// find the desired user
var user = await _oktaClient.Users.FirstOrDefault(x => x.Profile.Email == "laura.rodriguez@okta.com");

// get the user's groups
var groups = await user.Groups.ToList();
```

## Call other API endpoints

The SDK client object can be used to make calls to any Okta API (not just the endpoints officially supported by the SDK) via the `GetAsync`, `PostAsync`, `PutAsync` and `DeleteAsync` methods. You can take a look at [GitHub](https://github.com/okta/okta-sdk-dotnet/blob/master/src/Okta.Sdk/OktaClient.cs) to see the different overloadings.

### Activate a User via `PostAsync`

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

### Delete a User via `DeleteAsync`

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
## Configuration reference
  
This library looks for configuration in the following sources:
 
1. An `okta.yaml` file in a `.okta` folder in the current user's home directory (`~/.okta/okta.yaml` or `%userprofile\.okta\okta.yaml`)
2. An `okta.yaml` file in a `.okta` folder in the application or project's root directory
3. Environment variables
4. Configuration explicitly passed to the constructor (see the example in [Getting started](#getting-started))
 
Higher numbers win. In other words, configuration passed via the constructor will override configuration found in environment variables, which will override configuration in `okta.yaml` (if any), and so on.
 
### YAML configuration
 
The full YAML configuration looks like:
 
```yaml
okta:
  client:
    connectionTimeout: 30 # seconds
    orgUrl: "https://{yourOktaDomain}"
    proxy:
      port: null
      host: null
      username: null
      password: null
    token: {apiToken}
```
 
### Environment variables
 
Each one of the configuration values above can be turned into an environment variable name with the `_` (underscore) character:
 
* `OKTA_CLIENT_CONNECTIONTIMEOUT`
* `OKTA_CLIENT_TOKEN`
* and so on

## Building the SDK
 
In most cases, you won't need to build the SDK from source. If you want to build it yourself just clone the repo and compile using Visual Studio.
 
## Contributing
 
We're happy to accept contributions and PRs! Please see the [contribution guide](CONTRIBUTING.md) to understand how to structure a contribution.

[devforum]: https://devforum.okta.com/
[dotnetdocs]: https://developer.okta.com/okta-sdk-dotnet/latest/
[lang-landing]: https://developer.okta.com/code/dotnet/
[github-issues]: /issues
[github-releases]: /releases