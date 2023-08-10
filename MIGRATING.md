# Okta .NET management SDK migration guide

This library uses semantic versioning and follows Okta's [library version policy](https://developer.okta.com/code/library-versions/). In short, we don't make breaking changes unless the major version changes!

## Migrating from 6.x to 7.x

### RestSharp upgraded to 110.2.0

We have upgraded the RestSharp dependency from `106.13.0` to `110.2.0`. This caused a few breaking changes due to the removal and changes of interfaces. You can learn more about RestSharp changes [here](https://restsharp.dev/v107/#restsharp-v107).

* `IOAuthTokenProvider.GetOAuthRetryPolicy()` now returns `RestResponse` instead of `IRestResponse`. This has impacted `DefaultOAuthTokenProvider`.
* `RetryConfiguration.AsyncRetryPolicy` now receives/returns `AsyncPolicy<RestResponse>` instead of  `AsyncPolicy<IRestResponse>`
* `RetryConfiguration.GetRetryPolicy` has changed its interface from 

```csharp
public static Polly.AsyncPolicy<IRestResponse> GetRetryPolicy(IReadableConfiguration configuration, Func<DelegateResult<IRestResponse>, TimeSpan, int, Context, Task> onRetryAsyncFunc = null)
```

to 

```csharp
  public static Polly.AsyncPolicy<RestResponse> GetRetryPolicy(IReadableConfiguration configuration, Func<DelegateResult<RestResponse>, TimeSpan, int, Context, Task> onRetryAsyncFunc = null)
```

* `RetryConfiguration.AddRetryHeaders` has changed its interface from 

```csharp
public static void AddRetryHeaders (Context context, IRestRequest request)
```

to

```csharp
public static void AddRetryHeaders (Context context, RestRequest request)
```
        
* `ApiClient.InterceptRequest` partial method now receive `RestRequest` instead of `IRestRequest`
* `ApiClient.InterceptResponse` partial method now receive `RestResponse` instead of `IRestResponse`

### OpenAPI specification reorg and standardization

We have upgraded the Okta management OpenAPI specification to be aligned with the Okta release [v2023.07.0](https://help.okta.com/en-us/Content/Topics/ReleaseNotes/okta-relnotes.htm). As part of a naming standardization performed by the API teams, a few methods have changed their name in order to use unified prefixes. For example:

* If an operation requires a PUT request that replaces a resource with the passed values, the method will now use the `Replace` prefix instead of `Update`

* if the method performs a partial update on a specific resource, the method will now use the `PartialUpdate` prefix instead of `Update`

* If the operation's prefix started with `Add`, it now starts with `Create`

 Some assigments and factors operations have also changed the prefix, for example:
 
* `CreateApplicationGroupAssignmentAsync` is now `AssignGroupToApplicationAsync`
* `DeleteApplicationGroupAssignmentAsync` is now `UnassignApplicationFromGroupAsync`
* `DeleteFactorAsync` is now `UnenrollFactorAsync`

Also, some operations have been moved to their own API Client. For example, multiple operations that corresponded to an application's resource and have been part of the `ApplicationsApi`, are now available in their own application-resource API client:

- ApplicationTokensApi
- ApplicationLogosApi
- ApplicationUsersApi
- ApplicationGroupsApi
- ApplicationCredentialsApi
- ApplicationGrantsApi
- ApplicationConnectionsApi
- ApplicationUsersApi

Additionally, the method `UserApi.DeactivateOrDeleteUserAsync` has been split into two separate methods: `UserApi.DeactivateUserAsync` and `UserApi.DeleteUserAsync`.

`ProfileMappingApi.UpdateProfileMappingAsync` now receives an `ProfileMappingRequest` param instead of a `Mapping` param:

_Before_

```csharp
var mapping = await _profileMappingApi.GetProfileMappingAsync(mappings.FirstOrDefault().Id);

// Add properties
if (mapping.Properties == null)
{
    mapping.Properties = new Dictionary<string, ProfileMappingProperty>();
}

mapping.Properties.Add("userType", new ProfileMappingProperty
{
    Expression = "appuser.firstName",
    PushStatus = ProfileMappingPropertyPushStatus.PUSH,
});

mapping.Properties.Add("nickName", new ProfileMappingProperty
{
    Expression = "appuser.firstName + appuser.lastName",
    PushStatus = ProfileMappingPropertyPushStatus.PUSH,
});

var updatedMapping = await _profileMappingApi.UpdateProfileMappingAsync(mapping.Id, mapping);
```

_Now_

```csharp
var profileMappingRequest = new ProfileMappingRequest();
profileMappingRequest.Properties = new Dictionary<string, ProfileMappingProperty>();
profileMappingRequest.Properties.Add("userType", new ProfileMappingProperty
{
    Expression = "appuser.firstName",
    PushStatus = ProfileMappingPropertyPushStatus.PUSH,
});

profileMappingRequest.Properties.Add("nickName", new ProfileMappingProperty
{
    Expression = "appuser.firstName + appuser.lastName",
    PushStatus = ProfileMappingPropertyPushStatus.PUSH,
});


var updatedMapping = await _profileMappingApi.UpdateProfileMappingAsync(mapping.Id, profileMappingRequest);
```

 > Note: For more details about API changes, check out the latest changes on the [Okta OpenAPI specification](https://github.com/okta/okta-sdk-dotnet/blob/master/openapi3/management.yaml).


### Enums

As a general rule, we try to avoid inline enums. However, this version of the OpenAPI specification contains a few inline enums.

### Obsolete methods

The following obsolete methods have been removed:

* UserApi

```csharp
[Obsolete("This method is obsolete. Use UpdateUserAsync(string userId, User user,...) instead.")]
System.Threading.Tasks.Task<User> UpdateUserAsync(string userId, UpdateUserRequest user, bool? strict = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

```  

```csharp
[Obsolete("This method is obsolete. Use UpdateUserWithHttpInfoAsync(string userId, User user,...) instead.")]
System.Threading.Tasks.Task<ApiResponse<User>> UpdateUserWithHttpInfoAsync(string userId, UpdateUserRequest user, bool? strict = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
```

* RoleApi

```csharp
[Obsolete("This method is obsolete. Use CreateRoleAsync(CreateIamRoleRequest,...) instead.")]
System.Threading.Tasks.Task<IamRole> CreateRoleAsync(IamRole instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
```

```csharp
[Obsolete("This method is obsolete. Use CreateRoleWithHttpInfoAsync(CreateIamRoleRequest,...) instead.")]
System.Threading.Tasks.Task<ApiResponse<IamRole>> CreateRoleWithHttpInfoAsync(IamRole instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
```

```csharp
[Obsolete("This method is obsolete. Use ReplaceRoleAsync(string roleIdOrLabel, UpdateIamRoleRequest,...) instead.")]
System.Threading.Tasks.Task<IamRole> ReplaceRoleAsync(string roleIdOrLabel, IamRole instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
```

```csharp
[Obsolete("This method is obsolete. Use ReplaceRoleWithHttpInfoAsync(string roleIdOrLabel, UpdateIamRoleRequest,...) instead.")]
System.Threading.Tasks.Task<ApiResponse<IamRole>> ReplaceRoleWithHttpInfoAsync(string roleIdOrLabel, IamRole instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
```

* ResourceSetApi

```csharp
[Obsolete("This method is obsolete and will be removed in the next major release. Use CreateResourceSetAsync(CreateResourceSetRequest instance...)")]
public async System.Threading.Tasks.Task<ResourceSet> CreateResourceSetAsync(ResourceSet instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
```

```csharp
[Obsolete("This method is obsolete and will be removed in the next major release. Use CreateResourceSetWithHttpInfoAsync(CreateResourceSetRequest instance...)")]
public async System.Threading.Tasks.Task<Okta.Sdk.Client.ApiResponse<ResourceSet>> CreateResourceSetWithHttpInfoAsync(ResourceSet instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
```
### Model updates

`Model.IsRequired` attribute is now `Default` to avoid JSON serialization runtime issues.

## Migrating from 5.x to 6.x

In releases prior to version 6 we use an Open API v2 specification, and an Okta custom client generator to partially generate our SDK. A new version of the Open API specification (V3) has been released, and new well-known generators are now available and well received by the community. Planning the future of this SDK, we consider this a good opportunity to modernize by aligning with established standards for API client generation. 

We acknowledge that migrating from v5 to v6 will require considerable effort, but we expect this change to benefit our customers in the long term.

As it's mentioned above, in previous versions we used an OpenAPI v2 specification with many custom attributes and vendor extensions that required us to implement a custom client generator that should work for all the languages Okta supports. Our process to release support for new APIs and endpoints could have been better since, most of the time we needed to add new APIs, the generator required some adjustments to support new attributes added to the spec. This process caused delays in releases that could be available for our customers sooner.

With OpenAPI v3, we saw an opportunity for improvement in several areas:

* We can provide an API specification that follows the OpenAPI v3 standard and eliminate custom attributes and vendor extensions.
* Given that our specification is now compliant with OASv3, we can use well-known generators used and maintained by the community. In this case, we chose openapi-generator.tech.
* Given that we eliminated custom attributes, we can speed up our release process and let our customers access new APIs sooner. Also, everyone will have access to the OpenAPI specification and will be able to generate their own clients in other languages of their choice.

### OktaClient vs API clients

In releases prior to version 6, you would instantiate a global `OktaClient` and access specific API clients via its properties. Now, each API has its own client and you only instantiate those clients you are interested in:

_Before:_

```csharp

var oktaClient = new OktaClient();
var apps = await oktaClient.Applications.ListApplications().ToListAsync();

```

_Now:_

```csharp
var appApiClient = new ApplicationApi();
var apps = await appApiClient.ListApplications().ToListAsync();
```

> Note: Check out the [SDK tests](https://github.com/okta/okta-sdk-dotnet/tree/master/src/Okta.Sdk.IntegrationTest) to see more 6.x APIs examples.

#### Dependency Injection in ASP.NET Core

In order to implement DI, you have to register your APIs in the Dependency Injection Container:

_Before:_

1- Register your `OktaClient` in the `Startup.cs` or `Program.cs` file.
```csharp
// Startup.cs or Program.cs
// ...
// This sample uses OAuth but you can also use your API Token
builder.Services.AddScoped<IOktaClient>(_ => new OktaClient(
    new Configuration
    {
        OktaDomain = "https://myOktaDomain.com/",
        Scopes = new List<string> { "okta.users.read" },
        ClientId = "CLIENT_ID",
        AuthorizationMode = AuthorizationMode.PrivateKey,
        PrivateKey = new JsonWebKeyConfiguration("JSON_PRIVATE_KEY"),
    }));

var app = builder.Build();

```

2- Inject your `OktaClient` in your controllers or Minimal APIs

```csharp
app.MapGet("/users", async (IOktaClient oktaClient) =>
    {
        return await oktaClient.Users.ListUsers().ToListAsync();
    });

```

_Now:_

1- Register your APIs in the `Startup.cs` or `Program.cs` file.
```csharp
// Startup.cs or Program.cs
// ...
// This sample uses OAuth but you can also use your API Token
builder.Services.AddScoped<IUserApi>(_ => new UserApi(
    new Configuration
    {
        OktaDomain = "https://myOktaDomain.com/",
        Scopes = new HashSet<string> { "okta.users.read" },
        ClientId = "CLIENT_ID",
        AuthorizationMode = AuthorizationMode.PrivateKey,
        PrivateKey = new JsonWebKeyConfiguration("JSON_PRIVATE_KEY"),
    }));

var app = builder.Build();

```

2- Inject your APIs in your controllers or Minimal APIs

```csharp
app.MapGet("/users", async (IUserApi api) =>
    {
        return await api.ListUsers().ToListAsync();
    });

```

> Note: Consider [registering groups of services](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-7.0#register-groups-of-services-with-extension-methods) if you need to configure DI for multiple APIs. 

### Configuration

Unlike previous versions, `ConnectionTimeout`and `RequestTimeout` should now expressed in milliseconds. Also, `Scopes` is now a `HashSet<string>` to avoid duplicated entries.

### Enums

`StringEnums` are still supported. However, format might slightly change depending on the OpenAPI specification and codegen.

### Resource model removed

In previous versions, all models inherited from `Resource` to facilitate the JSON serialization process and manipulate raw data. In series 6.x, this is no longer the case; The SDK now uses the JSON SubTypes dependency. 

### Manipulate Custom Attributes

Models that support dynamic properties now expose the `AdditionalProperties` property:

_Before:_

```csharp
user.Profile["homeworld"] = "Tattooine";
```

_Now:_

```csharp
user.Profile.AdditionalProperties = new Dictionary<string, object>();
user.Profile.AdditionalProperties["homeworld"] = "Planet Earth";
```

### Get data from _links

In previous versions, you had to manipulate raw data via the `Resource` convenience methods to access `Links`. Now, `Links` are exposed are standard properties:

_Before:_

```csharp
var accessPolicyHref = createdApp.GetProperty<Resource>("_links")?
          .GetProperty<Resource>("accessPolicy")?
          .GetProperty<string>("href");
```

_Now:_

```csharp
var accessPolicyHref = createdApp.Links.AccessPolicy.Href;
```

### Cast polymorphic models

In previous versions, the OktaClient provided a generic `Get` method where devs could provide a specifc type to cast a model. Now, you have to cast a model after a `Get` method using `as`:

_Before:_

```csharp
var retrievedApp = await client.Applications.GetApplicationAsync<IBookmarkApplication>(createdApp.Id);
```

_Now:_

```csharp
var retrievedApp = await _applicationApi.GetApplicationAsync(createdApp.Id) as BookmarkApplication;
```

### Handling errors

The now SDK throws an `ApiException` every time the server responds with an invalid status code, or there is an internal error.

_Before:_

```csharp
try
{
    // ...
    var retrievedApp = await client.Applications.GetApplicationAsync<IBookmarkApplication>("unknownId");
}    
catch (OktaApiException apiException)
{
    var message = apiException.Message; //"Not found: Resource not found: foo (AppInstance) (404, E0000007)"
    var statusCode = apiException.StatusCode; //404
    var errorSummary = apiException.ErrorSummary; //"Not found: Resource not found: foo (AppInstance)"
    var errorId = apiException.ErrorId; //"E0000007"
    var errorCode = apiException.ErrorCode; //"E0000007"
}
```

_Now:_

```csharp
try
{
    //...
    var retrievedApp = await _applicationApi.GetApplicationAsync("unknownId") as BookmarkApplication;
}
catch (ApiException apiException)
{
    var message = apiException.Message; //Error calling GetApplication: {"errorCode":"E0000007","errorSummary":"Not found: Resource not found: foo (AppInstance)","errorLink":"E0000007","errorId":"oaeWzp-a2A0TCOm7D0FtnHcbg","errorCauses":[]}
    var statusCode = apiException.ErrorCode; //404
    var errorContent = apiException.ErrorContent; //{"errorCode":"E0000007","errorSummary":"Not found: Resource not found: foo (AppInstance)","errorLink":"E0000007","errorId":"oaeWzp-a2A0TCOm7D0FtnHcbg","errorCauses":[]}
    
    //ErrorId and ErrorCode should be parsed from ErrorContent at the moment, but convenience methods will be added soon. OKTA-555564
}
```

### Features parity

The following features have been ported to 6.x:

* Iniline configuration, configuration via environment variables, appsettings.json or YAML files
* Manual pagination for collections
* Default retry strategy for 429 HTTP responses and ability to provide your own strategy
* Web proxy 
* OAuth for Okta


### Dependencies

We now use [RestSharp](https://restsharp.dev/) as our internal REST API client library unlike previous versions which were using `HttpClient`. For more details about other dependencies, please check out the _Dependencies_ section [here](API_README.md).

### New APIs

In order to provide better structuring, some endpoints have been moved from an existing client/API to their own API client:

_Before:_

```csharp

var oktaClient = new OktaClient();

await oktaClient.Groups.AssignRoleAsync(groupId, new AssignRoleRequest
                {
                    Type = RoleType.UserAdmin,
                });

var roles = await oktaClient.Groups.ListGroupAssignedRoles(createdGroup.Id).ToListAsync();

/// ...

await oktaClient.Groups.AddGroupTargetToGroupAdministratorRoleForGroupAsync(createdGroup1.Id, role.Id, createdGroup2.Id);

var groups = await oktaClient.Groups.ListGroupTargetsForGroupRole(createdGroup1.Id, role.Id).ToListAsync();
```

_Now:_

```csharp
var _roleAssignmentApi = new RoleAssignmentApi();

var role1 = await _roleAssignmentApi.AssignRoleToGroupAsync(createdGroup.Id, new AssignRoleRequest
                {
                    Type = "SUPER_ADMIN"
                });

var roles = await _roleAssignmentApi.ListGroupAssignedRoles(createdGroup.Id).ToListAsync();

/// ...

var _roleTargetApi = new RoleTargetApi();

await _roleTargetApi.AddGroupTargetToGroupAdministratorRoleForGroupAsync(group1.Id, role1.Id, group2.Id);

var groupTargetList = await _roleTargetApi.ListGroupTargetsForGroupRole(createdGroup1.Id, role1.Id).ToListAsync();
```

For more details about other APIs, please check out [here](API_README.md#documentation-for-API-Endpoints).

### Rate Limit

The SDK uses [Polly](https://github.com/App-vNext/Polly) to implement the retry strategy when rate limit has been exceeded. The default retry strategy behavior and the way you configure it remains the same. However, if you want to provide your own retry logic you have to use Polly. Check out the [README](README.md#custom-retry) for more details.


## Migrating from 4.x to 5.x

In previous versions, null resource properties would result in a resource object with all its properties set to `null`. Now, null resource properties will result in `null` property value.

_Before:_

```
{                                                 deserializedResource.Prop1.Should().Be("Hello World!");          
    prop1 : "Hello World!",         =>            deserializedResource.NestedObject.Should().NotBeNull();
    nestedObject: null                            deserializedResource.NestedObject.Prop1.Should().BeNull();
}

```

_Now:_

```
{                                                 deserializedResource.Prop1.Should().Be("Hello World!");          
    prop1 : "Hello World!",         =>            deserializedResource.NestedObject.Should().BeNull();
    nestedObject: null                            
}

```

Since this is a breaking change in the default behavior, the major version of Okta.Sdk was incremented to 5; the latest version is now 5.0.0.

If you were relying on this behavior, make sure to update your code and verify the resource is not `null` before accessing its properties.

## Migrating from 3.x to 4.x

The 3.x series of this library introduced a new client for Authorization Servers. This client had an issue when trying to retrieve policy rules for given Authorization Server Policy. In order to fix this issue, new policy models were created to represent both policies and policy rules for Authorization Servers.

Because this was a breaking change, Okta.Sdk was published with version numbers starting from 4.0.0.

All Authorization Server methods that manipulate Policies and/or Policy Rules have changed:

### `AuthorizationServer`

Below APIs has undergone a signature change.

*  `public ICollectionClient<IPolicy> ListPolicies()` changed to `public ICollectionClient<IAuthorizationServerPolicy> ListPolicies()`
> Note that the method returns now an `IAuthorizationServerPolicy`.

* ` public Task<IPolicy> CreatePolicyAsync(IPolicy policy, CancellationToken cancellationToken = default(CancellationToken))` changed to `public Task<IAuthorizationServerPolicy> CreatePolicyAsync(IAuthorizationServerPolicy policy, CancellationToken cancellationToken = default(CancellationToken))` 

> Note that the method expects and returns now an `IAuthorizationServerPolicy`.

* `public Task<IPolicy> GetPolicyAsync(string policyId, CancellationToken cancellationToken = default(CancellationToken))` changed to `public Task<IAuthorizationServerPolicy> GetPolicyAsync(string policyId, CancellationToken cancellationToken = default(CancellationToken))`

> Note that the method returns now an `IAuthorizationServerPolicy`.

### `AuthorizationServersClient`

Below APIs has undergone a signature change.

* `public ICollectionClient<IPolicy> ListAuthorizationServerPolicies(string authServerId)` changed to `public ICollectionClient<IAuthorizationServerPolicy> ListAuthorizationServerPolicies(string authServerId)`

> Note that the method returns now an `ICollectionClient` of `IAuthorizationServerPolicy`.

* `public async Task<IPolicy> CreateAuthorizationServerPolicyAsync(IPolicy policy, string authServerId, CancellationToken cancellationToken = default(CancellationToken))` change to `public async Task<IAuthorizationServerPolicy> CreateAuthorizationServerPolicyAsync(IAuthorizationServerPolicy policy, string authServerId, CancellationToken cancellationToken = default(CancellationToken))`

> Note that the method expects and returns now an `IAuthorizationServerPolicy`.

* `public async Task<IPolicy> GetAuthorizationServerPolicyAsync(string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken))` changed to `public async Task<IAuthorizationServerPolicy> GetAuthorizationServerPolicyAsync(string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken))`

> Note that the method returns now an `IAuthorizationServerPolicy`.

* ` public async Task<IPolicy> UpdateAuthorizationServerPolicyAsync(IPolicy policy, string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken))` changed to `public async Task<IAuthorizationServerPolicy> UpdateAuthorizationServerPolicyAsync(IAuthorizationServerPolicy policy, string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken))`

> Note that the method expects and returns now an `IAuthorizationServerPolicy`.

You now can get policy rules given an Authorization Server Policy:

```csharp
var authorizationServerPolicy = await authorizationServer.GetPolicyAsync(policy.Id);
var authorizationServerPolicyRules = await authorizationServerPolicy.ListPolicyRules(authorizationServer.Id).ToListAsync();
```

## Migrating from 2.0.0 to 3.x

Version 3.0.0 of this library introduces a number of breaking changes from previous versions; in addition to new classes some class definitions are no longer backward compatible due to method renames and signature changes, see [Breaking Changes](#breaking-changes).

### Breaking Changes

The following is a list of changes that break backward compatibility in version 3.0.0.

**Okta.Sdk.OktaClient**
- `CreatedScoped(Okta.Sdk.RequestContext requestContext)`
<br />&mdash; Renamed `CreateScoped(Okta.Sdk.RequestContext requestContext)`

**Okta.Sdk.GroupsClient**                
- `ListGroups(string q, string filter, string after, int limit, string expand)` 
<br />&mdash; Signature changed `ListGroups(string q, string filter, string after, int limit)`
- `ListRules(int limit, string after, string expand)` 
<br />&mdash; Renamed with new signature `ListGroupRules(int limit, string after, string search, string expand)`
- `CreateRuleAsync(Okta.Sdk.IGroupRule groupRule, CancellationToken cancellationToken)` 
<br />&mdash; Renamed `CreateGroupRuleAsync(Okta.Sdk.IGroupRule groupRule, CancellationToken cancellationToken)`
- `DeleteRuleAsync(string ruleId, bool removeUsers, CancellationToken cancellationToken)` 
<br />&mdash; Renamed with new signature `DeleteGroupRuleAsync(string ruleId, CancellationToken cancellationToken)`
- `GetRuleAsync(string ruleId, string expand, CancellationToken cancellationToken)` 
<br />&mdash; Renamed `GetGroupRuleAsync(string ruleId, string expand, CancellationToken cancellationToken)`
- `UpdateRuleAsync(Okta.Sdk.IGroupRule groupRule, string ruleId, CancellationToken cancellationToken)`
<br />&mdash; Renamed `UpdateGroupRuleAsync(Okta.Sdk.IGroupRule groupRule, string ruleId, CancellationToken cancellationToken)`
- `ActivateRuleAsync(string ruleId, CancellationToken cancellationToken)`
<br />&mdash; Renamed `ActivateGroupRuleAsync(string ruleId, CancellationToken cancellationToken)`
- `DeactivateRuleAsync(string ruleId, CancellationToken cancellationToken)`
<br />&mdash; Renamed `DeactivateGroupRuleAsync(string ruleId, CancellationToken cancellationToken)`
- `GetGroupAsync(string groupId, string expand, CancellationToken cancellationToken)`
<br />&mdash; Signature changed `GetGroupAsync(string groupId, CancellationToken cancellationToken)`
- `ListGroupUsers(string groupId, string after, int limit, string managedBy)`
<br />&mdash; Signature changed `ListGroupUsers(string groupId, string after, int limit)`
- `RemoveGroupUserAsync(string groupId, string userId, CancellationToken cancellationToken)`
<br />&mdash; Renamed `RemoveUserFromGroupAsync(string groupId, string userId, CancellationToken cancellationToken)`

**Okta.Sdk.PoliciesClient**
- `ListPolicies(string type, string status, string after, int limit, string expand)`
<br />&mdash; Signature changed `ListPolicies(string type, string status, string expand)`
- `AddPolicyRuleAsync(Okta.Sdk.IPolicyRule policyRule, string policyId, bool activate, CancellationToken cancellationToken)`
<br />&mdash; Signature changed `AddPolicyRuleAsync(Okta.Sdk.IPolicyRule policyRule, string policyId, CancellationToken cancellationToken)`

**Okta.Sdk.UserFactorsClient**                
- `AddFactorAsync(Okta.Sdk.IFactor factor, string userId, bool updatePhone, string templateId, int tokenLifetimeSeconds, bool activate, CancellationToken cancellationToken)`
<br />&mdash; Renamed with new signature `EnrollFactorAsync(Okta.Sdk.IUserFactor body, string userId, bool updatePhone, string templateId, int tokenLifetimeSeconds, bool activate, CancellationToken ca
ncellationToken)`
- `ActivateFactorAsync(Okta.Sdk.IVerifyFactorRequest verifyFactorRequest, string userId, string factorId, CancellationToken cancellationToken)`
<br />&mdash; Renamed with new signature `ActivateFactorAsync(Okta.Sdk.IActivateFactorRequest body, string userId, string factorId, CancellationToken cancellationToken)`

**Okta.Sdk.UsersClient**
- `ListUsers(string q, string after, int limit, string filter, string format, string search, string expand)`
<br />&mdash; Signature changed `ListUsers(string q, string after, int limit, string filter, string search, string sortBy, string sortOrder)`
- `CreateUserAsync(Okta.Sdk.IUser user, bool activate, bool provider, Okta.Sdk.UserNextLogin nextLogin, CancellationToken cancellationToken)`
<br />&mdash; Signature changed `CreateUserAsync(Okta.Sdk.ICreateUserRequest body, bool activate, bool provider, Okta.Sdk.UserNextLogin nextLogin, CancellationToken cancellationToken)`
- `ListAppLinks(string userId, bool showAll)`
<br />&mdash; Signature changed `ListAppLinks(string userId)`
- `ListUserGroups(string userId, string after, int limit)`
<br />&mdash; Signature changed `ListUserGroups(string userId)`
- `ExpirePasswordAsync(string userId, bool tempPassword, CancellationToken cancellationToken)`
<br />&mdash; Signature changed `ExpirePasswordAsync(string userId, CancellationToken cancellationToken)` 
- `ResetAllFactorsAsync(string userId, CancellationToken cancellationToken)`
<br />&mdash; Renamed `ResetFactorsAsync(string userId, CancellationToken cancellationToken)`
- `ResetPasswordAsync(string userId, Okta.Sdk.AuthenticationProviderType provider, bool sendEmail, CancellationToken cancellationToken)`
<br />&mdash; Removed; instead use any of the following:
  - `ForgotPasswordGenerateOneTimeTokenAsync(string userId, bool sendEmail, CancellationToken cancellationToken)`
  - `ForgotPasswordSetNewPasswordAsync(Okta.Sdk.IUserCredentials user, string userId, bool sendEmail, CancellationToken cancellationToken)`
  - `ExpirePasswordAsync(string userId, CancellationToken cancellationToken)`
  - `ExpirePasswordAndGetTemporaryPasswordAsync(string userId, CancellationToken cancellationToken)`
- `ListAssignedRoles(string userId, string expand)`
<br />&mdash; Renamed `ListAssignedRolesForUser(string userId, string expand)`
- `EndAllUserSessionsAsync(string userId, bool oauthTokens, CancellationToken cancellationToken)`
<br />&mdash; Renamed `ClearUserSessionsAsync(string userId, bool oauthTokens, CancellationToken cancellationToken)`

### New Okta Clients
The following is a list of context specific clients that are new in version 3.0.0. Instances of each are available as properties of an OktaClient instance where the name of the property is the name of the type with the "Client" suffix removed.

- `Okta.Sdk.AuthorizationServersClient`, see [Authorization Servers API](https://developer.okta.com/docs/reference/api/authorization-servers/).
- `Okta.Sdk.EventHooksClient`, see [Event Hooks Management API](https://developer.okta.com/docs/reference/api/event-hooks/).
- `Okta.Sdk.FeaturesClient`, see [Features API](https://developer.okta.com/docs/reference/api/features/).
- `Okta.Sdk.IdentityProvidersClient`, see [Identity Providers API](https://developer.okta.com/docs/reference/api/idps/).
- `Okta.Sdk.InlineHooksClient`, see [Inline Hooks Management API](https://developer.okta.com/docs/reference/api/inline-hooks/).
- `Okta.Sdk.LinkedObjectsClient`, see [Linked Objects API](https://developer.okta.com/docs/reference/api/linked-objects/).
- `Okta.Sdk.TemplatesClient`, see [Custom Templates API](https://developer.okta.com/docs/reference/api/templates/).
- `Okta.Sdk.TrustedOriginsClient`, see [Trusted Origins API](https://developer.okta.com/docs/reference/api/trusted-origins/).
- `Okta.Sdk.UserTypesClient`, see [User Types API](https://developer.okta.com/docs/reference/api/user-types/).



## Migrating from 0.3.3 to 1.x

The previous version of this library, [Okta.Core.Client](https://www.nuget.org/packages/Okta.Core.Client), has been rewritten from the ground up as [Okta.Sdk](https://www.nuget.org/packages/Okta.Sdk) (this project). This was done to improve stability and to add support for .NET Core alongside .NET Framework.

Because this was a breaking change, Okta.Sdk was published with version numbers starting from 1.0. The last published version of Okta.Core.Client is 0.3.3.



### New configuration model

This library now supports a flexible [configuration model](https://github.com/okta/okta-sdk-dotnet#configuration-reference) that allows you to provide configuration in code, via a JSON or YAML file, or via environment variables.

The simplest way to construct a client is via code:

```csharp
var client = new OktaClient(new OktaClientConfiguration
{
    OrgUrl = "https://{{yourOktaDomain}}",
    Token = "{{yourApiToken}}"
});
```

### New method organization

In version 0.3.3, you had to create a `new UsersClient()` or call `client.GetUsersClient()` to get access to methods that operated on a User (for example). This has now been simplified to `client.Users`:

```csharp
var vader = await client.Users.CreateUserAsync(...);
```

The `Users` object acts as a collection, so you can also do:

```csharp
var allUsers = await client.Users.ToArray();
```

The [readme](https://github.com/okta/okta-sdk-dotnet#usage-guide) in this repository contains a number of usage examples.

### Async by default

In version 1.0 and above, every method that makes a network call is Task-returning and awaitable. Use `await` when calling these methods, and avoid using `.Result` or `.Wait()` unless absolutely necessary.

### Authentication API support moved

In version 0.3.3, the `AuthClient` class provided the ability to call the [Authentication API](https://developer.okta.com/docs/api/resources/authn) to log a user in with a username and password, or perform other tasks like enrolling and challenging factors during authentication.  The object and security model of the Authentication API compared the rest of the management APIs (Users, Factors, Groups, etc.) is different enough that it made sense to split it into two libraries.

Starting with version 1.0, Authentication has been broken out into a separate library, the [Okta .NET Authentication SDK](https://github.com/okta/okta-auth-dotnet).

Many applications can use our [ASP.NET and ASP.NET Core middleware](https://github.com/okta/okta-aspnet) to log users in without needing to call the Authentication API directly, and we recommend only using the Authentication SDK in complex scenarios that can't be handled with the middleware or widget.

## Getting help

If you have questions about this library or about the Okta APIs, post a question on our [Developer Forum](https://devforum.okta.com).

If you find a bug or have a feature request for this library specifically, [post an issue](https://github.com/okta/okta-sdk-dotnet/issues) here on GitHub.
