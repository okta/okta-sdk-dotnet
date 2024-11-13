#!/bin/bash

pushd ../src
#rm -fr Okta.Sdk.UnitTest/
cp -R Okta.Sdk.UnitTest_$1/ Okta.Sdk.UnitTest
popd