# Okta.Sdk.Model.CaepSessionRevokedEvent
The session of the subject was revoked

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CurrentIp** | **string** | Current IP of the session | [optional] 
**CurrentUserAgent** | **string** | Current User Agent of the session | [optional] 
**EventTimestamp** | **long** | The time of the event (UNIX timestamp) | 
**InitiatingEntity** | **string** | The entity that initiated the event | [optional] 
**LastKnownIp** | **string** | Last known IP of the session | [optional] 
**LastKnownUserAgent** | **string** | Last known User Agent of the session | [optional] 
**ReasonAdmin** | [**CaepDeviceComplianceChangeEventReasonAdmin**](CaepDeviceComplianceChangeEventReasonAdmin.md) |  | [optional] 
**ReasonUser** | [**CaepDeviceComplianceChangeEventReasonUser**](CaepDeviceComplianceChangeEventReasonUser.md) |  | [optional] 
**Subjects** | [**SecurityEventSubject**](.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

