# Okta.Sdk.Model.OAuthCredentialsClient
OAuth 2.0 and OpenID Connect Client object > **Note:** You must complete client registration with the IdP Authorization Server for your Okta IdP instance to obtain client credentials.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ClientId** | **string** | The [Unique identifier](https://tools.ietf.org/html/rfc6749#section-2.2) issued by the AS for the Okta IdP instance | [optional] 
**ClientSecret** | **string** | The [Client secret](https://tools.ietf.org/html/rfc6749#section-2.3.1) issued by the AS for the Okta IdP instance | [optional] 
**PkceRequired** | **bool** | Require Proof Key for Code Exchange (PKCE) for additional verification | [optional] 
**TokenEndpointAuthMethod** | **string** | Client authentication methods supported by the token endpoint | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

