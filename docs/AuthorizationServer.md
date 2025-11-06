# Okta.Sdk.Model.AuthorizationServer

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccessTokenEncryptedResponseAlgorithm** | **KeyEncryptionAlgorithm** |  | [optional] 
**Audiences** | **List&lt;string&gt;** | The recipients that the tokens are intended for. This becomes the &#x60;aud&#x60; claim in an access token. Okta currently supports only one audience. | [optional] 
**Created** | **DateTimeOffset** |  | [optional] [readonly] 
**Credentials** | [**AuthorizationServerCredentials**](AuthorizationServerCredentials.md) |  | [optional] 
**Description** | **string** | The description of the custom authorization server | [optional] 
**Id** | **string** | The ID of the custom authorization server | [optional] [readonly] 
**Issuer** | **string** | The complete URL for the custom authorization server. This becomes the &#x60;iss&#x60; claim in an access token. | [optional] 
**IssuerMode** | **string** | Indicates which value is specified in the issuer of the tokens that a custom authorization server returns: the Okta org domain URL or a custom domain URL.  &#x60;issuerMode&#x60; is visible if you have a custom URL domain configured or the Dynamic Issuer Mode feature enabled. If you have a custom URL domain configured, you can set a custom domain URL in a custom authorization server, and this property is returned in the appropriate responses.  When set to &#x60;ORG_URL&#x60;, then in responses, &#x60;issuer&#x60; is the Okta org domain URL: &#x60;https://${yourOktaDomain}&#x60;.  When set to &#x60;CUSTOM_URL&#x60;, then in responses, &#x60;issuer&#x60; is the custom domain URL configured in the administration user interface.  When set to &#x60;DYNAMIC&#x60;, then in responses, &#x60;issuer&#x60; is the custom domain URL if the OAuth 2.0 request was sent to the custom domain, or is the Okta org&#39;s domain URL if the OAuth 2.0 request was sent to the original Okta org domain.  After you configure a custom URL domain, all new custom authorization servers use &#x60;CUSTOM_URL&#x60; by default. If the Dynamic Issuer Mode feature is enabled, then all new custom authorization servers use &#x60;DYNAMIC&#x60; by default. All existing custom authorization servers continue to use the original value until they&#39;re changed using the Admin Console or the API. This way, existing integrations with the client and resource server continue to work after the feature is enabled. | [optional] 
**Jwks** | [**ResourceServerJsonWebKeys**](ResourceServerJsonWebKeys.md) |  | [optional] 
**JwksUri** | **string** | &lt;x-lifecycle-container&gt;&lt;x-lifecycle class&#x3D;\&quot;ea\&quot;&gt;&lt;/x-lifecycle&gt;&lt;/x-lifecycle-container&gt;URL string that references a JSON Web Key Set for encrypting JWTs minted by the custom authorization server | [optional] 
**LastUpdated** | **DateTimeOffset** |  | [optional] [readonly] 
**Name** | **string** | The name of the custom authorization server | [optional] 
**Status** | **LifecycleStatus** |  | [optional] 
**Links** | [**AuthServerLinks**](AuthServerLinks.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

