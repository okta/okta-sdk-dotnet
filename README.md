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
* Manage custom domains with the [Domains API](https://developer.okta.com/docs/reference/api/domains/).
* Manage network zones with the [Zones API's endpoints](https://developer.okta.com/docs/reference/api/zones/).
* Much more!

> Note: For more details about the APIs and models the SDK support, check out the [API docs](/API_README.md) 

We also publish these other libraries for .NET:
 
* [Okta ASP.NET middleware](https://github.com/okta/okta-aspnet)
* [Okta .NET Authentication SDK](https://github.com/okta/okta-auth-dotnet)
 
You can learn more on the [Okta + .NET][lang-landing] page in our documentation.

## Release status

This library uses semantic versioning and follows Okta's [library version policy](https://developer.okta.com/code/library-versions/).

:heavy_check_mark: The current stable major version series is: 6.x
:heavy_check_mark: The 5.x series is retiring on June 8th 2023. Until then, we will only fix high-risk security vulnerabilities and other issues will be reviewed on a case-by-case basis. New APIs will be added only on series 6.x, but you can still use the 5.x series to call any new endpoint. The SDK will be still available on Nuget, and the source-code is located in the `legacy-5.x-series` [branch](https://github.com/okta/okta-sdk-dotnet/tree/legacy-5.x-series). Please, reach out to the Okta Customer Support Team at developers@okta.com if you have any questions or issues.

| Version | Status                    |
| ------- | ------------------------- |
| 9.x | :heavy_check_mark: Stable ([migration guide](MIGRATING.md))|
| 8.x | :warning: Retiring on April 3rd 2025 |
| 7.x | :stop_sign: Retired on December 11th 2024 |
 
The latest release can always be found on the [releases page][github-releases]. For more information about our SDKs' lifecycle, check out [our docs](https://developer.okta.com/code/library-versions/).

## Need help?
 
If you run into problems using the SDK, you can
 
* Ask questions on the [Okta Developer Forums][devforum]
* Post [issues][github-issues] here on GitHub (for code errors)


## Getting Started

The SDK is compatible with:

* [.NET Standard](https://docs.microsoft.com/en-us/dotnet/standard/library) 2.1
* .NET Framework 4.6.1 or higher
* .NET Core 3.0 or higher
* .NET 5.0 or higher

Visual Studio 2017 or newer is required as previous versions are not compatible with the above frameworks.

### Install using Nuget Package Manager
 1. Right-click on your project in the Solution Explorer and choose **Manage Nuget Packages...**
 2. Search for Okta. Install the `Okta.Sdk` package.

### Install using The Package Manager Console
Simply run `install-package Okta.Sdk`. Done!

You'll also need:

* An Okta account, called an _organization_ (sign up for a free [developer organization](https://developer.okta.com/signup) if you need one)
* An [API token](https://developer.okta.com/docs/api/getting_started/getting_a_token)
 
### Initialize an API client 

Construct a client instance by passing it your Okta domain name and API token:

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class Example
    {
        public static void Main()
        {

            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token.Add("Authorization", "YOUR_API_KEY");
            
            var apiInstance = new AgentPoolsApi(config);
            var poolId = "poolId_example";  // string | Id of the agent pool for which the settings will apply
            var updateId = "updateId_example";  // string | Id of the update

            try
            {
                // Activate an Agent Pool update
                AgentPoolUpdate result = apiInstance.ActivateAgentPoolsUpdate(poolId, updateId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling AgentPoolsApi.ActivateAgentPoolsUpdate: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }

        }
    }
}
```


> Hard-coding the Okta domain and API token works for quick tests, but for real projects you should use a more secure way of storing these values (such as environment variables). This library supports a few different configuration sources, covered in the [configuration reference](#configuration-reference) section.

To use the API client with an HTTP proxy, you can either setup your proxy via different configuration sources, covered in the [configuration reference](#configuration-reference) section, or via API constructor. If you have both, the proxy passed via constructor will take precedence.


```csharp
System.Net.WebProxy webProxy = new System.Net.WebProxy("http://myProxyUrl:80/");
webProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

var appsApi = new ApplicationApi(webProxy : webProxy);
```

### OAuth 2.0

Okta allows you to interact with Okta APIs using scoped OAuth 2.0 access tokens. Each access token enables the bearer to perform specific actions on specific Okta endpoints, with that ability controlled by which scopes the access token contains.

This SDK supports this feature only for service-to-service applications. Check out our guides to learn more about how to register a new service application using a private and public key pair.

When using this approach you won't need an API Token because the SDK will request an access token for you. In order to use OAuth 2.0, construct an API client instance by passing the following parameters:

```csharp
var oauthAppsApi = new ApplicationApi(new Configuration
{
    OktaDomain = "https://{{yourOktaDomain}}",
    AuthorizationMode = AuthorizationMode.PrivateKey,
    ClientId = "{{clientId}}",
    Scopes = new List<string> { "okta.users.read", "okta.apps.read" }, // Add all the scopes you need
    PrivateKey =  new JsonWebKeyConfiguration(jsonString)
});
```

Key object for assigning to the PrivateKey can be created and initialized inline like in this example for RSA key:

```csharp
var privateKey = new JsonWebKeyConfiguration
{
    P = "{{P}}",
    Kty = "RSA",
    Q = "{{Q}}",
    D = "{{D}}",
    E = "{{E}}",
    Kid = "{{P}}",
    Qi = "{{Qi}}"
};

var configuration = new Configuration
{
    OktaDomain = "https://{{yourOktaDomain}}",
    AuthorizationMode = AuthorizationMode.PrivateKey,
    ClientId = "{{clientId}}",
    Scopes = new HashSet<string> { "okta.users.read", "okta.apps.read" }, // Add all the scopes you need
    PrivateKey = privateKey
};

var oauthAppsApi = new ApplicationApi(configuration);
```

It is possible to use an access token you retrieved outside of the SDK for authentication. For that, set `Configuration.AuthorizationMode` configuration property to `AuthorizationMode.BearerToken` and `Configuration.AccessToken` to the token string.

> Note: Starting from 8.x series the Okta management SDK added support for DPoP. If the SDK detects the application has DPoP enabled, it will silently proceed to obtain a DPoP-bound access token, and will generate a new DPoP Proof JWT for every request. There's no additional configuration required for developers.

## Usage guide

These examples will help you understand how to use this library. You can also browse the full [API reference documentation][dotnetdocs].

Once you initialize an API client, you can call methods to make requests to the Okta API.

### Get a User
``` csharp
// Get the user with a user ID or login
var user = await userApi.GetUserAsync("<Some user ID or login>");
```

The string argument for `GetUserAsync` can be the user's ID or the user's login (usually their email).

### List all Users

The SDK will automatically [paginate](https://developer.okta.com/docs/api/getting_started/design_principles#pagination) Okta collections for you:

``` csharp
// These different styles all perform the same action:
var allUsers = await userApi.ListUsers().ToListAsync();
var allUsers = await userApi.ListUsers().ToArrayAsync();
```

### Filter or search for Users
``` csharp
var foundUsers = await userApi
                        .ListUsers(search: $"profile.nickName eq \"Skywalker\"")
                        .ToArrayAsync();
```

### Create a User

``` csharp
// Create a user with the specified password
var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "Anakin",
                    LastName = "Skywalker",
                    Email = "darth.vader@imperial-senate.gov",
                    Login = "darth.vader@imperial-senate.gov",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "D1sturB1ng"
                    }
                }
            };

var createdUser = await _userApi.CreateUserAsync(createUserRequest);
```

### Activate a User

``` csharp
// Activate the user
await _userApi.ActivateUserAsync(createdUser.Id, false);
```

### Update a User
``` csharp
// Update profile
createdUser.Profile.NickName = nickName;
var updateUserRequest = new UpdateUserRequest
{
    Profile = createdUser.Profile
};

var updatedUser = await _userApi.UpdateUserAsync(createdUser.Id, updateUserRequest);
```

### Get and set custom attributes

You can't create attributes via code right now, but you can get and set their values. To create them you have to use the Profile Editor in the Developer Console web UI. Once you have created them, you can use the code below:

```csharp
user.Profile.AdditionalProperties = new Dictionary<string, object>();
user.Profile.AdditionalProperties["homeworld"] = "Planet Earth";

var updateUserRequest = new UpdateUserRequest
{
    Profile = user.Profile
};

var updatedUser = await _userApi.UpdateUserAsync(createdUser.Id, updateUserRequest);

var userHomeworld = updatedUser.Profile.AdditionalProperties["homeworld"];
```

### Remove a User
``` csharp
 await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
```

### List all Applications
``` csharp
// List all applications
var appList = await _applicationApi.ListApplications().ToArrayAsync();
```

### Get an Application
``` csharp
var createdApp = await _applicationApi.CreateApplicationAsync(new CreateBasicAuthApplicationOptions()
                {
                    Label = "Sample Basic Auth App",
                    Url = "https://example.com/login.html",
                    AuthUrl = "https://example.com/auth.html",
                });

var retrievedById = await _applicationApi.GetApplicationAsync(createdApp.Id);
```

### Create an OpenID Application

``` csharp
var app = new OpenIdConnectApplication
        {
            Name = "oidc_client",
            SignOnMode = "OPENID_CONNECT",
            Label = $"dotnet-sdk: AddOpenIdConnectApp",
            Credentials = new OAuthApplicationCredentials()
            {
                OauthClient = new ApplicationCredentialsOAuthClient()
                {
                    ClientId = testClientId,
                    TokenEndpointAuthMethod = "client_secret_post",
                    AutoKeyRotation = true,
                },
            },
            Settings = new OpenIdConnectApplicationSettings
            {
                OauthClient = new OpenIdConnectApplicationSettingsClient()
                {
                    ClientUri = "https://example.com/client",
                    LogoUri = "https://example.com/assets/images/logo-new.png",
                    ResponseTypes = new List<string>
                    {
                        "token",
                        "id_token",
                        "code",
                    },
                    RedirectUris = new List<string>
                    {
                        "https://example.com/oauth2/callback",
                        "myapp://callback",
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://example.com/postlogout",
                        "myapp://postlogoutcallback",
                    },
                    GrantTypes = new List<string>
                    {
                        "implicit",
                        "authorization_code",
                    },
                    ApplicationType = "native",

                    TosUri = "https://example.com/client/tos",
                    PolicyUri = "https://example.com/client/policy",
                },
            }
        };

var createdApp = await _applicationApi.CreateApplicationAsync(app);

```

## Manual pagination

Collections can be fetched with manually controlled pagination, see the following.

```csharp
var retrievedUsers = new List<IUser>();
var users = _userApi.ListUsers(limit: 5); // 5 records per a page
var enumerator = users.GetPagedEnumerator();

while (await enumerator.MoveNextAsync())
{
    retrievedUsers.AddRange(enumerator.CurrentPage.Items);
    // ....................
}
```

> Note: For more API samples checkout our [tests](https://github.com/okta/okta-sdk-dotnet/tree/master/src/Okta.Sdk.IntegrationTest)

## Rate Limiting

The Okta API will return 429 responses if too many requests are made within a given time. Please see [Rate Limiting at Okta] for a complete list of which endpoints are rate limited.  When a 429 error is received, the `X-Rate-Limit-Reset` header will tell you the time at which you can retry. This section discusses  methods for handling rate limiting with this SDK.

### Built-In Retry

This SDK uses the built-in retry strategy to automatically retry on 429 errors. You can use the default configuration options for the built-in retry strategy, or provide your desired values via client configuration.

You can configure the following options when using the built-in retry strategy:

| Configuration Option | Description |
| ---------------------- | -------------- |
| RequestTimeout         | The waiting time in milliseconds for a request to be resolved by the client. Less than or equal to 0 means "no timeout". The default value is `0` (None). |
| MaxRetries             | The number of times to retry. |

Check out the [Configuration Reference section](#configuration-reference) for more details about how to set these values via configuration.

### Custom Retry

You can implement your own retry strategy via [Polly](https://github.com/App-vNext/Polly), and assign it to the `RetryConfiguration.AsyncPolicy` property. 

```csharp
 AsyncPolicy<IRestResponse> retryAsyncPolicy = Policy
                .Handle<ApiException>(ex => ex.ErrorCode == 429)
                .OrResult<IRestResponse>(r => (int)r.StatusCode == 429)
                .WaitAndRetryAsync(configuration.MaxRetries.Value, 
                                   sleepDurationProvider: (retryAttempt, response,
                                   context) => MyCalculateDelayMethod(retryAttempt, response, context)
                );

RetryPolicy.AsyncPolicy = retryAsyncPolicy;
```

You will have to read the `X-Rate-Limit-Reset` header on the 429 response.  This will tell you the time at which you can retry.  Because this is an absolute time value, we recommend calculating the wait time by using the `Date` header on the response, as it is in sync with the API servers, whereas your local clock may not be.  We also recommend adding 1 second to ensure that you will be retrying after the window has expired (there may be a sub-second relative time skew between the `X-Rate-Limit-Reset` and `Date` headers).

## Configuration reference
  
This library looks for configuration in the following sources:
 
1. An `okta.yaml` file in a `.okta` folder in the current user's home directory (`~/.okta/okta.yaml` or `%userprofile%\.okta\okta.yaml`)
2. An `appsettings.json` file in the application or project's root directory
3. An `okta.yaml` file in a `.okta` folder in the application or project's root directory
4. Environment variables
5. Configuration explicitly passed to the constructor (see the example in [Getting started](#getting-started))
 
Higher numbers win. In other words, configuration passed via the constructor will override configuration found in environment variables, which will override configuration in `okta.yaml` (if any), and so on.

Note that `json` files cannot be used if they contain JavaScript comments. Comments are not allowed by JSON format.

### YAML configuration
 
When you use an API Token instead of OAuth 2.0 the full YAML configuration looks like:
 
```yaml
okta:
  client:
    connectionTimeout: 30000 # milliseconds
    oktaDomain: "https://{yourOktaDomain}"
    proxy:
        port: null
        host: null
        username: null
        password: null
    token: {apiToken}
    requestTimeout: 0 # milliseconds
    rateLimit:
      maxRetries: 4
```

When you use OAuth 2.0 the full YAML configuration looks like this when using EC key:

```yaml
okta:
  client:
    connectionTimeout: 30000 # milliseconds
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
    requestTimeout: 0 # milliseconds
    rateLimit:
      maxRetries: 4
```

Or like this for RSA key:

```yaml
okta:
  client:
    connectionTimeout: 30000 # milliseconds
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
    PrivateKey: 
      "p": "{p}"
      "kty": "RSA"
      "q": "{q}"
      "d": "{d}"
      "e": "{e}"
      "kid": "{kid}"
      "qi": "{qi}"
    requestTimeout: 0 # milliseconds
    rateLimit:
      maxRetries: 4
```
 
 Beginning in version 8.0.1, If you have need for a `proxy` node in your configuration unrelated to a web proxy for the Okta API client or you want to disable the proxy without removing it from your configuration, set `useProxy` to `false`:

 ```json
 {
    "useProxy" : false
    "proxy" : "non web proxy settings"
 }
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
[dotnetdocs]: https://github.com/okta/okta-sdk-dotnet/tree/master/docs
[lang-landing]: https://developer.okta.com/code/dotnet/
[github-issues]: https://github.com/okta/okta-sdk-dotnet/issues
[github-releases]: https://github.com/okta/okta-sdk-dotnet/releases
[Rate Limiting at Okta]: https://developer.okta.com/docs/api/getting_started/rate-limits
