# Okta.Sdk.Model.AuthorizationServerPolicy

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | ID of the Policy | [optional] 
**Type** | **string** | Indicates that the Policy is an authorization server Policy | [optional] 
**Name** | **string** | Name of the Policy | [optional] 
**Conditions** | [**AuthorizationServerPolicyConditions**](AuthorizationServerPolicyConditions.md) |  | [optional] 
**Description** | **string** | Description of the Policy | [optional] 
**Priority** | **int** | Specifies the order in which this Policy is evaluated in relation to the other Policies in a custom authorization server | [optional] 
**Status** | **string** | Specifies whether requests have access to this Policy | [optional] 
**System** | **bool** | Specifies whether Okta created this Policy | [optional] 
**Created** | **DateTimeOffset** | Timestamp when the Policy was created | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the Policy was last updated | [optional] [readonly] 
**Links** | [**LinksSelfAndLifecycle**](LinksSelfAndLifecycle.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

