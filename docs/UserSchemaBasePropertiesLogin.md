# Okta.Sdk.Model.UserSchemaBasePropertiesLogin
Unique identifier for the user (`userName`)  The login property is validated according to its pattern attribute, which is a string. By default, the attribute is null. When the attribute is null, the username is required to be formatted as an email address as defined by [RFC 6531 Section 3.3](http://tools.ietf.org/html/rfc6531#section-3.3). The pattern can be set through the API to one of the following forms. (The Admin Console provides access to the same forms.)   * A login pattern of `\".+\"` indicates that there is no restriction on usernames. Any non-empty, unique value is permitted, and the minimum length of five isn't enforced. In this case, usernames don't need to include the `@` character. If a name does include `@`, the portion ahead of the `@` can be used for logging in, provided it identifies a unique user within the org.   * A login pattern of the form `\"[...]+\"` indicates that usernames must only contain characters from the set given between the brackets. The enclosing brackets and final `+` are required for this form. Character ranges can be indicated using hyphens. To include the hyphen itself in the allowed set, the hyphen must appear first. Any characters in the set except the hyphen, a-z, A-Z, and 0-9 must be preceded by a backslash (`\\`). For example, `\"[a-z13579\\.]+\"` would restrict usernames to lowercase letters, odd digits, and periods, while `\"[-a-zA-Z0-9]+\"` would allow basic alphanumeric characters and hyphens.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Default** | **Object** | If specified, assigns the value as the default value for the custom attribute. This is a nullable property. If you don&#39;t specify a value for this custom attribute during user creation or update, the &#x60;default&#x60; is used instead of setting the value to &#x60;null&#x60; or empty. | [optional] 
**Description** | **string** | Description of the property | [optional] 
**Enum** | **List&lt;Object&gt;** | Enumerated value of the property.  The value of the property is limited to one of the values specified in the enum definition. The list of values for the enum must consist of unique elements. | [optional] 
**ExternalName** | **string** | Name of the property as it exists in an external application  **NOTE**: When you add a custom property, only Identity Provider app user schemas require &#x60;externalName&#x60; to be included in the request body. If an existing custom Identity Provider app user schema property has an empty &#x60;externalName&#x60;, requests aren&#39;t allowed to update other properties until the &#x60;externalName&#x60; is defined. | [optional] 
**ExternalNamespace** | **string** | Namespace from the external application | [optional] 
**Format** | **UserSchemaAttributeFormat** | Identifies the type of data represented by the string | [optional] 
**Items** | [**UserSchemaAttributeItems**](UserSchemaAttributeItems.md) |  | [optional] 
**Master** | [**GroupSchemaAttributeMaster**](GroupSchemaAttributeMaster.md) |  | [optional] 
**MaxLength** | **int?** | Maximum character length of a string property | [optional] 
**MinLength** | **int?** | Minimum character length of a string property | [optional] 
**Mutability** | **UserSchemaAttributeMutabilityString** | Defines the mutability of the property | [optional] 
**OneOf** | [**List&lt;UserSchemaAttributeEnum&gt;**](UserSchemaAttributeEnum.md) | Non-empty array of valid JSON schemas.  The &#x60;oneOf&#x60; key is only supported in conjunction with &#x60;enum&#x60; and provides a mechanism to return a display name for the &#x60;enum&#x60; value.&lt;br&gt; Each schema has the following format:  &#x60;&#x60;&#x60; {   \&quot;const\&quot;: \&quot;enumValue\&quot;,   \&quot;title\&quot;: \&quot;display name\&quot; } &#x60;&#x60;&#x60;  When &#x60;enum&#x60; is used in conjunction with &#x60;oneOf&#x60;, you must keep the set of enumerated values and their order.&lt;br&gt; For example:  &#x60;&#x60;&#x60; \&quot;enum\&quot;: [\&quot;S\&quot;,\&quot;M\&quot;,\&quot;L\&quot;,\&quot;XL\&quot;], \&quot;oneOf\&quot;: [     {\&quot;const\&quot;: \&quot;S\&quot;, \&quot;title\&quot;: \&quot;Small\&quot;},     {\&quot;const\&quot;: \&quot;M\&quot;, \&quot;title\&quot;: \&quot;Medium\&quot;},     {\&quot;const\&quot;: \&quot;L\&quot;, \&quot;title\&quot;: \&quot;Large\&quot;},     {\&quot;const\&quot;: \&quot;XL\&quot;, \&quot;title\&quot;: \&quot;Extra Large\&quot;}   ] &#x60;&#x60;&#x60; | [optional] 
**Pattern** | **string** | For &#x60;string&#x60; property types, specifies the regular expression used to validate the property | [optional] 
**Permissions** | [**List&lt;UserSchemaAttributePermission&gt;**](UserSchemaAttributePermission.md) | Access control permissions for the property | [optional] 
**Required** | **bool?** | Determines whether the property is required | [optional] 
**Scope** | **UserSchemaAttributeScope** |  | [optional] 
**Title** | **string** | User-defined display name for the property | [optional] 
**Type** | **UserSchemaAttributeType** | Type of property | [optional] 
**Unique** | **bool?** | Determines whether property values must be unique | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

