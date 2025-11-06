# Okta.Sdk.Model.CreateGroupPushMappingRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AppConfig** | [**AppConfig**](.md) |  | [optional] 
**SourceGroupId** | **string** | The ID of the source group for the group push mapping | 
**Status** | **GroupPushMappingStatusUpsert** |  | [optional] 
**TargetGroupId** | **string** | The ID of the existing target group for the group push mapping. This is used to link to an existing group. Required if &#x60;targetGroupName&#x60; is not provided. | [optional] 
**TargetGroupName** | **string** | The name of the target group for the group push mapping. This is used when creating a new downstream group. If the group already exists, it links to the existing group. Required if &#x60;targetGroupId&#x60; is not provided. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

