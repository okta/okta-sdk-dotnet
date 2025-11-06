# Okta.Sdk.Model.Push1
Sends an asynchronous push notification to the device for approval by the user. A successful request returns an HTTP 201 response, unlike other factors. You must poll the transaction to determine the state of the verification. See [Retrieve a factor transaction status](./#tag/UserFactor/operation/getFactorTransactionStatus).

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UseNumberMatchingChallenge** | **bool** | Select whether to use a number matching challenge for a &#x60;push&#x60; factor.  &gt; **Note:** Sending a request with a body is required when you verify a &#x60;push&#x60; factor with a number matching challenge. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

