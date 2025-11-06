# Okta.Sdk.Model.ApplicationCredentialsUsernameTemplate
The template used to generate the username when the app is assigned through a group or directly to a user

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**PushStatus** | **string** | Determines if the username is pushed to the app on updates for CUSTOM &#x60;type&#x60; | [optional] 
**Template** | **string** | Mapping expression used to generate usernames.  The following are supported mapping expressions that are used with the &#x60;BUILT_IN&#x60; template type:  | Name                            | Template Expression                            | | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | AD Employee ID                  | &#x60;${source.employeeID}&#x60;                         | | AD SAM Account Name             | &#x60;${source.samAccountName}&#x60;                     | | AD SAM Account Name (lowercase) | &#x60;${fn:toLowerCase(source.samAccountName)}&#x60;     | | AD User Principal Name          | &#x60;${source.userName}&#x60;                           | | AD User Principal Name prefix   | &#x60;${fn:substringBefore(source.userName, \&quot;@\&quot;)}&#x60;  | | Email                           | &#x60;${source.email}&#x60;                              | | Email (lowercase)               | &#x60;${fn:toLowerCase(source.email)}&#x60;              | | Email prefix                    | &#x60;${fn:substringBefore(source.email, \&quot;@\&quot;)}&#x60;     | | LDAP UID + custom suffix        | &#x60;${source.userName}${instance.userSuffix}&#x60;     | | Okta username                   | &#x60;${source.login}&#x60;                              | | Okta username prefix            | &#x60;${fn:substringBefore(source.login, \&quot;@\&quot;)}&#x60;     | | [optional] [default to "${source.login}"]
**Type** | **string** | Type of mapping expression. Empty string is allowed. | [optional] [default to TypeEnum.BUILTIN]
**UserSuffix** | **string** | An optional suffix appended to usernames for &#x60;BUILT_IN&#x60; mapping expressions | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

