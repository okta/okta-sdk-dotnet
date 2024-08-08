# Okta.Sdk.Model.TrustedOrigin

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset** | Timestamp when the Trusted Origin was created | [optional] [readonly] 
**CreatedBy** | **string** | The ID of the user who created the Trusted Origin | [optional] 
**Id** | **string** | Unique identifier for the Trusted Origin | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the Trusted Origin was last updated | [optional] [readonly] 
**LastUpdatedBy** | **string** | The ID of the user who last updated the Trusted Origin | [optional] 
**Name** | **string** | Unique name for the Trusted Origin | [optional] 
**Origin** | **string** | Unique origin URL for the Trusted Origin. The supported schemes for this attribute are HTTP, HTTPS, FTP, Ionic 2, and Capacitor. | [optional] 
**Scopes** | [**List&lt;TrustedOriginScope&gt;**](TrustedOriginScope.md) | Array of Scope types that this Trusted Origin is used for | [optional] 
**Status** | **LifecycleStatus** |  | [optional] 
**Links** | [**LinksSelfAndLifecycle**](LinksSelfAndLifecycle.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

