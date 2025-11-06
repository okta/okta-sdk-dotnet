# Okta.Sdk.Model.Saml
SAML configuration details

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Acs** | [**List&lt;SamlAcsInner&gt;**](SamlAcsInner.md) | List of Assertion Consumer Service (ACS) URLs. The default ACS URL is required and is indicated by a null &#x60;index&#x60; value. You can use the org-level variables you defined in the &#x60;config&#x60; array in the URL. For example: &#x60;https://${org.subdomain}.example.com/saml/login&#x60; | 
**Claims** | [**List&lt;SamlClaimsInner&gt;**](SamlClaimsInner.md) | Attribute statements to appear in the Okta SAML assertion | [optional] 
**Doc** | **string** | The URL to your customer-facing instructions for configuring your SAML integration. See [Customer configuration document guidelines](https://developer.okta.com/docs/guides/submit-app-prereq/main/#customer-configuration-document-guidelines). | 
**EntityId** | **string** | Globally unique name for your SAML entity. For instance, your Identity Provider (IdP) or Service Provider (SP) URL. | 
**Groups** | **List&lt;string&gt;** | Defines the group attribute names for the SAML assertion statement. Okta inserts the list of Okta user groups into the attribute names in the statement. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

