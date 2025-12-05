# Okta.Sdk.Model.Agent
Agent details

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | Unique identifier for the agent that&#39;s generated during installation | [optional] [readonly] 
**IsHidden** | **bool** | Determines if an agent is hidden from the Admin Console | [optional] 
**IsLatestGAedVersion** | **bool** | Determines if the agent is on the latest generally available version | [optional] 
**LastConnection** | **long** | Unix timestamp in milliseconds when the agent last connected to Okta | [optional] 
**Name** | **string** | Agent name | [optional] 
**OperationalStatus** | **OperationalStatus** |  | [optional] 
**PoolId** | **string** | Pool ID | [optional] 
**Type** | **AgentType** |  | [optional] 
**UpdateMessage** | **string** | Status message of the agent | [optional] 
**UpdateStatus** | **AgentUpdateInstanceStatus** |  | [optional] 
**_Version** | **string** | Agent version number | [optional] 
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

