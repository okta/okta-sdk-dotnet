# Okta.Sdk.Model.OpenIdConnectApplicationSettingsClient

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ApplicationType** | **OpenIdConnectApplicationType** |  | [optional] 
**ClientUri** | **string** |  | [optional] 
**ConsentMethod** | **OpenIdConnectApplicationConsentMethod** |  | [optional] 
**DpopBoundAccessTokens** | **bool** | Indicates that the client application uses Demonstrating Proof-of-Possession (DPoP) for token requests. If &#x60;true&#x60;, the authorization server rejects token requests from this client that don&#39;t contain the DPoP header. | [optional] [default to false]
**FrontchannelLogoutSessionRequired** | **bool** | Include user session details. | [optional] 
**FrontchannelLogoutUri** | **string** | URL where Okta sends the logout request. | [optional] 
**GrantTypes** | [**List&lt;OAuthGrantType&gt;**](OAuthGrantType.md) |  | [optional] 
**IdpInitiatedLogin** | [**OpenIdConnectApplicationIdpInitiatedLogin**](OpenIdConnectApplicationIdpInitiatedLogin.md) |  | [optional] 
**InitiateLoginUri** | **string** |  | [optional] 
**IssuerMode** | **OpenIdConnectApplicationIssuerMode** |  | [optional] 
**Jwks** | [**OpenIdConnectApplicationSettingsClientKeys**](OpenIdConnectApplicationSettingsClientKeys.md) |  | [optional] 
**JwksUri** | **string** | URL string that references a JSON Web Key Set for validating JWTs presented to Okta. | [optional] 
**LogoUri** | **string** |  | [optional] 
**ParticipateSlo** | **bool** | Allows the app to participate in front-channel single logout. | [optional] 
**PolicyUri** | **string** |  | [optional] 
**PostLogoutRedirectUris** | **List&lt;string&gt;** |  | [optional] 
**RedirectUris** | **List&lt;string&gt;** |  | [optional] 
**RefreshToken** | [**OpenIdConnectApplicationSettingsRefreshToken**](OpenIdConnectApplicationSettingsRefreshToken.md) |  | [optional] 
**ResponseTypes** | [**List&lt;OAuthResponseType&gt;**](OAuthResponseType.md) |  | [optional] 
**TosUri** | **string** |  | [optional] 
**WildcardRedirect** | **string** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

