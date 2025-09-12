# Okta.Sdk.Model.OAuth2Scope

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Scope name | 
**Consent** | **OAuth2ScopeConsentType** |  | [optional] 
**Default** | **bool** | Indicates if this Scope is a default scope | [optional] [default to false]
**Description** | **string** | Description of the Scope | [optional] 
**DisplayName** | **string** | Name of the end user displayed in a consent dialog | [optional] 
**Id** | **string** | Scope object ID | [optional] [readonly] 
**MetadataPublish** | **OAuth2ScopeMetadataPublish** |  | [optional] 
**Optional** | **bool** | Indicates whether the Scope is optional. When set to &#x60;true&#x60;, the user can skip consent for the scope. | [optional] [default to false]
**System** | **bool** | Indicates if Okta created the Scope | [optional] [default to false]
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

