using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public IRepository<BankAccount> BankAccounts { get; private set; }
    public IRepository<Category> Categories { get; private set; }
    public IRepository<Operation> Operations { get; private set; }

    public UnitOfWork()
    {
        BankAccounts = new AccountRepository();
        Categories = new CategoryRepository();
        Operations = new FinancialOperationRepository();
    }

    public void Save()
    {
        // а што делать
    }
}