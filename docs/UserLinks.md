# Okta.Sdk.Model.UserLinks
Specifies link relations (see [Web Linking](https://datatracker.ietf.org/doc/html/rfc8288) available for the current status of a user. The Links object is used for dynamic discovery of related resources, lifecycle operations, and credential operations. The Links object is read-only.  For an individual user result, the Links object contains a full set of link relations available for that user as determined by your policies. For a collection of users, the Links object contains only the `self` link. Operations that return a collection of Users include List Users and List Group Members.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Self** | [**HrefObject**](HrefObject.md) | URL to the individual user | [optional] 
**Activate** | [**HrefObject**](HrefObject.md) | URL to activate the user | [optional] 
**ResetPassword** | [**HrefObject**](HrefObject.md) | URL to reset the user&#39;s password | [optional] 
**ResetFactors** | [**HrefObject**](HrefObject.md) | URL to reset the user&#39;s factors | [optional] 
**ExpirePassword** | [**HrefObject**](HrefObject.md) | URL to expire the user&#39;s password | [optional] 
**ForgotPassword** | [**HrefObject**](HrefObject.md) | URL to initiate a forgot password operation | [optional] 
**ChangeRecoveryQuestion** | [**HrefObject**](HrefObject.md) | URL to change the user&#39;s recovery question | [optional] 
**Deactivate** | [**HrefObject**](HrefObject.md) | URL to deactivate a user | [optional] 
**Reactivate** | [**HrefObject**](HrefObject.md) | URL to reactivate the user | [optional] 
**ChangePassword** | [**HrefObject**](HrefObject.md) | URL to change the user&#39;s password | [optional] 
**Schema** | [**HrefObject**](HrefObject.md) | URL to the user&#39;s profile schema | [optional] 
**Suspend** | [**HrefObject**](HrefObject.md) | URL to suspend the user | [optional] 
**Unsuspend** | [**HrefObject**](HrefObject.md) | URL to unsuspend the user | [optional] 
**Unlock** | [**HrefObject**](HrefObject.md) | URL to unlock the locked-out user | [optional] 
**Type** | [**HrefObject**](HrefObject.md) | URL to the user type | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

