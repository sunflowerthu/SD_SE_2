using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Services.Interfaces;

public interface IAccountService
{
    void AddAccount(BankAccount account);
    void UpdateAccount(BankAccount account);
    void DeleteAccount(BankAccount account);
}