# Okta.Sdk.Model.SamlSettings
Advanced settings for the SAML 2.0 protocol

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**HonorPersistentNameId** | **bool** | Determines if the IdP should persist account linking when the incoming assertion NameID format is &#x60;urn:oasis:names:tc:SAML:2.0:nameid-format:persistent&#x60; | [optional] [default to true]
**NameFormat** | **SamlNameIdFormat** |  | [optional] 
**ParticipateSlo** | **bool** | Set to &#x60;true&#x60; to have Okta send a logout request to the upstream IdP when a user signs out of Okta or a downstream app. | [optional] 
**SendApplicationContext** | **bool** | Determines if the IdP should send the application context as &#x60;&lt;OktaAppInstanceId&gt;&#x60; and &#x60;&lt;OktaAppName&gt;&#x60; in the &#x60;&lt;saml2p:Extensions&gt;&#x60; element of the &#x60;&lt;AuthnRequest&gt;&#x60; message | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

