# Okta.Sdk.Model.UserImportResponseCommandsInner

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** | The command types supported for the import inline hook. When using the &#x60;com.okta.action.update&#x60; command to specify that the user should be treated as a match, you need to also provide a &#x60;com.okta.user.update&#x60; command that sets the ID of the Okta user. | [optional] 
**Value** | **Dictionary&lt;string, string&gt;** | The &#x60;value&#x60; object is the parameter to pass to the command. In the case of the &#x60;com.okta.appUser.profile.update&#x60; and &#x60;com.okta.user.profile.update&#x60; commands,  the parameter should be a list of one or more profile attributes and the values you wish to set them to. In the case of the &#x60;com.okta.action.update&#x60; command, the parameter should be a &#x60;result&#x60; property set to either &#x60;CREATE_USER&#x60; or &#x60;LINK_USER&#x60;. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

