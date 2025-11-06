# Okta.Sdk.Model.PolicyNetworkCondition
Specifies a network selection mode and a set of network zones to be included or excluded. If the connection parameter's data type is `ZONE`, one of the `include` or `exclude` arrays is required. Specific zone IDs to include or exclude are enumerated in the respective arrays.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Connection** | **PolicyNetworkConnection** |  | [optional] 
**Exclude** | **List&lt;string&gt;** | The zones to exclude. Required only if connection data type is &#x60;ZONE&#x60; | [optional] 
**Include** | **List&lt;string&gt;** | The zones to include. Required only if connection data type is &#x60;ZONE&#x60; | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

