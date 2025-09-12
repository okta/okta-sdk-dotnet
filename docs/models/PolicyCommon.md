# Okta.Sdk.Model.PolicyCommon

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the policy | 
**Type** | **PolicyType** |  | 
**Created** | **DateTimeOffset** | Timestamp when the policy was created | [optional] [readonly] 
**Description** | **string** | Description of the Policy | [optional] 
**Id** | **string** | Identifier of the Policy | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the policy was last modified | [optional] [readonly] 
**Priority** | **int** | Specifies the order in which this policy is evaluated in relation to the other policies | [optional] [default to 1]
**Status** | **LifecycleStatus** | Whether or not the policy is active. Use the &#x60;activate&#x60; query parameter to set the status of a policy. | [optional] 
**System** | **bool** | Specifies whether Okta created the Policy | [optional] [default to false]
**Embedded** | **Dictionary&lt;string, Object&gt;** |  | [optional] [readonly] 
**Links** | [**PolicyLinks**](PolicyLinks.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

