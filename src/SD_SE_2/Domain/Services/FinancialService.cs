using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Enums;
using SD_SE_2.Domain.Observers.Interfaces;
using SD_SE_2.Domain.Repositories;

namespace SD_SE_2.Domain.Services;

public class FinancialService : IFinancialService
{
    private readonly OperationRepository _operationRepository;
    private readonly BankAccountRepository _accountRepository;
    private readonly List<IOperationObserver> _observers;

    public FinancialService(
        OperationRepository operationRepository, 
        BankAccountRepository accountRepository,
        List<IOperationObserver> observers)
    {
        _operationRepository = operationRepository;
        _accountRepository = accountRepository;
        _observers = observers;
    }

    public void AddOperation(Operation operation)
    {
        _operationRepository.Add(operation);
        UpdateAccountBalance(operation.AccountId, operation.Amount, operation.Type);
        
        // Уведомляем наблюдателей
        foreach (var observer in _observers)
        {
            observer.OnOperationAdded(operation);
        }
    }

    public void UpdateOperation(Operation operation)
    {
        var oldOperation = _operationRepository.GetById(operation.Id);
        if (oldOperation != null)
        {
            UpdateAccountBalance(oldOperation.AccountId, -oldOperation.Amount, oldOperation.Type);
            _operationRepository.Update(operation);
            UpdateAccountBalance(operation.AccountId, operation.Amount, operation.Type);
            
            // Уведомляем наблюдателей об обновлении
            foreach (var observer in _observers)
            {
                observer.OnOperationUpdated(oldOperation, operation);
            }
        }
    }

    public void DeleteOperation(Guid operationId)
    {
        var operation = _operationRepository.GetById(operationId);
        if (operation != null)
        {
            UpdateAccountBalance(operation.AccountId, -operation.Amount, operation.Type);
            _operationRepository.Delete(operationId);
            
            // Уведомляем наблюдателей об удалении
            foreach (var observer in _observers)
            {
                observer.OnOperationDeleted(operation);
            }
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
        
        foreach (var observer in _observers)
        {
            observer.OnBalanceRecalculated(accountId, newBalance);
        }
        
        return newBalance;
    }
}