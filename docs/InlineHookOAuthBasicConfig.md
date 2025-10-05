# Okta.Sdk.Model.InlineHookOAuthBasicConfig

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AuthType** | **string** |  | [optional] 
**ClientId** | **string** | A publicly exposed string provided by the service that&#39;s used to identify the OAuth app and build authorization URLs | [optional] 
**Scope** | **string** | Include the scopes that allow you to perform the actions on the hook endpoint that you want to access | [optional] 
**TokenUrl** | **string** | The URI where inline hooks can exchange an authorization code for access and refresh tokens | [optional] 
**Headers** | [**List&lt;InlineHookChannelConfigHeaders&gt;**](InlineHookChannelConfigHeaders.md) | An optional list of key/value pairs for headers that you can send with the request to the external service | [optional] 
**Method** | **string** | The method of the Okta inline hook request | [optional] 
**Uri** | **string** | The external service endpoint that executes the inline hook handler. It must begin with &#x60;https://&#x60; and be reachable by Okta. No white space is allowed in the URI. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

