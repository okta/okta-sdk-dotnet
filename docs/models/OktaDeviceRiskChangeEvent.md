# Okta.Sdk.Model.OktaDeviceRiskChangeEvent
The device risk level changed

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CurrentLevel** | **string** | Current risk level of the device | 
**EventTimestamp** | **long** | The time of the event (UNIX timestamp) | 
**PreviousLevel** | **string** | Previous risk level of the device | 
**Subject** | [**SecurityEventSubject**](SecurityEventSubject.md) |  | 
**InitiatingEntity** | **string** | The entity that initiated the event | [optional] 
**ReasonAdmin** | [**CaepDeviceComplianceChangeEventReasonAdmin**](CaepDeviceComplianceChangeEventReasonAdmin.md) |  | [optional] 
**ReasonUser** | [**CaepDeviceComplianceChangeEventReasonUser**](CaepDeviceComplianceChangeEventReasonUser.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

