# Okta.Sdk.Model.ListProfileMappings
A collection of the profile mappings that include a subset of the profile mapping object's properties. The profile mapping object describes a mapping between an Okta user's and an app user's properties using [JSON Schema Draft 4](https://datatracker.ietf.org/doc/html/draft-zyp-json-schema-04).  > **Note:** Same type source/target mappings aren't supported by this API. Profile mappings must either be Okta->App or App->Okta.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | Unique identifier for profile mapping | [optional] [readonly] 
**Source** | [**ProfileMappingSource**](ProfileMappingSource.md) |  | [optional] 
**Target** | [**ProfileMappingTarget**](ProfileMappingTarget.md) |  | [optional] 
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

