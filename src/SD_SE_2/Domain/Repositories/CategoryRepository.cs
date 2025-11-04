using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Enums;

namespace SD_SE_2.Domain.Repositories;

public class CategoryRepository : IRepository<Category>
{
    private readonly List<Category> _categories = new List<Category>();

    public void Add(Category entity) => _categories.Add(entity);
    public Category GetById(Guid id) => _categories.FirstOrDefault(c => c.Id == id);
    public IEnumerable<Category> GetAll() => _categories.AsEnumerable();
        
    public void Update(Category entity)
    {
        var existing = GetById(entity.Id);
        if (existing != null)
        {
            _categories.Remove(existing);
            _categories.Add(entity);
        }
    }
        
    public void Delete(Guid id) => _categories.RemoveAll(c => c.Id == id);
    public bool Exists(Guid id) => _categories.Any(c => c.Id == id);
        
    public IEnumerable<Category> GetByType(CategoryType type) => 
        _categories.Where(c => c.Type == type);
}
