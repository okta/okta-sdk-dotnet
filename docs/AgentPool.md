# Okta.Sdk.Model.AgentPool
An AgentPool is a collection of agents that serve a common purpose. An AgentPool has a unique ID within an org, and contains a collection of agents disjoint to every other AgentPool (i.e. no two AgentPools share an Agent).

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Agents** | [**List&lt;Agent&gt;**](Agent.md) |  | [optional] 
**Id** | **string** |  | [optional] [readonly] 
**Name** | **string** |  | [optional] 
**OperationalStatus** | **string** | Operational status of a given agent | [optional] 
**Type** | **string** | Agent types that are being monitored | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

