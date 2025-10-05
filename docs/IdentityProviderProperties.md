# Okta.Sdk.Model.IdentityProviderProperties
The properties in the IdP `properties` object vary depending on the IdP type

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AalValue** | **string** | The [authentication assurance level](https://developers.login.gov/oidc/#aal-values) (AAL) value for the Login.gov IdP.  See [Add a Login.gov IdP](https://developer.okta.com/docs/guides/add-logingov-idp/). Applies to &#x60;LOGINGOV&#x60; and &#x60;LOGINGOV_SANDBOX&#x60; IdP types. | [optional] 
**AdditionalAmr** | **List&lt;string&gt;** | The additional Assurance Methods References (AMR) values for Smart Card IdPs. Applies to &#x60;X509&#x60; IdP type. | [optional] 
**IalValue** | **string** | The [type of identity verification](https://developers.login.gov/oidc/#ial-values) (IAL) value for the Login.gov IdP.  See [Add a Login.gov IdP](https://developer.okta.com/docs/guides/add-logingov-idp/). Applies to &#x60;LOGINGOV&#x60; and &#x60;LOGINGOV_SANDBOX&#x60; IdP types. | [optional] 
**InquiryTemplateId** | **string** | The ID of the inquiry template from your Persona dashboard. The inquiry template always starts with &#x60;itmpl&#x60;. Applies to the &#x60;IDV_PERSONA&#x60; IdP type. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

