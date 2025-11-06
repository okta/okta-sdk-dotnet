# Okta.Sdk.Model.IdentityProviderApplicationUser

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset** | Timestamp when the object was created | [optional] [readonly] 
**ExternalId** | **string** | Unique IdP-specific identifier for the user | [optional] [readonly] 
**Id** | **string** | Unique key of the user | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the object was last updated | [optional] [readonly] 
**Profile** | **Dictionary&lt;string, Object&gt;** | IdP-specific profile for the user.   IdP user profiles are IdP-specific but may be customized by the Profile Editor in the Admin Console.  &gt; **Note:** Okta variable names have reserved characters that may conflict with the name of an IdP assertion attribute. You can use the **External name** to define the attribute name as defined in an IdP assertion such as a SAML attribute name. | [optional] 
**Embedded** | **Dictionary&lt;string, Object&gt;** | Embedded resources related to the IdP user | [optional] [readonly] 
**Links** | [**IdentityProviderApplicationUserLinks**](IdentityProviderApplicationUserLinks.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

