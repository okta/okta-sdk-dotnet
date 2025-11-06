# Okta.Sdk.Model.RegistrationResponseErrorErrorCausesInner

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ErrorSummary** | **string** | Human-readable summary of the error. | [optional] 
**Reason** | **string** | A brief, enum-like string that indicates the nature of the error. For example, &#x60;UNIQUE_CONSTRAINT&#x60; for a property uniqueness violation. | [optional] 
**LocationType** | **string** | Where in the request the error was found (&#x60;body&#x60;, &#x60;header&#x60;, &#x60;url&#x60;, or &#x60;query&#x60;). | [optional] 
**Location** | **string** | The valid JSON path to the location of the error. For example, if there was an error in the user&#39;s &#x60;login&#x60; field, the &#x60;location&#x60; might be &#x60;data.userProfile.login&#x60;. | [optional] 
**Domain** | **string** | Indicates the source of the error. If the error was in the user&#39;s profile, for example, you might use &#x60;end-user&#x60;. If the error occurred in the external service, you might use &#x60;external-service&#x60;. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

