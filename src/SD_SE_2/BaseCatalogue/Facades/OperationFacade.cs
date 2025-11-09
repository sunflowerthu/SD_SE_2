using SD_SE_2.BaseCatalogue.Commands.ConcreteCommands;
using SD_SE_2.BaseCatalogue.Commands.Interfaces;
using SD_SE_2.BaseCatalogue.Entities;
using SD_SE_2.BaseCatalogue.Enums;
using SD_SE_2.BaseCatalogue.Facades.Interfaces;
using SD_SE_2.BaseCatalogue.Factories.Interfaces;
using SD_SE_2.BaseCatalogue.Services.Interfaces;

namespace SD_SE_2.BaseCatalogue.Facades;

public class OperationFacade(
    IOperationService operationService, 
    IOperationFactory operationFactory, 
    ICommandManager commandManager
    ) : IOperationFacade 
{
    public void CreateOperation(OperationType type, Guid accountId, decimal amount, Guid categoryId,
        string description)
    {
        var operation = operationFactory.CreateOperation(type, accountId, amount, categoryId, description);
        var addOperationCommand = new AddOperationCommand(operation, operationService);
        commandManager.ExecuteCommand(addOperationCommand);
    }
    
    public void EditOperation(Guid operationId, OperationType newType = OperationType.Income, decimal newAmount = 0, 
        Guid newCategoryId = new Guid(), string newDescription = null)
    {
        var oldOperation = operationService.GetOperationById(operationId);
        if (oldOperation == null)
        {
            throw new ArgumentException($"Operation with ID {operationId} not found");
        }

        var newOperation = operationFactory.CreateOperation(
            newType,
            oldOperation.AccountId,
            newAmount > 0 ? newAmount : oldOperation.Amount,
            newCategoryId != Guid.Empty ? newCategoryId : oldOperation.CategoryId,
            newDescription ?? oldOperation.Description
        );

        newOperation.Id = oldOperation.Id;
        newOperation.Date = oldOperation.Date;

        var editCommand = new EditOperationCommand(oldOperation, newOperation, operationService);
        commandManager.ExecuteCommand(editCommand);
    }

    public void DeleteOperation(Guid operationId)
    {
        var operation = operationService.GetOperationById(operationId);
        var deleteCommand = new DeleteOperationCommand(operation, operationService);
        commandManager.ExecuteCommand(deleteCommand);
    }
    
    public IEnumerable<Operation> GetAllOperations()
    {
        return operationService.GetAllOperations();
    }
}