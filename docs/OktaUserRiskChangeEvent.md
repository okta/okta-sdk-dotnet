# Okta.Sdk.Model.OktaUserRiskChangeEvent
The user risk level changed

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CurrentLevel** | **string** | Current risk level of the user | 
**EventTimestamp** | **long** | The time of the event (UNIX timestamp) | 
**InitiatingEntity** | **string** | The entity that initiated the event | [optional] 
**PreviousLevel** | **string** | Previous risk level of the user | 
**ReasonAdmin** | [**CaepDeviceComplianceChangeEventReasonAdmin**](CaepDeviceComplianceChangeEventReasonAdmin.md) |  | [optional] 
**ReasonUser** | [**CaepDeviceComplianceChangeEventReasonUser**](CaepDeviceComplianceChangeEventReasonUser.md) |  | [optional] 
**Subjects** | [**SecurityEventSubject**](.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

