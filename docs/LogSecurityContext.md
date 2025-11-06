# Okta.Sdk.Model.LogSecurityContext
The `securityContext` object provides security information that is directly related to the evaluation of the event's IP reputation. IP reputation is a trustworthiness rating that evaluates how likely a sender is to be malicious and is based on the sender's IP address. As the name implies, the `securityContext` object is useful for security applications-flagging and inspecting suspicious events.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AsNumber** | **int** | The [Autonomous system](https://docs.telemetry.mozilla.org/datasets/other/asn_aggregates/reference) number that&#39;s associated with the autonomous system the event request was sourced to | [optional] [readonly] 
**AsOrg** | **string** | The organization that is associated with the autonomous system that the event request is sourced to | [optional] [readonly] 
**Domain** | **string** | The domain name that&#39;s associated with the IP address of the inbound event request | [optional] [readonly] 
**Isp** | **string** | The Internet service provider that&#39;s used to send the event&#39;s request | [optional] [readonly] 
**IsProxy** | **bool** | Specifies whether an event&#39;s request is from a known proxy | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

