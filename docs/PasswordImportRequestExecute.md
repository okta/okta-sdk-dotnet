# Okta.Sdk.Model.PasswordImportRequestExecute
Password import inline hook request

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CloudEventVersion** | **string** | The inline hook cloud version | [optional] 
**ContentType** | **string** | The inline hook request header content | [optional] 
**EventId** | **string** | The individual inline hook request ID | [optional] 
**EventTime** | **string** | The time the inline hook request was sent | [optional] 
**EventTypeVersion** | **string** | The inline hook version | [optional] 
**Data** | [**PasswordImportRequestData**](PasswordImportRequestData.md) |  | [optional] 
**EventType** | **string** | The type of inline hook. The password import inline hook type is &#x60;com.okta.user.credential.password.import&#x60;. | [optional] 
**Source** | **string** | The ID and URL of the password import inline hook | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

