# Okta.Sdk.Model.AuthenticatorProfileTacResponsePost
Defines the authenticator specific parameters

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ExpiresAt** | **DateTimeOffset** | The time when the TAC enrollment expires in the UTC timezone | [optional] 
**MultiUse** | **bool** | Determines whether an enrollment can be used more than once | [optional] 
**Tac** | **string** | A temporary access code used for authentication. It can be used one or more times and is valid for a defined period specified by the &#x60;ttl&#x60; property. The &#x60;tac&#x60; is returned in the response when the enrollment is created. It is not returned when the enrollment is retrieved. Issuing a new TAC invalidates any existing TAC for this user. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

