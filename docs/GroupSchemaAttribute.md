# Okta.Sdk.Model.GroupSchemaAttribute

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Description** | **string** | Description of the property | [optional] 
**Enum** | **List&lt;Object&gt;** | Enumerated value of the property.  The value of the property is limited to one of the values specified in the enum definition. The list of values for the enum must consist of unique elements. | [optional] 
**ExternalName** | **string** | Name of the property as it exists in an external application | [optional] 
**ExternalNamespace** | **string** | Namespace from the external application | [optional] 
**Format** | **UserSchemaAttributeFormat** | Identifies the type of data represented by the string | [optional] 
**Items** | [**UserSchemaAttributeItems**](UserSchemaAttributeItems.md) |  | [optional] 
**Master** | [**GroupSchemaAttributeMaster**](GroupSchemaAttributeMaster.md) |  | [optional] 
**MaxLength** | **int?** | Maximum character length of a string property | [optional] 
**MinLength** | **int?** | Minimum character length of a string property | [optional] 
**Mutability** | **UserSchemaAttributeMutabilityString** | Defines the mutability of the property | [optional] 
**OneOf** | [**List&lt;UserSchemaAttributeEnum&gt;**](UserSchemaAttributeEnum.md) | Non-empty array of valid JSON schemas.  The &#x60;oneOf&#x60; key is only supported in conjunction with &#x60;enum&#x60; and provides a mechanism to return a display name for the &#x60;enum&#x60; value.&lt;br&gt; Each schema has the following format:  &#x60;&#x60;&#x60; {   \&quot;const\&quot;: \&quot;enumValue\&quot;,   \&quot;title\&quot;: \&quot;display name\&quot; } &#x60;&#x60;&#x60;  When &#x60;enum&#x60; is used in conjunction with &#x60;oneOf&#x60;, you must keep the set of enumerated values and their order.&lt;br&gt; For example:  &#x60;&#x60;&#x60; \&quot;enum\&quot;: [\&quot;S\&quot;,\&quot;M\&quot;,\&quot;L\&quot;,\&quot;XL\&quot;], \&quot;oneOf\&quot;: [     {\&quot;const\&quot;: \&quot;S\&quot;, \&quot;title\&quot;: \&quot;Small\&quot;},     {\&quot;const\&quot;: \&quot;M\&quot;, \&quot;title\&quot;: \&quot;Medium\&quot;},     {\&quot;const\&quot;: \&quot;L\&quot;, \&quot;title\&quot;: \&quot;Large\&quot;},     {\&quot;const\&quot;: \&quot;XL\&quot;, \&quot;title\&quot;: \&quot;Extra Large\&quot;}   ] &#x60;&#x60;&#x60; | [optional] 
**Permissions** | [**List&lt;UserSchemaAttributePermission&gt;**](UserSchemaAttributePermission.md) | Access control permissions for the property | [optional] 
**Required** | **bool?** | Determines whether the property is required | [optional] 
**Scope** | **UserSchemaAttributeScope** | Determines whether a group attribute can be set at the individual or group level | [optional] 
**Title** | **string** | User-defined display name for the property | [optional] 
**Type** | **UserSchemaAttributeType** | Type of property | [optional] 
**Unique** | **bool?** | Determines whether property values must be unique | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

