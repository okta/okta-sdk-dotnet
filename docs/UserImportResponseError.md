# Okta.Sdk.Model.UserImportResponseError
An object to return an error. Returning an error causes Okta to record a failure event in the Okta System Log.  The string supplied in the `errorSummary` property is recorded in the System Log event.  >**Note:** If a response to an import inline hook request is not received from your external service within three seconds, a timeout occurs. In this scenario, the Okta import process continues and the user is created.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ErrorSummary** | **string** | A human-readable summary of the error | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

