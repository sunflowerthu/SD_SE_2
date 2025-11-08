using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Enums;

namespace SD_SE_2.Domain.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository() : base("Category") { }

    protected override string GetEntityDisplayName(Category entity)
    {
        return $"{entity.Name} ({entity.Type})";
    }

    public List<Category> GetCategoriesByType(CategoryType type)
    {
        return Find(c => c.Type == type);
    }

    public List<Category> GetIncomeCategories() => GetCategoriesByType(CategoryType.Income);
    public List<Category> GetExpenseCategories() => GetCategoriesByType(CategoryType.Expense);

    public bool ExistByName(string name)
    {
        foreach (Category category in _entities)
        {
            if (category.Name == name)
            {
                return true;
            }
        }

        return false;
    }
}