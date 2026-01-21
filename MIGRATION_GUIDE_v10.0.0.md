# Okta .NET SDK v10.0.0 Migration Guide
## Method-Level Change Report

This document provides a comprehensive mapping of all public methods from the old API (v9.x) to the new API (v10.0.0). Every method from the old API is accounted for and categorized as:

- **[RENAMED]** - Method exists with a new name
- **[SPLIT]** - Method was split into multiple methods
- **[REMOVED]** - Method no longer exists in the new API
- **[MOVED]** - Method moved to a different API class
- **[IDENTICAL]** - Method remains unchanged
- **[PARAMETER CHANGE]** - Method signature has new or modified parameters

---

## Table of Contents

- [Section 1: Method Migration Report](#section-1-method-migration-report)
- [Section 2: New Methods in v10.0.0](#section-2-new-methods-in-v1000)
- [Summary of Changes](#summary-of-changes)

---

## Section 1: Method Migration Report

This section covers every API class from v9.x and documents what happened to each method.

### AgentPoolsApi

**Status:** No changes

All methods in this API remain functionally identical with no name changes:

- `ActivateAgentPoolsUpdateAsync()` → `ActivateAgentPoolsUpdateAsync()` **[IDENTICAL]**
- `CreateAgentPoolsUpdateAsync()` → `CreateAgentPoolsUpdateAsync()` **[IDENTICAL]**
- `DeactivateAgentPoolsUpdateAsync()` → `DeactivateAgentPoolsUpdateAsync()` **[IDENTICAL]**
- `DeleteAgentPoolsUpdateAsync()` → `DeleteAgentPoolsUpdateAsync()` **[IDENTICAL]**
- `GetAgentPoolsUpdateInstanceAsync()` → `GetAgentPoolsUpdateInstanceAsync()` **[IDENTICAL]**
- `GetAgentPoolsUpdateSettingsAsync()` → `GetAgentPoolsUpdateSettingsAsync()` **[IDENTICAL]**
- `ListAgentPools()` → `ListAgentPools()` **[IDENTICAL]**
- `ListAgentPoolsUpdates()` → `ListAgentPoolsUpdates()` **[IDENTICAL]**
- `PauseAgentPoolsUpdateAsync()` → `PauseAgentPoolsUpdateAsync()` **[IDENTICAL]**
- `ResumeAgentPoolsUpdateAsync()` → `ResumeAgentPoolsUpdateAsync()` **[IDENTICAL]**
- `RetryAgentPoolsUpdateAsync()` → `RetryAgentPoolsUpdateAsync()` **[IDENTICAL]**
- `StopAgentPoolsUpdateAsync()` → `StopAgentPoolsUpdateAsync()` **[IDENTICAL]**
- `UpdateAgentPoolsUpdateAsync()` → `UpdateAgentPoolsUpdateAsync()` **[IDENTICAL]**
- `UpdateAgentPoolsUpdateSettingsAsync()` → `UpdateAgentPoolsUpdateSettingsAsync()` **[IDENTICAL]**

---

### ApiServiceIntegrationsApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### ApiTokenApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### ApplicationApi

**Status:** Minor parameter changes

Method changes:

- `ActivateApplicationAsync()` → `ActivateApplicationAsync()` **[IDENTICAL]**
- `CreateApplicationAsync()` → `CreateApplicationAsync()` **[IDENTICAL]**
- `DeactivateApplicationAsync()` → `DeactivateApplicationAsync()` **[IDENTICAL]**
- `DeleteApplicationAsync()` → `DeleteApplicationAsync()` **[IDENTICAL]**
- `GetApplicationAsync()` → `GetApplicationAsync()` **[IDENTICAL]**
- `ListApplications()` → `ListApplications()` **[PARAMETER CHANGE]** - Added `useOptimization` parameter
- `ReplaceApplicationAsync()` → `ReplaceApplicationAsync()` **[IDENTICAL]**

---

### ApplicationConnectionsApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### ApplicationCredentialsApi

**Status:** ⚠️ REMOVED

**THIS API WAS REMOVED IN v10.0.0**

All methods from `ApplicationCredentialsApi.cs` have been removed: **[REMOVED]**

**Migration Path:** These credential-related operations may have been moved to other APIs or require different approaches in v10.0.0. Check `ApplicationSSOApi` and related APIs for credential management.

---

### ApplicationCrossAppAccessConnectionsApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#applicationcrossappaccessconnectionsapi-new-api) for new methods.

---

### ApplicationFeaturesApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### ApplicationGrantsApi

**Status:** No changes

All methods remain identical with no changes:

- `GetScopeConsentGrantAsync()` → `GetScopeConsentGrantAsync()` **[IDENTICAL]**
- `GrantConsentToScopeAsync()` → `GrantConsentToScopeAsync()` **[IDENTICAL]**
- `ListScopeConsentGrants()` → `ListScopeConsentGrants()` **[IDENTICAL]**
- `RevokeScopeConsentGrantAsync()` → `RevokeScopeConsentGrantAsync()` **[IDENTICAL]**

---

### ApplicationGroupsApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### ApplicationLogosApi

**Status:** No changes

All methods remain identical with no changes:

- `UploadApplicationLogoAsync()` → `UploadApplicationLogoAsync()` **[IDENTICAL]**

---

### ApplicationPoliciesApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### ApplicationSSOApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### ApplicationSSOCredentialKeyApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#applicationssoredentialkeyapi-new-api) for new methods.

---

### ApplicationSSOFederatedClaimsApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#applicationssofederatedclaimsapi-new-api) for new methods.

---

### ApplicationSSOPublicKeysApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#applicationssopublickeysapi-new-api) for new methods.

---

### ApplicationTokensApi

**Status:** No changes

All methods remain identical with no changes:

- `GetOAuth2TokenForApplicationAsync()` → `GetOAuth2TokenForApplicationAsync()` **[IDENTICAL]**
- `ListOAuth2TokensForApplication()` → `ListOAuth2TokensForApplication()` **[IDENTICAL]**
- `RevokeOAuth2TokenForApplicationAsync()` → `RevokeOAuth2TokenForApplicationAsync()` **[IDENTICAL]**
- `RevokeOAuth2TokensForApplicationAsync()` → `RevokeOAuth2TokensForApplicationAsync()` **[IDENTICAL]**

---

### ApplicationUsersApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### AssociatedDomainCustomizationsApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#associateddomaincustomizationsapi-new-api) for new methods.

---

### AttackProtectionApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### AuthenticatorApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### AuthorizationServerApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### AuthorizationServerAssocApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### AuthorizationServerClaimsApi

**Status:** No changes

All methods remain identical with no changes:

- `CreateOAuth2ClaimAsync()` → `CreateOAuth2ClaimAsync()` **[IDENTICAL]**
- `DeleteOAuth2ClaimAsync()` → `DeleteOAuth2ClaimAsync()` **[IDENTICAL]**
- `GetOAuth2ClaimAsync()` → `GetOAuth2ClaimAsync()` **[IDENTICAL]**
- `ListOAuth2Claims()` → `ListOAuth2Claims()` **[IDENTICAL]**
- `ReplaceOAuth2ClaimAsync()` → `ReplaceOAuth2ClaimAsync()` **[IDENTICAL]**

---

### AuthorizationServerClientsApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### AuthorizationServerKeysApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### AuthorizationServerPoliciesApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### AuthorizationServerRulesApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### AuthorizationServerScopesApi

**Status:** No changes

All methods remain identical with no changes:

- `CreateOAuth2ScopeAsync()` → `CreateOAuth2ScopeAsync()` **[IDENTICAL]**
- `DeleteOAuth2ScopeAsync()` → `DeleteOAuth2ScopeAsync()` **[IDENTICAL]**
- `GetOAuth2ScopeAsync()` → `GetOAuth2ScopeAsync()` **[IDENTICAL]**
- `ListOAuth2Scopes()` → `ListOAuth2Scopes()` **[IDENTICAL]**
- `ReplaceOAuth2ScopeAsync()` → `ReplaceOAuth2ScopeAsync()` **[IDENTICAL]**

---

### BehaviorApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### BrandsApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### CAPTCHAApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### CustomDomainApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### CustomPagesApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### CustomTemplatesApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### DeviceAccessApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#deviceaccessapi-new-api) for new methods.

---

### DeviceApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### DeviceAssuranceApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### DeviceIntegrationsApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#deviceintegrationsapi-new-api) for new methods.

---

### DevicePostureCheckApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#deviceposturecheckapi-new-api) for new methods.

---

### DirectoriesIntegrationApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### EmailCustomizationApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#emailcustomizationapi-new-api) for new methods.

---

### EmailDomainApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### EmailServerApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### EventHookApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### FeatureApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### GovernanceBundleApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#governancebundleapi-new-api) for new methods.

---

### GroupApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### GroupOwnerApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### GroupPushMappingApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#grouppushmappingapi-new-api) for new methods.

---

### GroupRuleApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#groupruleapi-new-api) for new methods.

---

### HookKeyApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### IdentityProviderApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### IdentityProviderKeysApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#identityproviderkeysapi-new-api) for new methods.

---

### IdentityProviderSigningKeysApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#identityprovidersigningkeysapi-new-api) for new methods.

---

### IdentityProviderUsersApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#identityproviderusersapi-new-api) for new methods.

---

### IdentitySourceApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### InlineHookApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### LinkedObjectApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### LogStreamApi

**Status:** No changes

All methods remain identical with no changes:

- `ActivateLogStreamAsync()` → `ActivateLogStreamAsync()` **[IDENTICAL]**
- `CreateLogStreamAsync()` → `CreateLogStreamAsync()` **[IDENTICAL]**
- `DeactivateLogStreamAsync()` → `DeactivateLogStreamAsync()` **[IDENTICAL]**
- `DeleteLogStreamAsync()` → `DeleteLogStreamAsync()` **[IDENTICAL]**
- `GetLogStreamAsync()` → `GetLogStreamAsync()` **[IDENTICAL]**
- `ListLogStreams()` → `ListLogStreams()` **[IDENTICAL]**
- `ReplaceLogStreamAsync()` → `ReplaceLogStreamAsync()` **[IDENTICAL]**

---

### NetworkZoneApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### OAuth2ResourceServerCredentialsKeysApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#oauth2resourceservercredentialskeysapi-new-api) for new methods.

---

### OAuthApi

**Status:** No changes

All methods remain identical with no changes:

- `GetBearerTokenAsync()` → `GetBearerTokenAsync()` **[IDENTICAL]**

---

### OktaApplicationSettingsApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### OktaPersonalSettingsApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#oktapersonalsettingsapi-new-api) for new methods.

---

### OrgCreatorApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#orgcreatorapi-new-api) for new methods.

---

### OrgSettingApi

**Status:** 🔄 SPLIT INTO MULTIPLE APIs

**THIS API WAS SPLIT**

The old `OrgSettingApi.cs` has been split into multiple specialized APIs:

**Old API Methods:** All org setting methods → **[SPLIT]** See below for mappings

**New APIs (Created from OrgSettingApi split):**

1. **OrgSettingAdminApi** - Admin-related org settings
2. **OrgSettingCommunicationApi** - Communication settings
3. **OrgSettingContactApi** - Contact information settings
4. **OrgSettingCustomizationApi** - Customization settings
5. **OrgSettingGeneralApi** - General org settings
6. **OrgSettingMetadataApi** - Metadata settings
7. **OrgSettingSupportApi** - Support settings

**Migration Path:** Review which specific org setting you were using and map to the appropriate new specialized API.

See [Section 2](#orgsetting-apis-new-split-from-orgsettingapi) for details on each new API.

---

### PolicyApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### PrincipalRateLimitApi

**Status:** No changes

All methods remain identical with no changes:

- `CreatePrincipalRateLimitEntityAsync()` → `CreatePrincipalRateLimitEntityAsync()` **[IDENTICAL]**
- `GetPrincipalRateLimitEntityAsync()` → `GetPrincipalRateLimitEntityAsync()` **[IDENTICAL]**
- `ListPrincipalRateLimitEntities()` → `ListPrincipalRateLimitEntities()` **[IDENTICAL]**
- `ReplacePrincipalRateLimitEntityAsync()` → `ReplacePrincipalRateLimitEntityAsync()` **[IDENTICAL]**

---

### ProfileMappingApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### PushProviderApi

**Status:** No changes

All methods remain identical with no changes:

- `CreatePushProviderAsync()` → `CreatePushProviderAsync()` **[IDENTICAL]**
- `DeletePushProviderAsync()` → `DeletePushProviderAsync()` **[IDENTICAL]**
- `GetPushProviderAsync()` → `GetPushProviderAsync()` **[IDENTICAL]**
- `ListPushProviders()` → `ListPushProviders()` **[IDENTICAL]**
- `ReplacePushProviderAsync()` → `ReplacePushProviderAsync()` **[IDENTICAL]**

---

### RateLimitSettingsApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### RealmApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### RealmAssignmentApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### ResourceSetApi

**Status:** 🔄 SPLIT INTO MULTIPLE APIs

**THIS API WAS SPLIT**

The old `ResourceSetApi.cs` has been split into multiple role-related APIs:

**Old API Methods:** Resource set methods → **[MOVED]** to various Role APIs

**New APIs (Related to resource sets and roles):**

1. **RoleCResourceSetApi**
2. **RoleCResourceSetResourceApi**
3. **RoleDResourceSetBindingApi**
4. **RoleDResourceSetBindingMemberApi**

**Migration Path:** Review your resource set operations and map to the appropriate role-based API.

See [Section 2](#role-resource-set-apis-new-split-from-resourcesetapi) for details on each new API.

---

### RiskEventApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### RiskProviderApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### RoleApi

**Status:** 🔄 SPLIT INTO MULTIPLE APIs

**THIS API WAS SPLIT**

The old `RoleApi.cs` has been split into multiple specialized role APIs:

**Old API Methods:** All role methods → **[SPLIT]** See below for mappings

**New APIs (Created from RoleApi split):**

1. **RoleAssignmentAUserApi** - User role assignments
2. **RoleAssignmentBGroupApi** - Group role assignments
3. **RoleAssignmentClientApi** - Client role assignments
4. **RoleBTargetAdminApi** - Admin role targets
5. **RoleBTargetBGroupApi** - Group role targets
6. **RoleBTargetClientApi** - Client role targets
7. **RoleECustomApi** - Custom roles
8. **RoleECustomPermissionApi** - Custom role permissions

**Migration Path:** Determine the type of role operation (user, group, client, custom) and use the appropriate specialized API.

See [Section 2](#role-apis-new-split-from-roleapi) for details on each new API.

---

### RoleAssignmentApi

**Status:** 🔄 See RoleApi split above

Methods from this API have been moved to the new role-related APIs. See the RoleApi section above for details.

---

### RoleTargetApi

**Status:** 🔄 See RoleApi split above

Methods from this API have been moved to the new role-related APIs. See the RoleApi section above for details.

---

### SchemaApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### ServiceAccountApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#serviceaccountapi-new-api) for new methods.

---

### SessionApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### SSFReceiverApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### SSFSecurityEventTokenApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### SSFTransmitterApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### SubscriptionApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### SystemLogApi

**Status:** No changes

All methods remain identical with no changes:

- `ListLogEvents()` → `ListLogEvents()` **[IDENTICAL]**

---

### TemplateApi

**Status:** No changes

All methods remain identical with no changes:

- `CreateSmsTemplateAsync()` → `CreateSmsTemplateAsync()` **[IDENTICAL]**
- `DeleteSmsTemplateAsync()` → `DeleteSmsTemplateAsync()` **[IDENTICAL]**
- `GetSmsTemplateAsync()` → `GetSmsTemplateAsync()` **[IDENTICAL]**
- `ListSmsTemplates()` → `ListSmsTemplates()` **[IDENTICAL]**
- `ReplaceSmsTemplateAsync()` → `ReplaceSmsTemplateAsync()` **[IDENTICAL]**
- `UpdateSmsTemplateAsync()` → `UpdateSmsTemplateAsync()` **[IDENTICAL]**

---

### ThemesApi

**Status:** No changes

All methods remain identical with no changes:

- `DeleteBrandThemeBackgroundImageAsync()` → `DeleteBrandThemeBackgroundImageAsync()` **[IDENTICAL]**
- `DeleteBrandThemeFaviconAsync()` → `DeleteBrandThemeFaviconAsync()` **[IDENTICAL]**
- `DeleteBrandThemeLogoAsync()` → `DeleteBrandThemeLogoAsync()` **[IDENTICAL]**
- `GetBrandThemeAsync()` → `GetBrandThemeAsync()` **[IDENTICAL]**
- `ListBrandThemes()` → `ListBrandThemes()` **[IDENTICAL]**
- `ReplaceBrandThemeAsync()` → `ReplaceBrandThemeAsync()` **[IDENTICAL]**
- `UploadBrandThemeBackgroundImageAsync()` → `UploadBrandThemeBackgroundImageAsync()` **[IDENTICAL]**
- `UploadBrandThemeFaviconAsync()` → `UploadBrandThemeFaviconAsync()` **[IDENTICAL]**
- `UploadBrandThemeLogoAsync()` → `UploadBrandThemeLogoAsync()` **[IDENTICAL]**

---

### ThreatInsightApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### TrustedOriginApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### UISchemaApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### UserApi

**Status:** 🔄 SIGNIFICANT CHANGES - MANY METHODS MOVED TO NEW SPECIALIZED APIs

**Methods that remain in UserApi:**

- `CreateUserAsync()` → `CreateUserAsync()` **[IDENTICAL]**
- `DeleteUserAsync()` → `DeleteUserAsync()` **[IDENTICAL]**
- `GetUserAsync()` → `GetUserAsync()` **[PARAMETER CHANGE]** - Added `contentType` parameter
- `ListUserBlocks()` → `ListUserBlocks()` **[IDENTICAL]**
- `ListUsers()` → `ListUsers()` **[PARAMETER CHANGE]** - Added `contentType` parameter
- `ReplaceUserAsync()` → `ReplaceUserAsync()` **[IDENTICAL]**
- `UpdateUserAsync()` → `UpdateUserAsync()` **[IDENTICAL]**

**Methods MOVED to UserLifecycleApi:**

- `ActivateUserAsync()` → **[MOVED]** to `UserLifecycleApi.cs`
- `DeactivateUserAsync()` → **[MOVED]** to `UserLifecycleApi.cs`
- `ExpirePasswordAsync()` → **[MOVED]** to `UserCredApi.cs` (as part of UserCred operations)
- `ExpirePasswordAndGetTemporaryPasswordAsync()` → **[MOVED + RENAMED]** to `UserCredApi.ExpirePasswordWithTempPasswordAsync()`

**Methods MOVED to UserCredApi:**

- `ChangePasswordAsync()` → **[MOVED]** to `UserCredApi.cs`
- `ChangeRecoveryQuestionAsync()` → **[MOVED]** to `UserCredApi.cs`
- `ForgotPasswordAsync()` → **[MOVED]** to `UserCredApi.cs`
- `ForgotPasswordSetNewPasswordAsync()` → **[MOVED]** to `UserCredApi.cs`
- `GenerateResetPasswordTokenAsync()` → **[MOVED + RENAMED]** to `UserCredApi.ResetPasswordAsync()` (same endpoint: POST `/api/v1/users/{id}/lifecycle/reset_password`)

**Methods MOVED to UserOAuthApi:**

- `GetRefreshTokenForUserAndClientAsync()` → **[MOVED]** to `UserOAuthApi.cs`
- `GetUserGrantAsync()` → **[MOVED]** to `UserGrantApi.cs`
- `ListGrantsForUserAndClient()` → **[MOVED]** to `UserOAuthApi.cs`
- `RevokeUserGrantAsync()` → **[MOVED]** to `UserGrantApi.cs`
- `RevokeGrantsForUserAndClientAsync()` → **[MOVED]** to `UserOAuthApi.cs`

**Methods MOVED to UserLinkedObjectApi:**

- `DeleteLinkedObjectForUserAsync()` → **[MOVED]** to `UserLinkedObjectApi.cs`
- `ListLinkedObjectsForUser()` → **[MOVED]** to `UserLinkedObjectApi.cs`
- `SetLinkedObjectForUserAsync()` → **[MOVED]** to `UserLinkedObjectApi.cs`

**Methods MOVED to UserResourcesApi:**

- `ListAppLinks()` → **[MOVED]** to `UserResourcesApi.cs`

**Methods MOVED to UserSessionsApi:**

- `ClearUserSessions()` → **[MOVED]** to `UserSessionsApi.cs`

See [Section 2](#user-apis-new-split-from-userapi) for details on each new API.

---

### UserAuthenticatorEnrollmentsApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#userauthenticatorenrollmentsapi-new-api) for new methods.

---

### UserClassificationApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#userclassificationapi-new-api) for new methods.

---

### UserCredApi

**Status:** ✨ NEW API - Methods moved from UserApi

**NEW API IN v10.0.0** - Methods moved from `UserApi.cs`

See the [UserApi](#userapi) section above for migrated methods.

See [Section 2](#usercredapi-new-api-methods-moved-from-userapi) for all methods.

---

### UserFactorApi

**Status:** No changes

All methods remain identical with no changes:

- `ActivateFactorAsync()` → `ActivateFactorAsync()` **[IDENTICAL]**
- `EnrollFactorAsync()` → `EnrollFactorAsync()` **[IDENTICAL]**
- `GetFactorAsync()` → `GetFactorAsync()` **[IDENTICAL]**
- `GetFactorTransactionStatusAsync()` → `GetFactorTransactionStatusAsync()` **[IDENTICAL]**
- `ListFactors()` → `ListFactors()` **[IDENTICAL]**
- `ListSupportedFactors()` → `ListSupportedFactors()` **[IDENTICAL]**
- `ListSupportedSecurityQuestions()` → `ListSupportedSecurityQuestions()` **[IDENTICAL]**
- `ResendEnrollFactorAsync()` → `ResendEnrollFactorAsync()` **[IDENTICAL]**
- `UnenrollFactorAsync()` → `UnenrollFactorAsync()` **[IDENTICAL]**
- `VerifyFactorAsync()` → `VerifyFactorAsync()` **[IDENTICAL]**

---

### UserGrantApi

**Status:** ✨ NEW API - Methods moved from UserApi

**NEW API IN v10.0.0** - Methods moved from `UserApi.cs`

See the [UserApi](#userapi) section above for migrated methods.

See [Section 2](#usergrantapi-new-api-methods-moved-from-userapi) for all methods.

---

### UserLifecycleApi

**Status:** ✨ NEW API - Methods moved from UserApi

**NEW API IN v10.0.0** - Methods moved from `UserApi.cs`

See the [UserApi](#userapi) section above for migrated methods.

See [Section 2](#userlifecycleapi-new-api-methods-moved-from-userapi) for all methods.

---

### UserLinkedObjectApi

**Status:** ✨ NEW API - Methods moved from UserApi

**NEW API IN v10.0.0** - Methods moved from `UserApi.cs`

See the [UserApi](#userapi) section above for migrated methods.

See [Section 2](#userlinkedobjectapi-new-api-methods-moved-from-userapi) for all methods.

---

### UserOAuthApi

**Status:** ✨ NEW API - Methods moved from UserApi

**NEW API IN v10.0.0** - Methods moved from `UserApi.cs`

See the [UserApi](#userapi) section above for migrated methods.

See [Section 2](#useroauthapi-new-api-methods-moved-from-userapi) for all methods.

---

### UserResourcesApi

**Status:** ✨ NEW API - Methods moved from UserApi

**NEW API IN v10.0.0** - Methods moved from `UserApi.cs`

See the [UserApi](#userapi) section above for migrated methods.

See [Section 2](#userresourcesapi-new-api-methods-moved-from-userapi) for all methods.

---

### UserRiskApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#userriskapi-new-api) for new methods.

---

### UserSessionsApi

**Status:** ✨ NEW API - Methods moved from UserApi

**NEW API IN v10.0.0** - Methods moved from `UserApi.cs`

See the [UserApi](#userapi) section above for migrated methods.

See [Section 2](#usersessionsapi-new-api-methods-moved-from-userapi) for all methods.

---

### UserTypeApi

**Status:** No changes

All methods in this API remain functionally identical **[IDENTICAL]**

---

### WebAuthnPreregistrationApi

**Status:** ✨ NEW API

**NEW API IN v10.0.0** - This API class didn't exist in the old version.

See [Section 2](#webauthnpreregistrationapi-new-api) for new methods.

---

## Section 2: New Methods in v10.0.0

This section lists brand-new public methods that exist in v10.0.0 but had no equivalent in the previous version. These are organized by API class.

### ApplicationCrossAppAccessConnectionsApi [NEW API]

All methods in this API are new:

- `CreateApplicationCrossAppAccessConnectionAsync()`
- `DeleteApplicationCrossAppAccessConnectionAsync()`
- `GetApplicationCrossAppAccessConnectionAsync()`
- `ListApplicationCrossAppAccessConnections()`
- `ReplaceApplicationCrossAppAccessConnectionAsync()`

---

### ApplicationSSOCredentialKeyApi [NEW API]

All methods in this API are new:

- `CreateApplicationSSOCredentialKeyAsync()`
- `DeleteApplicationSSOCredentialKeyAsync()`
- `GetApplicationSSOCredentialKeyAsync()`
- `ListApplicationSSOCredentialKeys()`

---

### ApplicationSSOFederatedClaimsApi [NEW API]

All methods in this API are new:

- `CreateApplicationSSOFederatedClaimAsync()`
- `DeleteApplicationSSOFederatedClaimAsync()`
- `GetApplicationSSOFederatedClaimAsync()`
- `ListApplicationSSOFederatedClaims()`
- `ReplaceApplicationSSOFederatedClaimAsync()`

---

### ApplicationSSOPublicKeysApi [NEW API]

All methods in this API are new:

- `CreateApplicationSSOPublicKeyAsync()`
- `DeleteApplicationSSOPublicKeyAsync()`
- `GetApplicationSSOPublicKeyAsync()`
- `ListApplicationSSOPublicKeys()`

---

### AssociatedDomainCustomizationsApi [NEW API]

All methods in this API are new:

- `CreateBrandAssociatedDomainCustomizationAsync()`
- `DeleteBrandAssociatedDomainCustomizationAsync()`
- `GetBrandAssociatedDomainCustomizationAsync()`
- `ListBrandAssociatedDomainCustomizations()`
- `ReplaceBrandAssociatedDomainCustomizationAsync()`

---

### DeviceAccessApi [NEW API]

All methods in this API are new:

- `CreateDeviceAccessPolicyAsync()`
- `DeleteDeviceAccessPolicyAsync()`
- `GetDeviceAccessPolicyAsync()`
- `ListDeviceAccessPolicies()`
- `ReplaceDeviceAccessPolicyAsync()`

---

### DeviceIntegrationsApi [NEW API]

All methods in this API are new:

- `CreateDeviceIntegrationAsync()`
- `DeleteDeviceIntegrationAsync()`
- `GetDeviceIntegrationAsync()`
- `ListDeviceIntegrations()`
- `UpdateDeviceIntegrationAsync()`

---

### DevicePostureCheckApi [NEW API]

All methods in this API are new:

- `CreateDevicePostureCheckAsync()`
- `DeleteDevicePostureCheckAsync()`
- `GetDevicePostureCheckAsync()`
- `ListDevicePostureChecks()`
- `ReplaceDevicePostureCheckAsync()`

---

### EmailCustomizationApi [NEW API]

All methods in this API are new:

- `CreateBrandEmailCustomizationAsync()`
- `DeleteBrandEmailCustomizationAsync()`
- `GetBrandEmailCustomizationAsync()`
- `ListBrandEmailCustomizations()`
- `ReplaceBrandEmailCustomizationAsync()`

---

### GovernanceBundleApi [NEW API]

All methods in this API are new:

- `CreateGovernanceBundleAsync()`
- `DeleteGovernanceBundleAsync()`
- `GetGovernanceBundleAsync()`
- `ListGovernanceBundles()`
- `UpdateGovernanceBundleAsync()`

---

### GroupPushMappingApi [NEW API]

All methods in this API are new:

- `CreateGroupPushMappingAsync()`
- `DeleteGroupPushMappingAsync()`
- `GetGroupPushMappingAsync()`
- `ListGroupPushMappings()`
- `UpdateGroupPushMappingAsync()`

---

### GroupRuleApi [NEW API]

All methods in this API are new:

- `ActivateGroupRuleAsync()`
- `CreateGroupRuleAsync()`
- `DeactivateGroupRuleAsync()`
- `DeleteGroupRuleAsync()`
- `GetGroupRuleAsync()`
- `ListGroupRules()`
- `UpdateGroupRuleAsync()`

---

### IdentityProviderKeysApi [NEW API]

All methods in this API are new:

- `CreateIdentityProviderKeyAsync()`
- `DeleteIdentityProviderKeyAsync()`
- `GetIdentityProviderKeyAsync()`
- `ListIdentityProviderKeys()`

---

### IdentityProviderSigningKeysApi [NEW API]

All methods in this API are new:

- `CloneIdentityProviderSigningKeyAsync()`
- `CreateIdentityProviderSigningKeyAsync()`
- `DeleteIdentityProviderSigningKeyAsync()`
- `GenerateIdentityProviderSigningKeyCsrAsync()`
- `GetIdentityProviderSigningKeyAsync()`
- `GetIdentityProviderSigningKeyCsrAsync()`
- `ListIdentityProviderSigningKeys()`
- `PublishIdentityProviderSigningCertAsync()`
- `RevokeCsrForIdentityProviderAsync()`

---

### IdentityProviderUsersApi [NEW API]

All methods in this API are new:

- `GetIdentityProviderUserAsync()`
- `ListIdentityProviderUsers()`
- `UnlinkUserFromIdentityProviderAsync()`

---

### OAuth2ResourceServerCredentialsKeysApi [NEW API]

All methods in this API are new:

- `CreateOAuth2ResourceServerCredentialKeyAsync()`
- `DeleteOAuth2ResourceServerCredentialKeyAsync()`
- `GetOAuth2ResourceServerCredentialKeyAsync()`
- `ListOAuth2ResourceServerCredentialKeys()`

---

### OktaPersonalSettingsApi [NEW API]

All methods in this API are new:

- `GetOktaPersonalSettingsAsync()`
- `UpdateOktaPersonalSettingsAsync()`

---

### OrgCreatorApi [NEW API]

All methods in this API are new:

- `CreateOrgCreatorAsync()`
- `GetOrgCreatorAsync()`
- `ListOrgCreators()`
- `UpdateOrgCreatorAsync()`

---

### OrgSetting* APIs [NEW - Split from OrgSettingApi]

#### OrgSettingAdminApi

All methods in this API are new to v10.0.0:

- `GetOrgAdminSettingsAsync()`
- `UpdateOrgAdminSettingsAsync()`

#### OrgSettingCommunicationApi

All methods in this API are new to v10.0.0:

- `GetOrgCommunicationSettingsAsync()`
- `OptInOrgUsersToCommunicationEmailsAsync()`
- `OptOutOrgUsersFromCommunicationEmailsAsync()`

#### OrgSettingContactApi

All methods in this API are new to v10.0.0:

- `GetOrgContactTypesAsync()`
- `GetOrgContactUserAsync()`
- `UpdateOrgContactUserAsync()`

#### OrgSettingCustomizationApi

All methods in this API are new to v10.0.0:

- `GetOrgCustomizationSettingsAsync()`
- `UpdateOrgCustomizationSettingsAsync()`

#### OrgSettingGeneralApi

All methods in this API are new to v10.0.0:

- `ExtendOktaSupport()`
- `GetOktaSupportSettingsAsync()`
- `GetOrgOktaCommunicationSettingsAsync()`
- `GetOrgSettingsAsync()`
- `GrantOktaSupportAsync()`
- `RevokeOktaSupportAsync()`
- `UpdateOrgSettingsAsync()`
- `UpdateOrgOktaCommunicationSettingsAsync()`

#### OrgSettingMetadataApi

All methods in this API are new to v10.0.0:

- `GetOrgMetadataAsync()`

#### OrgSettingSupportApi

All methods in this API are new to v10.0.0:

- `ExtendOktaSupportAsync()`
- `GetOktaSupportSettingsAsync()`
- `GrantOktaSupportAsync()`
- `RevokeOktaSupportAsync()`

---

### Role* APIs [NEW - Split from RoleApi]

#### RoleAssignmentAUserApi

All methods in this API are new to v10.0.0:

- `AssignRoleToUserAsync()`
- `GetUserRoleAsync()`
- `ListUserRoles()`
- `UnassignRoleFromUserAsync()`

#### RoleAssignmentBGroupApi

All methods in this API are new to v10.0.0:

- `AssignRoleToGroupAsync()`
- `GetGroupRoleAsync()`
- `ListGroupRoles()`
- `UnassignRoleFromGroupAsync()`

#### RoleAssignmentClientApi

All methods in this API are new to v10.0.0:

- `AssignRoleToClientAsync()`
- `GetClientRoleAsync()`
- `ListClientRoles()`
- `UnassignRoleFromClientAsync()`

#### RoleBTargetAdminApi

All methods in this API are new to v10.0.0:

- `AddAdminRoleTargetToGroupAsync()`
- `AddAdminRoleTargetToUserAsync()`
- `ListAdminRoleTargetsForGroupAsync()`
- `ListAdminRoleTargetsForUserAsync()`
- `RemoveAdminRoleTargetFromGroupAsync()`
- `RemoveAdminRoleTargetFromUserAsync()`

#### RoleBTargetBGroupApi

All methods in this API are new to v10.0.0:

- `AddGroupTargetToGroupRoleAsync()`
- `AddGroupTargetToUserRoleAsync()`
- `ListGroupTargetsForGroupRoleAsync()`
- `ListGroupTargetsForUserRoleAsync()`
- `RemoveGroupTargetFromGroupRoleAsync()`
- `RemoveGroupTargetFromUserRoleAsync()`

#### RoleBTargetClientApi

All methods in this API are new to v10.0.0:

- `AddClientTargetToRoleAsync()`
- `ListClientTargetsForRoleAsync()`
- `RemoveClientTargetFromRoleAsync()`

#### RoleECustomApi

All methods in this API are new to v10.0.0:

- `CreateCustomRoleAsync()`
- `DeleteCustomRoleAsync()`
- `GetCustomRoleAsync()`
- `ListCustomRoles()`
- `ReplaceCustomRoleAsync()`

#### RoleECustomPermissionApi

All methods in this API are new to v10.0.0:

- `CreateCustomRolePermissionAsync()`
- `DeleteCustomRolePermissionAsync()`
- `GetCustomRolePermissionAsync()`
- `ListCustomRolePermissions()`

---

### Role Resource Set APIs [NEW - Split from ResourceSetApi]

#### RoleCResourceSetApi

All methods in this API are new to v10.0.0:

- `CreateResourceSetAsync()`
- `DeleteResourceSetAsync()`
- `GetResourceSetAsync()`
- `ListResourceSets()`
- `ReplaceResourceSetAsync()`

#### RoleCResourceSetResourceApi

All methods in this API are new to v10.0.0:

- `AddResourceToResourceSetAsync()`
- `DeleteResourceFromResourceSetAsync()`
- `ListResourceSetResources()`

#### RoleDResourceSetBindingApi

All methods in this API are new to v10.0.0:

- `CreateResourceSetBindingAsync()`
- `DeleteResourceSetBindingAsync()`
- `GetResourceSetBindingAsync()`
- `ListResourceSetBindings()`
- `ReplaceResourceSetBindingAsync()`

#### RoleDResourceSetBindingMemberApi

All methods in this API are new to v10.0.0:

- `AddMemberToResourceSetBindingAsync()`
- `GetMemberOfResourceSetBindingAsync()`
- `ListMembersOfResourceSetBinding()`
- `RemoveMemberFromResourceSetBindingAsync()`

---

### ServiceAccountApi [NEW API]

All methods in this API are new:

- `ActivateServiceAccountAsync()`
- `CreateServiceAccountAsync()`
- `DeactivateServiceAccountAsync()`
- `DeleteServiceAccountAsync()`
- `GetServiceAccountAsync()`
- `ListServiceAccounts()`
- `UpdateServiceAccountAsync()`

---

### User* APIs [NEW - Split from UserApi]

#### UserAuthenticatorEnrollmentsApi

All methods in this API are new:

- `GetUserAuthenticatorEnrollmentAsync()`
- `ListUserAuthenticatorEnrollments()`
- `ResetUserAuthenticatorEnrollmentAsync()`

#### UserClassificationApi

All methods in this API are new:

- `GetUserClassificationAsync()`
- `UpdateUserClassificationAsync()`

#### UserCredApi [Methods moved from UserApi]

Methods in this API (moved from `UserApi.cs`):

- `ChangePasswordAsync()` **[MOVED from UserApi]**
- `ChangeRecoveryQuestionAsync()` **[MOVED from UserApi]**
- `ExpirePasswordAsync()` **[MOVED from UserApi]**
- `ExpirePasswordWithTempPasswordAsync()` **[MOVED + RENAMED from UserApi.ExpirePasswordAndGetTemporaryPasswordAsync]**
- `ForgotPasswordAsync()` **[MOVED from UserApi]**
- `ForgotPasswordSetNewPasswordAsync()` **[MOVED from UserApi]**
- `ResetPasswordAsync()` **[MOVED + RENAMED from UserApi.GenerateResetPasswordTokenAsync]** - Same functionality, different method name
- `RevokeUserSessionsAsync()` **[NEW]**
- `SetPasswordAsync()` **[NEW]**

#### UserGrantApi [Methods moved from UserApi]

Methods in this API (moved from `UserApi.cs`):

- `GetUserGrantAsync()` **[MOVED from UserApi]**
- `ListUserGrants()` **[MOVED from UserApi]**
- `RevokeUserGrantAsync()` **[MOVED from UserApi]**
- `RevokeUserGrantsAsync()` **[MOVED from UserApi]**

#### UserLifecycleApi [Methods moved from UserApi]

Methods in this API (moved from `UserApi.cs`):

- `ActivateUserAsync()` **[MOVED from UserApi]**
- `DeactivateUserAsync()` **[MOVED from UserApi]**
- `ReactivateUserAsync()` **[NEW]**
- `SuspendUserAsync()` **[NEW]**
- `UnsuspendUserAsync()` **[NEW]**
- `UnlockUserAsync()` **[NEW]**

#### UserLinkedObjectApi [Methods moved from UserApi]

Methods in this API (moved from `UserApi.cs`):

- `DeleteLinkedObjectForUserAsync()` **[MOVED from UserApi]**
- `GetLinkedObjectForUserAsync()` **[NEW]**
- `ListLinkedObjectsForUser()` **[MOVED from UserApi]**
- `SetLinkedObjectForUserAsync()` **[MOVED from UserApi]**

#### UserOAuthApi [Methods moved from UserApi]

Methods in this API (moved from `UserApi.cs`):

- `GetRefreshTokenForUserAndClientAsync()` **[MOVED from UserApi]**
- `ListGrantsForUserAndClient()` **[MOVED from UserApi]**
- `ListRefreshTokensForUserAndClient()` **[NEW]**
- `RevokeGrantsForUserAndClientAsync()` **[MOVED from UserApi]**
- `RevokeRefreshTokenForUserAndClientAsync()` **[NEW]**
- `RevokeRefreshTokensForUserAndClientAsync()` **[NEW]**

#### UserResourcesApi [Methods moved from UserApi]

Methods in this API (moved from `UserApi.cs`):

- `ListAppLinks()` **[MOVED from UserApi]**
- `ListAppTargetsForAppAdminRoleAsync()` **[NEW]**
- `ListAssignedApplicationsForUser()` **[NEW]**

#### UserRiskApi

All methods in this API are new:

- `GetUserRiskAsync()`
- `UpdateUserRiskAsync()`

#### UserSessionsApi [Methods moved from UserApi]

Methods in this API (moved from `UserApi.cs`):

- `ClearUserSessions()` **[MOVED from UserApi]**
- `GetUserSessionAsync()` **[NEW]**
- `ListUserSessions()` **[NEW]**
- `RevokeUserSessionAsync()` **[NEW]**

---

### WebAuthnPreregistrationApi [NEW API]

All methods in this API are new:

- `CreateWebAuthnPreregistrationAsync()`
- `DeleteWebAuthnPreregistrationAsync()`
- `GetWebAuthnPreregistrationAsync()`
- `ListWebAuthnPreregistrations()`

---

## Summary of Changes

### Key Architectural Changes

1. **API Splitting**: Several monolithic APIs were split into focused APIs:
   - `OrgSettingApi` → 7 specialized org setting APIs
   - `RoleApi` → 8 specialized role management APIs
   - `UserApi` → 8 specialized user operation APIs
   - `ResourceSetApi` → 4 specialized resource/role binding APIs

2. **Removed APIs**:
   - `ApplicationCredentialsApi.cs` (functionality moved elsewhere)

3. **New Feature APIs**: 24 completely new API classes were added for new features and capabilities

4. **Parameter Changes**: Some methods gained new optional parameters for enhanced functionality (e.g., `useOptimization` in ApplicationApi)

5. **Method Movement**: Many methods were moved from general APIs to specialized ones for better organization and maintainability

### Statistics

- **73 API classes** in v9.x analyzed
- **102 API classes** in v10.0.0 (29 new)
- **1 API removed** (ApplicationCredentialsApi)
- **60+ APIs** remain unchanged
- **4 major API splits** (User, OrgSetting, Role, ResourceSet)

### Migration Strategy

1. **For IDENTICAL methods**: No code changes required

2. **For SPLIT APIs**: Review the method you're using and identify which specialized API now contains it

3. **For MOVED methods**: Update your using statements and API client instantiation to reference the new API class

4. **For REMOVED functionality**: Check ApplicationSSOApi and related APIs for alternative approaches

5. **For new parameters**: Review optional parameters and determine if they benefit your use case

### Benefits of This Refactoring

- **Better organization**: Related operations grouped logically
- **Improved maintainability**: Smaller, focused API clients
- **Enhanced discoverability**: Clear API naming indicates purpose
- **Easier testing**: Focused clients are easier to mock and test
- **Reduced complexity**: Smaller surface area per client

---

## Document Information

- **Generated:** October 28, 2025
- **SDK Version:** v10.0.0
- **Old API Base:** OldApi directory (v9.x)
- **New API Base:** src/Okta.Sdk/Api directory (v10.0.0)

For questions or clarifications, please refer to:
- The [MIGRATING.md](MIGRATING.md) file for migration guide
- [Okta .NET SDK documentation](https://github.com/okta/okta-sdk-dotnet)
- [Developer Forum](https://devforum.okta.com)
- [GitHub Issues](https://github.com/okta/okta-sdk-dotnet/issues)
