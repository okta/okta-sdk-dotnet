# Okta.Sdk.Model.ActiveDirectoryApplicationSettingsApplication
App-specific settings for Active Directory applications

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ActivationEmail** | **string** | Email address to send activation emails | [optional] 
**FilterGroupsByOU** | **bool** | Whether to filter groups by organizational unit | [optional] 
**JitGroupsAcrossDomains** | **bool** | Whether to enable just-in-time provisioning of groups across domains | [optional] 
**Login** | **string** | Login username for AD connection | [optional] 
**NamingContext** | **string** | The AD domain naming context (e.g., &#39;corp.local&#39;) | [optional] 
**Password** | **string** | Password for AD connection | [optional] 
**ScanRate** | **int?** | Rate at which to scan the AD directory | [optional] 
**SearchOrgUnit** | **string** | Organizational unit to search within | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

