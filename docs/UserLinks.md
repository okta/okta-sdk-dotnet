# Okta.Sdk.Model.UserLinks
Specifies link relations (see [Web Linking](https://datatracker.ietf.org/doc/html/rfc8288) available for the current status of a user. The Links object is used for dynamic discovery of related resources, lifecycle operations, and credential operations. The Links object is read-only.  For an individual user result, the Links object contains a full set of link relations available for that user as determined by your policies. For a collection of users, the Links object contains only the `self` link. Operations that return a collection of Users include List Users and List Group Members.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Self** | [**UserLinksAllOfSelf**](UserLinksAllOfSelf.md) |  | [optional] 
**Activate** | [**UserLinksAllOfActivate**](UserLinksAllOfActivate.md) |  | [optional] 
**ResetPassword** | [**UserLinksAllOfResetPassword**](UserLinksAllOfResetPassword.md) |  | [optional] 
**ResetFactors** | [**UserLinksAllOfResetFactors**](UserLinksAllOfResetFactors.md) |  | [optional] 
**ExpirePassword** | [**UserLinksAllOfExpirePassword**](UserLinksAllOfExpirePassword.md) |  | [optional] 
**ForgotPassword** | [**UserLinksAllOfForgotPassword**](UserLinksAllOfForgotPassword.md) |  | [optional] 
**ChangeRecoveryQuestion** | [**UserLinksAllOfChangeRecoveryQuestion**](UserLinksAllOfChangeRecoveryQuestion.md) |  | [optional] 
**Deactivate** | [**UserLinksAllOfDeactivate**](UserLinksAllOfDeactivate.md) |  | [optional] 
**Reactivate** | [**UserLinksAllOfReactivate**](UserLinksAllOfReactivate.md) |  | [optional] 
**ChangePassword** | [**UserLinksAllOfChangePassword**](UserLinksAllOfChangePassword.md) |  | [optional] 
**Schema** | [**UserLinksAllOfSchema**](UserLinksAllOfSchema.md) |  | [optional] 
**Suspend** | [**UserLinksAllOfSuspend**](UserLinksAllOfSuspend.md) |  | [optional] 
**Unsuspend** | [**UserLinksAllOfUnsuspend**](UserLinksAllOfUnsuspend.md) |  | [optional] 
**Unlock** | [**UserLinksAllOfUnlock**](UserLinksAllOfUnlock.md) |  | [optional] 
**Type** | [**UserLinksAllOfType**](UserLinksAllOfType.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

