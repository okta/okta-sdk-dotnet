# Okta.Sdk.Model.IdentityProviderProtocol
IdP-specific protocol settings for endpoints, bindings, and algorithms used to connect with the IdP and validate messages

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Algorithms** | [**OidcAlgorithms**](OidcAlgorithms.md) |  | [optional] 
**Credentials** | [**IDVCredentials**](IDVCredentials.md) |  | [optional] 
**Endpoints** | [**IDVEndpoints**](IDVEndpoints.md) |  | [optional] 
**OktaIdpOrgUrl** | **string** | URL of the IdP org | [optional] 
**RelayState** | [**SamlRelayState**](SamlRelayState.md) |  | [optional] 
**Settings** | [**OidcSettings**](OidcSettings.md) |  | [optional] 
**Type** | **string** | ID verification protocol | [optional] 
**Scopes** | **List&lt;string&gt;** | IdP-defined permission bundles to request delegated access from the user. &gt; **Note:** The [identity provider type](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/IdentityProvider/#tag/IdentityProvider/operation/createIdentityProvider!path&#x3D;type&amp;t&#x3D;request) table lists the scopes that are supported for each IdP. | [optional] 
**Issuer** | [**ProtocolEndpointOidcIssuer**](ProtocolEndpointOidcIssuer.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

