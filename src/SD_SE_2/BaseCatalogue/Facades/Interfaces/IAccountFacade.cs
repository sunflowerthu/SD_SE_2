using SD_SE_2.BaseCatalogue.Entities;

namespace SD_SE_2.BaseCatalogue.Facades.Interfaces;

public interface IAccountFacade
{
    void CreateAccount(string name, decimal initialBalance);
    void EditAccount(Guid accountId, string? newName, decimal? newBalance);
    void DeleteAccount(Guid accountId);
    IEnumerable<BankAccount> GetAllAccounts();
}