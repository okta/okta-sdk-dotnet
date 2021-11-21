# Okta .NET management SDK migration guide

This library uses semantic versioning and follows Okta's [library version policy](https://developer.okta.com/code/library-versions/). In short, we don't make breaking changes unless the major version changes!

## Migrating from 5.x to 6.x

Changed default behaviour of `User` object.  Previously `null` properties were omitted from the payload for Add support for null User object property values. Now it's possible to remove properties, for example, the second email, by setting it to null like the following:

```csharp
    userProfile["secondEmail"] = null;
```

This will be included in the request payload. Previously, all null values were stripped from the payload. 


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
