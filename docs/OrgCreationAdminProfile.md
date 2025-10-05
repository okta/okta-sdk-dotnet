# Okta.Sdk.Model.OrgCreationAdminProfile
Specifies the profile attributes for the first super admin user. The minimal set of required attributes are `email`, `firstName`, `lastName`, and `login`. See [profile](/openapi/okta-management/management/tag/User/#tag/User/operation/getUser!c=200&path=profile&t=response) for additional profile attributes.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**FirstName** | **string** | Given name of the User (&#x60;givenName&#x60;) | 
**LastName** | **string** | The family name of the User (&#x60;familyName&#x60;) | 
**Email** | **string** | The primary email address of the User. For validation, see [RFC 5322 Section 3.2.3](https://datatracker.ietf.org/doc/html/rfc5322#section-3.2.3). | 
**Login** | **string** | The unique identifier for the User (&#x60;username&#x60;) | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

