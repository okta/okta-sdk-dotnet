# Okta.Sdk.Model.DTCChromeOS
Google Chrome Device Trust Connector provider

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AllowScreenLock** | **bool** | Indicates whether the AllowScreenLock enterprise policy is enabled | [optional] 
**BrowserVersion** | [**ChromeBrowserVersion**](ChromeBrowserVersion.md) |  | [optional] 
**BuiltInDnsClientEnabled** | **bool** | Indicates if a software stack is used to communicate with the DNS server | [optional] 
**ChromeRemoteDesktopAppBlocked** | **bool** | Indicates whether access to the Chrome Remote Desktop application is blocked through a policy | [optional] 
**DeviceEnrollmentDomain** | **string** | Enrollment domain of the customer that is currently managing the device | [optional] 
**DiskEnrypted** | **bool** | Indicates whether the main disk is encrypted | [optional] 
**KeyTrustLevel** | **KeyTrustLevelOSMode** |  | [optional] 
**OsFirewall** | **bool** | Indicates whether a firewall is enabled at the OS-level on the device | [optional] 
**OsVersion** | [**OSVersion**](OSVersion.md) |  | [optional] 
**PasswordProtectionWarningTrigger** | **PasswordProtectionWarningTrigger** |  | [optional] 
**RealtimeUrlCheckMode** | **bool** | Indicates whether enterprise-grade (custom) unsafe URL scanning is enabled | [optional] 
**SafeBrowsingProtectionLevel** | **SafeBrowsingProtectionLevel** |  | [optional] 
**ScreenLockSecured** | **bool** | Indicates whether the device is password-protected | [optional] 
**SiteIsolationEnabled** | **bool** | Indicates whether the Site Isolation (also known as **Site Per Process**) setting is enabled | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

