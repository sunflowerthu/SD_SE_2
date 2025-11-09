using SD_SE_2.BaseCatalogue.Entities;

namespace SD_SE_2.BaseCatalogue.Services.Interfaces;

public interface IAccountService
{
    void AddAccount(BankAccount account);
    void UpdateAccount(BankAccount account);
    void DeleteAccount(BankAccount account);
    BankAccount GetAccountById(Guid accountId);
    IEnumerable<BankAccount> GetAllAccounts();
}