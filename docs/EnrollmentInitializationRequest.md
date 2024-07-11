# Okta.Sdk.Model.EnrollmentInitializationRequest
Enrollment Initialization Request

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**EnrollmentRpIds** | **List&lt;string&gt;** | List of Relying Party hostnames to register on the YubiKey. | [optional] 
**FulfillmentProvider** | **string** | Name of the fulfillment provider for the WebAuthn Preregistration Factor | [optional] 
**UserId** | **string** | ID of an existing Okta user | [optional] 
**YubicoTransportKeyJWK** | [**ECKeyJWK**](ECKeyJWK.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

