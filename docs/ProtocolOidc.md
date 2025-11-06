# Okta.Sdk.Model.ProtocolOidc
Protocol settings for authentication using the [OpenID Connect Protocol](http://openid.net/specs/openid-connect-core-1_0.html#CodeFlowAuth)

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Algorithms** | [**OidcAlgorithms**](OidcAlgorithms.md) |  | [optional] 
**Credentials** | [**OAuthCredentials**](OAuthCredentials.md) |  | [optional] 
**Endpoints** | [**OAuthEndpoints**](OAuthEndpoints.md) |  | [optional] 
**OktaIdpOrgUrl** | **string** | URL of the IdP org | [optional] 
**Scopes** | **List&lt;string&gt;** | OpenID Connect and IdP-defined permission bundles to request delegated access from the user &gt; **Note:** The [IdP type](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/IdentityProvider/#tag/IdentityProvider/operation/createIdentityProvider!path&#x3D;type&amp;t&#x3D;request) table lists the scopes that are supported for each IdP. | [optional] 
**Settings** | [**OidcSettings**](OidcSettings.md) |  | [optional] 
**Type** | **string** | OpenID Connect Authorization Code flow | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

