# Okta.Sdk.Model.UserLinks
Specifies link relations (see [Web Linking](https://datatracker.ietf.org/doc/html/rfc8288) available for the current status of a user. The Links object is used for dynamic discovery of related resources, lifecycle operations, and credential operations. The Links object is read-only.  For an individual user result, the Links object contains a full set of link relations available for that user as determined by your policies. For a collection of users, the Links object contains only the self link. Operations that return a collection of Users include List Users and List Group Members.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Self** | [**HrefObject**](HrefObject.md) |  | [optional] 
**Activate** | [**HrefObject**](HrefObject.md) |  | [optional] 
**ResetPassword** | [**HrefObject**](HrefObject.md) |  | [optional] 
**ResetFactors** | [**HrefObject**](HrefObject.md) |  | [optional] 
**ExpirePassword** | [**HrefObject**](HrefObject.md) |  | [optional] 
**ForgotPassword** | [**HrefObject**](HrefObject.md) |  | [optional] 
**ChangeRecoveryQuestion** | [**HrefObject**](HrefObject.md) |  | [optional] 
**Deactivate** | [**HrefObject**](HrefObject.md) |  | [optional] 
**Reactivate** | [**HrefObject**](HrefObject.md) |  | [optional] 
**ChangePassword** | [**HrefObject**](HrefObject.md) |  | [optional] 
**Schema** | [**HrefObject**](HrefObject.md) |  | [optional] 
**Suspend** | [**HrefObject**](HrefObject.md) |  | [optional] 
**Unsuspend** | [**HrefObject**](HrefObject.md) |  | [optional] 
**Unlock** | [**HrefObject**](HrefObject.md) |  | [optional] 
**Type** | [**HrefObject**](HrefObject.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

