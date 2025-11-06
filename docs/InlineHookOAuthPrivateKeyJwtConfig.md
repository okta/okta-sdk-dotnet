# Okta.Sdk.Model.InlineHookOAuthPrivateKeyJwtConfig

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AuthScheme** | **string** | Not applicable. Must be &#x60;null&#x60;. | [optional] 
**HookKeyId** | **string** | An ID value of the hook key pair generated from the [Hook Keys API](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/HookKey/#tag/HookKey) | [optional] 
**Method** | **string** | The method of the Okta inline hook request. Only accepts &#x60;POST&#x60;. | [optional] 
**Headers** | [**List&lt;InlineHookChannelConfigHeaders&gt;**](InlineHookChannelConfigHeaders.md) | An optional list of key/value pairs for headers that you can send with the request to the external service | [optional] 
**Uri** | **string** | The external service endpoint that executes the inline hook handler. It must begin with &#x60;https://&#x60; and be reachable by Okta. No white space is allowed in the URI. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

