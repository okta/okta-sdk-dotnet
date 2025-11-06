# Okta.Sdk.Model.LogIssuer
Describes the issuer of the authorization server when the authentication is performed through OAuth. This is the location where well-known resources regarding the details of the authorization servers are published.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | Varies depending on the type of authentication. If authentication is SAML 2.0, &#x60;id&#x60; is the issuer in the SAML assertion. For social login, &#x60;id&#x60; is the issuer of the token. | [optional] [readonly] 
**Type** | **string** | Information on the &#x60;issuer&#x60; and source of the SAML assertion or token | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

