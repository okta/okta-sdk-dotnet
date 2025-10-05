# Okta.Sdk.Model.PasswordPolicyPasswordSettingsComplexity
Complexity settings

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Dictionary** | [**PasswordDictionary**](PasswordDictionary.md) |  | [optional] 
**ExcludeAttributes** | **List&lt;string&gt;** | The User profile attributes whose values must be excluded from the password: currently only supports &#x60;firstName&#x60; and &#x60;lastName&#x60; | [optional] 
**ExcludeUsername** | **bool** | Indicates if the Username must be excluded from the password | [optional] [default to true]
**MinLength** | **int** | Minimum password length | [optional] [default to 8]
**MinLowerCase** | **int** | Indicates if a password must contain at least one lower case letter: &#x60;0&#x60; indicates no, &#x60;1&#x60; indicates yes | [optional] [default to 1]
**MinNumber** | **int** | Indicates if a password must contain at least one number: &#x60;0&#x60; indicates no, &#x60;1&#x60; indicates yes | [optional] [default to 1]
**MinSymbol** | **int** | Indicates if a password must contain at least one symbol (For example: !@#$%^&amp;*): &#x60;0&#x60; indicates no, &#x60;1&#x60; indicates yes | [optional] [default to 1]
**MinUpperCase** | **int** | Indicates if a password must contain at least one upper case letter: &#x60;0&#x60; indicates no, &#x60;1&#x60; indicates yes | [optional] [default to 1]
**OelStatement** | **string** | &lt;x-lifecycle-container&gt;&lt;x-lifecycle class&#x3D;\&quot;ea\&quot;&gt;&lt;/x-lifecycle&gt; &lt;x-lifecycle class&#x3D;\&quot;oie\&quot;&gt;&lt;/x-lifecycle&gt;&lt;/x-lifecycle-container&gt;Use an [Expression Language](https://developer.okta.com/docs/reference/okta-expression-language-in-identity-engine/) expression to block a word from being used in a password. You can only block one word per expression. Use the &#x60;OR&#x60; operator to connect multiple expressions to block multiple words. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

