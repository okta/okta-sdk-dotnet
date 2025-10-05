# Okta.Sdk.Model.PolicyCommon

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset** | Timestamp when the policy was created | [optional] [readonly] 
**Description** | **string** | Description of the Policy | [optional] 
**Id** | **string** | Identifier of the Policy | [optional] [readonly] [default to "Assigned"]
**LastUpdated** | **DateTimeOffset** | Timestamp when the policy was last modified | [optional] [readonly] 
**Name** | **string** | Name of the policy | 
**Priority** | **int** | Specifies the order in which this policy is evaluated in relation to the other policies | [optional] 
**Status** | **LifecycleStatus** |  | [optional] 
**System** | **bool** | Specifies whether Okta created the Policy | [optional] [default to false]
**Type** | **PolicyType** |  | 
**Embedded** | **Dictionary&lt;string, Object&gt;** |  | [optional] [readonly] 
**Links** | [**PolicyLinks**](PolicyLinks.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

