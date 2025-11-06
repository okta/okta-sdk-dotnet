# Okta.Sdk.Model.AuthenticatorEnrollmentPolicyRule

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset?** | Timestamp when the rule was created | [optional] [readonly] 
**Id** | **string** | Identifier for the rule | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset?** | Timestamp when the rule was last modified | [optional] [readonly] 
**Name** | **string** | Name of the rule | [optional] 
**Priority** | **int?** | Priority of the rule | [optional] 
**Status** | [**LifecycleStatus**](LifecycleStatus.md) |  | [optional] 
**System** | **bool** | Specifies whether Okta created the policy rule (&#x60;system&#x3D;true&#x60;). You can&#39;t delete policy rules that have &#x60;system&#x60; set to &#x60;true&#x60;. | [optional] [default to false]
**Type** | [**PolicyRuleType**](PolicyRuleType.md) |  | [optional] 
**Links** | [**PolicyLinks**](PolicyLinks.md) |  | [optional] 
**Actions** | [**AuthenticatorEnrollmentPolicyRuleActions**](AuthenticatorEnrollmentPolicyRuleActions.md) |  | [optional] 
**Conditions** | [**AuthenticatorEnrollmentPolicyRuleConditions**](AuthenticatorEnrollmentPolicyRuleConditions.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

