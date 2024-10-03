# Okta.Sdk.Model.OAuthMetadata

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AuthorizationEndpoint** | **string** | URL of the authorization server&#39;s authorization endpoint. | [optional] 
**BackchannelAuthenticationRequestSigningAlgValuesSupported** | [**List&lt;SigningAlgorithm&gt;**](SigningAlgorithm.md) | &lt;div class&#x3D;\&quot;x-lifecycle-container\&quot;&gt;&lt;x-lifecycle class&#x3D;\&quot;lea\&quot;&gt;&lt;/x-lifecycle&gt; &lt;x-lifecycle class&#x3D;\&quot;oie\&quot;&gt;&lt;/x-lifecycle&gt;&lt;/div&gt;A list of signing algorithms that this authorization server supports for signed requests. | [optional] 
**BackchannelTokenDeliveryModesSupported** | [**List&lt;TokenDeliveryMode&gt;**](TokenDeliveryMode.md) | &lt;div class&#x3D;\&quot;x-lifecycle-container\&quot;&gt;&lt;x-lifecycle class&#x3D;\&quot;lea\&quot;&gt;&lt;/x-lifecycle&gt; &lt;x-lifecycle class&#x3D;\&quot;oie\&quot;&gt;&lt;/x-lifecycle&gt;&lt;/div&gt;The delivery modes that this authorization server supports for Client-Initiated Backchannel Authentication. | [optional] 
**ClaimsSupported** | **List&lt;string&gt;** | A list of the claims supported by this authorization server. | [optional] 
**CodeChallengeMethodsSupported** | [**List&lt;CodeChallengeMethod&gt;**](CodeChallengeMethod.md) | A list of PKCE code challenge methods supported by this authorization server. | [optional] 
**DeviceAuthorizationEndpoint** | **string** |  | [optional] 
**DpopSigningAlgValuesSupported** | **List&lt;string&gt;** | A list of signing algorithms supported by this authorization server for Demonstrating Proof-of-Possession (DPoP) JWTs. | [optional] 
**EndSessionEndpoint** | **string** | URL of the authorization server&#39;s logout endpoint. | [optional] 
**GrantTypesSupported** | [**List&lt;GrantType&gt;**](GrantType.md) | A list of the grant type values that this authorization server supports. | [optional] 
**IntrospectionEndpoint** | **string** | URL of the authorization server&#39;s introspection endpoint. | [optional] 
**IntrospectionEndpointAuthMethodsSupported** | [**List&lt;EndpointAuthMethod&gt;**](EndpointAuthMethod.md) | A list of client authentication methods supported by this introspection endpoint. | [optional] 
**Issuer** | **string** | The authorization server&#39;s issuer identifier. In the context of this document, this is your authorization server&#39;s base URL. This becomes the &#x60;iss&#x60; claim in an access token. | [optional] 
**JwksUri** | **string** | URL of the authorization server&#39;s JSON Web Key Set document. | [optional] 
**PushedAuthorizationRequestEndpoint** | **string** |  | [optional] 
**RegistrationEndpoint** | **string** | URL of the authorization server&#39;s JSON Web Key Set document. | [optional] 
**RequestObjectSigningAlgValuesSupported** | [**List&lt;SigningAlgorithm&gt;**](SigningAlgorithm.md) | A list of signing algorithms that this authorization server supports for signed requests. | [optional] 
**RequestParameterSupported** | **bool** | Indicates if Request Parameters are supported by this authorization server. | [optional] 
**ResponseModesSupported** | [**List&lt;ResponseMode&gt;**](ResponseMode.md) | A list of the &#x60;response_mode&#x60; values that this authorization server supports. More information here. | [optional] 
**ResponseTypesSupported** | [**List&lt;ResponseTypesSupported&gt;**](ResponseTypesSupported.md) | A list of the &#x60;response_type&#x60; values that this authorization server supports. Can be a combination of &#x60;code&#x60;, &#x60;token&#x60;, and &#x60;id_token&#x60;. | [optional] 
**RevocationEndpoint** | **string** | URL of the authorization server&#39;s revocation endpoint. | [optional] 
**RevocationEndpointAuthMethodsSupported** | [**List&lt;EndpointAuthMethod&gt;**](EndpointAuthMethod.md) | A list of client authentication methods supported by this revocation endpoint. | [optional] 
**ScopesSupported** | **List&lt;string&gt;** | A list of the scope values that this authorization server supports. | [optional] 
**SubjectTypesSupported** | [**List&lt;SubjectType&gt;**](SubjectType.md) | A list of the Subject Identifier types that this authorization server supports. Valid types include &#x60;pairwise&#x60; and &#x60;public&#x60;, but only &#x60;public&#x60; is currently supported. See the [Subject Identifier Types](https://openid.net/specs/openid-connect-core-1_0.html#SubjectIDTypes) section in the OpenID Connect specification. | [optional] 
**TokenEndpoint** | **string** | URL of the authorization server&#39;s token endpoint. | [optional] 
**TokenEndpointAuthMethodsSupported** | [**List&lt;EndpointAuthMethod&gt;**](EndpointAuthMethod.md) | A list of client authentication methods supported by this token endpoint. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

