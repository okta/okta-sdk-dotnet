[<img src="https://aws1.discourse-cdn.com/standard14/uploads/oktadev/original/1X/0c6402653dfb70edc661d4976a43a46f33e5e919.png" align="right" width="256px"/>](https://devforum.okta.com/)

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
* Manage templates with the [Custom Templates API](https://developer.okta.com/docs/reference/api/templates/)
* Manage identity providers with the [Identity Providers API](https://developer.okta.com/docs/reference/api/idps/)
* Manage authorization servers with the [Authorization Servers API](https://developer.okta.com/docs/reference/api/authorization-servers/)
* Manage event hooks with the [Event Hooks Management API](https://developer.okta.com/docs/reference/api/event-hooks/)
* Manage inline hooks with the [Inline Hooks Management API](https://developer.okta.com/docs/reference/api/inline-hooks/).
* Manage features with the [Features API](https://developer.okta.com/docs/reference/api/features/).
* Manage linked objects with the [Linked Objects API](https://developer.okta.com/docs/reference/api/linked-objects/).
* Manage trusted origins with the [Trusted Origins API](https://developer.okta.com/docs/reference/api/trusted-origins/).
* Manage user types with the [User Types API](https://developer.okta.com/docs/reference/api/user-types/).
* Much more!


We also publish these other libraries for .NET:
 
* [Okta ASP.NET middleware](https://github.com/okta/okta-aspnet)
* [Okta .NET Authentication SDK](https://github.com/okta/okta-auth-dotnet)
 
You can learn more on the [Okta + .NET][lang-landing] page in our documentation.

## Release status

This library uses semantic versioning and follows Okta's [library version policy](https://developer.okta.com/code/library-versions/).

:heavy_check_mark: The current stable major version series is: 3.x

| Version | Status                    |
| ------- | ------------------------- |
| 0.3.3   | :warning: Retired on 2019-12-11 ([migration guide](MIGRATING.md))  |
| 1.x | :warning: Retiring on 2020-12-27 |
| 2.x | :warning: Retiring on 2021-04-10 ([migration guide](MIGRATING.md))  |
| 3.x | :heavy_check_mark: Stable |

 
The latest release can always be found on the [releases page][github-releases].

## Need help?
 
If you run into problems using the SDK, you can
 
* Ask questions on the [Okta Developer Forums][devforum]
* Post [issues][github-issues] here on GitHub (for code errors)


## Getting Started

The SDK is compatible with:

* [.NET Standard](https://docs.microsoft.com/en-us/dotnet/standard/library) 2.0 and 2.1
* .NET Framework 4.6.1 or higher
* .NET Core 3.0 or higher
* .NET 5.0

Visual Studio 2017 or newer is required as previous versions are not compatible with the above frameworks.

### Install using Nuget Package Manager
 1. Right-click on your project in the Solution Explorer and choose **Manage Nuget Packages...**
 2. Search for Okta. Install the `Okta.Sdk` package.

### Install using The Package Manager Console
Simply run `install-package Okta.Sdk`. Done!

The [`legacy` branch](https://github.com/okta/okta-sdk-dotnet/tree/legacy) is published on NuGet as [Okta.Core.Client 0.3.3](https://www.nuget.org/packages/Okta.Core.Client/0.3.3).  This version is *retired* and is no longer supported. 

The [1.x series](https://github.com/okta/okta-sdk-dotnet/tree/legacy-1.x-series) will not be supported past December 27, 2020.  It will likely remain working after that date but you should make a plan to migrate to the new 3.x version.

You'll also need:

* An Okta account, called an _organization_ (sign up for a free [developer organization](https://developer.okta.com/signup) if you need one)
* An [API token](https://developer.okta.com/docs/api/getting_started/getting_a_token)
 
### Initialize a client 
Construct a client instance by passing it your Okta domain name and API token:
 
``` csharp
var client = new OktaClient(new OktaClientConfiguration
{
    OktaDomain = "https://{{yourOktaDomain}}",
    Token = "{{yourApiToken}}"
});
```

Hard-coding the Okta domain and API token works for quick tests, but for real projects you should use a more secure way of storing these values (such as environment variables). This library supports a few different configuration sources, covered in the [configuration reference](#configuration-reference) section.

### Create a scoped client
Create a client scoped to a specific context to specify a custom content type:
``` csharp
var client = new OktaClient(new OktaClientConfiguration
{
    OktaDomain = "https://{{yourOktaDomain}}",
    Token = "{{yourApiToken}}"
});

var scopedClient = client.CreateScoped(new RequestContext { ContentType = "my-custom-content-type" });
```
The content type specified in a scoped client overrides the content type specified on a request, see also [Call other API endpoints](#call-other-api-endpoints).

### OAuth 2.0

Okta allows you to interact with Okta APIs using scoped OAuth 2.0 access tokens. Each access token enables the bearer to perform specific actions on specific Okta endpoints, with that ability controlled by which scopes the access token contains. 

This SDK supports this feature only for service-to-service applications. Check out [our guides](https://developer.okta.com/docs/guides/implement-oauth-for-okta/overview/) to learn more about how to register a new service application using a private and public key pair.

When using this approach you won't need an API Token because the SDK will request an access token for you. In order to use OAuth 2.0, construct a client instance by passing the following parameters:

``` csharp
var client = new OktaClient(new OktaClientConfiguration
{
    OktaDomain = "https://{{yourOktaDomain}}",
    AuthorizationMode = AuthorizationMode.PrivateKey,
    ClientId = "{{clientId}}",
    Scopes = new List<string> { "okta.users.read", "okta.apps.read" }, // Add all the scopes you need
    PrivateKey =  new JsonWebKeyConfiguration(jsonString)
});
```

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

``` csharp
// These different styles all perform the same action:
var allUsers = await client.Users.ToArrayAsync();
var allUsers = await client.Users.ToListAsync();
var allUsers = await client.Users.ListUsers().ToArrayAsync();
```

### Filter or search for Users
``` csharp
var foundUsers = await client.Users
                        .ListUsers(search: $"profile.nickName eq \"Skywalker\"")
                        .ToArrayAsync();
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
var user = await client.Users.FirstOrDefaultAsync(x => x.Profile.Email == "darth.vader@imperial-senate.gov");

// get the user's groups
var groups = await user.Groups.ToListAsync();
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
var user = await client.Users.FirstOrDefaultAsync(x => x.Profile.Email == "darth.vader@imperial-senate.gov");

// find the desired group
var group = await client.Groups.FirstOrDefaultAsync(x => x.Profile.Name == "Stormtroopers");

// add the user to the group by using their id's
if (group != null && user != null)
{
    await client.Groups.AddUserToGroupAsync(group.Id, user.Id);
}
```

### List a User's enrolled Factors

``` csharp
// Find the desired user
var user = await client.Users.FirstOrDefaultAsync(x => x.Profile.Email == "darth.vader@imperial-senate.gov");

// Get user factors
var factors = await user.ListFactors().ToListAsync();
```

### Enroll a User in a new Factor
``` csharp
// Find the desired user
var user = await client.Users.FirstOrDefaultAsync(x => x.Profile.Email == "darth.vader@imperial-senate.gov");

// Enroll in Okta SMS factor
await user.AddFactorAsync(new AddSmsFactorOptions
{
    PhoneNumber = "+99999999999",
});
```
### Activate a Factor
``` csharp
// Find the desired user
var user = await client.Users.FirstAsync(x => x.Profile.Email == "darth.vader@imperial-senate.gov");

// Find the desired factor
var smsFactor = await user.Factors.FirstAsync(x => x.FactorType == FactorType.Sms);

// Activate sms factor
var activateFactorRequest = new ActivateFactorRequest()
{
    PassCode = "foo",
};

await client.UserFactors.ActivateFactorAsync(activateFactorRequest, user.Id, smsFactor.Id);
```

### Verify a Factor
``` csharp
// Find the desired user
var user = await client.Users.FirstOrDefaultAsync(x => x.Profile.Email == "darth.vader@imperial-senate.gov");

// Find the desired factor
var smsFactor = await user.Factors.FirstOrDefaultAsync(x => x.FactorType == FactorType.Sms);

// Verify sms factor
var verifyFactorRequest = new VerifyFactorRequest()
{
    PassCode = "foo",
};

var response = await client.UserFactors.VerifyFactorAsync(verifyFactorRequest, user.Id, smsFactor.Id);
```

### Issuing an SMS Factor Challenge Using a Custom Template

You can customize and optionally localize the SMS message sent to the user on verification. For more information about this feature and the underlying API call, see the related [developer documentation](https://developer.okta.com/docs/reference/api/factors/#issuing-an-sms-factor-challenge-using-a-custom-template).

If you need to send additional information via the `AcceptLanguage` header, use an scoped client and pass a `RequestContext` object with your desired headers:

```csharp
// Create scoped client with specific headers
var scopedClient = client.CreateScoped(new RequestContext() { AcceptLanguage = "de" });

await scopedClient.UserFactors.VerifyFactorAsync(userId, factorId, templateId);
```

### List all Applications
``` csharp
// List all applications
var appList = await client.Applications.ListApplications().ToArrayAsync();

// List all applications of a specific type
var bookmarkAppList = await client.Applications.ListApplications().OfType<IBookmarkApplication>().ToArrayAsync();
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

This SDK uses the built-in retry strategy to automatically retry on 429 errors. You can use the default configuration options for the built-in retry strategy, or provide your desired values via client configuration.

You can configure the following options when using the built-in retry strategy:

| Configuration Option | Description |
| ---------------------- | -------------- |
| RequestTimeout         | The waiting time in seconds for a request to be resolved by the client. Less than or equal to 0 means "no timeout". The default value is `0` (None). |
| MaxRetries             | The number of times to retry. |

Check out the [Configuration Reference section](#configuration-reference) for more details about how to set these values via configuration.

> Note: The default retry strategy will be automatically added to the client for 2.x series.

### Custom Retry

You can build your own retry strategy by implementing the `IRetryStrategy` interface and pass it to the `OktaClient`.
You will have to read the `X-Rate-Limit-Reset` header on the 429 response.  This will tell you the time at which you can retry.  Because this is an absolute time value, we recommend calculating the wait time by using the `Date` header on the response, as it is in sync with the API servers, whereas your local clock may not be.  We also recommend adding 1 second to ensure that you will be retrying after the window has expired (there may be a sub-second relative time skew between the `X-Rate-Limit-Reset` and `Date` headers).

## JSON Serialization

This SDK provides a `DefaultSerializer` which has all the logic needed by this SDK to work properly. While the `OktaClient` constructor allows a custom `ISerializer` to be set, we highly recommend using the `DefaultSerializer`, otherwise it is the developer's responsibility to add all the logic required by this SDK to continue working properly. This change was added to support edge cases with custom attributes, but will be removed in the next major release, where the default behavior will be to treat all the custom attributes as strings or arrays when applicable.

### Default Serializer Settings

In 2.x series all date formatted strings attributes are deserialized as strings by default. This was not true in previous versions where date-formatted strings were deserialized as `DateTime`. The default configuration for date parsing is now [`DateParseHandling.None`](https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_DateParseHandling.htm).

If you are using an older version of the SDK and you have date-formatted strings among your Okta custom attributes and you don't want them to be parsed to a date type and read them as strings instead, use the following code:

```csharp
var serializer = new DefaultSerializer(new JsonSerializerSettings()
{
    DateParseHandling = DateParseHandling.None,
});

var client = new Okta.Sdk.OktaClient(new Okta.Sdk.Configuration.OktaClientConfiguration
{
    OktaDomain = "https://{yourOktaDomain}",
    Token = "{apiToken}"
}, serializer: serializer);

var user = await client.Users.GetUserAsync("user@test.com");
var stringDate = user.Profile["myCustomDate"];
```

You can still use the `GetProperty<T>` method to return a `DateTimeOffset?`:

```csharp
DateTimeOffset? myCustomDateTimeOffset = user.Profile.GetProperty<DateTimeOffset?>("myCustomDate");
```

Since the `DefaultSerializer` is used to parse other `DateTime` fields across the SDK, such as `User.LastLogin`,
keep in mind that this configuration will also affect how all other date-formatted strings are parsed. For example, if you choose `DateParseHandling.DateTime` your original timezone could be ignored. For more details check out [DateParseHandling](https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_DateParseHandling.htm).

## Configuration reference
  
This library looks for configuration in the following sources:
 
1. An `okta.yaml` file in a `.okta` folder in the current user's home directory (`~/.okta/okta.yaml` or `%userprofile%\.okta\okta.yaml`)
2. An `okta.yaml` file in a `.okta` folder in the application or project's root directory
3. Environment variables
4. Configuration explicitly passed to the constructor (see the example in [Getting started](#getting-started))
 
Higher numbers win. In other words, configuration passed via the constructor will override configuration found in environment variables, which will override configuration in `okta.yaml` (if any), and so on.
 
### YAML configuration
 
When you use an API Token instead of OAuth 2.0 the full YAML configuration looks like:
 
```yaml
okta:
  client:
    connectionTimeout: 30 # seconds
    oktaDomain: "https://{yourOktaDomain}"
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
 
When you use OAuth 2.0 the full YAML configuration looks like:

```yaml
okta:
  client:
    connectionTimeout: 30 # seconds
    oktaDomain: "https://{yourOktaDomain}"
    proxy:
      port: null
      host: null
      username: null
      password: null
    authorizationMode: "PrivateKey"
    clientId: "{yourClientId}"
    Scopes:
    - scope1
    - scope2
    PrivateKey: # This SDK supports both RSA and EC keys.
        kty: "EC"
        crv: "P-256"
        x: "{x}"
        y: "{y}"
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
