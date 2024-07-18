# Okta.Sdk.Model.LogTargetChangeDetails
Details on the target's changes. Not all event types support the `changeDetails` property, and not all target objects contain the `changeDetails` property.You must include a property within the object. When querying on this property, you can't search on the `to` or `from` objects alone. You must include a property within the object.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**From** | **Dictionary&lt;string, Object&gt;** | The original properties of the target | [optional] 
**To** | **Dictionary&lt;string, Object&gt;** | The updated properties of the target | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

