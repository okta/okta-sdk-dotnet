# Okta.Sdk.Model.AccessPolicy

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset** | Timestamp when the Policy was created | [optional] [readonly] 
**Description** | **string** | Policy description | [optional] 
**Id** | **string** | Policy ID | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the Policy was last updated | [optional] [readonly] 
**Name** | **string** | Policy name | [optional] 
**Priority** | **int** | Specifies the order in which this Policy is evaluated in relation to the other policies | [optional] 
**Status** | [**LifecycleStatus**](LifecycleStatus.md) |  | [optional] 
**System** | **bool** | Specifies whether Okta created the Policy | [optional] 
**Type** | [**PolicyType**](PolicyType.md) |  | [optional] 
**Embedded** | **Dictionary&lt;string, Object&gt;** |  | [optional] [readonly] 
**Links** | [**PolicyLinks**](PolicyLinks.md) |  | [optional] 
**Conditions** | [**PolicyRuleConditions**](PolicyRuleConditions.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

