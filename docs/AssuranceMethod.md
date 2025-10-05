# Okta.Sdk.Model.AssuranceMethod

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | [**PolicyRuleVerificationMethodType**](PolicyRuleVerificationMethodType.md) |  | [optional] 
**Constraints** | [**List&lt;AccessPolicyConstraints&gt;**](AccessPolicyConstraints.md) | Specifies constraints for the authenticator. Constraints are logically evaluated such that only one constraint object needs to be satisfied. But, within a constraint object, each constraint property must be satisfied. | [optional] 
**FactorMode** | **AssuranceMethodFactorMode** |  | [optional] 
**InactivityPeriod** | **string** | The inactivity duration after which the user must re-authenticate. Use the ISO 8601 period format (for example, PT2H). | [optional] 
**ReauthenticateIn** | **string** | The duration after which the user must re-authenticate, regardless of user activity. Keep in mind that the re-authentication intervals for constraints take precedent over this value. Use the ISO 8601 period format for recurring time intervals (for example, PT2H, PT0S, PT43800H, and so on). | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

