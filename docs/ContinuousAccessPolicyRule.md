# Okta.Sdk.Model.ContinuousAccessPolicyRule

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset?** | Timestamp when the rule was created | [optional] [readonly] 
**Id** | **string** | Identifier for the rule | [optional] 
**LastUpdated** | **DateTimeOffset?** | Timestamp when the rule was last modified | [optional] [readonly] 
**Name** | **string** | Name of the rule | [optional] 
**Priority** | **int?** | Priority of the rule | [optional] 
**Status** | [**LifecycleStatus**](LifecycleStatus.md) |  | [optional] 
**System** | **bool** | Specifies whether Okta created the Policy Rule (&#x60;system&#x3D;true&#x60;). You can&#39;t delete Policy Rules that have &#x60;system&#x60; set to &#x60;true&#x60;. | [optional] [default to false]
**Type** | [**PolicyRuleType**](PolicyRuleType.md) |  | [optional] 
**Actions** | [**ContinuousAccessPolicyRuleAllOfActions**](ContinuousAccessPolicyRuleAllOfActions.md) |  | [optional] 
**Conditions** | [**ContinuousAccessPolicyRuleAllOfConditions**](ContinuousAccessPolicyRuleAllOfConditions.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

