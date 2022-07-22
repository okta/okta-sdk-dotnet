# Okta.Sdk.Model.AgentPoolUpdate
Various information about agent auto update configuration

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Agents** | [**List&lt;Agent&gt;**](Agent.md) |  | [optional] 
**AgentType** | **string** | Agent types that are being monitored | [optional] 
**Enabled** | **bool** |  | [optional] 
**Id** | **string** |  | [optional] [readonly] 
**Name** | **string** |  | [optional] 
**NotifyAdmin** | **bool** |  | [optional] 
**Reason** | **string** |  | [optional] 
**Schedule** | [**AutoUpdateSchedule**](AutoUpdateSchedule.md) |  | [optional] 
**SortOrder** | **int** |  | [optional] 
**Status** | **string** | Overall state for the auto-update job from admin perspective | [optional] 
**TargetVersion** | **string** |  | [optional] 
**Links** | [**HrefObject**](HrefObject.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

