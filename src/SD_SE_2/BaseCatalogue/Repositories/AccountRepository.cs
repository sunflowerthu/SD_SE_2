using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Repositories;

public class AccountRepository : BaseRepository<BankAccount>, IAccountRepository
{
    public AccountRepository() : base("BankAccount") { }

    protected override string GetEntityDisplayName(BankAccount entity)
    {
        return entity.Name;
    }

    public List<BankAccount> GetActiveBankAccounts()
    {
        return Find(a => a.IsActive);
    }

    public List<BankAccount> GetBankAccountsWithMinimumBalance(decimal minBalance)
    {
        return Find(a => a.Balance >= minBalance);
    }

    public decimal GetTotalBalance()
    {
        return _entities.Sum(a => a.Balance);
    }
}