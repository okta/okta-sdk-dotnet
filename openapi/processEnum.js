/*
Creates the context that the handlebars template is bound to:

{
  "memberName": "FactorStatus",
  "items": [
    { "memberName": "PendingActivation", value: "PENDING_ACTIVATION" }
  ]
}
*/

const { 
  pascalCase,
  camelCase
 } = require('./utils');
 
 const {
   applyEnumErrata
 } = require('./errata');

function createContextForEnum(model, errFunc, infoLogger) {
  let memberName = model.modelName || '';
  if (!memberName.length) errFunc("modelName is zero-length", model);

  let context = {
    memberName,
    items: []
  };

  for (let rawEnum of model.enum) {
    let enumDefinition = { fullPath : `${model.modelName}.${camelCase(rawEnum)}`, memberName : camelCase(rawEnum) };

    context.items.push({
      memberName: pascalCase(applyEnumErrata(enumDefinition, infoLogger).memberName),
      value: rawEnum
    })
  }

  return context;
}

module.exports.createContextForEnum = createContextForEnum;
