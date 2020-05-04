const {
  camelCase,
  pascalCase,
  createMethodSignatureLiteral,
  createParametersLiteral,
  getPluralName,
  getTypeForMember
} = require('./utils');

const {
  shouldSkipOperation,
  applyOperationErrata
} = require('./errata');

function getTemplatesForClients(operations, infoLogger, errorLogger) {
  let clients = {};

  // pre-process the operations and split into tags
  for (let operation of operations) {
    let shouldSkip = shouldSkipOperation(operation.operationId);
    if (shouldSkip) {
      infoLogger(`Skipping operation ${operation.operationId} (Reason: ${shouldSkip.reason})`);
      operation.hidden = true;
      continue;
    }

    operation.allParams = (operation.pathParams || [])
                   .concat(operation.queryParams || []);

    operation.tags = operation.tags || [];

    if (operation.tags.length === 0) {
      operation.tags.push('Okta');
      infoLogger(`Adding default tag to ${operation.operationId}`);
    }

    if (operation.tags.length > 1) {
      infoLogger(`Warning: more than one tag on ${operation.operationId}`);
    }
    
    operation = applyOperationErrata(operation.tags[0], operation, infoLogger);
    let clientName = operation.tags[0];
    clients[clientName] = clients[clientName] || [];
    clients[clientName].push(operation);
  }

  // Assign handlebars templates to each client
  let clientTemplates = [];
  for (let clientName of Object.keys(clients)) {
    let pluralClientName = getPluralName(clientName);
    clientTemplates.push({
      src: 'templates/IClient.cs.hbs',
      dest: `Generated/I${pluralClientName}Client.Generated.cs`,
      context: createContextForClient(clientName, clients[clientName])
    });

    clientTemplates.push({
      src: 'templates/Client.cs.hbs',
      dest: `Generated/${pluralClientName}Client.Generated.cs`,
      context: createContextForClient(clientName, clients[clientName])
    });
  }

  return clientTemplates;
}

/*
Creates the context that the handlebars template is bound to:

{
  memberName: 'Users',
  resourceName: 'User',
  operations: [
    {
      memberName: 'ListUsers',
      description: 'Lists users in your organization with pagination in most cases.',
      hasCancellationToken: false,
      isCollection: true,
      returnType = {
        memberName: 'IUser,
        literal = 'ICollectionClient<IUser>',
        documentationLiteral = 'A collection of <see cref="IUser"/> that can be enumerated asynchronously.'
      },
      methodSignatureLiteral: 'string q = null, string after = null, int? limit = -1',
      path: '/api/v1/users',
      httpMethod: {
        memberName: 'Post'
      },
      bodyModel: {
        type: {
          memberName: 'User'
        },
        parameterName: 'user'
      },
      pathParameters: [
        { name: 'id', description: 'The user ID' }
      ],
      queryParameters: [
        { name: 'q', description: 'Finds a user that matches firstName, lastName, and email properties' }
      ],
    }
  ]
}
*/
function createContextForClient(tag, operations) {
  let context = {
    memberName: getPluralName(tag),
    resourceName: tag,
    operations: []
  };

  for (let operation of operations) {
    if (operation.hidden) continue;

    let operationContext = {
      description: operation.description,
      pathParameters: operation.pathParams,
      queryParameters: operation.queryParams,
      hasCancellationToken: !operation.isArray,
      isCollection: operation.isArray,
      path: operation.path,
      httpMethod: {
        memberName: `${pascalCase(operation.method)}Async`
      }
    }

    operationContext.memberName = pascalCase(operation.operationId);
    if (!operation.isArray) operationContext.memberName += 'Async';

    if (operation.bodyModel) {
      let bodyModelParamName = operation.bodyModel;
      let bodyModelParams = operation.parameters.filter(x => x.in == 'body');
      if(bodyModelParams != null){
        let bodyModelParam = bodyModelParams[0];
        bodyModelParamName = bodyModelParam.name;
      }

      operationContext.bodyModel = {
        type: { 
          memberName: getTypeForMember(operation.bodyModel, operation.bodyFormat)
        },
        parameterName: camelCase(bodyModelParamName)
      };
    }

    operationContext.returnType = {
      memberName: operation.responseModel
    };

    if (operation.isArray) {
      operationContext.returnType.literal = `ICollectionClient<${getTypeForMember(operationContext.returnType.memberName)}>`;
      operationContext.returnType.documentationLiteral = `A collection of <see cref="${getTypeForMember(operationContext.returnType.memberName)}"/> that can be enumerated asynchronously.`;
    } else if (operation.responseModel) {
      operationContext.returnType.literal = `Task<${getTypeForMember(operationContext.returnType.memberName)}>`;
      operationContext.returnType.documentationLiteral = `The <see cref="${getTypeForMember(operationContext.returnType.memberName)}"/> response.`;
    } else if (operation.returnType) {
      operationContext.returnType.literal = `Task<${getTypeForMember(operation.returnType)}>`;
      operationContext.returnType.documentationLiteral = `The <see cref="${getTypeForMember(operation.returnType)}"/> response.`;
    } else {
      operationContext.returnType.literal = 'Task';
      operationContext.returnType.documentationLiteral = 'A Task that represents the asynchronous operation.';
    }

    operationContext.methodSignatureLiteral
      = createMethodSignatureLiteral(operation);

    context.operations.push(operationContext);
  }

  return context;
}

module.exports.getTemplatesForClients = getTemplatesForClients;
