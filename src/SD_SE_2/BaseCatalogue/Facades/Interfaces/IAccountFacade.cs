namespace SD_SE_2.Facades;

public interface IAccountFacade
{
    void CreateAccount(string name, decimal initialBalance);
    void EditAccount(Guid accountId, string? newName, decimal? newBalance);
    void DeleteAccount(Guid accountId);
}