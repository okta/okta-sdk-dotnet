# Okta.Sdk.Model.SamlTrustCredentials
Federation Trust Credentials for verifying assertions from the IdP

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AdditionalKids** | **List&lt;string&gt;** | Additional IdP key credential reference to the Okta X.509 signature certificate | [optional] 
**Audience** | **string** | URI that identifies the target Okta IdP instance (SP) for an &#x60;&lt;Assertion&gt;&#x60; | [optional] 
**Issuer** | **string** | URI that identifies the issuer (IdP) of a &#x60;&lt;SAMLResponse&gt;&#x60; message &#x60;&lt;Assertion&gt;&#x60; element | [optional] 
**Kid** | **string** | IdP key credential reference to the Okta X.509 signature certificate | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

