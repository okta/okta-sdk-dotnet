# Okta.Sdk.Model.UserImportRequestDataContext

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Conflicts** | **List&lt;Dictionary&lt;string, Object&gt;&gt;** | An array of user profile attributes that are in conflict | [optional] 
**Application** | [**UserImportRequestDataContextApplication**](UserImportRequestDataContextApplication.md) |  | [optional] 
**Job** | [**UserImportRequestDataContextJob**](UserImportRequestDataContextJob.md) |  | [optional] 
**Matches** | **List&lt;Dictionary&lt;string, Object&gt;&gt;** | The list of Okta users currently matched to the app user based on import matching. There can be more than one match. | [optional] 
**Policy** | **List&lt;Dictionary&lt;string, Object&gt;&gt;** | The list of any policies that apply to the import matching | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

