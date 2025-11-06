# Okta.Sdk.Model.AppUserCredentials
Specifies a user's credentials for the app. This parameter can be omitted for apps with [sign-on mode](/openapi/okta-management/management/tag/Application/#tag/Application/operation/getApplication!c=200&path=0/signOnMode&t=response) (`signOnMode`) or [authentication schemes](/openapi/okta-management/management/tag/Application/#tag/Application/operation/getApplication!c=200&path=0/credentials/scheme&t=response) (`credentials.scheme`) that don't require credentials. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Password** | [**AppUserPasswordCredential**](AppUserPasswordCredential.md) |  | [optional] 
**UserName** | **string** | The user&#39;s username in the app  &gt; **Note:** The [userNameTemplate](/openapi/okta-management/management/tag/Application/#tag/Application/operation/createApplication!path&#x3D;0/credentials/userNameTemplate&amp;t&#x3D;request) in the application object defines the default username generated when a user is assigned to that app. &gt; If you attempt to assign a username or password to an app with an incompatible [authentication scheme](/openapi/okta-management/management/tag/Application/#tag/Application/operation/createApplication!path&#x3D;0/credentials/scheme&amp;t&#x3D;request), the following error is returned: &gt; \&quot;Credentials should not be set on this resource based on the scheme.\&quot; | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

