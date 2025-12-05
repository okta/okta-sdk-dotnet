# Okta.Sdk.Model.OktaActiveDirectoryGroupProfile
Profile for a group that is imported from Active Directory.  The `objectClass` for such groups is `okta:windows_security_principal`.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Description** | **string** | Description of the Windows group | [optional] 
**Dn** | **string** | The distinguished name of the Windows group | [optional] 
**ExternalId** | **string** | Base-64 encoded GUID (&#x60;objectGUID&#x60;) of the Windows group | [optional] 
**GroupScope** | **string** | The scope of the Windows group (DomainLocal, Global, or Universal) | [optional] 
**GroupType** | **string** | The type of the Windows group (Security or Distribution) | [optional] 
**ManagedBy** | **string** | Distinguished name of the group that manages this group | [optional] 
**Name** | **string** | Name of the Windows group | [optional] 
**ObjectSid** | **string** | The Windows Security Identifier (SID) for the group | [optional] 
**SamAccountName** | **string** | Pre-Windows 2000 name of the Windows group | [optional] 
**WindowsDomainQualifiedName** | **string** | Fully qualified name of the Windows group | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

