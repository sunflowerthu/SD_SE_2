using SD_SE_2.BaseCatalogue.Entities;

namespace SD_SE_2.BaseCatalogue.Repositories.Interfaces;

public interface IAccountRepository : IRepository<BankAccount>
{
    List<BankAccount> GetActiveBankAccounts();
    List<BankAccount> GetBankAccountsWithMinimumBalance(decimal minBalance);
    decimal GetTotalBalance();
}