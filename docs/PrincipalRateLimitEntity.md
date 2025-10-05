# Okta.Sdk.Model.PrincipalRateLimitEntity

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreatedBy** | **string** | The Okta user ID of the user who created the principle rate limit entity | [optional] [readonly] 
**CreatedDate** | **DateTimeOffset** | The date and time the principle rate limit entity was created | [optional] [readonly] 
**DefaultConcurrencyPercentage** | **int** | The default percentage of a given concurrency limit threshold that the owning principal can consume | [optional] 
**DefaultPercentage** | **int** | The default percentage of a given rate limit threshold that the owning principal can consume | [optional] 
**Id** | **string** | The unique identifier of the principle rate limit entity | [optional] [readonly] 
**LastUpdate** | **DateTimeOffset** | The date and time the principle rate limit entity was last updated | [optional] [readonly] 
**LastUpdatedBy** | **string** | The Okta user ID of the user who last updated the principle rate limit entity | [optional] [readonly] 
**OrgId** | **string** | The unique identifier of the Okta org | [optional] [readonly] 
**PrincipalId** | **string** | The unique identifier of the principal. This is the ID of the API token or OAuth 2.0 app. | 
**PrincipalType** | **PrincipalType** |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

