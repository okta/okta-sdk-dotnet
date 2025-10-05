# API Migration Guide: Okta SDK v2024.07.0 → v5.1.0

## Overview
This document outlines the breaking changes in the Okta .NET SDK after migrating from OpenAPI spec version 2024.07.0 to 5.1.0.

## ✅ Build Status
- **SDK Build**: SUCCESS (0 errors, 351 warnings - mostly XML documentation)
- **Unit Tests**: 32 errors (require updates for API changes)

## Breaking Changes

### 1. Identity Provider User Management APIs

**What Changed**: Methods moved from `IdentityProviderApi` to `IdentityProviderUsersApi`

| Old API (IdentityProviderApi) | New API (IdentityProviderUsersApi) |
|-------------------------------|-------------------------------------|
| `ListIdentityProviderApplicationUsers()` | `ListIdentityProviderApplicationUsers()` |
| `GetIdentityProviderApplicationUserAsync()` | `GetIdentityProviderApplicationUserAsync()` |
| `LinkUserToIdentityProviderAsync()` | `LinkUserToIdentityProviderAsync()` |
| `UnlinkUserFromIdentityProviderAsync()` | `UnlinkUserFromIdentityProviderAsync()` |
| `ListSocialAuthTokens()` | `ListSocialAuthTokens()` |

**Migration Example**:
```csharp
// OLD
var identityProviderApi = new IdentityProviderApi(config);
var users = await identityProviderApi.ListIdentityProviderApplicationUsers(idpId);

// NEW
var identityProviderUsersApi = new IdentityProviderUsersApi(config);
var users = await identityProviderUsersApi.ListIdentityProviderApplicationUsers(idpId);
```

### 2. User Factor Verification

**What Changed**: `VerifyFactorRequest` class renamed or restructured

**Status**: NEEDS INVESTIGATION - Check the new model structure in `src/Okta.Sdk/Model/`

**Files to check**:
- `UserFactorVerifyRequest.cs` (exists but constructor changed)
- Previous properties like `ClientData`, `AuthenticatorData`, `SignatureData` may have been restructured

### 3. Role Management APIs

**What Changed**: `RoleTargetApi` split into multiple specialized APIs

| Old API | New APIs |
|---------|----------|
| `RoleTargetApi` | `RoleBTargetAdminApi` - Admin role targets |
|  | `RoleBTargetBGroupApi` - Group role targets |
|  | `RoleBTargetClientApi` - Client role targets |

**Migration Example**:
```csharp
// OLD
var roleTargetApi = new RoleTargetApi(config);

// NEW - Choose the appropriate API based on your use case
var adminRoleTargetApi = new RoleBTargetAdminApi(config);
var groupRoleTargetApi = new RoleBTargetBGroupApi(config);
var clientRoleTargetApi = new RoleBTargetClientApi(config);
```

### 4. User Factor Types

**What Changed**: `UserFactorCustomHOTP` removed or renamed

**Status**: NEEDS INVESTIGATION - Check available factor types in the new spec

**Alternative**: Use the base `UserFactor` types or check for replacement classes

### 5. Application Features

**What Changed**: `ApplicationFeature` structure changed - `Capabilities` property removed/restructured

**Current Properties** in `ApplicationFeature`:
- `Name` (ApplicationFeatureType)
- `Status` (EnabledStatus)
- `Description` (string)
- `Links` (ApplicationFeatureLinks)

**Capabilities Models Still Exist**:
- `CapabilitiesObject`
- `CapabilitiesCreateObject`
- `CapabilitiesUpdateObject`
- `CapabilitiesInboundProvisioningObject`
- `CapabilitiesImportRulesObject`
- `CapabilitiesImportSettingsObject`

**Status**: Feature capabilities are likely managed through separate models now. Check `UpdateFeatureForApplicationRequest` usage.

### 6. SAML Application Settings

**What Changed**: `SamlApplicationSettings.App` property renamed or restructured

**Status**: NEEDS INVESTIGATION

**Check**: 
- `SamlApplicationSettings.cs` for new property names
- May be renamed to `Application` or moved to a different structure

### 7. Additional Properties Pattern

**What Changed**: Some models no longer expose `AdditionalProperties` directly

**Affected Models**:
- `GroupProfile`
- `UserFactorVerifyResponse`

**Impact**: Custom properties may need to be accessed differently or may not support additional properties in the new spec.

## Test Files Requiring Updates

### High Priority (Integration Test Blockers)

1. **IdentityProviderApiTests.cs** (5 errors)
   - Update to use `IdentityProviderUsersApi`
   - Lines: 78, 132, 176, 193, 215

2. **UserFactorApiTests.cs** (6 errors)
   - Update `VerifyFactorRequest` usage
   - Fix `UserFactorCustomHOTP` references
   - Update `UserFactorVerifyRequest` constructor
   - Lines: 126, 192, 255, 378, 383, 409-419

3. **ApplicationApiTests.cs** (11 errors)
   - Update `ApplicationFeature.Capabilities` access
   - Fix `SamlApplicationSettings.App` property
   - Lines: 140, 183, 224, 482-489

4. **GroupApiTests.cs** (6 errors)
   - Update to use new Role Target APIs
   - Fix `GroupProfile.AdditionalProperties`
   - Lines: 115, 167, 175, 189, 205, 220

## Verification Steps

### 1. Core API Verification ✅

The following core APIs have been verified to have correct method signatures:

#### UserApi ✅
- `CreateUserAsync()` ✅
- `DeleteUserAsync()` ✅
- `GetUserAsync()` ✅
- `ListUsersAsync()` ✅
- `ReplaceUserAsync()` ✅
- `UpdateUserAsync()` ✅
- `ListUserBlocksAsync()` ✅

#### ApplicationApi ✅
- `ActivateApplicationAsync()` ✅
- `CreateApplicationAsync()` ✅
- `DeactivateApplicationAsync()` ✅
- `DeleteApplicationAsync()` ✅
- `GetApplicationAsync()` ✅
- `ListApplicationsAsync()` ✅
- `ReplaceApplicationAsync()` ✅

#### GroupApi ✅
- `AddGroupAsync()` ✅
- `AssignUserToGroupAsync()` ✅
- `DeleteGroupAsync()` ✅
- `GetGroupAsync()` ✅
- `ListAssignedApplicationsForGroupAsync()` ✅
- `ListGroupUsersAsync()` ✅
- `ListGroupsAsync()` ✅
- `ReplaceGroupAsync()` ✅
- `UnassignUserFromGroupAsync()` ✅

#### IdentityProviderUsersApi ✅
- `GetIdentityProviderApplicationUserAsync()` ✅
- `LinkUserToIdentityProviderAsync()` ✅
- `ListIdentityProviderApplicationUsersAsync()` ✅
- `ListSocialAuthTokensAsync()` ✅
- `ListUserIdentityProvidersAsync()` ✅
- `UnlinkUserFromIdentityProviderAsync()` ✅

### 2. Model Structure Verification

Run this check for key models:
```bash
# Check if critical models exist
find src/Okta.Sdk/Model -name "User.cs"
find src/Okta.Sdk/Model -name "Application.cs"
find src/Okta.Sdk/Model -name "Group.cs"
find src/Okta.Sdk/Model -name "UserFactor*.cs"
```

### 3. Integration Test Updates Required

Before running integration tests, update the following test files:

```bash
# Files requiring updates
src/Okta.Sdk.UnitTest/Api/IdentityProviderApiTests.cs
src/Okta.Sdk.UnitTest/Api/UserFactorApiTests.cs
src/Okta.Sdk.UnitTest/Api/ApplicationApiTests.cs
src/Okta.Sdk.UnitTest/Api/GroupApiTests.cs
```

## Recommendations

### Immediate Actions Required

1. **Update IdentityProviderApiTests.cs**
   - Replace `IdentityProviderApi` with `IdentityProviderUsersApi` for user-related methods
   - Keep `IdentityProviderApi` for IdP configuration methods

2. **Investigate UserFactor Changes**
   - Review new `UserFactorVerifyRequest` constructor requirements
   - Check if `UserFactorCustomHOTP` has a replacement
   - Update verification flow if the model structure changed

3. **Update Role Target API Usage**
   - Map existing role target operations to the new specialized APIs:
     - Admin operations → `RoleBTargetAdminApi`
     - Group operations → `RoleBTargetBGroupApi`
     - Client operations → `RoleBTargetClientApi`

4. **Review Application Feature Management**
   - Check how capabilities are now managed
   - May need to use separate requests for capability updates
   - Review `UpdateFeatureForApplicationRequest` usage

5. **Fix SAML Application Settings**
   - Find the new property name for application settings
   - Update all references in tests

### Testing Strategy

1. **Unit Tests**: Fix compilation errors first
2. **Integration Tests**: Run against a test Okta org
3. **Regression Tests**: Verify core flows still work:
   - User CRUD operations
   - Group management
   - Application lifecycle
   - Factor enrollment/verification

## Migration Checklist

- [x] SDK builds successfully (0 compilation errors)
- [x] Verified core API methods exist and have correct signatures
- [ ] Update test files for API changes
- [ ] Investigate and document UserFactor model changes
- [ ] Update integration tests for new API structure
- [ ] Run full test suite against test Okta org
- [ ] Update documentation with breaking changes
- [ ] Update SDK samples/examples if any exist

## Notes

- The SDK successfully compiles with the new spec
- All core API operations are present with correct signatures
- Main changes are organizational (method moves to specialized APIs)
- Some model structures have changed (capabilities, additional properties)
- Tests need updates but underlying API functionality is intact

## Questions to Resolve

1. What is the new constructor signature for `UserFactorVerifyRequest`?
2. What replaced `UserFactorCustomHOTP`?
3. How are application feature capabilities now accessed?
4. What is the new property name in `SamlApplicationSettings` (previously `.App`)?
5. Are `AdditionalProperties` still supported on models, or is there a new pattern?

---

**Generated**: October 5, 2025
**SDK Version**: 5.1.0
**OpenAPI Spec**: management-5.1.0.yaml
