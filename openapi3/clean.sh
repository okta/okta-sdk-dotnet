#!/bin/bash

pushd ..
rm -fr docs
pushd src
rm -fr Okta.Sdk
popd
popd