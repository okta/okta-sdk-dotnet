# Okta.Sdk.Model.UserFactorLinks

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Activate** | [**HrefObject**](HrefObject.md) | Activates an enrolled factor. See [Activate a factor](/openapi/okta-management/management/tag/UserFactor/#tag/UserFactor/operation/activateFactor). | [optional] 
**Cancel** | [**HrefObject**](HrefObject.md) | Cancels a &#x60;push&#x60; factor challenge with a &#x60;WAITING&#x60; status | [optional] 
**Deactivate** | [**HrefObject**](HrefObject.md) | Deactivates the factor. See [Unenroll a factor](/openapi/okta-management/management/tag/UserFactor/#tag/UserFactor/operation/unenrollFactor). | [optional] 
**Enroll** | [**HrefObject**](HrefObject.md) | Enrolls a supported factor. See [Enroll a factor](/openapi/okta-management/management/tag/UserFactor/#tag/UserFactor/operation/enrollFactor). | [optional] 
**Factor** | [**HrefObject**](HrefObject.md) | Link to the factor resource | [optional] 
**Poll** | [**HrefObject**](HrefObject.md) | Polls the factor resource for status information. Always use the &#x60;poll&#x60; link instead of manually constructing your own URL. | [optional] 
**Qrcode** | [**HrefObject**](HrefObject.md) | QR code that encodes the push activation code needed for enrollment on the device | [optional] 
**Question** | [**HrefObject**](HrefObject.md) | Lists all supported security questions. See [List all supported security questions](/openapi/okta-management/management/tag/UserFactor/#tag/UserFactor/operation/listSupportedSecurityQuestions). | [optional] 
**Resend** | [**HrefObject**](HrefObject.md) | Resends the factor enrollment challenge. See [Resend a factor enrollment](/openapi/okta-management/management/tag/UserFactor/#tag/UserFactor/operation/resendEnrollFactor). | [optional] 
**Send** | [**HrefObject**](HrefObject.md) | Sends an activation link through email or sms for users who can&#39;t scan the QR code | [optional] 
**Self** | [**HrefObjectSelfLink**](HrefObjectSelfLink.md) |  | [optional] 
**User** | [**HrefObject**](HrefObject.md) | Returns information on the specified user | [optional] 
**Verify** | [**HrefObject**](HrefObject.md) | Verifies the factor resource. See [Verify a factor](/openapi/okta-management/management/tag/UserFactor/#tag/UserFactor/operation/verifyFactor). | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

