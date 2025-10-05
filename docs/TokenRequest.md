# Okta.Sdk.Model.TokenRequest
Token inline hook request

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CloudEventVersion** | **string** | The inline hook cloud version | [optional] 
**ContentType** | **string** | The inline hook request header content | [optional] 
**EventId** | **string** | The individual inline hook request ID | [optional] 
**EventTime** | **string** | The time the inline hook request was sent | [optional] 
**EventTypeVersion** | **string** | The inline hook version | [optional] 
**Data** | [**TokenPayLoadData**](TokenPayLoadData.md) |  | [optional] 
**EventType** | **string** | The type of inline hook. The token inline hook type is &#x60;com.okta.oauth2.tokens.transform&#x60;. | [optional] 
**Source** | **string** | The URL of the token inline hook | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

