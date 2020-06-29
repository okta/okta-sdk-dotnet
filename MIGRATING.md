# Okta .NET management SDK migration guide

This library uses semantic versioning and follows Okta's [library version policy](https://developer.okta.com/code/library-versions/). In short, we don't make breaking changes unless the major version changes!

## Migrating to 3.0

Version 3.0 of this library introduces a number of breaking changes from previous versions; in addition to new classes some class definitions are no longer backward compatible due to method renames and signature changes, see [Breaking Changes](#breaking-changes).

### Breaking Changes

The following is a list of changes that break backward compatibility in version 3.0.

**Okta.Sdk.OktaClient**
- `CreatedScoped(Okta.Sdk.RequestContext requestContext)`
<br />&mdash; Renamed `CreateScoped(Okta.Sdk.RequestContext requestContext)`

**Okta.Sdk.GroupsClient**                
- `ListGroups(String q,String filter,String after,Int32 limit,String expand)` 
<br />&mdash; Signature changed `ListGroups(String q,String filter,String after,Int32 limit)`
- `ListRules(Int32 limit,String after,String expand)` 
<br />&mdash; Renamed with new signature `ListGroupRules(Int32 limit,String after,String search,String expand)`
- `CreateRuleAsync(Okta.Sdk.IGroupRule groupRule,CancellationToken cancellationToken)` 
<br />&mdash; Renamed `CreateGroupRuleAsync(Okta.Sdk.IGroupRule groupRule,CancellationToken cancellationToken)`
- `DeleteRuleAsync(String ruleId,Boolean removeUsers,CancellationToken cancellationToken)` 
<br />&mdash; Renamed with new signature `DeleteGroupRuleAsync(String ruleId,CancellationToken cancellationToken)`
- `GetRuleAsync(String ruleId,String expand,CancellationToken cancellationToken)` 
<br />&mdash; Renamed `GetGroupRuleAsync(String ruleId,String expand,CancellationToken cancellationToken)`
- `UpdateRuleAsync(Okta.Sdk.IGroupRule groupRule,String ruleId,CancellationToken cancellationToken)`
<br />&mdash; Renamed `UpdateGroupRuleAsync(Okta.Sdk.IGroupRule groupRule,String ruleId,CancellationToken cancellationToken)`
- `ActivateRuleAsync(String ruleId,CancellationToken cancellationToken)`
<br />&mdash; Renamed `ActivateGroupRuleAsync(String ruleId,CancellationToken cancellationToken)`
- `DeactivateRuleAsync(String ruleId,CancellationToken cancellationToken)`
<br />&mdash; Renamed `DeactivateGroupRuleAsync(String ruleId,CancellationToken cancellationToken)`
- `GetGroupAsync(String groupId,String expand,CancellationToken cancellationToken)`
<br />&mdash; Signature changed `GetGroupAsync(String groupId,CancellationToken cancellationToken)`
- `ListGroupUsers(String groupId,String after,Int32 limit,String managedBy)`
<br />&mdash; Signature changed `ListGroupUsers(String groupId,String after,Int32 limit)`
- `RemoveGroupUserAsync(String groupId,String userId,CancellationToken cancellationToken)`
<br />&mdash; Renamed `RemoveUserFromGroupAsync(String groupId,String userId,CancellationToken cancellationToken)`

**Okta.Sdk.PoliciesClient**
- `ListPolicies(String type,String status,String after,Int32 limit,String expand)`
<br />&mdash; Signature changed `ListPolicies(String type,String status,String expand)`
- `AddPolicyRuleAsync(Okta.Sdk.IPolicyRule policyRule,String policyId,Boolean activate,CancellationToken cancellationToken)`
<br />&mdash; Signature changed `AddPolicyRuleAsync(Okta.Sdk.IPolicyRule policyRule,String policyId,CancellationToken cancellationToken)`

**Okta.Sdk.UserFactorsClient**                
- `AddFactorAsync(Okta.Sdk.IFactor factor,String userId,Boolean updatePhone,String templateId,Int32 tokenLifetimeSeconds,Boolean activate,CancellationToken cancellationToken)`
<br />&mdash; Renamed with new signature `EnrollFactorAsync(Okta.Sdk.IUserFactor body,String userId,Boolean updatePhone,String templateId,Int32 tokenLifetimeSeconds,Boolean activate,CancellationToken ca
ncellationToken)`
- `ActivateFactorAsync(Okta.Sdk.IVerifyFactorRequest verifyFactorRequest,String userId,String factorId,CancellationToken cancellationToken)`
<br />&mdash;Renamed with new signature `ActivateFactorAsync(Okta.Sdk.IActivateFactorRequest body,String userId,String factorId,CancellationToken cancellationToken)`

**Okta.Sdk.UsersClient**
- `ListUsers(String q,String after,Int32 limit,String filter,String format,String search,String expand)`
<br />&mdash; Signature changed `ListUsers(String q,String after,Int32 limit,String filter,String search,String sortBy,String sortOrder)`
- `CreateUserAsync(Okta.Sdk.IUser user,Boolean activate,Boolean provider,Okta.Sdk.UserNextLogin nextLogin,CancellationToken cancellationToken)`
<br />&mdash; Signature changed `CreateUserAsync(Okta.Sdk.ICreateUserRequest body,Boolean activate,Boolean provider,Okta.Sdk.UserNextLogin nextLogin,CancellationToken cancellationToken)`
- `ListAppLinks(String userId,Boolean showAll)`
<br />&mdash; Signature changed `ListAppLinks(String userId)`
- `ListUserGroups(String userId,String after,Int32 limit)`
<br />&mdash; Signature changed `ListUserGroups(String userId)`
- `ExpirePasswordAsync(String userId,Boolean tempPassword,CancellationToken cancellationToken)`
<br />&mdash; Signature changed `ExpirePasswordAsync(String userId,CancellationToken cancellationToken)` 
- `ResetAllFactorsAsync(String userId,CancellationToken cancellationToken)`
<br />&mdash; Renamed `ResetFactorsAsync(String userId,CancellationToken cancellationToken)`
- `ResetPasswordAsync(String userId,Okta.Sdk.AuthenticationProviderType provider,Boolean sendEmail,CancellationToken cancellationToken)`
<br />&mdash; Removed; instead use any of the following:
  - `ForgotPasswordGenerateOneTimeTokenAsync(String userId,Boolean sendEmail,CancellationToken cancellationToken)`
  - `ForgotPasswordSetNewPasswordAsync(Okta.Sdk.IUserCredentials user,String userId,Boolean sendEmail,CancellationToken cancellationToken)`
  - `ExpirePasswordAsync(String userId,CancellationToken cancellationToken)`
  - `ExpirePasswordAndGetTemporaryPasswordAsync(String userId,CancellationToken cancellationToken)`
- `ListAssignedRoles(String userId,String expand)`
<br />&mdash; Renamed `ListAssignedRolesForUser(String userId,String expand)`
- `EndAllUserSessionsAsync(String userId,Boolean oauthTokens,CancellationToken cancellationToken)`
<br />&mdash; Renamed `ClearUserSessionsAsync(String userId,Boolean oauthTokens,CancellationToken cancellationToken)`

### New Okta Clients
The following is a list of context specific clients that are new in version 3.0.  Instances of each are available as properties of an OktaClient instance where the name of the property is the name of the type with the "Client" suffix removed.

- `Okta.Sdk.AuthorizationServersClient`, see [Authorization Servers](https://developer.okta.com/docs/reference/api/authorization-servers/).
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
