# Okta.Sdk.Model.BaseContextUserIdentity
Provides information on the user's identity claims and token properties. This property is present in token inline hook payloads for refresh_token grant types.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Claims** | **Object** | Claims included in the token. Consists of name-value pairs for each included claim. For descriptions of the claims that you can include, see the Okta [OpenID Connect and OAuth 2.0 API reference](/openapi/okta-oauth/guides/overview/#claims). | [optional] 
**Token** | [**BaseTokenToken**](BaseTokenToken.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

