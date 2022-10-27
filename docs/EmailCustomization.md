# Okta.Sdk.Model.EmailCustomization

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Body** | **string** | The email&#39;s HTML body. May contain [variable references](https://velocity.apache.org/engine/1.7/user-guide.html#references). | 
**Subject** | **string** | The email&#39;s subject. May contain [variable references](https://velocity.apache.org/engine/1.7/user-guide.html#references). | 
**Created** | **DateTimeOffset** | The UTC time at which this email customization was created. | [optional] [readonly] 
**Id** | **string** | A unique identifier for this email customization. | [optional] [readonly] 
**IsDefault** | **bool** | Whether this is the default customization for the email template. Each customized email template must have exactly one default customization. Defaults to &#x60;true&#x60; for the first customization and &#x60;false&#x60; thereafter. | [optional] 
**Language** | **string** | The language specified as an [IETF BCP 47 language tag](https://datatracker.ietf.org/doc/html/rfc5646). | 
**LastUpdated** | **DateTimeOffset** | The UTC time at which this email customization was last updated. | [optional] [readonly] 
**Links** | [**EmailCustomizationAllOfLinks**](EmailCustomizationAllOfLinks.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

