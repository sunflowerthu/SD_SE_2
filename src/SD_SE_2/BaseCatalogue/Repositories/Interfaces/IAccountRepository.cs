using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Repositories;

public interface IBankAccountRepository : IRepository<BankAccount>
{
    List<BankAccount> GetActiveBankAccounts();
    List<BankAccount> GetBankAccountsWithMinimumBalance(decimal minBalance);
    decimal GetTotalBalance();
}