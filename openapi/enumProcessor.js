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
  pascalCase
 } = require('./utils');
 
function createContextForEnum(model, errFunc) {
  let memberName = model.modelName || '';
  if (!memberName.length) errFunc("modelName is zero-length", model);

  let context = {
    memberName,
    items: []
  };

  for (let rawEnum of model.enum) {
    context.items.push({
      memberName: pascalCase(rawEnum),
      value: rawEnum
    })
  }

  return context;
}

module.exports.createContextForEnum = createContextForEnum;
