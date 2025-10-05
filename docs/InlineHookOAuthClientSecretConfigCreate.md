# Okta.Sdk.Model.InlineHookOAuthClientSecretConfigCreate

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ClientSecret** | **string** | A private value provided by the service used to authenticate the identity of the app to the service | [optional] 
**Method** | **string** | The method of the Okta inline hook request. Only accepts &#x60;POST&#x60;. | [optional] 
**Headers** | [**List&lt;InlineHookChannelConfigHeaders&gt;**](InlineHookChannelConfigHeaders.md) | An optional list of key/value pairs for headers that you can send with the request to the external service | [optional] 
**Uri** | **string** | The external service endpoint that executes the inline hook handler. It must begin with &#x60;https://&#x60; and be reachable by Okta. No white space is allowed in the URI. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

