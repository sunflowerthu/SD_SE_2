using SD_SE_2.Domain.Commands;
using SD_SE_2.Domain.Enums;
using SD_SE_2.Domain.Factories;
using SD_SE_2.Domain.Repositories;
using SD_SE_2.Domain.Services.Interfaces;

namespace SD_SE_2.Facades;

public class OperationFacade(IOperationService operationService, IOperationFactory operationFactory, ICommandManager commandManager) 
{
    public void CreateOperation(OperationType type, Guid accountId, decimal amount, Guid categoryId,
        string description)
    {
        var operation = operationFactory.CreateOperation(type, accountId, amount, categoryId, description);
        var addOperationCommand = new AddOperationCommand(operation, operationService);
        commandManager.ExecuteCommand(addOperationCommand);
    }
}