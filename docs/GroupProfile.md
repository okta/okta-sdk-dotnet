# Okta.Sdk.Model.GroupProfile
Specifies required and optional properties for a group. The `objectClass` of a group determines which additional properties are available.  You can extend group profiles with custom properties, but you must first add the properties to the group profile schema before you can reference them. Use the Profile Editor in the Admin Console or the [Schemas API](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/Schema/)to manage schema extensions.  Custom properties can contain HTML tags. It is the client's responsibility to escape or encode this data before displaying it. Use [best-practices](https://cheatsheetseries.owasp.org/cheatsheets/Cross_Site_Scripting_Prevention_Cheat_Sheet.html) to prevent cross-site scripting.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Description** | **string** | Description of the Windows group | [optional] 
**Name** | **string** | Name of the Windows group | [optional] 
**Dn** | **string** | The distinguished name of the Windows group | [optional] 
**ExternalId** | **string** | Base-64 encoded GUID (&#x60;objectGUID&#x60;) of the Windows group | [optional] 
**GroupScope** | **string** | The scope of the Windows group (DomainLocal, Global, or Universal) | [optional] 
**GroupType** | **string** | The type of the Windows group (Security or Distribution) | [optional] 
**ManagedBy** | **string** | Distinguished name of the group that manages this group | [optional] 
**ObjectSid** | **string** | The Windows Security Identifier (SID) for the group | [optional] 
**SamAccountName** | **string** | Pre-Windows 2000 name of the Windows group | [optional] 
**WindowsDomainQualifiedName** | **string** | Fully qualified name of the Windows group | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

