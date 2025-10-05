# Okta.Sdk.Model.OidcSettings
Advanced settings for the OpenID Connect protocol

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ParticipateSlo** | **bool** | Set to &#x60;true&#x60; to have Okta send a logout request to the upstream IdP when a user signs out of Okta or a downstream app. | [optional] 
**SendApplicationContext** | **bool** | Determines if the IdP should send the application context as &#x60;OktaAppInstanceId&#x60; and &#x60;OktaAppName&#x60; params in the request | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

