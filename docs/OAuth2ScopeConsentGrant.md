# Okta.Sdk.Model.OAuth2ScopeConsentGrant
Grant object that represents an app consent scope grant

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ClientId** | **string** | Client ID of the app integration | [optional] [readonly] 
**Created** | **DateTimeOffset** | Timestamp when the Grant object was created | [optional] [readonly] 
**CreatedBy** | [**OAuth2Actor**](OAuth2Actor.md) |  | [optional] 
**Id** | **string** | ID of the Grant object | [optional] [readonly] 
**Issuer** | **string** | The issuer of your org authorization server. This is typically your Okta domain. | 
**LastUpdated** | **DateTimeOffset** | Timestamp when the Grant object was last updated | [optional] [readonly] 
**ScopeId** | **string** | The name of the [Okta scope](https://developer.okta.com/docs/api/oauth2/#oauth-20-scopes) for which consent is granted | 
**Source** | **OAuth2ScopeConsentGrantSource** |  | [optional] 
**Status** | **GrantOrTokenStatus** |  | [optional] 
**UserId** | **string** | User ID that granted consent (if &#x60;source&#x60; is &#x60;END_USER&#x60;) | [optional] [readonly] 
**Embedded** | [**OAuth2ScopeConsentGrantEmbedded**](OAuth2ScopeConsentGrantEmbedded.md) |  | [optional] 
**Links** | [**OAuth2ScopeConsentGrantLinks**](OAuth2ScopeConsentGrantLinks.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

