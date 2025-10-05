# Okta.Sdk.Model.LogTargetChangeDetails
Details on the target's changes. Not all event types support the `changeDetails` property, and not all `target` objects contain the `changeDetails` property.  > **Note:** You can't run queries on `changeDetails` or the object's `to` or `from` properties.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**From** | **Dictionary&lt;string, Object&gt;** | The original properties of the target | [optional] 
**To** | **Dictionary&lt;string, Object&gt;** | The updated properties of the target | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

