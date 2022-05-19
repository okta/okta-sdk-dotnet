# Org.OpenAPITools.Model.EmailCustomizationAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Language** | **string** | The language specified as an [IETF BCP 47 language tag](https://datatracker.ietf.org/doc/html/rfc5646). | 
**IsDefault** | **bool** | Whether this is the default customization for the email template. Each customized email template must have exactly one default customization. Defaults to &#x60;true&#x60; for the first customization and &#x60;false&#x60; thereafter. | [optional] 
**Id** | **string** | A unique identifier for this email customization. | [optional] [readonly] 
**Created** | **DateTime** | The UTC time at which this email customization was created. | [optional] [readonly] 
**LastUpdated** | **DateTime** | The UTC time at which this email customization was last updated. | [optional] [readonly] 
**Links** | [**EmailCustomizationAllOfLinks**](EmailCustomizationAllOfLinks.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

