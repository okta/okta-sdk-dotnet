# Okta.Sdk.Model.EventHookFilters
The optional filter defined on a specific event type  > **Note:** Event hook filters is a [self-service Early Access (EA)](/openapi/okta-management/guides/release-lifecycle/#early-access-ea) to enable. If you want to disable this feature, it's recommended to first remove all event filters.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**EventFilterMap** | [**List&lt;EventHookFilterMapObject&gt;**](EventHookFilterMapObject.md) | The object that maps the filter to the event type | [optional] 
**Type** | **string** | The type of filter. Currently only supports &#x60;EXPRESSION_LANGUAGE&#x60; | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

