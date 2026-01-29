# Okta.Sdk.Model.AuthorizationServerPolicyRuleRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Actions** | [**AuthorizationServerPolicyRuleActions**](AuthorizationServerPolicyRuleActions.md) |  | [optional] 
**Conditions** | [**AuthorizationServerPolicyRuleConditions**](AuthorizationServerPolicyRuleConditions.md) |  | 
**Created** | **DateTimeOffset** | Timestamp when the rule was created | [optional] [readonly] 
**Id** | **string** | Identifier of the rule | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the rule was last modified | [optional] [readonly] 
**Name** | **string** | Name of the rule | 
**Priority** | **int** | Priority of the rule | [optional] 
**Status** | **string** | Status of the rule | [optional] 
**System** | **bool** | Set to &#x60;true&#x60; for system rules. You can&#39;t delete system rules. | [optional] 
**Type** | **string** | Rule type | [default to TypeEnum.RESOURCEACCESS]
**Links** | [**AuthorizationServerPolicyRuleLinks**](AuthorizationServerPolicyRuleLinks.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

