# Okta.Sdk.Model.ModelClient

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ApplicationType** | **ApplicationType** |  | [optional] 
**ClientId** | **string** | Unique key for the client application. The &#x60;client_id&#x60; is immutable. When you create a client Application, you can&#39;t specify the &#x60;client_id&#x60; because Okta uses the application ID for the &#x60;client_id&#x60;. | [optional] [readonly] 
**ClientIdIssuedAt** | **int** | Time at which the &#x60;client_id&#x60; was issued (measured in unix seconds) | [optional] [readonly] 
**ClientName** | **string** | Human-readable string name of the client application | [optional] 
**ClientSecret** | **string** | OAuth 2.0 client secret string (used for confidential clients). The &#x60;client_secret&#x60; is shown only on the response of the creation or update of a client Application (and only if the &#x60;token_endpoint_auth_method&#x60; is one that requires a client secret). You can&#39;t specify the &#x60;client_secret&#x60;. If the &#x60;token_endpoint_auth_method&#x60; requires one, Okta generates a random &#x60;client_secret&#x60; for the client Application. | [optional] [readonly] 
**ClientSecretExpiresAt** | **int?** | Time at which the &#x60;client_secret&#x60; expires or 0 if it doesn&#39;t expire (measured in unix seconds) | [optional] [readonly] 
**FrontchannelLogoutSessionRequired** | **bool** | Include user session details | [optional] 
**FrontchannelLogoutUri** | **string** | URL where Okta sends the logout request | [optional] 
**GrantTypes** | [**List&lt;GrantType&gt;**](GrantType.md) | Array of OAuth 2.0 grant type strings. Default value: &#x60;[authorization_code]&#x60; | [optional] 
**InitiateLoginUri** | **string** | URL that a third party can use to initiate a login by the client | [optional] 
**JwksUri** | **string** | URL string that references a [JSON Web Key Set](https://tools.ietf.org/html/rfc7517#section-5) for validating JWTs presented to Okta | [optional] 
**LogoUri** | **string** | URL string that references a logo for the client consent dialog (not the sign-in dialog) | [optional] 
**PolicyUri** | **string** | URL string of a web page providing the client&#39;s policy document | [optional] 
**PostLogoutRedirectUris** | **List&lt;string&gt;** | Array of redirection URI strings for use for relying party initiated logouts | [optional] 
**RedirectUris** | **List&lt;string&gt;** | Array of redirection URI strings for use in redirect-based flows. All redirect URIs must be absolute URIs and must not include a fragment component. At least one redirect URI and response type is required for all client types, with the following exceptions: If the client uses the Resource Owner Password flow (if &#x60;grant_type&#x60; contains the value password) or the Client Credentials flow (if &#x60;grant_type&#x60; contains the value &#x60;client_credentials&#x60;), then no redirect URI or response type is necessary. In these cases, you can pass either null or an empty array for these attributes. | [optional] 
**RequestObjectSigningAlg** | [**List&lt;SigningAlgorithm&gt;**](SigningAlgorithm.md) | The type of [JSON Web Key Set](https://tools.ietf.org/html/rfc7517#section-5) algorithm that must be used for signing request objects | [optional] 
**ResponseTypes** | [**List&lt;ResponseType&gt;**](ResponseType.md) | Array of OAuth 2.0 response type strings. Default value: &#x60;[code]&#x60; | [optional] 
**TokenEndpointAuthMethod** | **EndpointAuthMethod** |  | [optional] 
**TosUri** | **string** | URL string of a web page providing the client&#39;s terms of service document | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

