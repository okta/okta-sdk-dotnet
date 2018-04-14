function createContextForOperationInterface(tag, spec, operations) {
  return {
    tag, spec, operations
  };
}

function createContextForOperation(tag, spec, operations) {
  return {
    tag, spec, operations
  };
}

module.exports.createContextForOperationInterface = createContextForOperationInterface;
module.exports.createContextForOperation = createContextForOperation;
