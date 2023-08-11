# Okta.Sdk.Model.GroupOwner

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DisplayName** | **string** | The display name of the group owner | [optional] [readonly] 
**Id** | **string** | The &#x60;id&#x60; of the group owner | [optional] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the group owner was last updated | [optional] [readonly] 
**OriginId** | **string** | The ID of the app instance if the &#x60;originType&#x60; is &#x60;APPLICATION&#x60;. This value is &#x60;NULL&#x60; if &#x60;originType&#x60; is &#x60;OKTA_DIRECTORY&#x60;. | [optional] 
**OriginType** | **GroupOwnerOriginType** |  | [optional] 
**Resolved** | **bool** | If &#x60;originType&#x60;is APPLICATION, this parameter is set to &#x60;FALSE&#x60; until the owner’s &#x60;originId&#x60; is reconciled with an associated Okta ID. | [optional] 
**Type** | **GroupOwnerType** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

