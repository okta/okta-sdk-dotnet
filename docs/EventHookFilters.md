# Okta.Sdk.Model.EventHookFilters
The optional filter defined on a specific event type  > **Note:** Event hook filters is a [self-service Early Access (EA)](/docs/concepts/feature-lifecycle-management/#self-service-features) feature. See [Manage Early Access and Beta features](https://help.okta.com/okta_help.htm?id=ext_secur_manage_ea_bata) to enable. If you want to disable this feature, it's recommended to first remove all event filters.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**EventFilterMap** | [**List&lt;EventHookFilterMapObject&gt;**](EventHookFilterMapObject.md) | The object that maps the filter to the event type | [optional] 
**Type** | **string** | The type of filter. Currently only supports &#x60;EXPRESSION_LANGUAGE&#x60; | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

