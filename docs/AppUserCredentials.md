# Okta.Sdk.Model.AppUserCredentials
Specifies a user's credentials for the app. This parameter can be omitted for apps with [sign-on mode](/openapi/okta-management/management/tag/Application/#tag/Application/operation/getApplication!c=200&path=0/signOnMode&t=response) (`signOnMode`) or [authentication schemes](/openapi/okta-management/management/tag/Application/#tag/Application/operation/getApplication!c=200&path=0/credentials/scheme&t=response) (`credentials.scheme`) that don't require credentials. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Password** | [**AppUserPasswordCredential**](AppUserPasswordCredential.md) |  | [optional] 
**UserName** | **string** | The user&#39;s username in the app | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

