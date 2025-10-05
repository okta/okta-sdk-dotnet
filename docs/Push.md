# Okta.Sdk.Model.Push
Sends an asynchronous push notification to the device for approval by the user. You must poll the transaction to determine the state of the verification. See [Retrieve a factor transaction status](./#tag/UserFactor/operation/getFactorTransactionStatus).  Activations have a short lifetime of several minutes and return a `TIMEOUT` if not completed before the timestamp specified in the `expiresAt` param. Use the published activate link to restart the activation process if the activation expires.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UseNumberMatchingChallenge** | **bool** | Select whether to use a number matching challenge for a &#x60;push&#x60; factor.  &gt; **Note:** Sending a request with a body is required when you verify a &#x60;push&#x60; factor with a number matching challenge. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

