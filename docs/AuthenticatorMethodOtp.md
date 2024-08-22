# Okta.Sdk.Model.AuthenticatorMethodOtp

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**VerifiableProperties** | [**List&lt;AuthenticatorMethodProperty&gt;**](AuthenticatorMethodProperty.md) |  | [optional] 
**AcceptableAdjacentIntervals** | **int** | The number of acceptable adjacent intervals, also known as the clock drift interval. This setting allows you to build in tolerance for any time difference between the token and the server. For example, with a &#x60;timeIntervalInSeconds&#x60; of 60 seconds and an &#x60;acceptableAdjacentIntervals&#x60; value of 5, Okta accepts passcodes within 300 seconds (60 * 5) before or after the end user enters their code. | [optional] 
**Algorithm** | **OtpTotpAlgorithm** |  | [optional] 
**Encoding** | **OtpTotpEncoding** |  | [optional] 
**FactorProfileId** | **string** | The &#x60;id&#x60; value of the factor profile | [optional] 
**PassCodeLength** | **int** | Number of digits in an OTP value | [optional] 
**Protocol** | **OtpProtocol** |  | [optional] 
**TimeIntervalInSeconds** | **int** | Time interval for TOTP in seconds | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

