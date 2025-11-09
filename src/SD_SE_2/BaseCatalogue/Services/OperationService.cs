using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Enums;
using SD_SE_2.Domain.Observers.Events;
using SD_SE_2.Domain.Observers.Publisher;
using SD_SE_2.Domain.Repositories;
using SD_SE_2.Domain.Services.Interfaces;

namespace SD_SE_2.Domain.Services;


public class OperationService(
    IOperationRepository operationRepository,
    IBankAccountRepository accountRepository,
    IEventPublisher eventPublisher)
    : IOperationService
{
    public void AddOperation(Operation operation)
    {
        operationRepository.Add(operation);
        UpdateAccountBalance(operation.AccountId, operation.Amount, operation.Type);
        
        eventPublisher.Publish(new OperationAddedEvent(operation));
    }

    public void UpdateOperation(Operation operation)
    {
        var oldOperation = operationRepository.GetById(operation.Id);
        if (oldOperation != null)
        {
            UpdateAccountBalance(oldOperation.AccountId, -oldOperation.Amount, oldOperation.Type);
            operationRepository.Update(operation);
            UpdateAccountBalance(operation.AccountId, operation.Amount, operation.Type);
            
            eventPublisher.Publish(new OperationUpdatedEvent(oldOperation, operation));
        }
    }

    public void DeleteOperation(Operation operation)
    {
        var operationExists = operationRepository.GetById(operation.Id);
        if (operationExists != null)
        {
            UpdateAccountBalance(operation.AccountId, -operation.Amount, operation.Type);
            operationRepository.Delete(operation.Id);
            
            eventPublisher.Publish(new OperationDeletedEvent(operation));
        }
        else
        {
            throw new NullReferenceException("Operation not found");
        }
    }

    private void UpdateAccountBalance(Guid accountId, decimal amount, OperationType type)
    {
        var account = accountRepository.GetById(accountId);
        if (account != null)
        {
            var balanceChange = type == OperationType.Income ? amount : -amount;
            if (balanceChange + account.Balance < 0)
            {
                throw new ArgumentException("malo denek :(");
            }
            account.UpdateBalance(balanceChange);
            accountRepository.Update(account);
        }
    }

    public Operation GetOperationById(Guid operationId)
    {
        try
        {
            var operation = operationRepository.GetById(operationId);
            return operation;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    
    public IEnumerable<Operation> GetAllOperations()
    {
        return operationRepository.GetAll();
    }
    
}