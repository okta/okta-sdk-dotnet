/**
 * This file is called by the @okta/openapi generator (npm run generate).
 * 
 * The input (JSON spec from @okta/openapi) is kind of messy, we need some
 * pre-processing before handing the spec data to the handlebars templates.
 * The handlebars templates are purposefully light on logic.
 */

const { getTemplatesforModels } = require('./processModels');
const { getTemplatesForClients } = require('./processClients')

function infoLogger() {
  console.log(...arguments);
}

function errorLogger(message, model) {
  console.error(model);
  throw new Error(message);
}

module.exports.process = ({spec, operations, models, handlebars}) => {
  const templates = [];

  templates.push(...getTemplatesforModels(models, infoLogger, errorLogger));
  templates.push(...getTemplatesForClients(operations, infoLogger, errorLogger));

  return templates;
}
