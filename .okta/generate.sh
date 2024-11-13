#!/bin/bash

pushd ../openapi3
openapi-generator-cli generate -g csharp-netcore -c config.json --skip-validate-spec
popd