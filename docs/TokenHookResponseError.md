# Okta.Sdk.Model.TokenHookResponseError
When an error object is returned, it causes Okta to return an OAuth 2.0 error to the requester of the token. In the error response, the value of `error` is `server_error`, and the value of `error_description` is the string that you supplied in the `errorSummary` property of the `error` object that you returned.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ErrorSummary** | **string** | Human-readable summary of the error. If the error object doesn&#39;t include the &#x60;errorSummary&#x60; property defined, the following common default message is returned to the end user: &#x60;The callback service returned an error&#x60;. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

