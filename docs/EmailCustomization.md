# Okta.Sdk.Model.EmailCustomization

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Body** | **string** | The HTML body of the email. May contain [variable references](https://velocity.apache.org/engine/1.7/user-guide.html#references).   &lt;x-lifecycle class&#x3D;\&quot;ea\&quot;&gt;&lt;/x-lifecycle&gt; Not required if Custom languages for Okta Email Templates is enabled. A &#x60;null&#x60; body is replaced with a default value from one of the following in priority order:  1. An existing default email customization, if one exists 2. Okta-provided translated content for the specified language, if one exists 3. Okta-provided translated content for the brand locale, if it&#39;s set  4. Okta-provided content in English  | 
**Subject** | **string** | The email subject. May contain [variable references](https://velocity.apache.org/engine/1.7/user-guide.html#references).  &lt;x-lifecycle class&#x3D;\&quot;ea\&quot;&gt;&lt;/x-lifecycle&gt; Not required if Custom languages for Okta Email Templates is enabled. A &#x60;null&#x60; subject is replaced with a default value from one of the following in priority order:  1. An existing default email customization, if one exists 2. Okta-provided translated content for the specified language, if one exists 3. Okta-provided translated content for the brand locale, if it&#39;s set 4. Okta-provided content in English  | 
**Created** | **DateTimeOffset** | The UTC time at which this email customization was created. | [optional] [readonly] 
**Id** | **string** | A unique identifier for this email customization | [optional] [readonly] 
**IsDefault** | **bool** | Whether this is the default customization for the email template. Each customized email template must have exactly one default customization. Defaults to &#x60;true&#x60; for the first customization and &#x60;false&#x60; thereafter. | [optional] 
**Language** | **string** | The language specified as an [IETF BCP 47 language tag](https://datatracker.ietf.org/doc/html/rfc5646) | 
**LastUpdated** | **DateTimeOffset** | The UTC time at which this email customization was last updated. | [optional] [readonly] 
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

