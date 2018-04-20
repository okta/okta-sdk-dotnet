const {
  camelCase,
  pascalCase,
  createMethodSignatureLiteral,
  createParametersLiteral
} = require('./utils');

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
        literal = 'IAsyncEnumerable<IUser>',
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
function createContextForClient(tag, spec, operations) {
  let context = {
    memberName: `${tag}s`,
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
      operationContext.bodyModel = {
        type: { 
          memberName: operation.bodyModel
        },
        parameterName: camelCase(operation.bodyModel)
      };
    }

    operationContext.returnType = {
      memberName: operation.responseModel
    };

    if (operation.isArray) {
      operationContext.returnType.literal = `IAsyncEnumerable<I${operationContext.returnType.memberName}>`;
      operationContext.returnType.documentationLiteral = `A collection of <see cref="I${operationContext.returnType.memberName}"/> that can be enumerated asynchronously.`;
    } else if (operation.responseModel) {
      operationContext.returnType.literal = `Task<I${operationContext.returnType.memberName}>`;
      operationContext.returnType.documentationLiteral = `The <see cref="I${operationContext.returnType.memberName}"/> response.`;
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

module.exports.createContextForClient = createContextForClient;
