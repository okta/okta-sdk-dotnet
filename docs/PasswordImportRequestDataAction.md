# Okta.Sdk.Model.PasswordImportRequestDataAction
This object specifies the default action Okta is set to take. Okta takes this action if your external service sends an empty HTTP 204 response. You can override the default action by returning a commands object in your response specifying the action to take.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Credential** | **string** | The status of the user credential, either &#x60;UNVERIFIED&#x60; or &#x60;VERIFIED&#x60; | [optional] [default to "UNVERIFIED"]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

