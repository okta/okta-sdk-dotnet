const _ = require('lodash');

function pascalCase(str) {
  return _.upperFirst(_.camelCase(str))
}

function getType(specType) {
  switch(specType) {
    case 'boolean': return 'bool?';
    case 'integer': return 'int?';
    case 'dateTime': return 'DateTimeOffset?';
    default: return specType;
  }
};

function paramToCLRType(param) {
  if (param.model) {
    return param.model;
  }
  
  return getType(param.type);
}

function propToCLRType(prop, isInterface) {
  switch (prop.commonType) {
    case 'array': return `IList<${getType(prop.model)}>`;
    case 'object': return isInterface ? `I${prop.model}` : prop.model;
    case 'enum': return prop.model;
    case 'hash': return `IDictionary<string, ${getType(prop.model)}>`;
    default: return getType(prop.commonType);
  }
}

function getterName(prop) {
  if (prop.commonType === 'array') {
    return `GetArrayProperty<${getType(prop.model)}>`;
  }

  if (prop.commonType === 'enum') {
    return `GetEnumProperty<${prop.model}>`;
  }

  let clrType = propToCLRType(prop);

  switch (clrType) {
    case 'bool?': return 'GetBooleanProperty';
    case 'int?': return 'GetIntegerProperty';
    case 'DateTimeOffset?': return 'GetDateTimeProperty';
    case 'string': return 'GetStringProperty';
    default: return `GetResourceProperty<${clrType}>`;
  }
}

module.exports.pascalCase = pascalCase;
module.exports.paramToCLRType = paramToCLRType;
module.exports.propToCLRType = propToCLRType;
module.exports.getterName = getterName;
