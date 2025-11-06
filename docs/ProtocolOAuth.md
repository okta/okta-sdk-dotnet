# Okta.Sdk.Model.ProtocolOAuth
Protocol settings for authentication using the [OAuth 2.0 Authorization Code flow](https://tools.ietf.org/html/rfc6749#section-4.1)

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Credentials** | [**OAuthCredentials**](OAuthCredentials.md) |  | [optional] 
**Endpoints** | [**OAuthEndpoints**](OAuthEndpoints.md) |  | [optional] 
**Scopes** | **List&lt;string&gt;** | IdP-defined permission bundles to request delegated access from the user. &gt; **Note:** The [identity provider type](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/IdentityProvider/#tag/IdentityProvider/operation/createIdentityProvider!path&#x3D;type&amp;t&#x3D;request) table lists the scopes that are supported for each IdP. | [optional] 
**Type** | **string** | OAuth 2.0 Authorization Code flow | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

