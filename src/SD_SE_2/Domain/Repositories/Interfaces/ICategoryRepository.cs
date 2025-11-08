using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Enums;

namespace SD_SE_2.Domain.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    List<Category> GetCategoriesByType(CategoryType type);
    List<Category> GetIncomeCategories();
    List<Category> GetExpenseCategories();
    bool ExistByName(string name);
}