# Okta.Sdk.Model.AgentPool
An agent pool is a collection of agents that serve a common purpose. An agent pool has a unique ID within an org, and contains a collection of agents disjoint to every other agent pool, meaning that no two agent pools share an agent.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Agents** | [**List&lt;Agent&gt;**](Agent.md) |  | [optional] 
**DisruptedAgents** | **int** | Number of agents in the pool that are in a disrupted state | [optional] 
**Id** | **string** | Agent pool ID | [optional] [readonly] 
**InactiveAgents** | **int** | Number of agents in the pool that are in an inactive state | [optional] 
**Name** | **string** | Agent pool name | [optional] 
**OperationalStatus** | **OperationalStatus** |  | [optional] 
**Type** | **AgentType** |  | [optional] 
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

