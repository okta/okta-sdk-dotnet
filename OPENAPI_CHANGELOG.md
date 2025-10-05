# OpenAPI Specification Changelog

## Summary
Comparison between:
- **Old spec**: `openapi3/management.yaml` (version 2024.07.0)
- **New spec**: `management-minimal.yaml` (version 5.1.0)

**Overall verdict**: **Breaking changes detected** ⚠️

### Statistics
- **206 new API operations added**
- **71 API operations removed**
- **Net change**: +135 operations

---

## 🔴 Breaking Changes

### 1. **Role Management Path Parameter Changes**
The role management endpoints have changed their path parameter naming convention:
- **Removed**: `{roleId}` parameter
- **Added**: `{roleAssignmentId}` parameter

**Affected endpoints (71 removed operations)**:

#### User Role Endpoints
- `/api/v1/users/{userId}/roles/{roleId}` → replaced with `/api/v1/users/{userId}/roles/{roleAssignmentId}`
- All role target operations under users now use `{roleAssignmentId}`

#### Group Role Endpoints
- `/api/v1/groups/{groupId}/roles/{roleId}` → replaced with `/api/v1/groups/{groupId}/roles/{roleAssignmentId}`
- All role target operations under groups now use `{roleAssignmentId}`

#### OAuth2 Client Role Endpoints
- `/oauth2/v1/clients/{clientId}/roles/{roleId}` → replaced with `/oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}`
- All role target operations under OAuth clients now use `{roleAssignmentId}`

### 2. **Hook Keys Parameter Renaming**
- **Removed**: `/api/v1/hook-keys/{hookKeyId}` and `/api/v1/hook-keys/public/{publicKeyId}`
- **Added**: `/api/v1/hook-keys/{id}` and `/api/v1/hook-keys/public/{keyId}`

### 3. **Resource Sets Parameter Renaming**
- **Removed**: `/api/v1/iam/resource-sets/{resourceSetId}/*`
- **Added**: `/api/v1/iam/resource-sets/{resourceSetIdOrLabel}/*`

### 4. **Identity Provider Keys Parameter Changes**
- **Removed**: `{idpKeyId}` parameter in IDP credential key operations
- **Added**: `{kid}` parameter (Key ID standard format)
  - `/api/v1/idps/credentials/keys/{idpKeyId}` → `/api/v1/idps/credentials/keys/{kid}`
  - `/api/v1/idps/{idpId}/credentials/keys/{idpKeyId}` → `/api/v1/idps/{idpId}/credentials/keys/{kid}`

### 5. **User Lifecycle Path Changes**
User-specific operations changed from `{userId}` to `{id}`:
- `/api/v1/users/{userId}/*` endpoints remain for most operations
- **New parallel paths**: `/api/v1/users/{id}/*` for core CRUD and lifecycle operations

---

## ✅ New API Operations (206 added)

### Well-Known Endpoints (3)
- `GET /.well-known/apple-app-site-association`
- `GET /.well-known/assetlinks.json`
- `GET /.well-known/webauthn`

### Application APIs

#### Cross-App Access (CAA) / Cross-Origin (CWO) Connections (5)
- `GET /api/v1/apps/{appId}/cwo/connections`
- `POST /api/v1/apps/{appId}/cwo/connections`
- `GET /api/v1/apps/{appId}/cwo/connections/{connectionId}`
- `PATCH /api/v1/apps/{appId}/cwo/connections/{connectionId}`
- `DELETE /api/v1/apps/{appId}/cwo/connections/{connectionId}`

#### Application Credentials - JWKS (6)
- `GET /api/v1/apps/{appId}/credentials/jwks`
- `POST /api/v1/apps/{appId}/credentials/jwks`
- `GET /api/v1/apps/{appId}/credentials/jwks/{keyId}`
- `DELETE /api/v1/apps/{appId}/credentials/jwks/{keyId}`
- `POST /api/v1/apps/{appId}/credentials/jwks/{keyId}/lifecycle/activate`
- `POST /api/v1/apps/{appId}/credentials/jwks/{keyId}/lifecycle/deactivate`

#### Application Credentials - Secrets (6)
- `GET /api/v1/apps/{appId}/credentials/secrets`
- `POST /api/v1/apps/{appId}/credentials/secrets`
- `GET /api/v1/apps/{appId}/credentials/secrets/{secretId}`
- `DELETE /api/v1/apps/{appId}/credentials/secrets/{secretId}`
- `POST /api/v1/apps/{appId}/credentials/secrets/{secretId}/lifecycle/activate`
- `POST /api/v1/apps/{appId}/credentials/secrets/{secretId}/lifecycle/deactivate`

#### Application Federated Claims (5)
- `GET /api/v1/apps/{appId}/federated-claims`
- `POST /api/v1/apps/{appId}/federated-claims`
- `GET /api/v1/apps/{appId}/federated-claims/{claimId}`
- `PUT /api/v1/apps/{appId}/federated-claims/{claimId}`
- `DELETE /api/v1/apps/{appId}/federated-claims/{claimId}`

#### Group Push Mappings (5)
- `GET /api/v1/apps/{appId}/group-push/mappings`
- `POST /api/v1/apps/{appId}/group-push/mappings`
- `GET /api/v1/apps/{appId}/group-push/mappings/{mappingId}`
- `PATCH /api/v1/apps/{appId}/group-push/mappings/{mappingId}`
- `DELETE /api/v1/apps/{appId}/group-push/mappings/{mappingId}`

#### Other App Endpoints (1)
- `GET /api/v1/apps/{appId}/connections/default/jwks`

### Authenticator APIs

#### AAGUID Management (7)
- `GET /api/v1/authenticators/{authenticatorId}/aaguids`
- `POST /api/v1/authenticators/{authenticatorId}/aaguids`
- `GET /api/v1/authenticators/{authenticatorId}/aaguids/{aaguid}`
- `PUT /api/v1/authenticators/{authenticatorId}/aaguids/{aaguid}`
- `PATCH /api/v1/authenticators/{authenticatorId}/aaguids/{aaguid}`
- `DELETE /api/v1/authenticators/{authenticatorId}/aaguids/{aaguid}`

### Authorization Server APIs

#### Resource Server Credentials Keys (6)
- `GET /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys`
- `POST /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys`
- `GET /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}`
- `DELETE /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}`
- `POST /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}/lifecycle/activate`
- `POST /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}/lifecycle/deactivate`

#### Additional Keys Endpoint (1)
- `GET /api/v1/authorizationServers/{authServerId}/credentials/keys/{keyId}`

### Brand APIs

#### Well-Known URIs Customization (4)
- `GET /api/v1/brands/{brandId}/well-known-uris`
- `GET /api/v1/brands/{brandId}/well-known-uris/{path}`
- `GET /api/v1/brands/{brandId}/well-known-uris/{path}/customized`
- `PUT /api/v1/brands/{brandId}/well-known-uris/{path}/customized`

### Device APIs

#### Device Integrations (4)
- `GET /api/v1/device-integrations`
- `GET /api/v1/device-integrations/{deviceIntegrationId}`
- `POST /api/v1/device-integrations/{deviceIntegrationId}/lifecycle/activate`
- `POST /api/v1/device-integrations/{deviceIntegrationId}/lifecycle/deactivate`

#### Device Posture Checks (5)
- `GET /api/v1/device-posture-checks`
- `POST /api/v1/device-posture-checks`
- `GET /api/v1/device-posture-checks/default`
- `GET /api/v1/device-posture-checks/{postureCheckId}`
- `PUT /api/v1/device-posture-checks/{postureCheckId}`
- `DELETE /api/v1/device-posture-checks/{postureCheckId}`

### Device Access APIs (4)
New `/device-access/api/v1/` namespace:
- `GET /device-access/api/v1/desktop-mfa/enforce-number-matching-challenge-settings`
- `PUT /device-access/api/v1/desktop-mfa/enforce-number-matching-challenge-settings`
- `GET /device-access/api/v1/desktop-mfa/recovery-pin-settings`
- `PUT /device-access/api/v1/desktop-mfa/recovery-pin-settings`

### IAM Governance Bundles (9)
New `/api/v1/iam/governance/` namespace:
- `GET /api/v1/iam/governance/bundles`
- `POST /api/v1/iam/governance/bundles`
- `GET /api/v1/iam/governance/bundles/{bundleId}`
- `PUT /api/v1/iam/governance/bundles/{bundleId}`
- `DELETE /api/v1/iam/governance/bundles/{bundleId}`
- `GET /api/v1/iam/governance/bundles/{bundleId}/entitlements`
- `GET /api/v1/iam/governance/bundles/{bundleId}/entitlements/{entitlementId}/values`
- `GET /api/v1/iam/governance/optIn`
- `POST /api/v1/iam/governance/optIn`
- `POST /api/v1/iam/governance/optOut`

### IAM Resource Sets - Enhanced (15)
Updated paths with `{resourceSetIdOrLabel}`:
- All previous resource set operations now support label-based access
- New operations:
  - `POST /api/v1/iam/resource-sets/{resourceSetIdOrLabel}/resources`
  - `GET /api/v1/iam/resource-sets/{resourceSetIdOrLabel}/resources/{resourceId}`
  - `PUT /api/v1/iam/resource-sets/{resourceSetIdOrLabel}/resources/{resourceId}`

### Identity Provider Keys - Updated (6)
With `{kid}` parameter:
- `GET /api/v1/idps/credentials/keys/{kid}`
- `PUT /api/v1/idps/credentials/keys/{kid}`
- `DELETE /api/v1/idps/credentials/keys/{kid}`
- `GET /api/v1/idps/{idpId}/credentials/keys/{kid}`
- `POST /api/v1/idps/{idpId}/credentials/keys/{kid}/clone`
- `GET /api/v1/idps/{idpId}/credentials/keys/active`

### Organization Settings

#### Yubikey Token Management (3)
- `GET /api/v1/org/factors/yubikey_token/tokens`
- `POST /api/v1/org/factors/yubikey_token/tokens`
- `GET /api/v1/org/factors/yubikey_token/tokens/{tokenId}`

#### Privacy - Aerial Access (3)
- `GET /api/v1/org/privacy/aerial`
- `POST /api/v1/org/privacy/aerial/grant`
- `POST /api/v1/org/privacy/aerial/revoke`

#### Support Cases (2)
- `GET /api/v1/org/privacy/oktaSupport/cases`
- `PATCH /api/v1/org/privacy/oktaSupport/cases/{caseNumber}`

#### Auto-Assign Admin App (2)
- `GET /api/v1/org/settings/autoAssignAdminAppSetting`
- `POST /api/v1/org/settings/autoAssignAdminAppSetting`

#### Org Creator (1)
- `POST /api/v1/orgs`

### Okta Personal Settings (3)
New `/okta-personal-settings/api/v1/` namespace:
- `PUT /okta-personal-settings/api/v1/edit-feature`
- `GET /okta-personal-settings/api/v1/export-blocklists`
- `PUT /okta-personal-settings/api/v1/export-blocklists`

### Privileged Access - Service Accounts (5)
New `/privileged-access/api/v1/` namespace:
- `GET /privileged-access/api/v1/service-accounts`
- `POST /privileged-access/api/v1/service-accounts`
- `GET /privileged-access/api/v1/service-accounts/{id}`
- `PATCH /privileged-access/api/v1/service-accounts/{id}`
- `DELETE /privileged-access/api/v1/service-accounts/{id}`

### SSF (Shared Signals Framework) Stream (7)
New `/api/v1/ssf/` namespace:
- `GET /api/v1/ssf/stream`
- `POST /api/v1/ssf/stream`
- `PUT /api/v1/ssf/stream`
- `PATCH /api/v1/ssf/stream`
- `DELETE /api/v1/ssf/stream`
- `GET /api/v1/ssf/stream/status`
- `POST /api/v1/ssf/stream/verification`

### User APIs

#### User Authenticator Enrollments (5)
- `GET /api/v1/users/{userId}/authenticator-enrollments`
- `POST /api/v1/users/{userId}/authenticator-enrollments/phone`
- `POST /api/v1/users/{userId}/authenticator-enrollments/tac`
- `GET /api/v1/users/{userId}/authenticator-enrollments/{enrollmentId}`
- `DELETE /api/v1/users/{userId}/authenticator-enrollments/{enrollmentId}`

#### User Classification (2)
- `GET /api/v1/users/{userId}/classification`
- `PUT /api/v1/users/{userId}/classification`

#### User Devices (1)
- `GET /api/v1/users/{userId}/devices`

#### User Risk Management (2)
- `GET /api/v1/users/{userId}/risk`
- `PUT /api/v1/users/{userId}/risk`

#### User Role Governance (4)
- `GET /api/v1/users/{userId}/roles/{roleAssignmentId}/governance`
- `GET /api/v1/users/{userId}/roles/{roleAssignmentId}/governance/{grantId}`
- `GET /api/v1/users/{userId}/roles/{roleAssignmentId}/governance/{grantId}/resources`
- `GET /api/v1/users/{userId}/roles/{roleIdOrEncodedRoleId}/targets`

#### User Session Management (1)
- `POST /api/v1/users/me/lifecycle/delete_sessions`

#### User Operations with `{id}` Parameter (12)
Parallel paths for core user operations:
- `GET /api/v1/users/{id}`
- `POST /api/v1/users/{id}`
- `PUT /api/v1/users/{id}`
- `DELETE /api/v1/users/{id}`
- `GET /api/v1/users/{id}/appLinks`
- `GET /api/v1/users/{id}/blocks`
- `GET /api/v1/users/{id}/groups`
- `GET /api/v1/users/{id}/idps`
- Plus all lifecycle operations with `{id}` parameter

### WebAuthn Registration (7)
New `/webauthn-registration/api/v1/` namespace:
- `POST /webauthn-registration/api/v1/activate`
- `POST /webauthn-registration/api/v1/enroll`
- `POST /webauthn-registration/api/v1/initiate-fulfillment-request`
- `POST /webauthn-registration/api/v1/send-pin`
- `GET /webauthn-registration/api/v1/users/{userId}/enrollments`
- `DELETE /webauthn-registration/api/v1/users/{userId}/enrollments/{authenticatorEnrollmentId}`
- `POST /webauthn-registration/api/v1/users/{userId}/enrollments/{authenticatorEnrollmentId}/mark-error`

---

## Schema Changes (Compatibility Issues)

### Breaking Schema Changes
The following endpoints have **broken compatibility** in their request/response schemas:

1. **User Operations**: Missing `status` and `type` properties in PUT requests
2. **Policy Operations**: Changed `status` property type (enum values may have changed)
3. **Identity Provider Operations**: 
   - Changed `protocol` object structure
   - Removed `policy.subject.format` array property
4. **Mapping Operations**: Schema structure changes
5. **Schema Operations**: `definitions` and `properties` changed from one object type to another
6. **Group Users**: Removed `groupRuleId` property from response

### Parameter Changes
- Multiple endpoints changed query parameter types and added/removed parameters
- Common changes:
  - Added `Content-Type` and `If-Match` headers
  - Modified pagination parameters (`after`, `limit`)
  - Changed filter/search parameter types

---

## Migration Recommendations

### High Priority
1. **Update role management integration**: Replace `roleId` with `roleAssignmentId` in all user, group, and OAuth client role operations
2. **Update IDP key operations**: Replace `idpKeyId` with `kid` parameter
3. **Review user lifecycle paths**: Determine if `{userId}` or `{id}` should be used
4. **Update hook key references**: Change `hookKeyId`/`publicKeyId` to `id`/`keyId`

### Medium Priority
1. **Adopt new credential management**: Implement JWKS and secrets management for apps
2. **Evaluate new governance features**: IAM Governance Bundles, user classification, risk management
3. **Consider new device features**: Device posture checks, device integrations
4. **Review SSF stream implementation** if using Shared Signals Framework

### Low Priority
1. **Explore new well-known endpoints** for mobile app links
2. **Consider WebAuthn preregistration** for streamlined authentication flows
3. **Review new org settings**: Yubikey tokens, auto-assign admin apps

---

## Version Information
- **Old Spec Version**: 2024.07.0
- **New Spec Version**: 5.1.0
- **Comparison Date**: October 5, 2025

---

## Notes
- All removed endpoints have equivalent replacements with parameter naming changes
- The new spec introduces significant new functionality around governance, device management, and modern authentication
- Backward compatibility is broken primarily due to parameter renaming rather than endpoint removal
- Consider a phased migration approach focusing on role management changes first
