# Okta.Sdk.Model.TelephonyRequestExecute
Telephony inline hook request body

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CloudEventVersion** | **string** | The inline hook cloud version | [optional] 
**ContentType** | **string** | The inline hook request header content | [optional] 
**EventId** | **string** | The individual inline hook request ID | [optional] 
**EventTime** | **string** | The time the inline hook request was sent | [optional] 
**EventTypeVersion** | **string** | The inline hook version | [optional] 
**Data** | [**TelephonyRequestData**](TelephonyRequestData.md) |  | [optional] 
**EventType** | **string** | The type of inline hook. The telephony inline hook type is &#x60;com.okta.telephony.provider&#x60;. | [optional] 
**RequestType** | **string** | The type of inline hook request. For example, &#x60;com.okta.user.telephony.pre-enrollment&#x60;. | [optional] 
**Source** | **string** | The ID and URL of the telephony inline hook | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

