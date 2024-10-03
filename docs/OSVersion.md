# Okta.Sdk.Model.OSVersion
Specifies the OS requirement for the policy.  There are two types of OS requirements:  * **Static**: A specific OS version requirement that doesn't change until you update the policy. A static OS requirement is specified with the `osVersion.minimum` property. * **Dynamic**: An OS version requirement that is relative to the latest major OS release and security patch. A dynamic OS requirement is specified with the `osVersion.dynamicVersionRequirement` property. > **Note:** Dynamic OS requirements are available only if the **Dynamic OS version compliance** [self-service EA](/openapi/okta-management/guides/release-lifecycle/#early-access-ea) feature is enabled. You can't specify both `osVersion.minimum` and `osVersion.dynamicVersionRequirement` properties at the same time. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DynamicVersionRequirement** | [**OSVersionDynamicVersionRequirement**](OSVersionDynamicVersionRequirement.md) |  | [optional] 
**Minimum** | **string** | The device version must be equal to or newer than the specified version string (maximum of three components for iOS and macOS, and maximum of four components for Android) | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

