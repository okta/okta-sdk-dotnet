# Okta.Sdk.Model.ProfileMappingSource
The parameter is the source of a profile mapping and is a valid [JSON Schema Draft 4](https://datatracker.ietf.org/doc/html/draft-zyp-json-schema-04) document with the following properties. The data type can be an app instance or an Okta object.  > **Note:** If the source is Okta and the UserTypes feature isn't enabled, then the source `_links` only has a link to the schema.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | Unique identifier for the application instance or userType | [optional] [readonly] 
**Name** | **string** | Variable name of the application instance or name of the referenced UserType | [optional] [readonly] 
**Type** | **string** | Type of user referenced in the mapping | [optional] [readonly] 
**Links** | [**SourceLinks**](SourceLinks.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

