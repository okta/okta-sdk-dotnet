# Okta.Sdk.Model.CaepCredentialChangeEvent
The credential was created, changed, revoked or deleted

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ChangeType** | **string** | The type of action done towards the credential | 
**CredentialType** | **string** | The credential type of the changed credential. It will one of the supported enum values or any other credential type supported mutually by the Transmitter and the Receiver. | 
**EventTimestamp** | **long** | The time of the event (UNIX timestamp) | [optional] 
**Fido2Aaguid** | **string** | FIDO2 Authenticator Attestation GUID | [optional] 
**FriendlyName** | **string** | Credential friendly name | [optional] 
**InitiatingEntity** | **string** | The entity that initiated the event | [optional] 
**ReasonAdmin** | [**CaepCredentialChangeEventReasonAdmin**](CaepCredentialChangeEventReasonAdmin.md) |  | [optional] 
**ReasonUser** | [**CaepCredentialChangeEventReasonUser**](CaepCredentialChangeEventReasonUser.md) |  | [optional] 
**Subject** | [**SecurityEventSubject**](SecurityEventSubject.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

