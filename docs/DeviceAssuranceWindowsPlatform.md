# Okta.Sdk.Model.DeviceAssuranceWindowsPlatform

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreatedBy** | **string** |  | [optional] [readonly] 
**CreatedDate** | **string** |  | [optional] [readonly] 
**Id** | **string** |  | [optional] [readonly] 
**LastUpdate** | **string** |  | [optional] [readonly] 
**LastUpdatedBy** | **string** |  | [optional] [readonly] 
**Name** | **string** | Display name of the Device Assurance Policy | [optional] 
**Platform** | [**Platform**](Platform.md) |  | [optional] 
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 
**DiskEncryptionType** | [**DeviceAssuranceMacOSPlatformAllOfDiskEncryptionType**](DeviceAssuranceMacOSPlatformAllOfDiskEncryptionType.md) |  | [optional] 
**OsVersion** | [**OSVersionFourComponents**](OSVersionFourComponents.md) |  | [optional] 
**OsVersionConstraints** | [**List&lt;OSVersionConstraint&gt;**](OSVersionConstraint.md) | &lt;div class&#x3D;\&quot;x-lifecycle-container\&quot;&gt;&lt;x-lifecycle class&#x3D;\&quot;ea\&quot;&gt;&lt;/x-lifecycle&gt;&lt;/div&gt;Specifies the Windows version requirements for the assurance policy. Each requirement must correspond to a different major version (Windows 11 or Windows 10). If a requirement isn&#39;t specified for a major version, then devices on that major version satisfy the condition.  There are two types of OS requirements: * **Static**: A specific Windows version requirement that doesn&#39;t change until you update the policy. A static OS Windows requirement is specified with &#x60;majorVersionConstraint&#x60; and &#x60;minimum&#x60;. * **Dynamic**: A Windows version requirement that is relative to the latest major release and security patch. A dynamic OS Windows requirement is specified with &#x60;majorVersionConstraint&#x60; and &#x60;dynamicVersionRequirement&#x60;.  &gt; **Note:** Dynamic OS requirements are available only if the **Dynamic OS version compliance** [self-service EA](/openapi/okta-management/guides/release-lifecycle/#early-access-ea) feature is enabled. The &#x60;osVersionConstraints&#x60; property is only supported for the Windows platform. You can&#39;t specify both &#x60;osVersion.minimum&#x60; and &#x60;osVersionConstraints&#x60; properties at the same time.  | [optional] 
**ScreenLockType** | [**DeviceAssuranceAndroidPlatformAllOfScreenLockType**](DeviceAssuranceAndroidPlatformAllOfScreenLockType.md) |  | [optional] 
**SecureHardwarePresent** | **bool** |  | [optional] 
**ThirdPartySignalProviders** | [**DeviceAssuranceWindowsPlatformAllOfThirdPartySignalProviders**](DeviceAssuranceWindowsPlatformAllOfThirdPartySignalProviders.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

