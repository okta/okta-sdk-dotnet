# Okta.Sdk.Model.EventHookChannelConfig

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AuthScheme** | [**EventHookChannelConfigAuthScheme**](EventHookChannelConfigAuthScheme.md) |  | [optional] 
**Headers** | [**List&lt;EventHookChannelConfigHeader&gt;**](EventHookChannelConfigHeader.md) | Optional list of key/value pairs for headers that can be sent with the request to the external service. For example, &#x60;X-Other-Header&#x60; is an example of an optional header, with a value of &#x60;my-header-value&#x60;, that you want Okta to pass to your external service. | [optional] 
**Method** | **string** | The method of the Okta event hook request | [optional] [readonly] 
**Uri** | **string** | The external service endpoint called to execute the event hook handler | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

