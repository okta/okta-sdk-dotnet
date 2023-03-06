# Changelog
Running changelog of releases since `3.1.1`

## 6.0.6

- Fix ResourceSet API and keep previous interface marked as obsolete for backwards compatibility.

## 6.0.5

- Fix "SDK calls with private key authorization mode start returning empty results after inner access token expired" issue (#616)

## 6.0.4

- Fix "PartialUpdateUserAsync behaves differently in Okta.Sdk v6" issue (#614)
- Ignore null values during JSON serialization.

## 6.0.3

- Fix "Listing IAM roles doesn't work" (#617)

## 6.0.2

- Fix "Pagination not working when using PrivateKey Authorization Mode" issue (#613)

## 6.0.1

- Make `AppUser.PasswordChanged` property nullable (#599)
- Fix "invalid audience" issue (#600)

## 6.0.0

- Add support for StringEnum
- Update OpenAPI spec

## 6.0.0-beta02

- Add support for OAuth for Okta
- Add support for Proxy configuration 
- Add support for dynamic properties

## 6.0.0-beta01

- Update Open API spec to 3.0.0
- Migrate from Okta-custom generator to [openapi-generator.tech/](https://openapi-generator.tech/) 
- Check out the [MIGRATING guide](./MIGRATING.md) for more details about migrating to 6.0.0

## 5.6.2

### Bug Fixes

- Add `search` parameter to `GroupsClient.ListGroups` to align with [documentation](https://developer.okta.com/docs/reference/api/groups/#list-groups)

## 5.6.1

### Bug Fixes

- Pass `HttpClient` to `DefaultOAuthTokenProvider` (#571)


## 5.6.0

- Update Open API spec to 2.12.0
- Add `Application.UpdateApplicationPolicyAsync` method
- Add `APPLE` as a `LogCredentialProvider` option
- Add support for `AllowedOktaApps` in Scopes
- Add `IframeEmbed` as a `ScopeType` option

## v5.5.0

- Add support for [Email template operations](https://developer.okta.com/docs/reference/api/brands/#email-template-operations).

## v5.4.1

### Bug Fixes

- Fix the issue "SDK doesn't retry a call to the server when the token has expired" (PrivateKey mode) (#535)


## v5.4.0

- Add support for [Application provisioning connection operations](https://developer.okta.com/docs/reference/api/apps/#application-provisioning-connection-operations)
- Add suport for [Application features operations](https://developer.okta.com/docs/reference/api/apps/#application-feature-operations)
- Add support for [Org2Org applications](https://developer.okta.com/docs/reference/api/apps/#add-okta-org2org-application).

## v5.3.2

### Bug Fixes

- Fix Unable to create OktaClient on linux build server after 5.2.1 upgrade. (#526)


## v5.3.1

### Features

- Add `VerifyUserFactorResponse.GetTransactionId` method to simplify access to the transaction ID of the `VerifyUserFactorResponse` where appropriate. The transaction ID is further used with the `GetFactorTransactionStatusAsync` operation. See [Issue a Push Factor challenge](https://developer.okta.com/docs/reference/api/factors/#issue-a-push-factor-challenge) for details. (#507)


## v5.3.0

### Features

- Add ability to use pre-requested access tokens for authentication (#508)
- Regenerate code using the [open API spec v2.9.2](https://github.com/okta/okta-management-openapi-spec/releases/tag/openapi-2.9.2)
- Add new models and operations to support [Brands API's endpoints](https://developer.okta.com/docs/reference/api/brands/)
- Add new models and operations to support [OIE policies](https://developer.okta.com/docs/reference/api/policy/)

### Updates

- `Group.AssignRoleAsync(IAssignRoleRequest assignRoleRequest, string disableNotifications, CancellationToken cancellationToken = default(CancellationToken));` is not marked as obsolete. Use `Group.AssignRoleAsync(IAssignRoleRequest assignRoleRequest, bool? disableNotifications = null, CancellationToken cancellationToken = default(CancellationToken));` instead.
- `UsersClient. AssignRoleToUserAsync(IAssignRoleRequest assignRoleRequest, string userId, string disableNotifications, CancellationToken cancellationToken = default(CancellationToken));` is not marked as obsolete. Use `UsersClient. AssignRoleToUserAsync(IAssignRoleRequest assignRoleRequest, string userId, bool? disableNotifications = null, CancellationToken cancellationToken = default(CancellationToken));` instead.


## v5.2.1

### Update

- Remove FlexibleConfiguration dependency and use .NET Configuration Providers instead.


## v5.2.0

### Features

- Regenerate code using the [open API spec v2.6.0](https://github.com/okta/okta-management-openapi-spec/releases/tag/openapi-2.6.0)
- Add new models and operations to support the following:
* [Domains API's endpoints](https://developer.okta.com/docs/reference/api/domains/)
* [Zones API's endpoints](https://developer.okta.com/docs/reference/api/zones/)
* [Mappings API's endpoints](https://developer.okta.com/docs/reference/api/mappings/)
* [ThreatInsight configuration API's endpoints](https://developer.okta.com/docs/reference/api/threat-insight/)
* [Authenticators API's endpoints](https://developer.okta.com/docs/reference/api/authenticators-admin/)
* [Org API's endpoints](https://developer.okta.com/docs/reference/api/org/)
* [GroupSchema API's endpoints](https://developer.okta.com/docs/reference/api/schemas/#group-schema-operations)
- Add an overload for `GroupsClient.DeleteGroupRuleAsync` method. Now you can specify `removeUsers` parameter indicating whether to keep or remove users from groups assigned by this rule.


### Bug Fixes

- Fix GroupsClient.ListGroups `filter` parameter doesn't work. Replaced with `search` parameter.
- Fix AuthorizationServerPolicyRule.ActivateAsync doesn't work.

## v5.1.1

### Features

* Change JWT Expiration time - 50 minutes will be used in order to have a 10 minutes leeway in case of clock skew.

## v5.1.0

### Features

- Update dependencies

* `FlexibleConfiguration 1.2.2 -> 2.0.0`
* `Microsoft.Extensions.Logging 3.1.1 -> 5.0.0`
* `System.IdentityModel.Tokens.Jwt 5.6.0 -> 6.11.1`
* `Newtonsoft.Json 12.0.3 -> 13.0.1`
* `System.Interactive.Async 4.0.0 -> 5.0.0`

## v5.0.0

### Features

- Regenerate code using the [open API spec v2.3.0](https://github.com/okta/okta-management-openapi-spec/releases/tag/openapi-2.3.0).
- Add new models and operations to support all the [UserSchema API's endpoints](https://developer.okta.com/docs/reference/api/schemas/).

_New models:_

* UserSchema
* UserSchemaAttribute
* UserSchemaAttributeMaster
* UserSchemaAttributePermission
* UserSchemaBase
* UserSchemaBaseProperties
* UserSchemaDefinitions
* UserSchemaPublic
* UserSchemasClient

### Breaking changes

- [Change in default behavior when serializing resources (JSON objects)](https://github.com/okta/okta-sdk-dotnet/pull/477/files#diff-6436f2d9902dcaed04626994e79b8c0da031d73e6ff937b1ec1014544228a5feR319). Previously, null resource properties would result in a resource object with all its properties set to `null`. Now, null resource properties would result in `null` property value. 

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


## v4.0.0

### Features

- Add new models for [Authorization Server Policies and Policy Rules](https://developer.okta.com/docs/reference/api/authorization-servers/#authorization-server-operations)

### Bug Fixes

- Fix AuthorizationServer.Policy.ListPolicyRules 404 error (#415). This fix requires a breaking change.
- Fix "New IApplication.Profile doesn't save when empty" issue (#319).

## v3.2.1

### Features

- Regenerate code using openapi 2.1.6
- Add `RefreshToken` property to `OpenIdConnectApplicationSettingsClient`
- Add `Jwks` property to `OpenIdConnectApplicationSettingsClient`

### Additions

- New models:  `OpenIdConnectRefreshTokenRotationType` and `OpenIdConnectApplicationSettingsRefreshToken`

### Bug Fixes

- Add `expand` property back to `GroupsClient.ListGroups` method (#447)

## v3.2.0

### Features

- Add helper method to create users with imported hashed password (#402)
- Add helper methods to create policy rules (#287)

### Bug Fixes

- Add `TryGetHomePath` method to avoid throwing an exception if HOME environment variable is missing (#316)

### Documentation

- Fix code samples in the README file.

## v3.1.1

### Bug Fixes

- Expose `TrustedOrigins` client in the `OktaClient` (#413)
