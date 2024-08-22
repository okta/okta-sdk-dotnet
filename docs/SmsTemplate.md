# Okta.Sdk.Model.SmsTemplate

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset** |  | [optional] [readonly] 
**Id** | **string** |  | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** |  | [optional] [readonly] 
**Name** | **string** | Human-readable name of the Template | [optional] 
**Template** | **string** | Text of the Template, including any [macros](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/Template/) | [optional] 
**Translations** | **Object** | - Template translations are optionally provided when you want to localize the SMS messages. Translations are provided as an object that contains &#x60;key:value&#x60; pairs: the language and the translated Template text. The key portion is a two-letter country code that conforms to [ISO 639-1](https://www.loc.gov/standards/iso639-2/php/code_list.php). The value is the translated SMS Template. - Just like with regular SMS Templates, the length of the SMS message can&#39;t exceed 160 characters.  | [optional] 
**Type** | **SmsTemplateType** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

