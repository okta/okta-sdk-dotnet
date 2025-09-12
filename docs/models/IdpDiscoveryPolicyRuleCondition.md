# Okta.Sdk.Model.IdpDiscoveryPolicyRuleCondition
Specifies conditions that must be met during policy evaluation to apply the rule. All policy conditions and conditions for at least one rule must be met to apply the settings specified in the policy and the associated rule.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**App** | [**AppAndInstancePolicyRuleCondition**](AppAndInstancePolicyRuleCondition.md) |  | [optional] 
**Network** | [**PolicyNetworkCondition**](PolicyNetworkCondition.md) |  | [optional] 
**Platform** | [**PlatformPolicyRuleCondition**](PlatformPolicyRuleCondition.md) |  | [optional] 
**UserIdentifier** | [**UserIdentifierPolicyRuleCondition**](UserIdentifierPolicyRuleCondition.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

