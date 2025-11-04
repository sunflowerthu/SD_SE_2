using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Repositories;

public class AccountRepository : IRepository<BankAccount>
{
    private readonly List<BankAccount> _accounts = new List<BankAccount>();

    public void Add(BankAccount entity) => _accounts.Add(entity);
        
    public BankAccount GetById(Guid id) => _accounts.FirstOrDefault(a => a.Id == id);
        
    public IEnumerable<BankAccount> GetAll() => _accounts.AsEnumerable();
        
    public void Update(BankAccount entity)
    {
        var existing = GetById(entity.Id);
        if (existing != null)
        {
            _accounts.Remove(existing);
            _accounts.Add(entity);
        }
    }
        
    public void Delete(Guid id) => _accounts.RemoveAll(a => a.Id == id);
        
    public bool Exists(Guid id) => _accounts.Any(a => a.Id == id);
}