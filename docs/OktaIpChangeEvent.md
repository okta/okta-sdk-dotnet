# Okta.Sdk.Model.OktaIpChangeEvent
IP changed for the subject's session

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CurrentIpAddress** | **string** | Current IP address of the subject | 
**EventTimestamp** | **long** | The time of the event (UNIX timestamp) | 
**InitiatingEntity** | **string** | The entity that initiated the event | [optional] 
**PreviousIpAddress** | **string** | Previous IP address of the subject | 
**ReasonAdmin** | [**CaepDeviceComplianceChangeEventReasonAdmin**](CaepDeviceComplianceChangeEventReasonAdmin.md) |  | [optional] 
**ReasonUser** | [**CaepDeviceComplianceChangeEventReasonUser**](CaepDeviceComplianceChangeEventReasonUser.md) |  | [optional] 
**Subjects** | [**SecurityEventSubject**](.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

