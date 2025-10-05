# Okta.Sdk.Model.CaepDeviceComplianceChangeEvent
The subject's device compliance was revoked

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CurrentStatus** | **string** | Current device compliance status | 
**EventTimestamp** | **long** | The time of the event (UNIX timestamp) | 
**InitiatingEntity** | **string** | The entity that initiated the event | [optional] 
**PreviousStatus** | **string** | Previous device compliance status | 
**ReasonAdmin** | [**CaepDeviceComplianceChangeEventReasonAdmin**](CaepDeviceComplianceChangeEventReasonAdmin.md) |  | [optional] 
**ReasonUser** | [**CaepDeviceComplianceChangeEventReasonUser**](CaepDeviceComplianceChangeEventReasonUser.md) |  | [optional] 
**Subject** | [**SecurityEventSubject**](SecurityEventSubject.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

