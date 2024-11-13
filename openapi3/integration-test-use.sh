#!/bin/bash

pushd ../src
rm -fr Okta.Sdk.IntegrationTest/
cp -R Okta.Sdk.IntegrationTest_$1/ Okta.Sdk.IntegrationTest
popd