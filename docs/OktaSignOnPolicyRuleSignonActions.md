# Okta.Sdk.Model.OktaSignOnPolicyRuleSignonActions
Specifies settings for the policy rule

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Access** | **string** | Indicates if a user is allowed to sign in | [optional] 
**FactorLifetime** | **int** | Interval of time that must elapse before the user is challenged for MFA, if the factor prompt mode is set to &#x60;SESSION&#x60;  &gt; **Note:** Required only if &#x60;requireFactor&#x60; is &#x60;true&#x60;.  | [optional] 
**FactorPromptMode** | **OktaSignOnPolicyFactorPromptMode** |  | [optional] 
**PrimaryFactor** | **OktaSignOnPolicyRuleSignonPrimaryFactor** |  | [optional] 
**RememberDeviceByDefault** | **bool** | Indicates if Okta should automatically remember the device | [optional] [default to false]
**RequireFactor** | **bool** | Indicates if multifactor authentication is required | [optional] [default to false]
**Session** | [**OktaSignOnPolicyRuleSignonSessionActions**](OktaSignOnPolicyRuleSignonSessionActions.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

