# Okta.Sdk.Model.LogStreamSchema

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Schema** | **string** | JSON schema version identifier | [optional] [readonly] 
**ErrorMessage** | **Object** | A collection of error messages for individual properties in the schema. Okta implements a subset of [ajv-errors](https://github.com/ajv-validator/ajv-errors). | [optional] 
**Id** | **string** | URI of log stream schema | [optional] [readonly] 
**OneOf** | [**List&lt;UserSchemaAttributeEnum&gt;**](UserSchemaAttributeEnum.md) | Non-empty array of valid JSON schemas.  Okta only supports &#x60;oneOf&#x60; for specifying display names for an &#x60;enum&#x60;. Each schema has the following format:  &#x60;&#x60;&#x60; {   \&quot;const\&quot;: \&quot;enumValue\&quot;,   \&quot;title\&quot;: \&quot;display name\&quot; } &#x60;&#x60;&#x60; | [optional] 
**Pattern** | **string** | For &#x60;string&#x60; log stream schema property type, specifies the regular expression used to validate the property | [optional] 
**Properties** | **Object** | log stream schema properties object | [optional] 
**Required** | **List&lt;string&gt;** | Required properties for this log stream schema object | [optional] 
**Title** | **string** | Name of the log streaming integration | [optional] 
**Type** | **string** | Type of log stream schema property | [optional] [readonly] 
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

