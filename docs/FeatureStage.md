# Okta.Sdk.Model.FeatureStage
Current release cycle stage of a feature  If a feature's stage value is `EA`, the state is `null` and not returned. If the value is `BETA`, the state is `OPEN` or `CLOSED` depending on whether the `BETA` feature is manageable.  > **Note:** If a feature's stage is `OPEN BETA`, you can update it only in Preview cells. If a feature's stage is `CLOSED BETA`, you can disable it only in Preview cells.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**State** | **FeatureStageState** |  | [optional] 
**Value** | **FeatureStageValue** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

