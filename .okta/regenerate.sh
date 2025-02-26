#!/bin/bash

if [[ -z "${CIRCLE_WORKING_DIRECTORY}" ]]; then
  OKTA_SCRIPT_ROOT="."
else
  OKTA_SCRIPT_ROOT="${CIRCLE_WORKING_DIRECTORY}.okta"
fi

echo OKTA_SCRIPT_ROOT = ${OKTA_SCRIPT_ROOT}
pushd ${OKTA_SCRIPT_ROOT}

./clean.sh

./generate.sh

popd
