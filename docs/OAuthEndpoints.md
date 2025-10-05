# Okta.Sdk.Model.OAuthEndpoints
The `OAUTH2` and `OIDC` protocols support the `authorization` and `token` endpoints. Also, the `OIDC` protocol supports the `userInfo` and `jwks` endpoints.  The IdP Authorization Server (AS) endpoints are currently defined as part of the [IdP provider]((https://developer.okta.com/docs/api/openapi/okta-management/management/tag/IdentityProvider/#tag/IdentityProvider/operation/createIdentityProvider!path=type&t=request)) and are read-only.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Authorization** | [**OAuthAuthorizationEndpoint**](OAuthAuthorizationEndpoint.md) |  | [optional] 
**Jwks** | [**OidcJwksEndpoint**](OidcJwksEndpoint.md) |  | [optional] 
**Slo** | [**OidcSloEndpoint**](OidcSloEndpoint.md) |  | [optional] 
**Token** | [**OAuthTokenEndpoint**](OAuthTokenEndpoint.md) |  | [optional] 
**UserInfo** | [**OidcUserInfoEndpoint**](OidcUserInfoEndpoint.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

