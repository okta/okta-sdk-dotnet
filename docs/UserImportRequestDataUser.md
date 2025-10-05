# Okta.Sdk.Model.UserImportRequestDataUser
Provides information on the Okta user profile currently set to be used for the user who is being imported, based on the matching  rules and attribute mappings that were applied.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Profile** | **Dictionary&lt;string, string&gt;** | The &#x60;data.user.profile&#x60; contains the name-value pairs of the attributes in the user profile. If the user has been matched to an existing Okta user, a &#x60;data.user.id&#x60; object is included, containing the unique identifier of the Okta user profile.  You can change the values of the attributes by means of the &#x60;commands&#x60; object you return. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

