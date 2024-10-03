# Okta.Sdk.Model.StreamConfiguration

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Aud** | [**StreamConfigurationAud**](StreamConfigurationAud.md) |  | [optional] 
**Delivery** | [**StreamConfigurationDelivery**](.md) |  | 
**EventsDelivered** | **List&lt;string&gt;** | The events (mapped by the array of event type URIs) that the transmitter actually delivers to the SSF Stream.  A read-only parameter that is set by the transmitter. If this parameter is included in the request, the value must match the expected value from the transmitter. | [optional] 
**EventsRequested** | **List&lt;string&gt;** | The events (mapped by the array of event type URIs) that the receiver wants to receive | 
**EventsSupported** | **List&lt;string&gt;** | An array of event type URIs that the transmitter supports.  A read-only parameter that is set by the transmitter. If this parameter is included in the request, the value must match the expected value from the transmitter. | [optional] 
**Format** | **string** | The Subject Identifier format expected for any SET transmitted. | [optional] 
**Iss** | **string** | The issuer used in Security Event Tokens (SETs). This value is set as &#x60;iss&#x60; in the claim.  A read-only parameter that is set by the transmitter. If this parameter is included in the request, the value must match the expected value from the transmitter. | [optional] 
**MinVerificationInterval** | **int?** | The minimum amount of time, in seconds, between two verification requests.  A read-only parameter that is set by the transmitter. If this parameter is included in the request, the value must match the expected value from the transmitter. | [optional] 
**StreamId** | **string** | The ID of the SSF Stream configuration | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

