# Okta.Sdk.Model.OpenIdConnectApplicationSettingsRefreshToken
Refresh token configuration for an OAuth 2.0 client  When you create or update an OAuth 2.0 client, you can configure refresh token rotation by setting the `rotation_type` and `leeway` properties. If you don't set these properties when you create an app integration, the default values are used. When you update an app integration, your previously configured values are used. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Leeway** | **int** | The leeway, in seconds, allowed for the OAuth 2.0 client. After the refresh token is rotated, the previous token remains valid for the specified period of time so clients can get the new token.  &gt; **Note:** A leeway of 0 doesn&#39;t necessarily mean that the previous token is immediately invalidated. The previous token is invalidated after the new token is generated and returned in the response.  | [optional] [default to 30]
**RotationType** | **OpenIdConnectRefreshTokenRotationType** |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

