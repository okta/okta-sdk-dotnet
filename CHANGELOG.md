# Changelog
Running changelog of releases since `3.1.1`

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

## Breaking changes

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
