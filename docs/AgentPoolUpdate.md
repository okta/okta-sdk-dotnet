# Okta.Sdk.Model.AgentPoolUpdate
Various information about agent auto-update configuration

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Agents** | [**List&lt;Agent&gt;**](Agent.md) |  | [optional] 
**AgentType** | **AgentType** |  | [optional] 
**Enabled** | **bool** | Indicates if auto-update is enabled for the agent pool | [optional] 
**Id** | **string** | ID of the agent pool update | [optional] [readonly] 
**Name** | **string** | Name of the agent pool update | [optional] 
**NotifyAdmin** | **bool** | Indicates if the admin is notified about the update | [optional] 
**Reason** | **string** | Reason for the update | [optional] 
**Schedule** | [**AutoUpdateSchedule**](AutoUpdateSchedule.md) |  | [optional] 
**SortOrder** | **int** | Specifies the sort order | [optional] 
**Status** | **AgentUpdateJobStatus** |  | [optional] 
**TargetVersion** | **string** | The agent version to update to | [optional] 
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

