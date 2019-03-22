[<img src="https://devforum.okta.com/uploads/oktadev/original/1X/bf54a16b5fda189e4ad2706fb57cbb7a1e5b8deb.png" align="right" width="256px"/>](https://devforum.okta.com/)

[![Support](https://img.shields.io/badge/support-Developer%20Forum-blue.svg)][devforum]
[![API Reference](https://img.shields.io/badge/docs-reference-lightgrey.svg)][dotnetdocs]

# Okta .NET management SDK

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
 
We also publish these other libraries for .NET:
 
* [Okta ASP.NET middleware](https://github.com/okta/okta-aspnet)
* [Okta .NET Authentication SDK](https://github.com/okta/okta-auth-dotnet)
 
You can learn more on the [Okta + .NET][lang-landing] page in our documentation.

## Release status

This library uses semantic versioning and follows Okta's [library version policy](https://developer.okta.com/code/library-versions/).

:heavy_check_mark: The current stable major version series is: 1.x

| Version | Status                    |
| ------- | ------------------------- |
| 0.3.3   | :warning: Retiring on 2019-12-11 ([migration guide](MIGRATING.md))  |
| 1.x | :heavy_check_mark: Stable |
 
The latest release can always be found on the [releases page][github-releases].

## Need help?
 
If you run into problems using the SDK, you can
 
* Ask questions on the [Okta Developer Forums][devforum]
* Post [issues][github-issues] here on GitHub (for code errors)


## Getting Started

The SDK is compatible with [.NET Standard](https://docs.microsoft.com/en-us/dotnet/standard/library) 1.3 and .NET Framework 4.6.1 or higher.

### Install using Nuget Package Manager
 1. Right-click on your project in the Solution Explorer and choose **Manage Nuget Packages...**
 2. Search for Okta. Install the `Okta.Sdk` package.

### Install using The Package Manager Console
Simply run `install-package Okta.Sdk`. Done!

The [`legacy` branch](https://github.com/okta/okta-sdk-dotnet/tree/legacy) is published on NuGet as [Okta.Core.Client 0.3.3](https://www.nuget.org/packages/Okta.Core.Client/0.3.3).  This version is retiring and will not be supported past December 11, 2019.  It will likely remain working after that date but you should make a plan to migrate to the new 1.x version.

You'll also need:

* An Okta account, called an _organization_ (sign up for a free [developer organization](https://developer.okta.com/signup) if you need one)
* An [API token](https://developer.okta.com/docs/api/getting_started/getting_a_token)
 
Construct a client instance by passing it your Okta domain name and API token:
 
``` csharp
var client = new OktaClient(new OktaClientConfiguration
{
    OktaDomain = "https://{{yourOktaDomain}}",
    Token = "{{yourApiToken}}"
});
```

Hard-coding the Okta domain and API token works for quick tests, but for real projects you should use a more secure way of storing these values (such as environment variables). This library supports a few different configuration sources, covered in the [configuration reference](#configuration-reference) section.
 
## Usage guide

These examples will help you understand how to use this library. You can also browse the full [API reference documentation][dotnetdocs].

Once you initialize an `OktaClient`, you can call methods to make requests to the Okta API.

### Authenticate a User

This library should be used with the Okta management API. For authentication, we recommend using an OAuth 2.0 or OpenID Connect library such as [Okta ASP.NET middleware](https://github.com/okta/okta-aspnet).

### Get a User
``` csharp
// Get the user with a user ID or login
var vader = await client.Users.GetUserAsync("<Some user ID or login>");
```

The string argument for `GetUserAsync` can be the user's ID or the user's login (usually their email).

### List all Users

The SDK will automatically [paginate](https://developer.okta.com/docs/api/getting_started/design_principles#pagination) Okta collections for you:

```
// These different styles all perform the same action:
var allUsers = await client.Users.ToArray();
var allUsers = await client.Users.ToList();
var allUsers = await client.Users.ListUsers().ToArray();
```

### Filter or search for Users
``` csharp
var foundUsers = await client.Users
                        .ListUsers(search: $"profile.nickName eq \"Skywalker\"")
                        .ToArray();
```

### Create a User

``` csharp
// Create a user with the specified password
var vader = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
{
    // User profile object
    Profile = new UserProfile
    {
        FirstName = "Anakin",
        LastName = "Skywalker",
        Email = "darth.vader@imperial-senate.gov",
        Login = "darth.vader@imperial-senate.gov",
    },
    Password = "D1sturB1ng!",
    Activate = false,
});
```

### Activate a User

``` csharp
// With an existing user, call
await vader.ActivateAsync();
```

### Update a User
``` csharp
// Set the nickname in the user's profile
vader.Profile["nickName"] = "Lord Vader";

// Then, save the user
await vader.UpdateAsync();
```

### Get and set custom attributes

You can't create attributes via code right now, but you can get and set their values. To create them you have to use the Profile Editor in the Developer Console web UI. Once you have created them, you can use the code below:

```csharp
vader.Profile["homeworld"] = "Tattooine";
await vader.UpdateAsync();
```

### Remove a User
``` csharp
// First, deactivate the user
await vader.DeactivateAsync();

// Then delete the user
await vader.DeactivateOrDeleteAsync();
```

### List a User's Groups

``` csharp
// Find the desired user
var user = await client.Users.FirstOrDefault(x => x.Profile.Email == "darth.vader@imperial-senate.gov");

// get the user's groups
var groups = await user.Groups.ToList();
```

### Create a Group
``` csharp
await client.Groups.CreateGroupAsync(new CreateGroupOptions()
{
    Name = "Stormtroopers",
    Description = "The 501st"
});
```

### Add a User to a Group
``` csharp
// Find the desired user
var user = await client.Users.FirstOrDefault(x => x.Profile.Email == "darth.vader@imperial-senate.gov");

// find the desired group
var group = await client.Groups.FirstOrDefault(x => x.Profile.Name == "Stormtroopers");

// add the user to the group by using their id's
if (group != null && user != null)
{
    await client.Groups.AddUserToGroupAsync(group.Id, user.Id);
}
```

### List a User's enrolled Factors

``` csharp
// Find the desired user
var user = await client.Users.FirstOrDefault(x => x.Profile.Email == "darth.vader@imperial-senate.gov");

// Get user factors
var factors = await user.Factors.ToArray();
```

### Enroll a User in a new Factor
``` csharp
// Find the desired user
var user = await client.Users.FirstOrDefault(x => x.Profile.Email == "darth.vader@imperial-senate.gov");

// Enroll in Okta SMS factor
await user.AddFactorAsync(new AddSmsFactorOptions
{
    PhoneNumber = "+99999999999",
});
```
### Activate a Factor
``` csharp
// Find the desired user
var user = await client.Users.First(x => x.Profile.Email == "darth.vader@imperial-senate.gov");

// Find the desired factor
var smsFactor = await user.Factors.First(x => x.FactorType == FactorType.Sms);

// Activate sms facotr
await client.UserFactors.ActivateFactorAsync(verifyFactorRequest, user.Id, smsFactor.Id);
```

### Verify a Factor
``` csharp
// Find the desired user
var user = await client.Users.FirstOrDefault(x => x.Profile.Email == "darth.vader@imperial-senate.gov");

// Find the desired factor
var smsFactor = await user.Factors.FirstOrDefault(x => x.FactorType == FactorType.Sms);

// Verify sms factor
var response = await client.UserFactors.VerifyFactorAsync(verifyFactorRequest, user.Id, smsFactor.Id);
```

### List all Applications
``` csharp
// List all applications
var appList = await client.Applications.Applications().ToArray();

// List all applications of a specific type
var bookmarkAppList = await client.Applications.ListApplications().OfType<IBookmarkApplication>().ToArray();
```

### Get an Application
``` csharp
var createdApp = await client.Applications.CreateApplicationAsync(new CreateBasicAuthApplicationOptions()
                {
                    Label = "Sample Basic Auth App",
                    Url = "https://example.com/login.html",
                    AuthUrl = "https://example.com/auth.html",
                });

var retrievedById = await client.Applications.GetApplicationAsync(createdApp.Id);
```

### Create a SWA Application

``` csharp
var createdApp = await client.Applications.CreateApplicationAsync(new CreateSwaApplicationOptions
{ 
    Label = "Sample Plugin App",
    ButtonField = "btn-login",
    PasswordField = "txtbox-password",
    UsernameField = "txtbox-username",
    Url = "https://example.com/login.html",
    LoginUrlRegex = "^https://example.com/login.html",
});

```

### Create an OpenID Application

``` csharp
var createdApp = await client.Applications.CreateApplicationAsync(new CreateOpenIdConnectApplication
{
    Label = "Sample Client",
    ClientId = "0oae8mnt9tZexampl3",
    TokenEndpointAuthMethod = OAuthEndpointAuthenticationMethod.ClientSecretPost,
    AutoKeyRotation = true,
    ClientUri = "https://example.com/client",
    LogoUri = "https://example.com/assets/images/logo-new.png",
    ResponseTypes = new List<OAuthResponseType>
    {
        OAuthResponseType.Token,
        OAuthResponseType.IdToken,
        OAuthResponseType.Code,
    },
    RedirectUris = new List<string>
    {
            "https://example.com/oauth2/callback",
            "myapp://callback",
    },
    GrantTypes = new List<OAuthGrantType>
    {
        OAuthGrantType.Implicit,
        OAuthGrantType.AuthorizationCode,
    },
    ApplicationType = OpenIdConnectApplicationType.Native,
    TermsOfServiceUri = "https://example.com/client/tos",
    PolicyUri = "https://example.com/client/policy",
});
```

## Call other API endpoints

The SDK client object can be used to make calls to any Okta API (not just the endpoints officially supported by the SDK) via the `GetAsync`, `PostAsync`, `PutAsync` and `DeleteAsync` methods.

For example, to activate a user using the `PostAsync` method (instead of `user.ActivateAsync`):

```csharp
await client.PostAsync(new Okta.Sdk.HttpRequest
{
    Uri = $"/api/v1/users/{userId}/lifecycle/activate",
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

In this case, there is no benefit to using `PostAsync` instead of `user.ActivateAsync`. However, this approach can be used to call any endpoints that are not represented by methods in the SDK.

## Rate Limiting

The Okta API will return 429 responses if too many requests are made within a given time. Please see [Rate Limiting at Okta] for a complete list of which endpoints are rate limited.  When a 429 error is received, the `X-Rate-Limit-Reset` header will tell you the time at which you can retry. This section discusses  methods for handling rate limiting with this SDK.

### Built-In Retry

You can configure your client to use the default retry strategy if you wish to automatically retry on 429 errors:

```
var maxRetries = configuration.MaxRetries ?? OktaClientConfiguration.DefaultMaxRetries;
var requestTimeout = configuration.RequestTimeout ?? OktaClientConfiguration.DefaultRequestTimeout;

var client = new OktaClient(apiClientConfiguration: configuration, httpClient: httpClient, retryStrategy: new DefaultRetryStrategy(maxRetries, requestTimeout));
```
> Note: Now, the client is using a `NoRetryStrategy` but in the next major version the default retry strategy will be automatically added to the client.

### Custom Retry

You can build your own retry strategy by implementing the `IRetryStrategy` interface and pass it to the `OktaClient`.
You will have to read the `X-Rate-Limit-Reset` header on the 429 response.  This will tell you the time at which you can retry.  Because this is an absolute time value, we recommend calculating the wait time by using the `Date` header on the response, as it is in sync with the API servers, whereas your local clock may not be.  We also recommend adding 1 second to ensure that you will be retrying after the window has expired (there may be a sub-second relative time skew between the `X-Rate-Limit-Reset` and `Date` headers).

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
    requestTimeout: 0 # seconds
    rateLimit:
      maxRetries: 4
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
[github-issues]: https://github.com/okta/okta-sdk-dotnet/issues
[github-releases]: https://github.com/okta/okta-sdk-dotnet/releases
[Rate Limiting at Okta]: https://developer.okta.com/docs/api/getting_started/rate-limits
