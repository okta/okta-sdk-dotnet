# Okta.Sdk.Model.SAMLPayLoadDataAssertion
Details of the SAML assertion that was generated

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Subject** | [**SAMLPayLoadDataAssertionSubject**](SAMLPayLoadDataAssertionSubject.md) |  | [optional] 
**Authentication** | [**SAMLPayLoadDataAssertionAuthentication**](SAMLPayLoadDataAssertionAuthentication.md) |  | [optional] 
**Conditions** | [**SAMLPayLoadDataAssertionConditions**](SAMLPayLoadDataAssertionConditions.md) |  | [optional] 
**Claims** | [**Dictionary&lt;string, SAMLPayLoadDataAssertionClaimsValue&gt;**](SAMLPayLoadDataAssertionClaimsValue.md) | Provides a JSON representation of the &#x60;&lt;saml:AttributeStatement&gt;&#x60; element contained in the generated SAML assertion. Contains any optional SAML attribute statements that you have defined for the app using the Admin Console&#39;s **SAML Settings**. | [optional] 
**Lifetime** | [**SAMLPayLoadDataAssertionLifetime**](SAMLPayLoadDataAssertionLifetime.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

