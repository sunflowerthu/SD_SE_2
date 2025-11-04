using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Repositories;

public class FinancialOperationRepository : IRepository<Operation>
{
    private readonly List<Operation> _operations = new List<Operation>();

    public void Add(Operation entity) => _operations.Add(entity);
    public Operation GetById(Guid id) => _operations.FirstOrDefault(o => o.Id == id);
    public IEnumerable<Operation> GetAll() => _operations.AsEnumerable();
        
    public void Update(Operation entity)
    {
        var existing = GetById(entity.Id);
        if (existing != null)
        {
            _operations.Remove(existing);
            _operations.Add(entity);
        }
    }
        
    public void Delete(Guid id) => _operations.RemoveAll(o => o.Id == id);
    public bool Exists(Guid id) => _operations.Any(o => o.Id == id);
    
    public IEnumerable<Operation> GetByAccountId(Guid accountId) => 
        _operations.Where(o => o.AccountId == accountId);
            
    public IEnumerable<Operation> GetByPeriod(DateTime from, DateTime to) => 
        _operations.Where(o => o.Date >= from && o.Date <= to);
            
    public IEnumerable<Operation> GetByCategoryId(int categoryId) => 
        _operations.Where(o => o.CategoryId == categoryId);
}
