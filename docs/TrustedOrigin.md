# Okta.Sdk.Model.TrustedOrigin

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset** | Timestamp when the trusted origin was created | [optional] [readonly] 
**CreatedBy** | **string** | The ID of the user who created the trusted origin | [optional] 
**Id** | **string** | Unique identifier for the trusted origin | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the trusted origin was last updated | [optional] [readonly] 
**LastUpdatedBy** | **string** | The ID of the user who last updated the trusted origin | [optional] 
**Name** | **string** | Unique name for the trusted origin | [optional] 
**Origin** | **string** | Unique origin URL for the trusted origin. The supported schemes for this attribute are HTTP, HTTPS, FTP, Ionic 2, and Capacitor. | [optional] 
**Scopes** | [**List&lt;TrustedOriginScope&gt;**](TrustedOriginScope.md) | Array of scope types that this trusted origin is used for | [optional] 
**Status** | **LifecycleStatus** |  | [optional] 
**Links** | [**LinksSelfAndLifecycle**](LinksSelfAndLifecycle.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

