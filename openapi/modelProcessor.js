const { 
  pascalCase
 } = require('./utils');

/*
Creates the context that the handlebars template is bound to:

{
  parentType: {
    memberName: "Factor"
  },
  resolvingProperty: {
    memberName: "FactorType",
    name: "factorType"
  },
  namesToValues: [
    { value: "call", resolvedType: { memberName: "CallFactor" } }
  ]
}
*/
function createContextForResolver(model, errFunc) {
  let context = {
    parentType: {
      memberName: model.modelName
    },
    resolvingProperty: {
      name: model.resolutionStrategy.propertyName,
      memberName: pascalCase(model.resolutionStrategy.propertyName)
    },
    namesToValues: []
  };

  for (let name of Object.keys(model.resolutionStrategy.valueToModelMapping)) {
    context.namesToValues.push({
      value: name,
      resolvedType: {
        memberName: model.resolutionStrategy.valueToModelMapping[name]
      }
    });
  }

  return context;
}

function createContextForModelInterface(model, errFunc) {
  return model;
}

function createContextForModel(model, errFunc) {
  return model;
}

module.exports.createContextForResolver = createContextForResolver;
module.exports.createContextForModelInterface = createContextForModelInterface;
module.exports.createContextForModel = createContextForModel;
