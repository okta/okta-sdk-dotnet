# Changelog
Running changelog of releases since `3.1.1`

## 10.0.3

### Bug Fixes

| Issue | Problem | Fix |
|-------|---------|-----|
| - | JWK deserialization fails when `use` is null | Handle null `use` in `ApplicationJsonConverter` to avoid oneOf discriminator errors |
| [#852](https://github.com/okta/okta-sdk-dotnet/issues/852) | DPoP token uses malformed `htm` claim (PascalCase instead of uppercase) | Fixed to use `.ToUpperInvariant()` for RFC 9449 compliance |
| [#850](https://github.com/okta/okta-sdk-dotnet/issues/850) | `ReplaceAuthorizationServerPolicyRuleAsync` fails with malformed request body | Initialize `Type` to `RESOURCE_ACCESS` by default in `AuthorizationServerPolicyRuleRequest` |
| [#849](https://github.com/okta/okta-sdk-dotnet/issues/849) | `ExpirePasswordWithTempPasswordAsync` returns `User` instead of `TempPassword` | Fixed return type to `TempPassword` containing the temporary password |

### Changes

- Added comprehensive unit and integration tests for Authentication & Authorization APIs
- Test coverage includes: AuthenticatorApi, AuthorizationServerApi, OAuth2ResourceServerCredentialsKeysApi, WebAuthnPreregistrationApi

## 10.0.2

### Bug Fixes

| Issue | Problem | Fix |
|-------|---------|-----|
| [#846](https://github.com/okta/okta-sdk-dotnet/issues/846) | Unable to set OIDC protocol's issuer | Added `Issuer` property to `ProtocolOidc` |
| [#836](https://github.com/okta/okta-sdk-dotnet/issues/836) | `ListApplications` returns 0 results (JWK deserialization) | Added discriminators to JWK oneOf schemas |
| [#834](https://github.com/okta/okta-sdk-dotnet/issues/834) | Inline Hook deserialise fails for Refresh Token | Added `policy` and `identity` properties to `BaseContext.user` |
| [#833](https://github.com/okta/okta-sdk-dotnet/issues/833) | `GenerateResetPasswordTokenAsync` missing | Updated migration guide for renamed methods |
| [#832](https://github.com/okta/okta-sdk-dotnet/issues/832) | Error reading `SamlAttributeStatement` | Added discriminator-based lookup for anyOf schemas |
| [#831](https://github.com/okta/okta-sdk-dotnet/issues/831) | `ListApplications` fails with `InvalidDataException` | Fixed JWK key schema deserialization |
| [#827](https://github.com/okta/okta-sdk-dotnet/issues/827) | Error reading user role assignments | Added discriminators to `StandardRole`/`CustomRole` oneOf schemas |
| [#826](https://github.com/okta/okta-sdk-dotnet/issues/826) | Error reading applications with JWKS keys | Added `alg` and `use` properties to `OAuth2ClientJsonWebKey` |
| [#825](https://github.com/okta/okta-sdk-dotnet/issues/825) | DPoP `htu` claim using template path causing 400 errors | Fixed to use expanded request URL |
| [#822](https://github.com/okta/okta-sdk-dotnet/issues/822) | Groups missing the `Source` property | Added `Source` property to `Group` |
| [#821](https://github.com/okta/okta-sdk-dotnet/issues/821) | Cannot read Active Directory app | Added `ActiveDirectoryApplication` for null `signOnMode` handling |
| [#820](https://github.com/okta/okta-sdk-dotnet/issues/820) | `Application` class missing `Name` property | Added `Name` property to base `Application` class |
| [#811](https://github.com/okta/okta-sdk-dotnet/issues/811) | OIDC and SWA app settings not accessible | Added `app` property to OIDC, SAML, AutoLogin, and SWA application settings |
| [#792](https://github.com/okta/okta-sdk-dotnet/issues/792) | Application `settings.app` data lost during deserialization | Fixed application settings deserialization |
| [#790](https://github.com/okta/okta-sdk-dotnet/issues/790) | `ProtocolSaml` missing `oktaIdpOrgUrl` property | Added `oktaIdpOrgUrl` to `ProtocolSaml` schema |
| [#838](https://github.com/okta/okta-sdk-dotnet/issues/838) | `ListIdentityProviders` returns empty result set | Added discriminator to `IdentityProviderProtocol` oneOf schema |
| [#824](https://github.com/okta/okta-sdk-dotnet/issues/824) | RestSharp v113 compatibility (`MaxTimeout` removed) | Replaced deprecated `MaxTimeout` with `Timeout` |

### Changes

- Fixed 351 build warnings in mustache templates
- Updated NuGet packages to latest compatible versions
- Upgraded test projects to .NET 10
- Moved artifact publishing to internal pipeline

## 10.0.1

### Bug Fixes

This release fixes 7 issues caused by OpenAPI spec mismatches with actual Okta API responses.

| Issue | Problem | Fix |
|-------|---------|-----|
| [#819](https://github.com/okta/okta-sdk-dotnet/issues/819) | `GetUserAsync` returns `UserGetSingleton` instead of `User` | Changed response type to `User`, removed `UserGetSingleton` schema |
| [#816](https://github.com/okta/okta-sdk-dotnet/issues/816) | `OriginalGrant.Request` always null in Token Inline Hooks | Renamed property from `request` to `authorization` |
| [#815](https://github.com/okta/okta-sdk-dotnet/issues/815) | `Group.Profile.AdditionalProperties` missing | Added `additionalProperties: true` to group profile schemas |
| [#814](https://github.com/okta/okta-sdk-dotnet/issues/814) | JSON parsing errors silently swallowed in List methods | Skip `oneOf`/`anyOf` deserialization for error responses |
| [#812](https://github.com/okta/okta-sdk-dotnet/issues/812) | `ListGroups()` returns empty for AD-synced groups | Added `objectClass` discriminator with custom `GroupJsonConverter` |
| [#808](https://github.com/okta/okta-sdk-dotnet/issues/808) | `ListAgentPools()` fails with JSON error | Changed `lastConnection` from `date-time` to `int64` |
| [#807](https://github.com/okta/okta-sdk-dotnet/issues/807) | `ListRolesForClientAsync` returns null | Changed response from single object to `IOktaCollectionClient<>` |

### Changes

#### OpenAPI Spec Corrections
- Fixed `getUser` response type from `UserGetSingleton` to `User`
- Fixed `TokenPayLoadDataContextAllOfProtocolOriginalGrant.request` → `authorization`
- Added `additionalProperties: true` to `OktaUserGroupProfile` and `OktaActiveDirectoryGroupProfile`
- Fixed `Agent.lastConnection` type from `date-time` string to `int64` (Unix timestamp)
- Fixed `listRolesForClient` response from single object to array

#### Custom Code Additions
- `GroupJsonConverter.cs`: Template-based converter using `objectClass` discriminator for group profile polymorphism
- `AbstractOpenAPISchema.cs`: Skip polymorphic deserialization for error responses to properly propagate `ApiException`

### Tests Added
- Unit tests for all deserialization fixes
- Integration tests: `GroupApiTests`, `AgentPoolsApiTests`, `RoleAssignmentClientApiTests`

## 10.0.0

### Breaking Changes

This is a major release with significant architectural improvements. Several large API clients have been split into specialized, focused clients for better maintainability and discoverability.

> **Migration Guide**: Please refer to [MIGRATION_GUIDE_v10.0.0.md](MIGRATION_GUIDE_v10.0.0.md) for comprehensive method-level mappings and [MIGRATING.md](MIGRATING.md) for migration examples.

### API Reorganization

#### UserApi Split (Major Change)
The monolithic `UserApi` has been refactored into specialized clients:
- **UserApi** - Core CRUD operations (CreateUser, GetUser, UpdateUser, DeleteUser, ListUsers)
- **UserLifecycleApi** - User lifecycle operations (Activate, Deactivate, Suspend, Unsuspend, Unlock, Reactivate)
- **UserCredApi** - Credential management (ChangePassword, ExpirePassword, ForgotPassword, ResetPassword, SetPassword)
- **UserGrantApi** - User grant operations (GetUserGrant, ListUserGrants, RevokeUserGrant)
- **UserOAuthApi** - OAuth token operations (ListGrantsForUserAndClient, RevokeGrantsForUserAndClient, Refresh tokens)
- **UserSessionsApi** - Session management (ClearUserSessions, ListUserSessions, GetUserSession, RevokeUserSession)
- **UserLinkedObjectApi** - Linked object operations (SetLinkedObject, DeleteLinkedObject, ListLinkedObjects)
- **UserResourcesApi** - User resources (ListAppLinks, ListAssignedApplications, ListAppTargets)
- **UserAuthenticatorEnrollmentsApi** - Authenticator enrollments (ListEnrollments, GetEnrollment, ResetEnrollment)
- **UserClassificationApi** - User classification (GetClassification, UpdateClassification)
- **UserRiskApi** - User risk operations (GetUserRisk, UpdateUserRisk)

#### OrgSettingApi Split
Organization settings divided into focused clients:
- **OrgSettingGeneralApi** - General org settings
- **OrgSettingAdminApi** - Admin settings
- **OrgSettingCommunicationApi** - Communication preferences
- **OrgSettingContactApi** - Contact information
- **OrgSettingCustomizationApi** - Customization settings
- **OrgSettingMetadataApi** - Organization metadata
- **OrgSettingSupportApi** - Support settings (GrantOktaSupport, RevokeOktaSupport, ExtendOktaSupport)

#### RoleApi Split
Role management reorganized into specialized clients:
- **RoleAssignmentAUserApi** - User role assignments (AssignRoleToUser, ListUserRoles, UnassignRoleFromUser)
- **RoleAssignmentBGroupApi** - Group role assignments (AssignRoleToGroup, ListGroupRoles, UnassignRoleFromGroup)
- **RoleAssignmentClientApi** - Client role assignments (AssignRoleToClient, ListClientRoles, UnassignRoleFromClient)
- **RoleBTargetAdminApi** - Admin role targets
- **RoleBTargetBGroupApi** - Group role targets
- **RoleBTargetClientApi** - Client role targets
- **RoleECustomApi** - Custom role management (CreateCustomRole, ListCustomRoles, DeleteCustomRole)
- **RoleECustomPermissionApi** - Custom role permissions

#### ResourceSetApi Split
Resource set operations moved to role-based clients:
- **RoleCResourceSetApi** - Resource set CRUD operations
- **RoleCResourceSetResourceApi** - Resource set resource operations
- **RoleDResourceSetBindingApi** - Resource set binding operations
- **RoleDResourceSetBindingMemberApi** - Resource set binding member operations

### New API Clients (29 Total)

#### Application APIs
- **ApplicationCrossAppAccessConnectionsApi** - Manage cross-app access connections
- **ApplicationSSOCredentialKeyApi** - Manage SSO credential keys
- **ApplicationSSOFederatedClaimsApi** - Manage SSO federated claims
- **ApplicationSSOPublicKeysApi** - Manage SSO public keys

#### Device Management APIs
- **DeviceAccessApi** - Device access policies
- **DeviceIntegrationsApi** - Device integrations
- **DevicePostureCheckApi** - Device posture checks

#### Identity Provider APIs
- **IdentityProviderKeysApi** - Identity provider keys
- **IdentityProviderSigningKeysApi** - Identity provider signing keys
- **IdentityProviderUsersApi** - Identity provider users

#### Other New APIs
- **AssociatedDomainCustomizationsApi** - Associated domain customizations
- **EmailCustomizationApi** - Email customizations
- **GovernanceBundleApi** - Governance bundles
- **GroupPushMappingApi** - Group push mappings
- **GroupRuleApi** - Group rules
- **OAuth2ResourceServerCredentialsKeysApi** - OAuth2 resource server credential keys
- **OktaPersonalSettingsApi** - Okta personal settings
- **OrgCreatorApi** - Organization creators
- **ServiceAccountApi** - Service account management
- **WebAuthnPreregistrationApi** - WebAuthn preregistration

### Changed

#### ApplicationApi
- `ListApplications()` - Added optional `useOptimization` parameter for improved performance

#### UserApi
- `GetUserAsync()` - Added optional `contentType` parameter
- `ListUsers()` - Added optional `contentType` parameter

### Removed

#### ApplicationCredentialsApi
- **Entire API removed** - Credential-related operations may be available through `ApplicationSSOApi` and related SSO APIs

### Fixed

- Improved API organization for better discoverability
- Enhanced separation of concerns with focused API clients
- Reduced complexity with smaller, maintainable API surfaces

### Benefits

- **Better Organization**: Related operations grouped logically
- **Improved Maintainability**: Smaller, focused API clients
- **Enhanced Discoverability**: Clear API naming indicates purpose
- **Easier Testing**: Focused clients are simpler to mock and test
- **Reduced Complexity**: Smaller surface area per client

### Unchanged APIs (60+)

The majority of API clients remain unchanged with identical method signatures:
`AgentPoolsApi`, `ApiServiceIntegrationsApi`, `ApiTokenApi`, `ApplicationConnectionsApi`, `ApplicationFeaturesApi`, `ApplicationGrantsApi`, `ApplicationGroupsApi`, `ApplicationLogosApi`, `ApplicationPoliciesApi`, `ApplicationSSOApi`, `ApplicationTokensApi`, `ApplicationUsersApi`, `AttackProtectionApi`, `AuthenticatorApi`, `AuthorizationServerApi`, `AuthorizationServerAssocApi`, `AuthorizationServerClaimsApi`, `AuthorizationServerClientsApi`, `AuthorizationServerKeysApi`, `AuthorizationServerPoliciesApi`, `AuthorizationServerRulesApi`, `AuthorizationServerScopesApi`, `BehaviorApi`, `BrandsApi`, `CAPTCHAApi`, `CustomDomainApi`, `CustomPagesApi`, `CustomTemplatesApi`, `DeviceApi`, `DeviceAssuranceApi`, `DirectoriesIntegrationApi`, `EmailDomainApi`, `EmailServerApi`, `EventHookApi`, `FeatureApi`, `GroupApi`, `GroupOwnerApi`, `HookKeyApi`, `IdentityProviderApi`, `IdentitySourceApi`, `InlineHookApi`, `LinkedObjectApi`, `LogStreamApi`, `NetworkZoneApi`, `OAuthApi`, `OktaApplicationSettingsApi`, `PolicyApi`, `PrincipalRateLimitApi`, `ProfileMappingApi`, `PushProviderApi`, `RateLimitSettingsApi`, `RealmApi`, `RealmAssignmentApi`, `RiskEventApi`, `RiskProviderApi`, `SchemaApi`, `SessionApi`, `SSFReceiverApi`, `SSFSecurityEventTokenApi`, `SSFTransmitterApi`, `SubscriptionApi`, `SystemLogApi`, `TemplateApi`, `ThemesApi`, `ThreatInsightApi`, `TrustedOriginApi`, `UISchemaApi`, `UserFactorApi`, `UserTypeApi`

## 9.2.3
- Fix runtime crash on .NET 8 by adding Microsoft.Bcl.AsyncInterfaces v8.0.0 as explicit dependency (#787)
- fix: make private key optional again after DPoP changes mistakenly required it by default

## 9.2.2
- Fix DPoP Proof Generation (#758)
- Fix: Resolve transient dependency conflict with Microsoft.IdentityModel.Protocols in JwtBearer authentication (#745)

## 9.2.1
- Fix environment-specific appsettings not being honored (#656)
- Fix ListFactors API to return correct fields for webauthn factors (#779)
- Updated System.Text.Json in Okta.Sdk.Extensions

## 9.2.0
Provide Interceptor Support

## 9.1.2
### Fixed
- Fixed deserialization issue in `ListFactors` where Security Question and SMS factors were missing or incorrectly mapped.
- Ensured `FactorType` is correctly inherited from the base `UserFactor` class. (#771)

## 9.1.0
## Fixed
- GetUser method now returns `User` instead of `UserGetSingleton`.  

> While this is technically a breaking change, the existence and use of `UserGetSingleton` was an obvious mistake rendering the method unusable, hence the minor version increment instead of major version increment.

## 9.0.4
### Fixed
- Handling of Multiple Scopes in Okta .NET SDK v9 (#753)

## 9.0.3
### Fixed
- CreateFederatedUser creates federated user instead of user in pending activation state
- Change Office365ApplicationSettings.App to dictionary

## 9.0.1
### Fixed
- AuthorizationServerPolicy model definition
- AppLink model definition

## 9.0.0
### Fixed

- Factors Api doesn't return factors setup on users (#650)
- AppAndInstanceConditionEvaluatorAppOrInstance ID property setter is private (#718)
- PolicyRule does not allow a null Priority to be specified. (#719)

### Changed

- ApiTokenApi
  - ListApiTokens
    - parameters removed.
- ApplicationTokensApi
  - ListOAuth2TokensForApplication
    - return type OAuth2Token changed to OAuth2RefreshToken.
  - GetOAuth2TokenForApplication
    - return type OAuth2Token changed to OAuth2RefreshToken.
- ApplicationUsersApi
  - AssignUserToApplication
    - parameter of type AppUser changed to AppUserAssignRequest.
  - UpdateApplicationUser
    - parameter of type AppUser changed to AppUserUpdateRequest.
- AuthenticatorApi
  - ListAuthenticators
    - return type Authenticator changed to AuthenticatorBase
- AuthorizationServerKeysApi
  - ListAuthorizationServerKeys
    - return type collection of JsonWebKey changed to collection of AuthorizationServerJsonWebKey.
  - RotateAuthorizationServerKeys
    - return type collection of JsonWebKey changed to collection of AuthorizationServerJsonWebKey.
- CustomTemplatesApi
  - ListEmailTemplates
    - return type EmailTemplate changed to EmailTemplateResponse.
  - GetEmailTemplate
    - return type EmailTemplate changed to EmailTemplateResponse.
  - GetEmailSettings
    - return type EmailSettings changed to EmailSettingsResponse.
- ThemesApi
  - ReplaceBrandTheme
    - parameter of type Theme changed to UpdateThemeRequest
- DeviceApi
  - ListDevices
    - return type collection of Device changed to collection of DeviceList.
- ApplicationConnectionsApi
  - GetDefaultProvisioningConnectionForApplication
    - return type ProvisioningConnection changed to ProvisioningConnectionResponse
  - UpdateDefaultProvisioningConnectionForApplication
    - return type ProvisioningConnection changed to ProvisioningConnectionResponse
- AuthenticatorApi methods that previously returned Authenticator now return AuthenticatorBase.
- GroupApi
  - ListGroupUsers
    - return type collection of User changed to collectio of GroupMember.
- RealmApi
  - CreateRealm
    - parameter of type Realm changed to CreateRealmRequest.
- UserFacorApi
  - ResendEnrollFactor 
    - parameter of type UserFactor changed to ResendUserFactor.
    - return type UserFactor changed to ResendUserFactor.
  - GetFactorTransactionStatus
    - return type VerifyUserFactorResponse changed to UserFactorPushTransaction 
  - VerifyFactor
    - parameter of type VerifyFactorRequest changed to UserFactorVerifyRequest
    - return type VerifyUserFactorResponse changed to UserFactorVerifyResponse 

### Moved

- AuthorizationServerApi functionality is now broken out into more specific API classes.
- GroupOwnerApi contains functionality previously in GroupsApi.

### Replaced

- CustomizationApi is replaced by CustomTemplatesApi, CusomPagesApi and BrandsApi.
- RealmApi.UpdateRealm is replaced by RealmApi.ReplaceRealm.
- ProvisioningConnection is replaced by ProvisioningConnectionRequest & ProvisioningConnectionResponse.
- VerifyFactorRequest is replaced by UserFactorVerifyRequest
- VerifyUserFactorResponse is replaced by UserFactorVerifyResponse 

### Removed
- SchemaApi methods removed:
  - GetAppUISchemaLinksAsync
- UserApi methods removed:
  - SetLinkedObjectForUser

### Added

- ApiTokenApi methods added:
  - UpsertApiToken
- ApplicationConnectionsApi methods added:
  - VerifyProvisioningConnectionForApplication
- AuthorizationAssocApi is a new API to maange authorization server associations.
- AuthorizationServerClaimsApi is a new API to manage authorization server claims.
- AuthroziationServerClientsApi is a new API to manage authorization server clients.
- AuthorizationServerKeysApi is a new API to manage authorization server keys.
- AuthorizationServerPoliciesApi is a new API to manage authorization server policies.
- AuthorizationServerRulesApi is a new API to manage authorization server rules.
- AuthorizationServerScopesApi is a new API to manage authorization server scopes.
- ApplicationGroupsApi methods added:
  - UpdateGroupAssignmentToApplication overload accepting a list of JsonPathOperation objects.
- BrandsApi is a new API to manage brands.
- CustomTemplatesApi is new API to manage custom templates.
- CustotmPagesApi is new API to manage custom pages.
- DirectoriesIntegrationApi is a new API to manage AD integrations.
- GroupOwnerApi is a new API to manage group owners.
- InlineHookApi methods added:
  - UpdateInlineHook
- OktaApplicationSettingsApi is a new API to manage Okta application settings.
- ThemesApi is a new API to manage themes.
- OrgSettingApi methods added:
  - GetThirdPartyAdminSetting
  - UpdateThirdPartyAdminSetting
  - GetClientPrivilegesSetting
  - AssignClientPrivilegesSetting
- RealAssignmentApi is a new API to manage realm assignments.
- SSFReceiverApi is a new API to manage the consumption of security events.
- SSFSecurityEventTokenApi is a new API to manage security event tokens.
- SSFTransmitterApi is a new API to manage security event transmitters.
- SessionApi methods added:
  - GetCurrentSession
  - CloseCurrentSession
  - RefreshCurrentSession
- UserApi methods added:
  - ReplaceLinkedObjectForUser
  - ListLinkedObjectsForUser
  - DeleteLinkedObjectForUser
- AttackProtectionApi methods added:
  - GetAuthenticatorSettings
  - ReplaceAuthenticatorSettings
- RoleAssignmentApi methods added:
  - ListRolesForClient
  - AssignRoleToClient

## 8.0.0

- Add support for OAuth 2.0 DPoP (#697)
- Fix "UserSchemaAttributes minLength and maxLength are non-nullable and cause array schema attribute creation to fail." issue (#702)
- Fix "Unable to access Links (_links) in version 7 for an IdentityProvider when using GetIdentityProviderAsync/CreateIdentityProviderAsync" (#700)
- Rollback `PolicyCanBeCreatedOrUpdated` schema changes
- Remove obsolete methods for `IdentityProviderPolicy`
- Update `AppAndInstanceConditionEvaluatorAppOrInstance.Id` readonly property from true to false (#716)

## 7.0.6

- Update OAS3 with the latest IdP Discovery policy changes. 
- `IdentityProviderPolicy` will no longer inherit from Policy in the major release. The inheritance has been marked as obsolete.
- The following `PolicyApi` methods have been marked as obsolete, and will be removed in the next major version: 
    - `System.Threading.Tasks.Task<Policy> CreatePolicyAsync(Policy policy, bool? activate = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));`
    - `System.Threading.Tasks.Task<ApiResponse<Policy>> CreatePolicyWithHttpInfoAsync(Policy policy, bool? activate = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));`
    - `System.Threading.Tasks.Task<Policy> ReplacePolicyAsync(string policyId, Policy policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));`
    - `System.Threading.Tasks.Task<ApiResponse<Policy>> ReplacePolicyWithHttpInfoAsync(string policyId, Policy policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));`
They will be replaced by the following ones:
    - `System.Threading.Tasks.Task<PolicyCanBeCreatedOrReplaced> CreatePolicyAsync(  PolicyCanBeCreatedOrReplaced policy ,   bool? activate = default(bool?) , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));`
    - `System.Threading.Tasks.Task<ApiResponse<PolicyCanBeCreatedOrReplaced>> CreatePolicyWithHttpInfoAsync(  PolicyCanBeCreatedOrReplaced policy ,   bool? activate = default(bool?) , System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));`
    - `System.Threading.Tasks.Task<Policy> ReplacePolicyAsync(string policyId, Policy policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));`
    - `System.Threading.Tasks.Task<ApiResponse<Policy>> ReplacePolicyWithHttpInfoAsync(string policyId, Policy policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));`
- Fix "API Gap - IdP Discovery Policy Rule does not exist" issue (#687)

## 7.0.5

- Downgrade `System.IdentityModel.Tokens*` dependencies from 7.2.0 to 6.35.0 to avoid breaking changes (#692)

## 7.0.4

- Update vulnerable `System.IdentityModel.Tokens.Jwt` dependency (OKTA-683207)
- Fix "Missing application settings when fetching SamlApplication" (#644)

## 7.0.3

- Fix "Missing data in verifyFactorRequest prevents verifying webauthn" (OKTA-656179)

## 7.0.2

- Fix "JTI Claim as a string instead of guid" (#682) 

## 7.0.1

- Fix "Incosistent Exception Handling" issue (#658)
- Fix "Update UserType.Id to be editable" issue (#660)
- Fix "Nuget package missing license information" issue (#667)
- Fix "VerifyUserFactorResponse doesn't correspond with the server's response" (#665)

## 7.0.0
- Upgraded the RestSharp dependency from `106.13.0` to `110.2.0` (#606)
- Upgraded the Okta management OpenAPI specification to be aligned with the Okta release [v2023.07.0](https://help.okta.com/en-us/Content/Topics/ReleaseNotes/okta-relnotes.htm). 
- New API clients added:  
* `ApiServiceIntegrationsApi`
* `ApplicationSSOApi`
* `AttackProtectionApi`
* `EmailServerApi`
* `IdentitySourceApi`
* `RealmApi`
* `UISchemaApi`
- Check out the [MIGRATING guide](./MIGRATING.md) for more details about migrating to 7.0.0

## 6.0.11

- Fix "Create/Update Account returns NULL when okta tenant hits rate limits" issue (#638)

## 6.0.10

- Fix "DeleteFactorAsync not removing phone with removeEnrollmentRecovery" issue (#630)
- Fix "ChangePasswordRequest.revokeSessions does not exist" issue (#624)

## 6.0.9

- Fix "Retrieving Group no Longer Retrieves Additional Profile Data" issue (#634)

## 6.0.8

- Fix "API Calls Trap Request Timeout Exceptions" issue (#632)
- Fix "Resend SMS as part of enrollment" issue (#633)
- Update `IamRoles.Permissions` object type from `Object` to `HrefObject`.
- Add `IamRoles.Self` property.

## 6.0.7

- Fix "UpdateProfileMappingAsync doesn't update properties" issue (#618)
- Fix "UpdateUserAsync should allow updating the user type" issue (#615)

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
