using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Enums;
using SD_SE_2.Domain.Observers.Events;
using SD_SE_2.Domain.Observers.Publisher;
using SD_SE_2.Domain.Repositories;

namespace SD_SE_2.Domain.Services;

public class OperationService
{
    private readonly OperationRepository _operationRepository;
    private readonly BankAccountRepository _accountRepository;
    private readonly IEventPublisher _eventPublisher;

    public OperationService(
        OperationRepository operationRepository,
        BankAccountRepository accountRepository,
        IEventPublisher eventPublisher)
    {
        _operationRepository = operationRepository;
        _accountRepository = accountRepository;
        _eventPublisher = eventPublisher;
    }

    public void AddOperation(Operation operation)
    {
        _operationRepository.Add(operation);
        UpdateAccountBalance(operation.AccountId, operation.Amount, operation.Type);
        
        _eventPublisher.Publish(new OperationAddedEvent(operation));
    }

    public void UpdateOperation(Operation operation)
    {
        var oldOperation = _operationRepository.GetById(operation.Id);
        if (oldOperation != null)
        {
            UpdateAccountBalance(oldOperation.AccountId, -oldOperation.Amount, oldOperation.Type);
            _operationRepository.Update(operation);
            UpdateAccountBalance(operation.AccountId, operation.Amount, operation.Type);
            
            _eventPublisher.Publish(new OperationUpdatedEvent(oldOperation, operation));
        }
    }

    public void DeleteOperation(Guid operationId)
    {
        var operation = _operationRepository.GetById(operationId);
        if (operation != null)
        {
            UpdateAccountBalance(operation.AccountId, -operation.Amount, operation.Type);
            _operationRepository.Delete(operationId);
            
            _eventPublisher.Publish(new OperationDeletedEvent(operation));
        }
    }

    private void UpdateAccountBalance(Guid accountId, decimal amount, OperationType type)
    {
        var account = _accountRepository.GetById(accountId);
        if (account != null)
        {
            var balanceChange = type == OperationType.Income ? amount : -amount;
            account.UpdateBalance(balanceChange);
            _accountRepository.Update(account);
        }
    }

    public decimal RecalculateBalance(Guid accountId)
    {
        var account = _accountRepository.GetById(accountId);
        if (account == null) return 0;

        var operations = _operationRepository.GetByAccountId(accountId);
        var newBalance = operations.Sum(o => o.Type == OperationType.Income ? o.Amount : -o.Amount);
        
        account.Balance = newBalance;
        _accountRepository.Update(account);
        
        _eventPublisher.Publish(new BalanceRecalculatedEvent(accountId, newBalance));
        
        return newBalance;
    }
}