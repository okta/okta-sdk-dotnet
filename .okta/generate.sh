#!/bin/bash

pushd ../openapi3
openapi-generator-cli generate -g csharp -c config.json --skip-validate-spec
popd