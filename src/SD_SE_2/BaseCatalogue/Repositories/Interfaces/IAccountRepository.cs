using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Repositories;

public interface IAccountRepository : IRepository<BankAccount>
{
    List<BankAccount> GetActiveBankAccounts();
    List<BankAccount> GetBankAccountsWithMinimumBalance(decimal minBalance);
    decimal GetTotalBalance();
}